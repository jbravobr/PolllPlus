using PollPlus.Domain;
using PollPlus.Helpers;
using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PollPlus.Filter;
using PollPlus.Models;
using PollPlus.Domain.Enumeradores;

namespace PollPlus.Controllers
{
    [OnlyAuthorizedUser]
    public class RelatorioController : Controller
    {
        readonly IUsuarioServiceWEB srvUsuario;
        readonly IEmpresaServiceWEB srvEmpresa;
        readonly IEnqueteServiceWEB srvEnquete;
        readonly IRespostaServiceWEB srvResposta;
        readonly IPerguntaRespostaServiceWEB srvPerguntaResposta;

        private object Cache { get; set; }

        public RelatorioController(IUsuarioServiceWEB srvUsuario,
            IEmpresaServiceWEB srvEmpresa, IEnqueteServiceWEB srvEnquete, IPerguntaRespostaServiceWEB srvPerguntaService,
            IRespostaServiceWEB srvResposta)
        {
            this.srvUsuario = srvUsuario;
            this.srvEmpresa = srvEmpresa;
            this.srvEnquete = srvEnquete;
            this.srvPerguntaResposta = srvPerguntaService;
            this.srvResposta = srvResposta;
        }

        [NonAction]
        private static IEnumerable<SelectListItem> PreparaParaListaDeEmpresas(ICollection<Empresa> empresas, int? empresaSelecionada = null)
        {
            foreach (var empresa in empresas)
            {
                if (empresaSelecionada != null)
                {
                    yield return new SelectListItem
                    {
                        Text = empresa.Nome,
                        Value = empresa.Id.ToString(),
                        Selected = empresa.Id == empresaSelecionada
                    };
                }

                yield return new SelectListItem
                {
                    Text = empresa.Nome,
                    Value = empresa.Id.ToString()
                };
            }
        }

        [HttpGet]
        public async Task<ActionResult> RelUsuariosCadastrados()
        {
            var empresas = await this.srvEmpresa.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));

            if (UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorMaster)
            {
                var _usuarios = await this.srvUsuario.RetornarTodosUsuarios();
                var _toList = _usuarios.OrderBy(x => x.Nome).ToList();
                this.Cache = _toList;

                return View("RelUsuarios", _toList.ToPagedList(1, 10));
            }
            else
            {
                var _usuarios = await this.srvUsuario.RetornarTodosUsuarios();
                var _toList = _usuarios.Where(e => e.EmpresaId == UsuarioLogado.UsuarioAutenticado().EmpresaId).OrderBy(x => x.Nome).ToList();
                this.Cache = _toList;

                return View("RelUsuarios", _toList.ToPagedList(1, 10));
            }
        }

        [HttpGet]
        public async Task<ActionResult> ExportarUsuariosCadastrados()
        {
            if (UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorMaster)
            {
                var _usuarios = await this.srvUsuario.RetornarTodosUsuarios();
                var _toList = _usuarios.OrderBy(x => x.Nome).ToList();
                var mapper = _toList.Select(x => new RelUsuariosViewModel
                {
                    Nome = x.Nome,
                    Email = x.Email,
                    Telefone = x.Telefone,
                    DataCriacao = x.DataCriacao.ToShortDateString(),
                    DataNascimento = x.DataNascimento
                });

                var _arqExcelBytes = new SimpleExcelExport.ExportToExcel().ListToExcel<RelUsuariosViewModel>(mapper.ToList());
                return File(_arqExcelBytes, "application/ms-excel", string.Format("Relatorio_Cadastro_Usuarios_{0}.xls", DateTime.Now.ToShortDateString()));
            }
            else
            {
                var _usuarios = await this.srvUsuario.RetornarTodosUsuarios();
                var _toList = _usuarios.Where(e => e.EmpresaId == UsuarioLogado.UsuarioAutenticado().EmpresaId).OrderBy(x => x.Nome).ToList();
                var mapper = _toList.Select(x => new RelUsuariosViewModel
                {
                    Nome = x.Nome,
                    Email = x.Email,
                    Telefone = x.Telefone,
                    DataCriacao = x.DataCriacao.ToShortDateString(),
                    DataNascimento = x.DataNascimento
                });

                var _arqExcelBytes = new SimpleExcelExport.ExportToExcel().ListToExcel<RelUsuariosViewModel>(mapper.ToList());
                return File(_arqExcelBytes, "application/ms-excel", string.Format("Relatorio_Cadastro_Usuarios_{0}.xls", DateTime.Now.ToShortDateString()));
            }
        }

        [HttpPost]
        public async Task<ActionResult> RelUsuariosCadastradosPaginado(int? empresaId, int? page)
        {
            var empresas = await this.srvEmpresa.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, empresaId));

            if (empresaId != null)
            {
                var _usuarios = await this.srvUsuario.RetornarTodosUsuarios();
                var _filtroUsuarios = _usuarios.Where(e => e.EmpresaId == UsuarioLogado.UsuarioAutenticado().EmpresaId).OrderBy(x => x.Nome).ToList();
                this.Cache = _filtroUsuarios;

                return View("RelUsuarios", _filtroUsuarios.ToPagedList(page ?? 1, 10));
            }
            else
            {
                var _usuarios = await this.srvUsuario.RetornarTodosUsuarios();
                var _filtroUsuarios = _usuarios.OrderBy(x => x.Nome).ToList();
                this.Cache = _filtroUsuarios;

                return View("RelUsuarios", _filtroUsuarios.ToPagedList(page ?? 1, 10));
            }
        }

        [HttpGet]
        public async Task<ActionResult> RelEmpresasCadastradas(int? page)
        {
            var _empresas = await this.srvEmpresa.RetornarTodasEmpresas();
            var _toList = _empresas.ToList();

            return View("RelEmpresas", _toList.ToPagedList(page ?? 1, 10));
        }

        [HttpGet]
        public async Task<ActionResult> ExportarEmpresasCadastrados()
        {
            var _empresas = await this.srvEmpresa.RetornarTodasEmpresas();
            var _toList = _empresas.ToList();
            var mapper = _toList.Select(x => new RelEmpresaViewModel
            {
                Nome = x.Nome,
                Documento = x.Documento.Numero.ToString(),
                DataCriacao = x.DataCriacao.ToShortDateString(),
            });

            var _arqExcelBytes = new SimpleExcelExport.ExportToExcel().ListToExcel<RelEmpresaViewModel>(mapper.ToList());
            return File(_arqExcelBytes, "application/ms-excel", string.Format("Relatorio_Cadastro_Empresa_{0}.xls", DateTime.Now.ToShortDateString()));
        }

        [HttpGet]
        public async Task<ActionResult> RelEnquetesCadastradas()
        {
            var empresas = await this.srvEmpresa.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));

            if (UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorEmpresa)
            {
                var enquetes = await this.srvEnquete.RetornarTodasEnquetes();
                var filtro = enquetes.Where(e => e.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
                ViewData.Add("EnqueteForSelectList", PreparaParaListaDeEnquetes(filtro, null));
            }
            else
            {
                var enquetes = await this.srvEnquete.RetornarTodasEnquetes();
                ViewData.Add("EnqueteForSelectList", PreparaParaListaDeEnquetes(enquetes.Where(x => x.PerguntaId != null).ToList(), null));
            }

            if (UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorMaster)
            {
                var _enquetes = await this.srvEnquete.RetornarTodasEnquetes();
                var _toList = _enquetes.OrderByDescending(e => e.DataCriacao).ToList();

                return View("RelEnquetes", _toList.ToPagedList(1, 20));
            }
            else
            {
                var _enquetes = await this.srvEnquete.RetornarTodasEnquetes();
                var _toList = _enquetes.Where(x => x.EmpresaId == UsuarioLogado.UsuarioAutenticado().EmpresaId).OrderByDescending(x => x.DataCriacao).ToList();

                return View("RelEnquetes", _toList.ToPagedList(1, 20));
            }
        }

        [NonAction]
        private static IEnumerable<SelectListItem> PreparaParaListaDeEnquetes(ICollection<Enquete> enquetes, int? enqueteSelecionada = null)
        {
            foreach (var enquete in enquetes)
            {
                if (enqueteSelecionada != null)
                {
                    yield return new SelectListItem
                    {
                        Text = enquete.Pergunta.TextoPergunta,
                        Value = enquete.Id.ToString(),
                        Selected = enquete.Id == enqueteSelecionada
                    };
                }

                yield return new SelectListItem
                {
                    Text = enquete.Pergunta.TextoPergunta,
                    Value = enquete.Id.ToString()
                };
            }
        }

        [HttpGet]
        public async Task<ActionResult> ExportarEnquetesCadastradas()
        {
            if (UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorMaster)
            {
                var _enquetes = await this.srvEnquete.RetornarTodasEnquetes();
                var _toList = _enquetes.Where(e => e.Tipo == EnumTipoEnquete.Interesse || e.Tipo == EnumTipoEnquete.Publica).OrderByDescending(e => e.DataCriacao).ToList();
                var mapper = _toList.Select(x => new RelEnquetesViewModel
                {
                    Id = x.Id,
                    Categoria = x.EnqueteCategoria != null && x.EnqueteCategoria.Any() ? x.EnqueteCategoria.First().Categoria.Nome : "Sem categoria",
                    Imagem = String.IsNullOrEmpty(x.Imagem) ? "Sem Imagem" : x.Imagem,
                    Status = x.Status.GetDescription(),
                    TemVoucher = x.TemVoucher ? "Sim" : "Não",
                    TextoPergunta = x.Pergunta.TextoPergunta,
                    UrlVideo = String.IsNullOrEmpty(x.UrlVideo) ? "Sem vídeo" : x.UrlVideo,
                    DataCriacao = x.DataCriacao.ToShortDateString(),
                });

                var _arqExcelBytes = new SimpleExcelExport.ExportToExcel().ListToExcel<RelEnquetesViewModel>(mapper.ToList());
                return File(_arqExcelBytes, "application/ms-excel", string.Format("Relatorio_Cadastro_Enquete_{0}.xls", DateTime.Now.ToShortDateString()));
            }
            else
            {
                var _enquetes = await this.srvEnquete.RetornarTodasEnquetes();
                var _toList = _enquetes.Where(x => x.EmpresaId == UsuarioLogado.UsuarioAutenticado().EmpresaId).OrderByDescending(x => x.DataCriacao).ToList();
                var mapper = _toList.Select(x => new RelEnquetesViewModel
                {
                    Id = x.Id,
                    Categoria = x.EnqueteCategoria != null && x.EnqueteCategoria.Any() ? x.EnqueteCategoria.First().Categoria.Nome : "Sem categoria",
                    Imagem = String.IsNullOrEmpty(x.Imagem) ? "Sem Imagem" : x.Imagem,
                    Status = x.Status.GetDescription(),
                    TemVoucher = x.TemVoucher ? "Sim" : "Não",
                    TextoPergunta = x.Pergunta.TextoPergunta,
                    UrlVideo = String.IsNullOrEmpty(x.UrlVideo) ? "Sem vídeo" : x.UrlVideo,
                    DataCriacao = x.DataCriacao.ToShortDateString(),
                });

                var _arqExcelBytes = new SimpleExcelExport.ExportToExcel().ListToExcel<RelEnquetesViewModel>(mapper.ToList());
                return File(_arqExcelBytes, "application/ms-excel", string.Format("Relatorio_Cadastro_Enquete_{0}.xls", DateTime.Now.ToShortDateString()));
            }
        }

        [HttpPost]
        public async Task<ActionResult> RelEnquetesCadastradasPaginada(int? empresaId, int? page)
        {
            var empresas = await this.srvEmpresa.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));

            if (UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorEmpresa)
            {
                var enquetes = await this.srvEnquete.RetornarTodasEnquetes();
                var filtro = enquetes.Where(e => e.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
                ViewData.Add("EnqueteForSelectList", PreparaParaListaDeEnquetes(filtro, null));
            }
            else
            {
                var enquetes = await this.srvEnquete.RetornarTodasEnquetes();
                ViewData.Add("EnqueteForSelectList", PreparaParaListaDeEnquetes(enquetes.Where(x => x.PerguntaId != null).ToList(), null));
            }

            if (UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorMaster)
            {
                var _enquetes = await this.srvEnquete.RetornarTodasEnquetes();
                var _toList = _enquetes.Where(x => x.EmpresaId == empresaId).OrderBy(e => e.Empresa.Nome).ToList();

                return View("RelEnquetes", _toList.ToPagedList(page ?? 1, 20));
            }
            else
            {
                var _enquetes = await this.srvEnquete.RetornarTodasEnquetes();
                var _toList = _enquetes.Where(x => x.EmpresaId == UsuarioLogado.UsuarioAutenticado().EmpresaId).OrderByDescending(x => x.DataCriacao).ToList();

                return View("RelEnquetes", _toList.ToPagedList(page ?? 1, 20));
            }
        }

        [AcceptVerbs(new[] { "POST" })]
        public async Task<JsonResult> GetRespostasComPercentual(int perguntaId)
        {
            var _respostas = await this.srvResposta.RetornarTodosRespostas();
            var _toList = _respostas.Where(r => r.PerguntaId == perguntaId).ToList();

            List<RespostasJson> _respostaJsonToList = new List<RespostasJson>();

            foreach (var resposta in _toList)
            {
                var _respostasRespondidas = await this.srvPerguntaResposta.RetornarPerguntaRespostaPorPergunta(resposta.Id);
                var percent = (_respostasRespondidas != null && !_respostasRespondidas.Any() && _respostasRespondidas.Count > 0)
                    ? _respostasRespondidas.First().percentual
                    : 0;

                _respostaJsonToList.Add(new RespostasJson
                {
                    Id = resposta.Id,
                    TextoResposta = resposta.TextoResposta,
                    Percentual = percent
                });
            }

            return Json(_respostaJsonToList);
        }

        [HttpGet]
        public async Task<ActionResult> ExportarRespostasEnquete(int enqueteId)
        {
            var _pergunta = await this.srvEnquete.RetornarEnquetePorId(enqueteId);
            var _respostas = await this.srvResposta.RetornarTodosRespostas();
            var _toList = _respostas.Where(r => r.PerguntaId == _pergunta.PerguntaId).ToList();

            List<RelEnquetesRespostas> _mapper = new List<RelEnquetesRespostas>();

            foreach (var resposta in _toList)
            {
                var _respostasRespondidas = await this.srvPerguntaResposta.RetornarPerguntaRespostaPorPergunta(resposta.Id);
                var percent = (_respostasRespondidas != null && !_respostasRespondidas.Any() && _respostasRespondidas.Count > 0)
                    ? _respostasRespondidas.First().percentual
                    : 0;

                _mapper.Add(new RelEnquetesRespostas
                {
                    Id = resposta.Id,
                    TextoRespostas = resposta.TextoResposta,
                    Percentual = percent.ToString(),
                    Categoria = _pergunta.EnqueteCategoria != null && _pergunta.EnqueteCategoria.Any() ? _pergunta.EnqueteCategoria.First().Categoria.Nome : "Sem Categoria",
                    TextoPergunta = _pergunta.Pergunta.TextoPergunta
                });
            }

            var _arqExcelBytes = new SimpleExcelExport.ExportToExcel().ListToExcel<RelEnquetesRespostas>(_mapper);
            return File(_arqExcelBytes, "application/ms-excel", string.Format("Relatorio_Respostas_Enquete_{0}.xls", DateTime.Now.ToShortDateString()));
        }
    }

    public class RespostasJson
    {
        public int Id { get; set; }
        public string TextoResposta { get; set; }
        public double Percentual { get; set; }
    }
}
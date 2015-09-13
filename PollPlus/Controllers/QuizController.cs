using PagedList;
using PollPlus.Domain;
using PollPlus.Filter;
using PollPlus.Helpers;
using PollPlus.Models;
using PollPlus.Repositorio;
using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PollPlus.Controllers
{
    public class QuizController : BaseController
    {
        readonly IEnqueteServiceWEB service;

        readonly IUsuarioServiceWEB serviceUsuario;

        readonly IPerguntaServiceWEB servicePergunta;

        readonly IRespostaServiceWEB serviceResposta;

        readonly IBlackListServiceWEB serviceBlackList;

        private RespostaImagemRepositorio repoRespostaImagem = new RespostaImagemRepositorio();

        private EnqueteCategoriaRepositorio enqueteCategoriaRepositorio = new EnqueteCategoriaRepositorio();

        public QuizController(IEnqueteServiceWEB _service, IPerguntaServiceWEB _servicePergunta,
            IRespostaServiceWEB _serviceResposta, IBlackListServiceWEB _serviceBlackList, IUsuarioServiceWEB _serviceUsuario)
        {
            this.service = _service;
            this.servicePergunta = _servicePergunta;
            this.serviceResposta = _serviceResposta;
            this.serviceBlackList = _serviceBlackList;
            this.serviceUsuario = _serviceUsuario;
        }

        public QuizController() { }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> NovoQuiz()
        {
            var categorias = await this.serviceUsuario.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, null));

            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> SalvaRespostas(PerguntaViewModel Pergunta, List<string> resposta, string correta)
        {
            if (!ModelState.IsValid || !resposta.Any())
                return View(Pergunta);

            var respostas = MapeiaListaDeRespostas(resposta, Pergunta.Id, correta);

            foreach (var r in respostas)
            {
                await this.serviceResposta.InserirResposta(r);
            }

            return RedirectToAction("ListarQuiz");
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> NovoQuiz(EnqueteViewModel model, HttpPostedFileBase file, List<string> resposta, List<HttpPostedFileBase> imagemResposta, string correta)
        {
            try
            {
                var categorias = await this.serviceUsuario.RetornarCategoriasDisponniveis();
                ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, null));

                if (!ModelState.IsValid)
                    return View(model);

                model.Status = Domain.Enumeradores.EnumStatusEnquete.Publicada;
                model.Tipo = Domain.Enumeradores.EnumTipoEnquete.Quiz;

                var enquete = await this.service.InserirRetornarEnquete(AutoMapper.Mapper.Map<Enquete>(model));

                if (enquete != null)
                {
                    if (file != null && file.ContentLength > 0)
                        Util.SalvarImagem(file);

                    enquete.AdicionarCategoria(model.CategoriasInteresse);

                    foreach (var uc in enquete.EnqueteCategoria)
                    {
                        await service.InserirEnqueteCategoria(uc);
                    }

                    var respostas = MapeiaListaDeRespostas(resposta, enquete.Pergunta.Id, correta);

                    var count = 0;
                    foreach (var r in respostas)
                    {
                        var _resposta = await this.serviceResposta.InserirRetornarResposta(r);

                        if (imagemResposta != null && imagemResposta.Any())
                        {
                            if (imagemResposta[count] != null)
                            {
                                var obj = new RespostaImagem { RespostaId = _resposta.Id, Imagem = imagemResposta[count].FileName };

                                if (await this.repoRespostaImagem.InserirRespostaImagem(obj))
                                {
                                    Util.SalvarImagem(imagemResposta[count]);
                                    count++;
                                }
                            }
                        }
                    }

                    return RedirectToAction("ListarQuiz");
                }

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> EditarQuiz(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);

            var respostas = enquete.Pergunta.Resposta;

            if (respostas != null && respostas.Any())
                ViewData.Add("Respostas", AutoMapper.Mapper.Map<ICollection<RespostaViewModel>>(respostas));

            var categorias = await this.serviceUsuario.RetornarCategoriasDisponniveis();
            var cats = enquete.EnqueteCategoria.Select(x => x.CategoriaId).ToList();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, cats));

            return View(AutoMapper.Mapper.Map<EnqueteViewModel>(enquete));
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> EditarQuiz(EnqueteViewModel model, List<string> resposta, HttpPostedFileBase file, List<HttpPostedFileBase> imagemResposta)
        {
            var respostas = model.Pergunta.Resposta;
            var enquete = await this.service.RetornarEnquetePorId(model.Id);

            var categorias = await this.serviceUsuario.RetornarCategoriasDisponniveis();
            var cats = enquete.EnqueteCategoria.Select(x => x.CategoriaId).ToList();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, cats));

            if (respostas != null && respostas.Any())
                ViewData.Add("Respostas", AutoMapper.Mapper.Map<RespostaViewModel>(respostas));

            if (!ModelState.IsValid)
                return View(model);

            if (await this.service.AtualizarEnquete(AutoMapper.Mapper.Map<Enquete>(model)))
                return RedirectToAction("ListarQuiz");

            return View(model);
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> ListarQuiz(int? pagina)
        {
            var listaEnquetes = await this.service.RetornarTodasEnquetes();

            return View(listaEnquetes. Where(x=>x.Tipo == Domain.Enumeradores.EnumTipoEnquete.Quiz)
                .OrderByDescending(x => x.DataCriacao).ToPagedList(pagina ?? 1, 10));
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> PublicarQuiz(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);
            enquete.Status = Domain.Enumeradores.EnumStatusEnquete.Publicada;

            await this.service.AtualizarEnquete(enquete);
            return Redirect("ListarEnquetes");
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> DespublicarQuiz(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);
            enquete.Status = Domain.Enumeradores.EnumStatusEnquete.Despublicada;

            await this.service.AtualizarEnquete(enquete);
            return Redirect("ListarEnquetes");
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> AtivarQuiz(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);
            enquete.Status = Domain.Enumeradores.EnumStatusEnquete.Ativa;

            await this.service.AtualizarEnquete(enquete);
            return Redirect("ListarEnquetes");
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> DesativarQuiz(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);
            enquete.Status = Domain.Enumeradores.EnumStatusEnquete.Inativa;

            await this.service.AtualizarEnquete(enquete);
            return Redirect("ListarEnquetes");
        }

        private static IEnumerable<Resposta> MapeiaListaDeRespostas(List<string> respostas, int perguntaId, string correta)
        {
            foreach (var resposta in respostas)
            {
                yield return new Resposta { TextoResposta = resposta, PerguntaId = perguntaId, correta = resposta == correta };
            }
        }

        [NonAction]
        private static IEnumerable<SelectListItem> PreparaParaListaDeCategorias(ICollection<Categoria> categorias, List<int> categoriaSelecionada = null)
        {
            foreach (var categoria in categorias)
            {
                if (categoriaSelecionada != null)
                {
                    yield return new SelectListItem
                    {
                        Text = categoria.Nome,
                        Value = categoria.Id.ToString(),
                        Selected = categoriaSelecionada.Contains((int)categoria.Id)
                    };
                }
                else
                {
                    yield return new SelectListItem
                    {
                        Text = categoria.Nome,
                        Value = categoria.Id.ToString()
                    };
                }
            }
        }
    }
}
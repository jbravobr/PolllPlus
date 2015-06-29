using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;
using PollPlus.Models;
using PollPlus.Domain.Enumeradores;
using PollPlus.Helpers;

namespace PollPlus.Service
{
    public class EnqueteServiceWEB : IEnqueteServiceWEB
    {
        readonly IEnqueteService service; 

        readonly ICategoriaService _serviceCategoria;

        readonly IEnqueteCategoriaService _serviceEnqueteCategoria;

        public EnqueteServiceWEB(IEnqueteService _service, ICategoriaService ServiceCategoria, IEnqueteCategoriaService ServiceEnqueteCategoria)
        {
            this.service = _service;
            this._serviceCategoria = ServiceCategoria;
            this._serviceEnqueteCategoria = ServiceEnqueteCategoria;
        }


        public async Task<Enquete> InserirRetornarEnquete(Enquete e)
        {
            return await this.service.InserirRetornarEnquete(e);
        }

        public async Task<bool> AtualizarEnquete(Enquete e)
        {
            return await this.service.AtualizarEnquete(e);
        }

        public async Task<bool> DeletarEnquete(Enquete e)
        {
            return await this.service.DeletarEnquete(e);
        }

        public async Task<bool> InserirEnquete(Enquete e)
        {
            return await this.service.InserirEnquete(e);
        }

        public async Task<Enquete> RetornarEnquetePorId(int id)
        {
            return await this.service.RetornarEnquetePorId(id);
        }

        public async Task<ICollection<Enquete>> RetornarTodasEnquetes()
        {
            var _enquetes = new List<Enquete>();
            if (UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa)
                _enquetes = (await this.service.RetornarTodasEnquetes()).Where(u => u.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
            else
                _enquetes = (await this.service.RetornarTodasEnquetes()).ToList();

            return _enquetes;
        }
        public async Task<ICollection<Categoria>> RetornarCategoriasDisponniveis()
        {
            var _categoria = new List<Categoria>();
            if (UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa)
                _categoria = (await this._serviceCategoria.RetornarTodasCategorias()).Where(u => u.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
            else
                _categoria = (await this._serviceCategoria.RetornarTodasCategorias()).ToList();
            return _categoria;
        }

        public async Task<bool> InserirEnqueteCategoria(EnqueteCategoria uc)
        {
            return await this._serviceEnqueteCategoria.InserirEnqueteCategoria(uc);
        }

    }
}

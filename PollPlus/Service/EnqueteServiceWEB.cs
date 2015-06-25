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

        public EnqueteServiceWEB(IEnqueteService _service)
        {
            this.service = _service;
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
    }
}

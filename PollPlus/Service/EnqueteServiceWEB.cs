using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;

namespace PollPlus.Service
{
    public class EnqueteServiceWEB : IEnqueteServiceWEB
    {
        readonly IEnqueteService service;

        public EnqueteServiceWEB(IEnqueteService _service)
        {
            this.service = _service;
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
            return await this.service.RetornarTodasEnquetes();
        }
    }
}

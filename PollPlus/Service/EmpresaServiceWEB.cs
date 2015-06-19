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
    public class EmpresaServiceWEB : IEmpresaServiceWEB
    {
        readonly IEmpresaService service;

        public EmpresaServiceWEB(IEmpresaService _service)
        {
            this.service = _service;
        }

        public async Task<bool> AtualizarEmpresa(Empresa e)
        {
            return await this.service.AtualizarEmpresa(e);
        }

        public async Task<bool> DeletarEmpresa(Empresa e)
        {
            return await this.service.DeletarEmpresa(e);
        }

        public async Task<bool> InserirEmpresa(Empresa e)
        {
            return await this.service.InserirEmpresa(e);
        }

        public async Task<Empresa> RetornarEmpresaPorId(int id)
        {
            return await this.service.RetornarEmpresaPorId(id);
        }

        public async Task<ICollection<Empresa>> RetornarTodasEmpresas()
        {
            return await this.service.RetornarTodasEmpresas();
        }
    }
}

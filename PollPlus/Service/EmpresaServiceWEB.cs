﻿using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;
using PollPlus.Models;
using System.Collections;
using PollPlus.Domain.Enumeradores;

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
            IEnumerable _empresa = new List<Empresa>();

            if (UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa)
                 _empresa = (await this.service.RetornarTodasEmpresas()).Where(u => u.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId);
            else
                _empresa = (await this.service.RetornarTodasEmpresas());

            return await this.service.RetornarTodasEmpresas();
        }
    }
}

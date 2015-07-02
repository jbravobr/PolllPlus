using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PollPlus.Domain;
using PollPlus.Models;
using PollPlus.Helpers;

namespace PollPlus.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<Categoria, CategoriaViewModel>();
            Mapper.CreateMap<Empresa, EmpresaViewModel>();

            Mapper.CreateMap<Enquete, EnqueteViewModel>()
                .BeforeMap((d, vm) =>
                {
                    vm.EmpresaId = (int)UsuarioLogado.UsuarioAutenticado().EmpresaId;
                    vm.UsuarioId = UsuarioLogado.UsuarioAutenticado().Id;
                    vm.Tipo = UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorEmpresa
                        ? Domain.Enumeradores.EnumTipoEnquete.Interesse
                        : Domain.Enumeradores.EnumTipoEnquete.Publica;
                });

            Mapper.CreateMap<Pergunta, PerguntaViewModel>();
            Mapper.CreateMap<Resposta, RespostaViewModel>();
            Mapper.CreateMap<Documento, DocumentoViewModel>();
            Mapper.CreateMap<Plataforma, PlataformaViewModel>();
            Mapper.CreateMap<Voucher, VoucherViewModel>();
            Mapper.CreateMap<Banner, BannerViewModel>();
        }
    }
}
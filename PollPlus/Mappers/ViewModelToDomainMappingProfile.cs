using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using AutoMapper;
using PollPlus.Models;
using PollPlus.Domain;
using PollPlus.Helpers;

namespace PollPlus.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<CategoriaViewModel, Categoria>();
            Mapper.CreateMap<EmpresaViewModel, Empresa>()
                .BeforeMap((vm, d) =>
                {
                    d.Documento = new Documento { Numero = vm.Documento.Numero, Tipo = Domain.Enumeradores.EnumTipoDocumento.Cnpj };

                    d.Plataforma = new Plataforma { App = vm.Plataforma.App };
                });
            Mapper.CreateMap<EnqueteViewModel, Enquete>();
            Mapper.CreateMap<PerguntaViewModel, Pergunta>();
            Mapper.CreateMap<RespostaViewModel, Resposta>();
            Mapper.CreateMap<DocumentoViewModel, Documento>();
            Mapper.CreateMap<PlataformaViewModel, Plataforma>();
            Mapper.CreateMap<VoucherViewModel, Voucher>();
            Mapper.CreateMap<BannerViewModel, Banner>()
                .BeforeMap((vm, d) =>
                {
                    d.FileName = vm.file.FileName;
                    d.EmpresaId = UsuarioLogado.UsuarioAutenticado().EmpresaId;
                });
        }
    }
}
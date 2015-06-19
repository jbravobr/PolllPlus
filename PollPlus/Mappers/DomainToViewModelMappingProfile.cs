using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PollPlus.Domain;
using PollPlus.Models;

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
            Mapper.CreateMap<Enquete, EnqueteViewModel>();
            Mapper.CreateMap<Pergunta, PerguntaViewModel>();
            Mapper.CreateMap<Resposta, RespostaViewModel>();
            Mapper.CreateMap<Documento, DocumentoViewModel>();
            Mapper.CreateMap<Plataforma, PlataformaViewModel>();
        }
    }
}
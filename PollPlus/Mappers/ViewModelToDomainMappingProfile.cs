using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using AutoMapper;
using PollPlus.Models;
using PollPlus.Domain;

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
            Mapper.CreateMap<UsuarioViewModel, Usuario>()
                .BeforeMap((viewModel, dominio) =>
                {
                    var categorias = ViewBag["CategoriasInteresse"];

                    foreach (var cat in viewModel.CategoriasInteresse)
                    {
                        dominio.CategoriasInteresse.Add()
                    }
                });
        }
    }
}
﻿using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PollPlus.Domain;

namespace PollPlus.Models
{
    public class EnqueteViewModel
    {
        public int Id { get; set; }
        public bool TemVoucher { get; set; }
        public string Descricao { get; set; }
        public int EmpresaId { get; set; }
        public int UsuarioId { get; set; }
        public EnumTipoEnquete Tipo { get; set; }
        public HttpPostedFileBase file { get; set; }
        public string UrlVideo { get; set; }
        public EnumStatusEnquete Status { get; set; }
        public string Titulo { get; set; }
        public string correta { get; set; }

        //[Required(ErrorMessage = "Campo obrigatório.")]
        public PerguntaViewModel Pergunta { get; set; }

        public ICollection<EnqueteCategoria> EnqueteCategoria { get; set; }

        public List<int> CategoriasInteresse { get; set; }

        public List<SelectListItem> CategoriasForSelectList { get; set; }
    }
}

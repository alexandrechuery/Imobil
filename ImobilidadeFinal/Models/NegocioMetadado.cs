using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImobilidadeFinal.Models
{
    [MetadataType(typeof(NegocioMetadado))]
    public partial class Negocio { }

    public class NegocioMetadado
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(30, MinimumLength = 1,
     ErrorMessage = "Este campo deve ter entre 1 e 30 caracteres.")]
        public string Valor { get; set; }


    }
}
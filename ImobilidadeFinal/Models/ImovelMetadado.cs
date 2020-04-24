using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImobilidadeFinal.Models
{
    [MetadataType(typeof(ImovelMetadado))]
    public partial class Imovel { }

    public class ImovelMetadado
    {
        [StringLength(2, MinimumLength = 1,
            ErrorMessage = "Este campo deve ter entre 1 e 2 caracteres.")]
        public string Vagas { get; set; }

        [StringLength(2, MinimumLength = 1,
            ErrorMessage = "Este campo deve ter entre 1 e 2 caracteres.")]
        public string Quartos { get; set; }

        [StringLength(2, MinimumLength = 1,
            ErrorMessage = "Este campo deve ter entre 1 e 2 caracteres.")]
        public string Suite { get; set; }
    }
}
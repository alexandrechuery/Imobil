using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImobilidadeFinal.Models
{
    [MetadataType(typeof(TipoNegocioMetadado))]
    public partial class TipoNegocio { }

    public class TipoNegocioMetadado
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(15, MinimumLength = 1,
    ErrorMessage = "Este campo deve ter entre 1 e 15 caracteres.")]
        public string NomeTipoNegocio{ get; set; }

    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImobilidadeFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Proprietario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proprietario()
        {
            this.Imovel = new HashSet<Imovel>();
        }
    
        public int IdProprietario { get; set; }
        public string NomeProprietario { get; set; }
        public string Telefone { get; set; }
        public string N_Casa { get; set; }
        public string CEP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cervejaria.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Acesso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Acesso()
        {
            this.Funcionario = new HashSet<Funcionario>();
        }
    
        public int ID_LOGIN { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }
        public string ATIVO { get; set; }
        public string PERFIL { get; set; }
        public string NOME { get; set; }
        public string SOBRENOME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinkupEDM.AppModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class EstadoEnvio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstadoEnvio()
        {
            this.Envio = new HashSet<Envio>();
        }
    
        public int Id_Estado { get; set; }
        public Nullable<bool> Enviado { get; set; }
        public Nullable<bool> Cancelado { get; set; }
        public Nullable<bool> Finalizado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Envio> Envio { get; set; }
    }
}
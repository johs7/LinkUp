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
    
    public partial class TipoCambio
    {
        public int Id_Cambio { get; set; }
        public decimal CambioDia { get; set; }
        public System.DateTime FechaCambio { get; set; }
        public int MonedaId { get; set; }
    
        public virtual Moneda Moneda { get; set; }
    }
}
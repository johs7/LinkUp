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
    
    public partial class Cuenta
    {
        public int Id_Cuenta { get; set; }
        public long NumeroCuenta { get; set; }
        public decimal SaldoCuenta { get; set; }
        public int IdCliente { get; set; }
        public bool Predeterminada { get; set; }
    
        public virtual Clientes Clientes { get; set; }
    }
}

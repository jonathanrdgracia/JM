//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JM.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pago
    {
        public int Id { get; set; }
        public Nullable<int> PagoPorDia { get; set; }
        public Nullable<int> DiasTrabajados { get; set; }
        public Nullable<int> Valor { get; set; }
        public string Fecha { get; set; }
        public Nullable<int> IdProyecto { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
    }
}

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
    
    public partial class PagoDetalle
    {
        public int Id { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public Nullable<int> IdPagoMaestro { get; set; }
    
        public virtual PagoMaestro PagoMaestro { get; set; }
        public virtual Proyecto_detalle Proyecto_detalle { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JM.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pago
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public string Fecha { get; set; }
        public Nullable<int> IdProyecto { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
    
        public virtual Abonado Abonado { get; set; }
        public virtual ProyectoConPresupuesto ProyectoConPresupuesto { get; set; }
    }
}

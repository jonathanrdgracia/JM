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
    
    public partial class Proyecto_detalle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proyecto_detalle()
        {
            this.PagoDetalles = new HashSet<PagoDetalle>();
        }
    
        public int IdProyectoDetalle { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public Nullable<int> IdProyecto { get; set; }
        public Nullable<int> Estado { get; set; }
    
        public virtual Abonado Abonado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PagoDetalle> PagoDetalles { get; set; }
        public virtual ProyectoConPresupuesto ProyectoConPresupuesto { get; set; }
    }
}

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
    
    public partial class ProyectoSinPresupuesto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProyectoSinPresupuesto()
        {
            this.ProyectoDetalleSinPresupuestoes = new HashSet<ProyectoDetalleSinPresupuesto>();
        }
    
        public int IdProyecto { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> CantidadPresupuestada { get; set; }
        public int IdCliente { get; set; }
        public string FechaCreacion { get; set; }
        public Nullable<int> Estado { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProyectoDetalleSinPresupuesto> ProyectoDetalleSinPresupuestoes { get; set; }
    }
}

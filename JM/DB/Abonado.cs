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
    
    public partial class Abonado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Abonado()
        {
            this.EmpleadoPresupuestoes = new HashSet<EmpleadoPresupuesto>();
            this.Pago_Informal = new HashSet<Pago_Informal>();
            this.Proyecto_detalle = new HashSet<Proyecto_detalle>();
            this.ProyectoDetalleSinPresupuestoes = new HashSet<ProyectoDetalleSinPresupuesto>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string TipoEmpleado { get; set; }
        public string Fecha_inscripcion { get; set; }
        public string Telefono { get; set; }
        public string Lugar { get; set; }
        public int Estado { get; set; }
        public Nullable<int> IdTipoEmpleado { get; set; }
    
        public virtual TipoEmpleado TipoEmpleado1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpleadoPresupuesto> EmpleadoPresupuestoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pago_Informal> Pago_Informal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyecto_detalle> Proyecto_detalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProyectoDetalleSinPresupuesto> ProyectoDetalleSinPresupuestoes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JM.Presupuesto;
using JM.DB;
using JM.Obra_Detalle;
using JM.Obra_Detalle.ListarPresupuesto;
namespace JM.Presupuesto.Ediciones
{


    class Buscar_listado_detalle
    {
       
     public List<Presupuestos> materiales_presupuesto_list = new List<Presupuestos>();
     public List<Presupuestos> obras_presupuesto_list = new List<Presupuestos>();
     private int p;


     public void entregarIdObra(int x) 
     {
        
         using (var db = new PresupuestoEntities5())
         {
             var variable = db.Traer_ObrasDetalles_Por_Id(x);
           
             foreach (var item in variable)
             {
                 Console.WriteLine("se llena");
                 obras_presupuesto_list.Add(new Presupuestos {
                 Descripcion=item.Descripcion,
                 Cantidad=item.Cantidad.ToString(),
                 ID=item.id.ToString(),
                 Precio=item.Precio.ToString(),
                 Unidad=item.Unidad,
                 Total=item.ToString()
                 });
                
             }

            
         }
     
     }

     public Buscar_listado_detalle(int p)
     {
         // TODO: Complete member initialization
         this.p = p;
     }

     public Buscar_listado_detalle()
     {
         // TODO: Complete member initialization
     }

        public void entregar(int id)
       {



           using (var db = new PresupuestoEntities5())
           {
               var variable = db.TraerMaterialesDetallesPorId(id);

               foreach (var item in variable)
               {
                   materiales_presupuesto_list.Add(new Presupuestos
                   {
                            ID = Convert.ToString(item.id),
                            Descripcion = item.Descripcion,
                            Cantidad =Convert.ToString(item.Cantidad),
                            Precio = Convert.ToString(item.Precio),
                            Total = Convert.ToString(item.Precio),
                            Unidad = item.Unidad
                    });
               }
           }


         
       }
    }
}

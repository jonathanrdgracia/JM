using System;
using System.Collections.Generic;
using System.Linq;
using JM.DB;
using System.Text;
using System.Threading.Tasks;

namespace JM.Proyecto
{
    class ProyectosClass
    {
        public void Registrar_proyecto(String descip,String dire, int valor, List<DB.Abonado> lista)
        {

            using (var db = new PresupuestoEntities5())
            {
                //db.GuardarProyectoSinPresupuesto(descip,dire,valor);
                //db.SaveChanges();
            }


        
        }
    }
}

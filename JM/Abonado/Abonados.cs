using JM.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Modificar
{
    class Abonados
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Fecha_Ingreso { get; set; }
        public string Cedula { get; set; }
        public int Estado { get; set; }
        public string Telefono { get; set; }
        public string Lugar { get; set; }

        public void llenarAbonado(DataGridView dataGridView1) 
        {
            using (var db = new PresupuestoEntities5())
            {
                var query =
                   from c in db.Abonadoes
                   where c.Estado == 1
                   orderby c.Id descending
                   select c;


                foreach (var item in query.ToList())
                {
                    dataGridView1.Rows.Add
                        (
                            item.Id,
                            item.Nombre,
                            item.Apellidos,
                            item.Telefono,
                            item.TipoEmpleado,
                            item.Fecha_inscripcion,
                            item.Lugar

                        );
                }

            }
        
        }

        public void LLenarComboxTipoEmpleado(ComboBox combo) 
        {
            using (var db = new PresupuestoEntities5()) 
            {
                var query = db.TipoEmpleadoes.Select(c => c.Tipo);
                foreach (var i in query)
                {
                    combo.Items.Add(i);
                }
            }
        }


        public void llenarAbonadoEliminados(DataGridView dataGridView1)
        {


        }


    }


  
}

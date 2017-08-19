using JM.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Unidad
{
    class LlenarUnidad
    {
        public void LLenarCombobox(ComboBox combo, string tipo) 
        {
            combo.Items.Clear();
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.Unidads.Where(c => c.Tipo == tipo))
                {
                    combo.Items.Add(item.Unidad1);
                }



            }
        
        
        }
        public void LLenarLista(DataGridView lista)
        {

            lista.Rows.Clear();

            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.Unidads)
                {
                    if (item.Tipo.Equals("mano"))
                    {
                        lista.Rows.Add
                        (
                            item.Id,
                            item.Unidad1,
                            "Mano de obra"
                        );
                    }
                    else {
                        lista.Rows.Add
                      (
                          item.Id,
                          item.Unidad1,
                          "Material" 
                      );
                    }
                }



            }


        }
    }
}

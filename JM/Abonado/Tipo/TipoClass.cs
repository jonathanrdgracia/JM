using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Abonado.Tipo
{
    class TipoClass
    {
        public void LlenarTipo(ComboBox combo)
        {
            using (var db=new DB.PresupuestoEntities5())
                {
                    foreach (var item in db.TipoEmpleadoes)
                    {
                    combo.Items.Add(item.Tipo);
                    }
                }

        }
    }
}

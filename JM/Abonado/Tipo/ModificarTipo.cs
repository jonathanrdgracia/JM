using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Abonado.Tipo
{
    public partial class ModificarTipo : Form
    {
        public ModificarTipo()
        {
            InitializeComponent();
        }

        private void ModificarTipo_Load(object sender, EventArgs e)
        {

        }
        public void LlenarDato(DataGridView data)
        {
            data.Rows.Clear();
            using (var db = new DB.PresupuestoEntities5())
            {
                foreach (var item in db.TipoEmpleadoes.OrderByDescending(c => c.IdTipoEmpleado))
                {
                    data.Rows.Add
                        (
                            item.IdTipoEmpleado,
                            item.Tipo
                        );
                }
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

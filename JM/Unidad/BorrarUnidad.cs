using JM.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Unidad
{
    public partial class BorrarUnidad : Form
    {
        Unidad.LlenarUnidad l = new LlenarUnidad();
        private int Id { get; set; }
        public BorrarUnidad()
        {
            InitializeComponent();
        }

        private void BorrarUnidad_Load(object sender, EventArgs e)
        {
           
            l.LLenarLista(dataGridView1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (Id!=0)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar este cliente?", "Eliminar cliente", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        using (var db = new PresupuestoEntities5())
                        {

                            var remove = from aremove in db.Unidads
                                         where aremove.Id == Id
                                         select aremove;

                            foreach (var detail in remove)
                            {
                                db.Unidads.Remove(detail);
                            }


                            db.SaveChanges();
                            MessageBox.Show("Unidad borrada exitosamente");

                            dataGridView1.Rows.Clear();
                            l.LLenarLista(dataGridView1);


                        }

                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           Id =Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

          

        }
    }
}

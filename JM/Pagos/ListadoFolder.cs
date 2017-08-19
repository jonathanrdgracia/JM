using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JM.DB;
using System.Globalization;

namespace JM.Pagos
{
    public partial class ListadoFolder : Form
    {
        public ListadoFolder()
        {
            InitializeComponent();


        }
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
       


        private void ListadoFolder_Load(object sender, EventArgs e)
        {
            nfi.CurrencyDecimalDigits = 2;
            using (var db = new PresupuestoEntities5()) 
            {
                var query = (from t1 in db.PagoMaestroes
                             join t2 in db.ProyectoConPresupuestoes on t1.Idproyecto equals t2.IdProyecto
                             where t2.Estado==2
                             select new {t2.IdProyecto,t2.Descripcion,t2.Direccion,t2.CantidadPresupuestada,t2.FechaCreacion });


                foreach (var i in query.OrderByDescending(c=>c.IdProyecto))
                {
                    dataGridView1.Rows.Add
                        (
                        i.IdProyecto,
                        i.Descripcion,
                        i.Direccion,
                        i.FechaCreacion,
                       Convert.ToInt32(i.CantidadPresupuestada).ToString("C",nfi)
                        );

                }
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
          
            try
            {
                var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                var id = Convert.ToInt32(x0);
                PagosEmpleados Lf = new PagosEmpleados();
                Lf.IdProyecto = id;
                Lf.ShowDialog();
            }
            catch (NullReferenceException es)
            {

                MessageBox.Show("Todos los campos son requeridos", "Presupuesto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException este)
            {
                MessageBox.Show("Verifique que todos los datos sean correctos ", "Presupuesto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal " + ex.Message, "Presupuesto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

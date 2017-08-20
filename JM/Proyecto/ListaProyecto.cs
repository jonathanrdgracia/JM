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
using JM.Pagos.Pagos_proyecto;

namespace JM.Proyecto
{
    public partial class ListaProyecto : Form
    {
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

        public ListaProyecto()
        {
            InitializeComponent();
        }

        private void ListaProyecto_Load(object sender, EventArgs e)
        {
            Llenar();
        }

        private void Llenar()
        {
            this.dataGridView1.Rows.Clear();
            using (PresupuestoEntities5 db = new PresupuestoEntities5())
            {
                nfi.CurrencyDecimalDigits = 2;
                //   var query=db.ProyectoSinPresupuestoes.SqlQuery("Select * from ProyectoSinPresupuesto where Estado=1");

                var query = from t1 in db.ProyectoConPresupuestoes
                            join t2 in db.Presupuestos on t1.IdPresupuesto equals t2.IdPresupuestos
                            join t3 in db.Clientes on t2.IdCliente equals t3.id
                            where t1.Estado != 0
                            select new { t1.IdProyecto, t1.Descripcion, t3.Nombre, t3.Apellido, t3.Telefono };


                foreach (var i in query.OrderByDescending(c => c.IdProyecto))
                {
                    this.dataGridView1.Rows.Add(
                            i.IdProyecto,
                            i.Descripcion,
                            i.Nombre + " " + i.Apellido,
                            i.Telefono
                        );
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
       
            try
            {
                ModificarProyecto m = new ModificarProyecto();


                var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                m.IdProtecto = Convert.ToInt32(x0);
                m.ShowDialog();

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
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas eliminar este proyecto?", "Eliminar", MessageBoxButtons.YesNo);
                var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                var id = Convert.ToInt32(x0);
                if (dialogResult == DialogResult.Yes)
                {
                    using (var db = new PresupuestoEntities5())
                    {
                        DB.ProyectoConPresupuesto pip;
                        pip = (from c in db.ProyectoConPresupuestoes
                               where c.IdProyecto == id
                               select c).First();
                        pip.Estado = 0;
                        db.SaveChanges();
                            MessageBox.Show("Proyecto eliminado con exito");
                            Llenar();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            catch (NullReferenceException es)
            {

                MessageBox.Show("Debes seleccionar una fila");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Intentelo de nuevo");
            }
        }
    }
}

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

namespace JM.Pagos.Pagos_proyecto
{
    public partial class ListadoTodoPagoProyecto : Form
    {
        public ListadoTodoPagoProyecto()
        {
            InitializeComponent();
        }
    
        
        private void ListadoTodoPagoProyecto_Load(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {
                 var query = (from t1 in db.ProyectoConPresupuestoes
                            join t2 in db.Presupuestos on t1.IdPresupuesto equals t2.IdPresupuestos
                            join t3 in db.Clientes on t2.IdCliente equals t3.id
                            join t4 in db.Pagoes on t1.IdProyecto equals t4.IdProyecto
                            select new {t1.IdProyecto, t1.Descripcion, t1.Direccion, t3.Nombre, t3.Telefono }).Distinct();

                 foreach (var i in query.OrderByDescending(c=>c.IdProyecto))
                 {
                     this.dataGridView1.Rows.Add
                         (
                            i.IdProyecto,
                            i.Descripcion,
                            i.Nombre,
                            i.Direccion
                           
                         );
                 }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                    var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    ListadoTodoPago a = new ListadoTodoPago();
                    a.IdProyecto = Convert.ToInt32(x0);
                    a.ShowDialog();
                   
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

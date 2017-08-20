using JM.DB;
using JM.Pagos.Pagos_proyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Pagos
{
    public partial class CrearFolderPago : Form
    {
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
           


        public CrearFolderPago()
        {
            InitializeComponent();
        }
        private void CrearFolderPago_Load(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5()) 
            {
                var query = from t1 in db.ProyectoConPresupuestoes
                            join t2 in db.Presupuestos on t1.IdPresupuesto equals t2.IdPresupuestos
                            join t3 in db.Clientes on t2.IdCliente equals t3.id
                            where t1.Estado == 1
                            select new { t1.IdProyecto, t1.Direccion, t1.Descripcion, t3.Nombre, t3.Apellido, t3.Telefono,t1.CantidadPresupuestada };


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
            var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Nuevo_pago_proyecto m = new Nuevo_pago_proyecto();
            m.IdProyecto = Convert.ToInt32(x0);

            m.ShowDialog();
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

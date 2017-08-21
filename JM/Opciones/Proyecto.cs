using JM.DB;
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

namespace JM.Opciones
{
    public partial class Proyecto : Form
    {
        public Proyecto()
        {
            InitializeComponent();
        }
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        private void Proyecto_Load(object sender, EventArgs e)
        {
            Llenar();
        }
        private void Llenar()
        {
            nfi.CurrencyDecimalDigits = 2;
            this.dataGridView1.Rows.Clear();
            using (PresupuestoEntities5 db = new PresupuestoEntities5())
            {
                nfi.CurrencyDecimalDigits = 2;
                //   var query=db.ProyectoSinPresupuestoes.SqlQuery("Select * from ProyectoSinPresupuesto where Estado=1");

                var query = from t1 in db.ProyectoConPresupuestoes
                            join t2 in db.Presupuestos on t1.IdPresupuesto equals t2.IdPresupuestos
                            join t3 in db.Clientes on t2.IdCliente equals t3.id
                            where t1.Estado == 0
                            select new { t1.IdProyecto, t1.Descripcion, t3.Nombre, t3.Apellido, t3.Telefono, t2.Direccion };


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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PresupuestoEntities5 db = new PresupuestoEntities5();
            DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas restaurar este proyecto?", "Proyecto", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
                int _id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

                var c = (from x in db.ProyectoConPresupuestoes
                         where x.IdProyecto == _id
                             select x).First();
                c.Estado = 1;
                db.SaveChanges();
                Llenar();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
    }
}

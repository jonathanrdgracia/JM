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

namespace JM.Pagos.Pagos_proyecto
{
    public partial class ListadoPagoProyecto : Form
    {
        public string Total { get; set; }
  
        PagoProyectoClass ppc = new PagoProyectoClass();
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public ListadoPagoProyecto()
        {
            InitializeComponent();
        }

        private void ListadoPagoProyecto_Load(object sender, EventArgs e)
        {
            nfi.CurrencyDecimalDigits = 2;
            using (PresupuestoEntities5 db = new PresupuestoEntities5())
            {
                nfi.CurrencyDecimalDigits = 2;
                //   var query=db.ProyectoSinPresupuestoes.SqlQuery("Select * from ProyectoSinPresupuesto where Estado=1");
                var query = from t1 in db.ProyectoConPresupuestoes
                            where t1.Estado==1
                            select new {t1.IdProyecto,t1.Descripcion, t1.Presupuesto ,t1.CantidadPresupuestada,t1.Direccion};


                foreach (var item in query.OrderByDescending(c => c.IdProyecto))
                {
                    this.dataGridView1.Rows.Add
                        (
                            item.IdProyecto,
                            item.Descripcion,
                            item.Direccion,
                            Convert.ToInt32(item.CantidadPresupuestada).ToString("C", nfi)

                        );
                }


            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
           Total = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
           ppc.IdProyecto = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
           Nuevo_pago_proyecto n = new Nuevo_pago_proyecto();
           n.IdProyecto=Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
           n.textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
           n.textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
           n.textBox7.Text = Total.ToString();
           this.Close();
            n.ShowDialog();
           
            
        }
    }
}

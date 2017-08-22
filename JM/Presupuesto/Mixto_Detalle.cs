using JM.DB;
using JM.Presupuesto.Ediciones;
using JM.Reportes;
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

namespace JM.Presupuesto
{
    public partial class Mixto_Detalle : Form
    {
        public Mixto_Detalle()
        {
            InitializeComponent();
        }
        private int Tipo;
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public int TIPO
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        
        private void Mixto_Detalle_Load(object sender, EventArgs e)
        {
            Llenar();
        }

        public void Llenar()
        {
            nfi.CurrencyDecimalDigits = 2;
            this.dataGridView1.Rows.Clear();
            using (var db = new PresupuestoEntities5())
            {
                //var query =db.Materiales_detalle.Where(c=>c.IdPresupuesto==idpre)

                foreach (var item in db.SP_ListadoPresupuestoDeManoDeObra(Tipo).OrderByDescending(c => c.IdPresupuestos))
                {
                    dataGridView1.Rows.Add(

                item.IdPresupuestos,
                item.Descripcion,
                item.Nombre,
                item.TipoCliente,
                item.Telefono,
                item.FechaCreacion,
                "RD"+Convert.ToInt32(item.Total).ToString("C", nfi)
                );

                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
            var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var id = Convert.ToInt32(x0);
            Ambos a = new Ambos();
            a.ID = id;
            a.ShowDialog();
            }
            catch (Exception)
            {
                
               
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            try
            {
                 var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var id = Convert.ToInt32(x0);
            Mixto_Ajustar a = new Mixto_Ajustar();
            a.ID_Que_Paso=id;
            a.ShowDialog();
            }
            catch (Exception)
            {
                
             
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var r = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                ModificarMixto a = new ModificarMixto();
                a.IdPropuesta = r;
                a.ShowDialog();

            }
            catch (Exception)
            {
                
              
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            var query = "%" + textBox6.Text + "%";
            using (var db = new PresupuestoEntities5())
            {


                foreach (var item in db.x(2, query))
                {

                dataGridView1.Rows.Add(
                item.IdPresupuestos,
                item.Descripcion,
                item.Nombre,
                item.TipoCliente,
                item.Telefono,
                item.FechaCreacion,
                "RD"+Convert.ToInt32(item.Total).ToString("C",nfi)
               
               
                );

                    
                }
            
            }
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            var query = "%" + textBox6.Text + "%";
            using (var db = new PresupuestoEntities5())
            {


                foreach (var item in db.x(2, query))
                {

                    dataGridView1.Rows.Add(
                    item.IdPresupuestos,
                    item.Descripcion,
                    item.Nombre,
                    item.TipoCliente,
                    item.Telefono,
                    item.FechaCreacion,
                    "RD"+Convert.ToInt32(item.Total).ToString("C", nfi)
                    );


                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                var x0 = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                PresupuestoEntities5 db = new PresupuestoEntities5();
                DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas eliminar este presupuesto?", "Presupuesto", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {



                    var c = (from x in db.Presupuestos
                             where x.IdPresupuestos == x0
                             select x).First();
                    c.Estado = 0;
                    db.SaveChanges();
                    Llenar();
                }
                else if (dialogResult == DialogResult.No)
                {

                }

            }
            catch (Exception)
            {


            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

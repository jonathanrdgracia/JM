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
using JM.Obra_Detalle.ListarPresupuesto;
using System.Globalization;
using JM.Presupuesto.Ediciones;

namespace JM.Presupuesto
{
    public partial class Materiales_Detalle : Form
    {
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        private int Tipo;

        public int TIPO
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        
        public Materiales_Detalle()
        {
            InitializeComponent();
        }

        private void Materiales_Detalle_Load(object sender, EventArgs e)
        {
          

            nfi.CurrencyDecimalDigits = 2;

            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.SP_ListadoPresupuestoDeMateriales(Tipo).OrderByDescending(c => c.IdPresupuestos))
                {
                    dataGridView1.Rows.Add(

                item.IdPresupuestos,
                item.Descripcion,
                item.Nombre,
                item.TipoCliente,
                item.Telefono,
                item.FechaCreacion,
                Convert.ToInt32(item.Total).ToString("C", nfi)
                );

                }


            }

        }

        public void Llenar()
        {
            nfi.CurrencyDecimalDigits = 2;
            this.dataGridView1.Rows.Clear();
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.SP_ListadoPresupuestoDeMateriales(Tipo).OrderByDescending(c => c.IdPresupuestos))
                {
                    dataGridView1.Rows.Add(

                item.IdPresupuestos,
                item.Descripcion,
                item.Nombre,
                item.TipoCliente,
                item.Telefono,
                item.FechaCreacion,
                Convert.ToInt32(item.Total).ToString("C", nfi)
                );

                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var  x0 = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

            Buscar_listado_detalle bl = new Buscar_listado_detalle();
          // Obras_ajustar m = new Obras_ajustar();
         //   m.Show();
         //   bl.entregar(x0);

        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           try
            {
                Materiales_ajustar m = new Materiales_ajustar();

                m.ID_Que_Paso = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
               
               m.textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                m.textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                m.ShowDialog();
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

        private void button7_Click(object sender, EventArgs e)
        {
           
                try
                {
                    var ID = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

                    ModificarPresupustoUnitario m = new ModificarPresupustoUnitario(ID);
                    
                    m.ShowDialog();
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

        private void button9_Click(object sender, EventArgs e)
        {
           

            try
            {
                Reportes.ReporteMateriales m = new Reportes.ReporteMateriales();
                m.ID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
                m.ShowDialog();
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

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            var ggg = textBox6.Text;
            nfi.CurrencyDecimalDigits = 2;
            this.dataGridView1.Rows.Clear();
            var w = "%" + ggg + "%";
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.SP_ListadoPresupuestoDeMaterialesQury(1,w).OrderByDescending(c => c.IdPresupuestos))
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ggg = textBox6.Text;
            nfi.CurrencyDecimalDigits = 2;
            this.dataGridView1.Rows.Clear();
            var w = "%" + ggg + "%";
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.SP_ListadoPresupuestoDeMaterialesQury(1, w).OrderByDescending(c => c.IdPresupuestos))
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            var x0 = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            try
            {
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
    }
}

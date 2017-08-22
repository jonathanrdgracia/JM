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
using JM.Reportes;
using JM.Unidad;

namespace JM.Presupuesto
{
    public partial class Obras_Detalle : Form
    {
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public Obras_Detalle()
        {
            InitializeComponent();
        }
        private int Tipo;

        public int TIPO
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        
        private void Obras_Detalle_Load(object sender, EventArgs e)
        {
            Llenar();
        }

        public void Llenar()
        {
            nfi.CurrencyDecimalDigits = 2;
            this.dataGridView1.Rows.Clear();
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.SP_ListadoPresupuestoDeManoDeObra(Tipo).OrderByDescending(c => c.IdPresupuestos))
                {
                    dataGridView1.Rows.Add(

                item.IdPresupuestos,
                item.Descripcion,
                item.Nombre,
                item.TipoCliente,
                item.Telefono,
                item.FechaCreacion,
                "RD" + Convert.ToInt32(item.Total).ToString("C", nfi)
                );

                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x0 = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            
            Buscar_listado_detalle bl = new Buscar_listado_detalle();
          
          
            bl.entregarIdObra(x0);
            //Obras_ajustar o = new Obras_ajustar();
          //  o.Show();
         
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                 var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var id = Convert.ToInt32(x0);

            ReporteManodeObra r = new ReporteManodeObra();
            r.IdProyecto = id;
            r.ShowDialog();
            }
            catch (Exception ze)
            {

                MessageBox.Show(ze.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Manos_ajustar m = new Manos_ajustar();
            var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var x2 = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            var id = Convert.ToInt32(x0);
            m.ID_Que_Paso=id;
            m.textBox1.Text = x1;
            m.textBox2.Text = x2;
            m.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                    var x= Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Obra_Modificar a = new Obra_Modificar();
                    a.MyId = x;
                    a.ShowDialog();
            }
            catch (Exception)
            {
                
               
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
          
                using (var db = new PresupuestoEntities5())
                {
              
                    this.dataGridView1.Rows.Clear();
                    var query = "%"+textBox6.Text+"%";

                    foreach (var i in db.x(1, query))
                    {
                        this.dataGridView1.Rows.Add
                            (
                            i.IdPresupuestos,
                            i.Descripcion,
                            i.Nombre,
                            i.TipoCliente,
                            i.Telefono,
                            i.FechaCreacion,
                            "RD"+Convert.ToInt32(i.Total).ToString("C",nfi)
                            );
                    }
                }
           
       
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
         
                using (var db = new PresupuestoEntities5())
                {
                  
                    this.dataGridView1.Rows.Clear();
                    var query = "%" + textBox6.Text + "%";

                    foreach (var i in db.x(1, query))
                    {
                        this.dataGridView1.Rows.Add
                            (
                            i.IdPresupuestos,
                            i.Descripcion,
                            i.Nombre,
                            i.TipoCliente,
                            i.Telefono,
                            i.FechaCreacion,
                            "RD" + Convert.ToInt32(i.Total).ToString("C", nfi)
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
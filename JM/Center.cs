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
using JM.DB;
using JM.Cliente;
using JM.Obra_Detalle;
namespace JM
{
    public partial class Center : Form
    {

        public Center()
        {
            InitializeComponent();
            label5.Text = fecha();
        }

        private void darToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }
        PresupuestoEntities5 dbcontext = new PresupuestoEntities5();

        List<Presupuestos> PREs = new List<Presupuestos>();
        private void button2_Click(object sender, EventArgs e)
        {
            //var d = Convert.ToDouble(textBox1.Text);
            //var x = Math.Ceiling(d);
            //MessageBox.Show(x.ToString());


            var descrip = descripcionbox.Text;
            var prec = maskedTextBox2.Text;
            var cantidad = textBox1.Text;
            var unidad = comboBox1.SelectedItem.ToString();
            var total = Convert.ToInt32(prec) * Convert.ToInt32(cantidad);



            PREs.Add(new Presupuestos
            {
                Descripcion = descrip,
                Precio = prec,
                Unidad=unidad,
                Cantidad=cantidad,
                Total=total.ToString()
                
                
            });



            //dataGridView1.DataSource = PREs.ToList();
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalDigits = 2;
            var pre = Convert.ToInt16(prec).ToString("C", nfi);

            dataGridView1.Rows.Add(
                PREs.Select(c => c.Descripcion).Last().ToString(),
                PREs.Select(c => c.Unidad).Last().ToString(),
               Convert.ToInt16(PREs.Select(c => c.Precio).Last().ToString()).ToString("C", nfi),
               PREs.Select(c => c.Cantidad).Last().ToString(),
               PREs.Select(c => c.Total).Last().ToString()
               

                );

            descripcionbox.Text = "";
            maskedTextBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListadoClientes lc = new ListadoClientes();
            lc.Show();
            this.Dispose();
        }

        private void Center_Load(object sender, EventArgs e)
        {
            fecha();
        }

        private string fecha()
        {
            return Convert.ToString(DateTime.Now.ToString("d/M/yyyy"));
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            using (var context = new PresupuestoEntities5())
            {

                var id = Convert.ToInt16(textBox2.Text);
                var fecha1 = fecha();
                var direccion = textBox3.Text;
                var comentario = textBox5.Text;

                var studentGrades = context.guardar_presupuesto_cabeza(fecha1, id, direccion, comentario);//guardo con un procedure la cabecera
              //  var miID = context.recuperar_idPresupuesto(id, feha, comentario).ToList();//recupero el id del presupuesto

                //var ID = "";
                //foreach (var item in miID)//busco el ID del presupuesto para usarlo en el listado de articulo
                //{
                //    ID = item.Value.ToString();//debo convertir a int
                //}

                //if (Obras.Select(c => c.Total).Count() >= 1 && PREs.Select(c => c.Cantidad).Count() == 0)// en caso de hacer un presupuesto solo con mano de obra
                //{
                //        foreach (var item in Obras)
                //        {
                //            var lista = context.guardar_obras_listado(Convert.ToInt16(ID), item.Descripcion.ToString(), item.Unidad.ToString(), Convert.ToInt16(item.Precio), Convert.ToInt32(item.Cantidad), Convert.ToInt16(item.Total),1); // el 1 es para saber si fue solo ese solamente para filtrar mejor en listado
                            
                //        }

                //}
                //else if (Obras.Select(c => c.Total).Count() == 0 && PREs.Select(c => c.Cantidad).Count() >= 1)// en caso de hacer un presupuesto solo con materiales
                //{
                //        foreach (var item in PREs)
                //        {
                //            var lista = context.guardar_presupuestos_listados(Convert.ToInt16(ID), item.Descripcion.ToString(), item.Unidad.ToString(), Convert.ToInt16(item.Precio), Convert.ToInt32(item.Cantidad), Convert.ToInt16(item.Total), 1);// el 1 es para saber si fue solo ese solamente para filtrar mejor en listado
                          
                //        }

                //}
                //else if (Obras.Select(c => c.Total).Count() >= 1 && PREs.Select(c => c.Cantidad).Count() >= 1)// en caso de hacer un presupuesto con materiales y mano de obra
                //{
                //    foreach (var item in PREs)
                //    {
                //        var lista = context.guardar_presupuestos_listados(Convert.ToInt32(ID), item.Descripcion.ToString(), item.Unidad.ToString(), Convert.ToInt32(item.Precio), Convert.ToInt32(item.Cantidad), Convert.ToInt32(item.Total),2);
                       
                //    }
                //    foreach (var item in Obras)
                //    {
                //        var lista = context.guardar_obras_listado(Convert.ToInt32(ID), item.Descripcion.ToString(), item.Unidad.ToString(), Convert.ToInt32(item.Precio), Convert.ToInt32(item.Cantidad), Convert.ToInt32(item.Total),2);
                       
                //    }

                //}
                //else
                //{

                //}

            }


        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login c = new login();
            c.Show();
        }

        private void realizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listado_cebecera l = new Listado_cebecera();
            l.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        List<ManoDeObra> Obras = new List<ManoDeObra>();
        private void button9_Click(object sender, EventArgs e)
        {

            var descripcion = textBox6.Text;
            var unidad = comboBox2.SelectedItem.ToString();
            var precio = maskedTextBox3.Text;
            var cantidad = maskedTextBox4.Text;
            var total = Convert.ToInt32(precio) * Convert.ToInt32(cantidad);

            Obras.Add(new ManoDeObra{
                Cantidad=cantidad,
                Descripcion=descripcion,
                Unidad=unidad,
                Precio=precio,
                Total=total.ToString()
            });

            //dataGridView2.DataSource = PREs.ToList();
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalDigits = 2;
            var pre = Convert.ToInt16(precio).ToString("C", nfi);
              
            dataGridView2.Rows.Add(
                Obras.Select(c => c.Descripcion).Last().ToString(),
                Obras.Select(c=>c.Unidad).Last().ToString(),
               Convert.ToInt16(Obras.Select(c => c.Precio).Last().ToString()).ToString("C", nfi),
               Obras.Select(c=>c.Cantidad).Last().ToString(),
               Obras.Select(c=>c.Total).Last().ToString()
           
               );

         }

        private void verPresupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listado_cebecera c = new Listado_cebecera();
            c.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
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
using JM.Presupuesto;


namespace JM.Cliente
{


    public partial class ListadoClientes : Form
    {


        int px, py;
        Boolean mover;

        public ListadoClientes()
        {

            InitializeComponent();

        }


        private void ListadoClientes_Load(object sender, EventArgs e)
        {

            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.Clientes.Where(c => c.Estado == 1).OrderByDescending(c => c.id))
                {
                    dataGridView1.Rows.Add(
                        "00" + item.id,
                        item.Nombre,
                        item.Telefono,
                        item.TipoCliente
                        );
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                ListadoClientes lc = new ListadoClientes();
             

                var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                var x2 = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                var x3 = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

                PresupuestoMateriales c = new PresupuestoMateriales();

                enviado(x0,x1,x2,x3);

              
                this.Dispose();
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione un cliente para agregarlo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ListadoClientes lc = new ListadoClientes();
           // Centro f = new Centro();

           // f.Show();
           
           // this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListadoClientes lc = new ListadoClientes();
           // Centro f = new Centro();

           // f.Show();
          
          //  this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            px = e.X;
            py = e.Y;
            mover = true;

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Location = this.PointToScreen(new Point(System.Windows.Forms.Control.MousePosition.X - this.Location.X - px, System.Windows.Forms.Control.MousePosition.Y - this.Location.Y - py));
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            var query = "%" + textBox1.Text + "%";
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.SP_FiltrarClienteActivo(query).OrderByDescending(c => c.id))
                {
                    dataGridView1.Rows.Add(
                        "00" + item.id,
                        item.Nombre + " " + item.Apellido,
                        item.Telefono,
                        item.TipoCliente
                        );
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        public delegate void enviar(string id,string dato,string dato2,string dato3);
        public event enviar enviado;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            var query = "%" + textBox1.Text + "%";
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.SP_FiltrarClienteActivo(query).OrderByDescending(c => c.id))
                {
                    dataGridView1.Rows.Add(
                        "00" + item.id,
                        item.Nombre + " " + item.Apellido,
                        item.Telefono,
                        item.TipoCliente
                        );
                }

            }
        }

        //private void ejecutar(string dato, string dato2, string dato3)
        //{
        //    textBox1.Text = dato;
        //}

    }
}
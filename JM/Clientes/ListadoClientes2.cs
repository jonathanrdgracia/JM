using JM.DB;
using JM.Presupuesto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Clientes
{
    public partial class ListadoClientes2 : Form
    {
        public ListadoClientes2()
        {
            InitializeComponent();
        }

        private void ListadoClientes2_Load(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.Clientes.Where(c => c.Estado == 1).OrderByDescending(c => c.id))
                {
                    dataGridView1.Rows.Add(
                        item.id,
                        item.Nombre,
                        item.Telefono,
                        item.TipoCliente
                        );
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            var query = "%" + textBox1.Text + "%";
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.SP_FiltrarClienteActivo(query).OrderByDescending(c => c.id))
                {
                    dataGridView1.Rows.Add(
                        item.id,
                        item.Nombre + " " + item.Apellido,
                        item.Telefono,
                        item.TipoCliente
                        );
                }

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                var x2 = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                var x3 = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

                PresupuestoObras c = new PresupuestoObras();

                enviado(x0, x1, x2, x3);


                this.Dispose();
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione un cliente para agregarlo");
            }
        }
        public delegate void enviar(string dato,string dato2,string dato3,string dato4);
        public event enviar enviado;

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            var query = "%" + textBox1.Text + "%";
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.SP_FiltrarClienteActivo(query).OrderByDescending(c => c.id))
                {
                    dataGridView1.Rows.Add(
                        item.id,
                        item.Nombre + " " + item.Apellido,
                        item.Telefono,
                        item.TipoCliente
                        );
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

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

namespace JM.Clientes
{
    public partial class EliminarCliente : Form
    {
        Clientes.ClientesClass a = new ClientesClass();
        public EliminarCliente()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EliminarCliente_Load(object sender, EventArgs e)
        {
            a.LlenarGridClientesActivos(dataGridView1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var id = Convert.ToInt32(x0);
            var db = new PresupuestoEntities5();

            DialogResult dialogResult = MessageBox.Show("(¿Seguro que deseas eliminar este cliente?", "Cliente", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var c = (from x in db.Clientes
                         where x.id == id
                         select x).First();

                c.Estado = 0;
                db.SaveChanges();
                MessageBox.Show("Cliente borrado exitosamente");

                dataGridView1.Rows.Clear();
                a.llenarCliente(dataGridView1);


            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            var query = textBox6.Text;
            this.dataGridView1.Rows.Clear();
            using (var db = new PresupuestoEntities5())
            {
                var w = "%" + query + "%";
                foreach (var item in db.SP_FiltrarClienteActivo(w).OrderByDescending(c => c.id))
                {
                    dataGridView1.Rows.Add
                        (
                            item.id,
                            item.Nombre,
                            item.Telefono,
                            item.TipoCliente
                        );
                }
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            var query = textBox6.Text;
            this.dataGridView1.Rows.Clear();
            using (var db = new PresupuestoEntities5())
            {
                var w = "%" + query + "%";
                foreach (var item in db.SP_FiltrarClienteActivo(w).OrderByDescending(c => c.id))
                {
                    dataGridView1.Rows.Add
                        (
                            item.id,
                            item.Nombre,
                            item.Telefono,
                            item.TipoCliente
                        );
                }
            }
        }
    }
}

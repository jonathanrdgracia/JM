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
    public partial class ListadoCliente4 : Form
    {
        public ListadoCliente4()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                var x2 = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                var x3 = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                var x4 = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();



                enviado(x0, x1, x2,x3,x4);


                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione un cliente para agregarlo");
            }
        }
        public delegate void enviar(string dato, string dato2, string dato3,string dato4,string dato5);
        public event enviar enviado;

        private void ListadoCliente4_Load(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.Abonadoes.Where(c => c.Estado == 1).OrderByDescending(c => c.Id))
                {
                    dataGridView1.Rows.Add(
                        item.Id,
                        item.Nombre,
                        item.TipoEmpleado,
                        item.Telefono,
                        item.Lugar

                        );
                }
            }
        }
        
    }
}

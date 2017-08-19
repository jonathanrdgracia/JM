using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using JM.DB;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Pagos.Pagos_Informales
{
    public partial class Nuevo_pago_informal_cliente_pago : Form
    {
        public delegate void enviar(int ID,string nombre, string apellido);
        public event enviar enviado;

        public Nuevo_pago_informal_cliente_pago()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            using (var db = new PresupuestoEntities5()) 
            {
               var x= textBox6.Text;
               dataGridView1.Rows.Clear();
                
                foreach (var item in db.Clientes.Where(c => c.Nombre.Contains(x)).Where(c=>c.Estado==1).Where(c=>c.Apellido.Contains(x)))
                {
                    dataGridView1.Rows.Add
                        (
                        item.id,
                        item.Nombre,
                        item.Apellido
                        );
                    
                }
            
            }
        }

        private void Nuevo_pago_informal_cliente_pago_Load(object sender, EventArgs e)
        {

            using (var db = new PresupuestoEntities5())
            {
               
              
                foreach (var item in db.Clientes.Where(c=>c.Estado==1))
                {
                    dataGridView1.Rows.Add
                        (
                        item.id,
                        item.Nombre,
                        item.Apellido
                        );

                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var x0 =Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var x2 = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            enviado(x0, x1, x2);
            this.Close();
        }
    }
}

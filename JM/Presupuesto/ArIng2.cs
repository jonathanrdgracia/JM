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

namespace JM.Presupuesto
{
    public partial class ArIng2 : Form
    {
        public ArIng2()
        {
            InitializeComponent();
        }

        private void ArIng2_Load(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {
                var query = (from t1 in db.Clientes select t1);
                            

                foreach (var item in query)
                {
                    dataGridView4.Rows.Add(

                        item.id,
                        item.Nombre,
                        item.Telefono
                      
                        );

                }

            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var Id = Convert.ToInt32(this.dataGridView4.CurrentRow.Cells[0].Value.ToString());
                var Nombre = this.dataGridView4.CurrentRow.Cells[1].Value.ToString();
                var Telefono = this.dataGridView4.CurrentRow.Cells[2].Value.ToString();
                enviado(Id, Nombre, Telefono);
                this.Close();
            }
            catch (Exception)
            {


            }

        }
        public delegate void enviar(int id, string nombre, string telefono);
        public event enviar enviado;

        private void button13_Click(object sender, EventArgs e)
        {

          
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
    }
}

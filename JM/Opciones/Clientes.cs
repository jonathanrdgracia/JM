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

namespace JM.Opciones
{
    public partial class Clientes : Form
    {
       
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            Llenar();
        }
        private void Llenar()
        {

            
            using (PresupuestoEntities5 db = new PresupuestoEntities5())
            {

                //   var query=db.ProyectoSinPresupuestoes.SqlQuery("Select * from ProyectoSinPresupuesto where Estado=1");
                this.dataGridView1.Rows.Clear();
                foreach (var item in db.Clientes.Where(c => c.Estado == 0).OrderByDescending(c => c.id))
                {
                        this.dataGridView1.Rows.Add(
                        item.id,
                        item.Nombre,
                        item.Telefono,
                        item.TipoCliente
                        );
                }





            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                PresupuestoEntities5 db = new PresupuestoEntities5();
                DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas restaurar este cliente?", "Cliente", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    int _id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

                    var c = (from x in db.Clientes
                             where x.id == _id
                             select x).First();
                    c.Estado = 1;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

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

namespace JM.Clientes
{
    public partial class ModificarCliente : Form
    {
        ClientesClass cc = new ClientesClass();
        public int IdCliente { get; set; }
        public ModificarCliente()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            cc.LlenarGridClientesActivos(dataGridView1);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
           
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
                            "00" + item.id,
                            item.Nombre,
                            item.Telefono,
                            item.TipoCliente
                        );
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            using (var db = new PresupuestoEntities5())
                {
                  //  var i =Convert.ToInt32(IdCliente.ToString().Substring(2, IdCliente.ToString().Length));
                  //  MessageBox.Show(IdCliente.ToString());
                 var  c = (from x in db.Clientes
                         where x.id == IdCliente
                         select x).First();


                 c.Nombre = textBox2.Text;
                 c.Telefono = textBox3.Text;
                 c.TipoCliente = comboBox1.SelectedItem.ToString();
                 db.SaveChanges();
                 this.dataGridView1.Rows.Clear();
                 cc.LlenarGridClientesActivos(dataGridView1);
                 textBox6.Text = "";
                
                }

 
            

              //  MessageBox.Show("Verifique que todo este en orden e intentelo de nuevo "+ex.Message);
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdCliente = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var x2 = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            var x3 = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.SelectedItem = x3;
            textBox2.Text = x1;
            textBox3.Text = x2;

        }
    }
}

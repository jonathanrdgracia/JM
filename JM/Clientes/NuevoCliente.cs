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
namespace JM.Cliente
{
    public partial class NuevoCliente : Form
    {
        public string _Telefono { get; set; }
        public NuevoCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nombre = textBox2.Text;
         
            var tele = textBox3.Text;

            using (var db = new PresupuestoEntities5())

            {
                db.Clientes.Add(new DB.Cliente
                {
                    Nombre = nombre,
                   
                    Telefono = tele
                });
                db.SaveChanges();
            }
        }

        private void NuevoCliente_Load(object sender, EventArgs e)
        {
            llenarData();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void llenarData()
        {
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.Clientes.Where(c => c.Estado == 1).OrderByDescending(c => c.id))
                {
                    dataGridView1.Rows.Add
                        (
                            item.id,
                            item.Nombre+" "+item.Apellido,
                            item.TipoCliente,
                            item.Telefono
                        );
                }

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var tipocliente = "";

            try
            {

                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Persona":
                        tipocliente = "Persona";
                        break;
                    case "Empresa":
                        tipocliente = "Empresa";
                        break;
                }

                if (buscarnumerodecliente(textBox3.Text))
                {
                    MessageBox.Show("Este numero de celular ya pertenece a un cliente");
                }
                else if (buscarnumerodeclienteeliminado(textBox3.Text))
                {
                    MessageBox.Show("Este numero de celular pertenece a un cliente eliminado, consulte al administrador");
                }
                else
                {

                    var nombre = textBox2.Text;
                    var TipoCliente = comboBox1.SelectedItem;
                    var telefono = textBox3.Text;

                    using (var cone = new PresupuestoEntities5())

                    {
                        DB.Cliente c = new DB.Cliente
                        {
                            Nombre = nombre,
                            Telefono = telefono,
                            Estado = 1,
                            TipoCliente = tipocliente

                        };
                        cone.Clientes.Add(c);
                        cone.SaveChanges();
                    }
                    dataGridView1.Rows.Clear();
                    llenarData();
                    this.textBox2.Text = string.Empty;
                    this.textBox3.Text = string.Empty;
                }

            }
            catch (Exception)
            {

             
            }
        }

        public bool buscarnumerodeclienteeliminado(string telefono)
        {
            using (var db = new PresupuestoEntities5())
            {
                var x="";
                foreach (var item in db.Clientes.Where(c=>c.Telefono==telefono).Where(c=>c.Estado==0))
                {
                    x = item.Telefono.ToString();
                }

                if (string.IsNullOrEmpty(x))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public bool buscarnumerodecliente(string telefono)
        {
            using (var db = new PresupuestoEntities5())
            {
                var x = "";
                foreach (var item in db.Clientes.Where(c => c.Telefono == telefono).Where(c => c.Estado == 1))
                {
                    x = item.Telefono.ToString();
                }

                if (string.IsNullOrEmpty(x))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox3.Text.ToString().Length == 10)
            {
                var x = Convert.ToInt64(textBox3.Text);
                var y = String.Format("{0:(###) ###-####}", x);
                textBox3.Text = Convert.ToString(y);
            }
            else
            {
                //Eror provider
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
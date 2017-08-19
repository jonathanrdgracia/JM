using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Proyecto.SubForms
{
    public partial class CantidadPresupuestada : Form
    {

        public CantidadPresupuestada()
        {
            InitializeComponent();
        }


       

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Proyecto.Nuevo c = new Proyecto.Nuevo();

               
                this.Close();

            }
            catch (Exception)
            {

                MessageBox.Show("Por favor intentelo de nuevo");
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CantidadPresupuestada_Load(object sender, EventArgs e)
        {

        }
    }
}

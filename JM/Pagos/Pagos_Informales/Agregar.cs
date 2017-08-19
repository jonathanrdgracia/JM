using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Pagos.Pagos_Informales
{
    public partial class Agregar : Form
    {
        public delegate void enviar(string dato);
        public event enviar enviado;

        public Agregar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            Nuevo_Pago_Informal c = new Nuevo_Pago_Informal();
           
        enviado(textBox1.Text);
        }
    }
}

using JM.Clientes;
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
    public partial class PresupuestoObras : Form
    {
        public PresupuestoObras()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListadoClientes2 c = new ListadoClientes2();
            c.enviado += new ListadoClientes2.enviar(ejecutar);
            c.ShowDialog();
        }
        private void ejecutar(string dato, string dato2, string dato3, string dato4)
        {
            textBox1.Text = dato;
            textBox2.Text = dato2;
            textBox5.Text = dato3;
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void PresupuestoObras_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

    }
}

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

        }
    }
}

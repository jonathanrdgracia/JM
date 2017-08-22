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

namespace JM.Pagos.Pagos_proyecto
{
    public partial class ModificarPago : Form
    {
        private string _pago;

        public string Pago
        {
            get { return _pago; }
            set { _pago = value; }
        }
        private int _idPago;

        public int IdPago
        {
            get { return _idPago; }
            set { _idPago = value; }
        }
        
        
        public ModificarPago()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var f = textBox8.Text;
                var a =Convert.ToInt32(f)*1;
                using (var db = new PresupuestoEntities5())
                {
                    var c = (from x in db.Pagoes
                             where x.Id == _idPago
                             select x).First();

                    c.Valor = f;
                    db.SaveChanges();
                    MessageBox.Show("Pago actualizado con exito");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Trate de ingresar el pago sin formato, ej: 500");
            }
        }

        private void ModificarPago_Load(object sender, EventArgs e)
        {
            textBox8.Text = _pago;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}

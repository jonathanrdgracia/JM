using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Pagos.Pagos_Informales
{
    public partial class Nuevo_Pago_Informal : Form
    {
        List<Pagos> ClienteyPago = new List<Pagos>(); 
         NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
          
        public Nuevo_Pago_Informal()
        {
            InitializeComponent();
        }

        private void Nuevo_Pago_Informal_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
          
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            nfi.CurrencyDecimalDigits = 2;
            ClienteyPago.Add(new Pagos
            {
                IdCliente=textBox4.Text,
                Nombre=textBox6.Text,
                Apellidos= textBox5.Text,
                valor=textBox3.Text,
                Concepto=textBox1.Text

            });

            dataGridView1.Rows.Clear();

            foreach (var item in ClienteyPago)
            {
                dataGridView1.Rows.Add
                    (
                        item.IdCliente.ToString(),
                        item.Nombre.ToString(),
                        item.Apellidos.ToString(),
                        item.Concepto.ToString(),
                        Convert.ToDouble(item.valor).ToString("C",nfi)
                    );
            }
            textBox4.Text="";
            textBox6.Text="";
            textBox5.Text="";
            textBox3.Text="";
            textBox1.Text = "";
       
        }

        private void ejecutar(string dato, string dato2)
        {
            textBox1.Text = dato;
            textBox3.Text = dato2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nuevo_pago_informal_concepto_listado a = new Nuevo_pago_informal_concepto_listado();
            
          
            a.enviado += new Nuevo_pago_informal_concepto_listado.enviar(ejecutar);

            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nuevo_pago_informal_cliente_pago n = new Nuevo_pago_informal_cliente_pago();


            n.enviado += new Nuevo_pago_informal_cliente_pago.enviar(ejecutar);
           


            n.ShowDialog();
        }

        private void ejecutar(int ID, string nombre, string apellido)
        {
            textBox4.Text = ID.ToString();
            textBox6.Text = nombre;
            textBox5.Text = apellido;
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

        private void button12_Click(object sender, EventArgs e)
        {
           
            var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var x2 = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            var x3 = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            var x4 = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dataGridView1.Rows.Clear();

            ClienteyPago.RemoveAll(c => c.IdCliente==x0);

            foreach (var item in ClienteyPago)
            {
                dataGridView1.Rows.Add
                    (
                 item.IdCliente,
                 item.Nombre,
                 item.Apellidos,
                 item.Concepto,
                 Convert.ToInt32(item.valor).ToString("C", nfi)
                 );
                
            }

        }
    }
}

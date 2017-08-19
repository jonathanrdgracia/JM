using JM.DB;
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
    public partial class Nuevo_pago_informal_concepto_listado : Form
    {
        
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                  

        public Nuevo_pago_informal_concepto_listado()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Nuevo_pago_informal_concepto_listado_Load(object sender, EventArgs e)
        {
            nfi.CurrencyDecimalDigits = 2;
            using (var db = new PresupuestoEntities5()) 
            {
                foreach (var item in db.Pago_Concepto)
                {
                    dataGridView1.Rows.Add(
                        item.Concepto.ToString(),
                        Convert.ToInt32(item.valor).ToString("C", nfi)
                    );

                }
            
            
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        public delegate void enviar(string dato, string dato2);
        public event enviar enviado;


        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            var query = "%"+textBox6.Text+"%";
            nfi.CurrencyDecimalDigits = 2;
            dataGridView1.Rows.Clear();
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.Filtrar_pago_concepto(query))
                {
                    dataGridView1.Rows.Add(
                        item.Concepto.ToString(),
                       Convert.ToInt32(item.valor).ToString("C",nfi)
                    );

                }


            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Nuevo_Pago_Informal c = new Nuevo_Pago_Informal();
            var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var x2 = x1.Substring(1, x1.Count() - 1);

            enviado(x0,x2);
            this.Close();
        }
    }
}

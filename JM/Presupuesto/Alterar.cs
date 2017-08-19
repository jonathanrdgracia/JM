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
using JM.DB;
namespace JM.Obra_Detalle
{
    public partial class Alterar : Form
    {
        public Alterar()
        {
            InitializeComponent();
        }
        List<Presupuestos> pres = new List<Presupuestos>();
        private void button2_Click(object sender, EventArgs e)
        {
            //var peso = Convert.ToDouble(moneybox.Text);
            //var diez = 0.10;
            //var residuo = 0.0;
            //using (var db = new PresupuestoEntities3())
            //{
            //       foreach (var item in db.Presupuestos_listado.OrderBy(c=>c.Precio))
            //            {
            //               pres.Add(new Presupuestos { 
            //                    Precio=item.Precio.ToString(),
            //                    Total=item.Total.ToString(),
            //                    Descripcion=item.Descripcion,
            //                    Unidad= item.Unidad,
            //                    Cantidad=item.Cantidad.ToString()
            //                });
                          
                            
            //            }
            //}


            //NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            //nfi.CurrencyDecimalDigits = 2;


            //dataGridView1.Rows.Add(
            //    pres.Select(c => c.Descripcion).Last().ToString(),
            //    pres.Select(c => c.Unidad).Last().ToString(),
            //   Convert.ToInt16(pres.Select(c => c.Precio).Last().ToString()).ToString("C", nfi),
            //   pres.Select(c => c.Cantidad).Last().ToString(),
            //   pres.Select(c => c.Total).Last().ToString()
            //);
        }

        private void descripcionbox_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}

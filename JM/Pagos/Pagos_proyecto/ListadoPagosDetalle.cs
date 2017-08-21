using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JM.DB;
using System.Windows.Forms;
using System.Globalization;

namespace JM.Pagos.Pagos_proyecto
{
    public partial class ListadoPagosDetalle : Form
    {
        public ListadoPagosDetalle()
        {
            InitializeComponent();
        }
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        private void ListadoPagosDetalle_Load(object sender, EventArgs e)
        {
           nfi.CurrencyDecimalDigits = 2;

            PresupuestoEntities5 db = new PresupuestoEntities5();
            var query = db.ListadoPagosPorProyectoDetalles(_id);
            
            foreach (var i in query)
            {
                this.dataGridView1.Rows.Add(
                    i.Id,
                    i.TipoEmpleado,
                    i.Nombre ,
                   i.Valor // Convert.ToInt32(i.Valor.ToString()).ToString("C", nfi)
                );
            }
            //ListadoPagosPorProyectoDetalle
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

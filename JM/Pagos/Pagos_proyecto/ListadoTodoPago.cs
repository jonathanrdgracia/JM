using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using JM.DB;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace JM.Pagos.Pagos_proyecto
{
    public partial class ListadoTodoPago : Form
    {
        public ListadoTodoPago()
        {
            InitializeComponent();
        }
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        
        private int Idproyecto;
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public int IdProyecto
        {
            get { return Idproyecto; }
            set { Idproyecto = value; }
        }
        
        private void ListadoTodoPago_Load(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {
                this.label4.Text = "Pagos relacionados al proyecto: " + Descripcion;
                var query = db.ListadoPagosPorProyecto(Idproyecto).OrderByDescending(c=>c.Fecha);

                foreach (var i in query.OrderByDescending(c=>c.Fecha))
                {
                    this.dataGridView1.Rows.Add
                        (
                            i.Id,
                             i.TipoEmpleado,
                            i.Nombre+" "+i.Apellidos,
                            i.Fecha,
                            Convert.ToInt32(i.Valor).ToString("C",nfi)
                        );
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verPagosDetalladosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               ListadoPagosDetalle l = new ListadoPagosDetalle();
                l.Id = IdProyecto;
                l.ShowDialog();

            }
            catch (Exception)
            {
                
              
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

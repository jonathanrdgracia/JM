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

namespace JM.Pagos.Pagos_proyecto
{
    public partial class ListadoPagosDetalle : Form
    {
        public ListadoPagosDetalle()
        {
            InitializeComponent();
        }
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        private void ListadoPagosDetalle_Load(object sender, EventArgs e)
        {
            PresupuestoEntities5 db = new PresupuestoEntities5();
            foreach (var i in db.ListadoPagosPorProyectoDetalle(5))
            {
                
            }
            //ListadoPagosPorProyectoDetalle
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

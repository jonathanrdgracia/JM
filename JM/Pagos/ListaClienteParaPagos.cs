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

namespace JM.Pagos
{
    public partial class ListaClienteParaPagos : Form
    {
        private int _idProyecto;

        public int IdProyecto
        {
            get { return _idProyecto; }
            set { _idProyecto = value; }
        }
        
        public ListaClienteParaPagos()
        {
            InitializeComponent();
        }

        private void ListaClienteParaPagos_Load(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {

                foreach (var i in db.SP_ModificarProyecto(_idProyecto))
                {
                    dataGridView4.Rows.Add
                    (
                    i.IdEmpleado,
                    i.Nombre + " " + i.Apellidos,
                    i.Telefono,
                    i.TipoEmpleado
                    );
                }

            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var x0 = this.dataGridView4.CurrentRow.Cells[0].Value.ToString();
            var x1 = this.dataGridView4.CurrentRow.Cells[1].Value.ToString();
            var x3 = this.dataGridView4.CurrentRow.Cells[3].Value.ToString();
            enviado(x0,x1,x3);
            this.Close();
        }
        public delegate void enviar(string dato,string dato2,string dato3);
        public event enviar enviado;

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            var query = "%" + textBox14.Text + "%";
            this.dataGridView4.Rows.Clear();
            using (var db = new PresupuestoEntities5())
            {
                foreach (var i in db.SP_ModificarProyectoFiltro(_idProyecto, query))
                {
                    this.dataGridView4.Rows.Add
                        (
                        i.IdEmpleado,
                        i.Nombre+" "+i.Apellidos,
                        i.Telefono,
                        i.TipoEmpleado

                        );

                }
            }
        }

        private void textBox14_KeyUp(object sender, KeyEventArgs e)
        {
            var query = "%" + textBox14.Text + "%";
            this.dataGridView4.Rows.Clear();
            using (var db = new PresupuestoEntities5())
            {
                foreach (var i in db.SP_ModificarProyectoFiltro(_idProyecto, query))
                {
                    this.dataGridView4.Rows.Add
                        (
                        i.IdEmpleado,
                        i.Nombre + " " + i.Apellidos,
                        i.Telefono,
                        i.TipoEmpleado

                        );

                }
            }
        }
    }
}

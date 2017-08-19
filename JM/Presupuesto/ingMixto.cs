using JM.DB;
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
    public partial class ingMixto : Form
    {
        public ingMixto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
        private void button13_Click(object sender, EventArgs e)
        {
          
                var Id = Convert.ToInt32(this.dataGridView4.CurrentRow.Cells[0].Value.ToString());
                var Nombre = this.dataGridView4.CurrentRow.Cells[1].Value.ToString();
                var Telefono = this.dataGridView4.CurrentRow.Cells[2].Value.ToString();
                var Ocupaion = this.dataGridView4.CurrentRow.Cells[3].Value.ToString();



                enviado(Id, Nombre, Telefono, Ocupaion);
           
        }

        public delegate void enviar(int id, string nombre, string telefono, string ocupacion);
        public event enviar enviado;
        private void ingMixto_Load(object sender, EventArgs e)
        {
               using (var db = new PresupuestoEntities5())
            {
                var query = from t1 in db.Abonadoes
                            join t2 in db.TipoEmpleadoes on t1.IdTipoEmpleado equals t2.IdTipoEmpleado
                            where t2.Tipo == "Ingeniero" || t2.Tipo == "Maestro" || t2.Tipo == "Arguitecto(a)"
                            select new { t1.Id, t1.Nombre, t1.Apellidos, t1.Telefono, t2.Tipo };

                foreach (var item in query)
                {
                    dataGridView4.Rows.Add(

                        item.Id,
                        item.Nombre + " " + item.Apellidos,
                        item.Telefono,
                        item.Tipo
                        );
                }
                }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

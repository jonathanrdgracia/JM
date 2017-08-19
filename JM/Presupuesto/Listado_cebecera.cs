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
using JM.Obra_Detalle;
using JM.Presupuesto;
using System.Globalization;

namespace JM.Obra_Detalle
{
    public partial class Listado_cebecera : Form
    {
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public Listado_cebecera()
        {
            InitializeComponent();
        }

        private void Listado_cebecera_Load(object sender, EventArgs e)
        {
            List<Presupuesto_materiales> ambos = new List<Presupuesto_materiales>();

           // var id_presupuesto = 0;//el id del presupuesto, con esto puedo actualizar luego
            using (var context = new PresupuestoEntities5())
            {

               

                foreach (var item in context.View_CabeceraAmbos.OrderByDescending(c=>c.IdPresupuestos))
                {

                    dataGridView1.Rows.Add(
                        item.IdPresupuestos.ToString(),
                        item.Comentario,
                        item.Direccion,
                        item.Nombre+" " +item.Apellido,
                        item.Telefono,
                        item.Fecha,
                        (Convert.ToInt32(item.TotalMateriales) + Convert.ToInt32(item.TotalObra)).ToString()
                        );

                    //dataGridView1.Rows[0].Cells[0].Value = Convert.ToString(item.Descripcion);
                    //dataGridView1.Rows[0].Cells[1].Value = Convert.ToString(item.Direccion);
                    //dataGridView1.Rows[0].Cells[2].Value = Convert.ToString(item.Cliente);
                    //dataGridView1.Rows[0].Cells[3].Value = Convert.ToString(item.Telefono);
                    //dataGridView1.Rows[0].Cells[4].Value = Convert.ToString(item.Fecha_presupuesto);
                    //dataGridView1.Rows[0].Cells[5].Value = Convert.ToString(item.Total);

                }
            }
        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
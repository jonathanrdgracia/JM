using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using JM.DB;
using System.Threading.Tasks;
using System.Windows.Forms;
using JM.Modificar;

namespace JM.Borrar_abonado
{
    public partial class BorrarAbonado : Form
    {
        int id = 0;
        Abonados a = new Abonados();
        
        public BorrarAbonado()
        {
            InitializeComponent();
        }

        private void BorrarAbonado_Load(object sender, EventArgs e)
        {

            a.llenarAbonado(dataGridView1);
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.Rows.Clear();
               var x = "%" + textBox6.Text + "%";
               using (var db = new PresupuestoEntities5())
            {
           
                foreach (var item in db.Filtrar_Abonado(x).OrderByDescending(c=>c.Id))
	                {
		                dataGridView1.Rows.Add
                            (
                            item.Id,
                            item.Nombre,
                            item.Apellidos,
                            item.Telefono,
                            item.TipoEmpleado,
                            item.Fecha_inscripcion,
                            item.Lugar
                            );
	                }
            
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
              
                id = Convert.ToInt32(x0);
               
              
                    DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar este cliente?", "Eliminar cliente", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        using (var db = new PresupuestoEntities5())
                        {

                              var  c = (from x in db.Abonadoes
                                     where x.Id == id
                                     select x).First();

                              c.Estado = 0;
                              db.SaveChanges();
                              MessageBox.Show("Empleado borrado exitosamente");

                              dataGridView1.Rows.Clear();
                              a.llenarAbonado(dataGridView1);


                        }
                     
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        
                    }
                
                


            }
            catch (Exception)
            {

                MessageBox.Show("Vuelva a intentarlo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

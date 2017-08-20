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

namespace JM.Pagos.Pagos_proyecto
{
    public partial class Nuevo_pago_proyecto : Form
    {
        PagoProyectoClass ppc = new PagoProyectoClass();
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public Nuevo_pago_proyecto()
        {
            InitializeComponent();
        }
        private int idProyecto;

        public int IdProyecto
        {
            get { return idProyecto; }
            set { idProyecto = value; }
        }
        
        private void Nuevo_pago_proyecto_Load(object sender, EventArgs e)
        {
            nfi.CurrencyDecimalDigits = 2;
          //  Convert.ToInt32(textBox7.Text).ToString("C",nfi);

            using (var db = new PresupuestoEntities5())
            {
                DB.ProyectoConPresupuesto todo = (from c in db.ProyectoConPresupuestoes
                                                    where c.IdProyecto==idProyecto
                                                    select c).First();

                textBox7.Text =Convert.ToInt32(todo.CantidadPresupuestada).ToString("C",nfi);
                textBox1.Text = todo.Descripcion;
                textBox2.Text = todo.Direccion;

                var query = db.SP_ModificarProyecto(idProyecto);

                foreach (var i in query)
                {
                    dataGridView1.Rows.Add
                        (
                            i.IdEmpleado,
                            i.Nombre,
                            i.Telefono,
                            i.TipoEmpleado,
                            i.direcccionempleado
                            
                            
                        );
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5()) 
            {

               

                
                   
                    DB.PagoMaestro p = new DB.PagoMaestro
                    {
                        Idproyecto = idProyecto
                    };

                    db.PagoMaestroes.Add(p);
                    db.SaveChanges();


                    var IdPagoMaestro = db.PagoMaestroes.Where(c => c.Idproyecto == idProyecto).Select(c => c.id).FirstOrDefault();

                    
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        var id = Convert.ToInt32(row.Cells[0].Value.ToString());

                       // DB.PagoDetalle PD = new PagoDetalle 
                       //{ IdPagoMaestro = IdPagoMaestro, 
                       //     IdEmpleado = id 
                       // };

                       // MessageBox.Show(" id del pago maestro "+IdPagoMaestro.ToString() + " :  empleado " + id.ToString());
                        //db.PagoDetalles.Add(PD);
                        //db.SaveChanges();
                    }


                    DB.ProyectoConPresupuesto pp_ = (from c in db.ProyectoConPresupuestoes
                                                     where c.IdProyecto == idProyecto
                                                     select c).First();
                    pp_.Estado = 2;
                    db.SaveChanges();
              

            }
        }
    }
}

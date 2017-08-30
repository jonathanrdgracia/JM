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
using JM.Clientes;

namespace JM.Proyecto
{
    public partial class ModificarProyecto : Form
    {
        public string Nombtre { get; set; }
        public string Telefono { get; set; }
        List<DB.Abonado> ListadoEmpleado = new List<DB.Abonado>();
        private List<DB.Abonado> ListadoEmpleado2 = new List<DB.Abonado>();
        public ModificarProyecto()
        {
            InitializeComponent();
        }
        private int idProyecto;
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public int IdProtecto
        {
            get { return idProyecto; }
            set { idProyecto = value; }
        }
        
        private void ModificarProyecto_Load(object sender, EventArgs e)
        {
          
            
            nfi.CurrencyDecimalDigits = 2;
            
            using(var db = new PresupuestoEntities5())
            {
                    var query = db.SP_ModificarProyectoCliente(idProyecto).FirstOrDefault();
                    Nombtre = query.Nombre;
                    Telefono = query.Telefono;
                    
                    
                    textBox3.Text = Nombtre;
                    textBox4.Text = Telefono;
                    foreach (var i in db.SP_ModificarProyecto(idProyecto))
                    {
                        textBox1.Text = i.DescripcionProyecto;
                        textBox7.Text = i.CantidadPresupuestada.ToString();
                        textBox2.Text = i.Direccion;
                        ListadoEmpleado.Add(new DB.Abonado
                        {
                            Id = i.IdEmpleado,
                            Nombre = i.Nombre,
                            Telefono = i.Telefono,
                            TipoEmpleado = i.TipoEmpleado,
                            Lugar = i.direcccionempleado
                        });
                    }

                    overCargar(ListadoEmpleado);
              

            }
        }

        private void overCargar(List<DB.Abonado> ListadoEmpleado)
        {
            foreach (var i in ListadoEmpleado)
            {

                this.dataGridView1.Rows.Add
                    (
                        i.Id,
                        i.Nombre+" "+i.Apellidos,
                        i.Telefono,
                        i.TipoEmpleado,
                        i.Lugar
                    );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

            ListadoCliente4 c = new ListadoCliente4();

            c.enviado += new ListadoCliente4.enviar(ejecutar);
            c.ShowDialog();
        }
        private void ejecutar(string id, string dato, string dato2, string dato3,string dato4)
        {
            int a = Convert.ToInt32(id);
            dataGridView1.Rows.Clear();
            ListadoEmpleado.Add(new DB.Abonado
            {
                Id = a,
                Nombre =dato,
                Telefono =dato3,
                TipoEmpleado = dato2,
                Lugar = dato4
            });

         
            foreach (var i in ListadoEmpleado)
            {

                this.dataGridView1.Rows.Add
                    (
                        i.Id,
                        i.Nombre,
                        i.Telefono,
                        i.TipoEmpleado,
                        i.Lugar
                    );
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                
                 DB.ProyectoConPresupuesto PP;
                DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas modificar este proyecto?", "Proyecto", MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.Yes)
                 {
                     int cantidad = Convert.ToInt32(textBox7.Text);
                     using (var db = new PresupuestoEntities5())
                     {
                         PP = (from c in db.ProyectoConPresupuestoes
                             where c.IdProyecto == idProyecto
                             select c).First();

                         PP.Descripcion = textBox1.Text;
                         PP.Direccion = textBox2.Text;
                         PP.CantidadPresupuestada = cantidad;
                         db.SaveChanges();


                         foreach (var i in ListadoEmpleado)//Agrego empleado
                         {
                             DB.Proyecto_detalle PD = new Proyecto_detalle
                             {
                                 IdEmpleado = i.Id,
                                 IdProyecto = idProyecto,
                                 Estado = 1
                             };
                             db.Proyecto_detalle.Add(PD);
                             db.SaveChanges();
                         }

                         foreach (var i in ListadoEmpleado2)//de esta menera paso todos los empleados 'eliminados' a un estado 0
                         {
                             db.EstadoCero(IdProtecto, i.Id);
                         }
                     }
                     MessageBox.Show("Proyecto modificado con exito");
                     this.Close();

                 }
                 else if (dialogResult == DialogResult.No)
                 {

                 }

            }
            catch (Exception es)
            {

                MessageBox.Show(es.Message);
            }
            
           
            
         }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                   DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas eliminar este empleado del proyecto?", "Proyecto", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                      

                       
                        var x0 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        int currentIndex = this.dataGridView1.CurrentCell.RowIndex;
                        ListadoEmpleado2.Add(new DB.Abonado
                        {
                            Id = x0
                        });

                        foreach (var i in ListadoEmpleado2)
                        {
                            MessageBox.Show("eliminados: " + i.Id);
                        }
                        dataGridView1.Rows.Clear();
                        ListadoEmpleado.RemoveAt(currentIndex);

                   
                    //    using (var db = new PresupuestoEntities5())
                    //    {
                    //        var de = (from c in db.Proyecto_detalle
                    //                  where c.IdEmpleado == x0  && c.IdProyecto==IdProtecto orderby c.IdProyectoDetalle descending 
                    //                  select c).First();
                            
                    //        de.Estado = 0;
                    //        db.SaveChanges();
                    //    }
                    //    MessageBox.Show("Empleado eliminado con exito");
                    //    this.Close();




                        foreach (var i in ListadoEmpleado)
                        {
                           
                            this.dataGridView1.Rows.Add
                               (
                               i.Id,
                               i.Nombre,
                               i.Telefono,
                               i.TipoEmpleado,
                               i.Lugar
                               );
                        }


                      
                       
                      

                    }
                    catch (Exception g)
                    {

                        MessageBox.Show(g.Message);
                    }
                  
                }
                else
                {

                }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

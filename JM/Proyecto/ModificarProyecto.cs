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
        List<DB.Abonado> ListadoEmpleado2 = new List<DB.Abonado>();
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
                        i.Nombre,
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
            ListadoEmpleado2.Add(new DB.Abonado
            {
                Id = a,
                Nombre =dato,
                Telefono =dato3,
                TipoEmpleado = dato2,
                Lugar = dato4
            });

            foreach (var i in ListadoEmpleado2)
            {
                dataGridView1.Rows.Add(
                    i.Id,
                    i.Nombre,
                    i.Telefono,
                    i.TipoEmpleado,
                    i.Lugar
                    );
            }
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
                     using (var db = new PresupuestoEntities5())
                     {
                         PP = (from c in db.ProyectoConPresupuestoes
                             where c.IdProyecto == idProyecto
                             select c).First();

                         PP.Descripcion = textBox1.Text;
                         PP.Direccion = textBox2.Text;
                         db.SaveChanges();


                         foreach (var i in ListadoEmpleado2)
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
                    var x0 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    try
                    {
                        using (var db = new PresupuestoEntities5())
                        {
                            var de = (from c in db.Proyecto_detalle
                                      where c.IdEmpleado == x0  && c.IdProyecto==IdProtecto
                                      select c).First();
                            de.Estado = 0;
                            db.SaveChanges();
                        }
                        MessageBox.Show("Empleado eliminado con exito");
                        this.Close();
                    }
                    catch (Exception)
                    {
                        foreach (var i in ListadoEmpleado2)
                        {
                            ListadoEmpleado2.RemoveAll(c => c.Id == x0);
                            this.dataGridView1.Rows.Add
                               (
                               i.Id,
                               i.Nombre,
                               i.Telefono,
                               i.TipoEmpleado,
                               i.Lugar
                               );
                        }
                        dataGridView1.Rows.Clear();
                        MessageBox.Show("Empleado eliminado con exito");
                        this.Close();
                       
                    }
                  
                }
                else
                {

                }
            }
        }
    }
}

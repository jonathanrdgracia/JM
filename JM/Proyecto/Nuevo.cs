using JM.Proyecto.SubForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using JM.DB;
using JM.Clientes;
using System.Threading.Tasks;
using System.Windows.Forms;
using JM.Cliente;

namespace JM.Proyecto
{
    public partial class Nuevo : Form
    {
        public Nuevo()
        {
            InitializeComponent();
        }
        List<DB.Abonado> empleados = new List<DB.Abonado>();
        List<DB.Abonado> empleadosId = new List<DB.Abonado>();
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public int valor { get; set; }
        public int IDCliente { get; set; }
        public int IdProyecto { get; set; }
        public int IdPresupuesto { get; set; }
        public int Cantidad { get; set; }
        public string f { get; set; }
        private void Nuevo_Load(object sender, EventArgs e)
        {

            using (var db = new PresupuestoEntities5())
            {

              
              
            }

            
            
        }
        private void ejecutar(List<DB.Abonado> lista)
        {
            foreach (var item in lista)
            {
                this.dataGridView1.Rows.Add
                    (
                    item.Id,
                    item.Nombre,
                    item.Apellidos,
                    item.Telefono,
                    item.Lugar
                    
                    );
            }
        }


        private void button13_Click(object sender, EventArgs e)
        {
           

        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            SubForms.CantidadPresupuestada c = new SubForms.CantidadPresupuestada();
          
            c.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SubForms.ListarEmpleados c = new SubForms.ListarEmpleados();
            c.enviado += new SubForms.ListarEmpleados.enviar(ejecutar);
            c.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Todos los campos son requeridos", "Campos vacios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if (this.dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Debes seleccionar al menos un empleado", "Listado vacio",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                try
                {
                    f = Fecha();
                    var descripcion = textBox1.Text;
                    var direccion = textBox2.Text;



                    using (var db = new PresupuestoEntities5()) //para devolver el ID del proyecto en IdProyecto
                    {
                        db.GuardarProyecto(IdPresupuesto, Cantidad, direccion, descripcion, f, 1);
                        db.SaveChanges(); //Guardo la cabecera del proyecto


                        /*Busco el id del proyecto*/
                            IdProyecto = db.ProyectoConPresupuestoes.Where(c => c.Descripcion == descripcion).
                            Where(c => c.Direccion == direccion).
                            Where(c => c.CantidadPresupuestada == Cantidad).
                            Where(c => c.FechaCreacion == f).Select(x => x.IdProyecto).FirstOrDefault();

                        /**/

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {


                            DB.Proyecto_detalle Py = new Proyecto_detalle
                            {

                                IdEmpleado = Convert.ToInt32(row.Cells[0].Value.ToString()),
                                IdProyecto =IdProyecto,
                                Estado = 1
                            };

                            db.Proyecto_detalle.Add(Py);
                            db.SaveChanges();

                        }

                        /*Pasa el presupuesto a estado=2 (ya tiene folder de pago)*/
                        DB.Presupuesto p = new DB.Presupuesto();
                        p = (from c in db.Presupuestos
                            where c.IdPresupuestos == this.IdPresupuesto
                            select c).First();
                        p.Estado = 2;
                        db.SaveChanges();
                    }
                    MessageBox.Show("Proyecto agregado con exito");
                    this.Close();


                }
                catch (Exception)
                {


                }
            }
            /**/ 
            



            //for (int i = 0; i < this.dataGridView1.Rows.Count; i++)// cogo directamente los id's del datagrdview
            //{
            //    var agrego = dataGridView1.Rows[i].Cells[0].Value.ToString();// despues lo asigno a 'agrego'
            //    var numero = agrego.Length - 2;// cogo la longuitud y le resto 2(porque manualmente asigne los '00' antes de los id's reales)
            //    var x =Convert.ToInt32(agrego.Substring(2, numero));//selecciono todo menos los '00' que estan alante
            //    db.SP_ProyectoDetalleSinPresupuesto(x, IdProyecto);

            //}
            // db.SP_ProyectoDetalleSinPresupuesto(IDCliente,IdProyecto);




        }

        private void llenar()
        {

            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                var agrego = dataGridView1.Rows[i].Cells[0].Value.ToString();
                var numero = agrego.Length-2;
                var x=agrego.Substring(2,numero);

               
            }
        }

     

     

        private string Fecha()
        {
            return Convert.ToString(DateTime.Now.ToString("d/M/yyyy"));
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
                SubForms.ListarCliente c = new SubForms.ListarCliente();
                c.enviado += new ListarCliente.enviar(ejecutar3);
            c.enviadoEmpleado += new SubForms.ListarCliente.enviarEmpleado(EjecutarEmpleado);
            c.ShowDialog();


        }

        private void EjecutarEmpleado(List<EmpleadosEx> lista)
        {
            try
            {
                using (var db = new PresupuestoEntities5())
                {
                   Cantidad = Convert.ToInt32(
                        (from c in db.Presupuestos where c.IdPresupuestos == IdPresupuesto select c.TotalGeneral)
                            .FirstOrDefault());

                    textBox7.Text = Cantidad.ToString("C", nfi);
                }

                dataGridView1.Rows.Clear();
                foreach (var i in lista)
                {

                    dataGridView1.Rows.Add
                        (
                        i.Id,
                        i.Nombtre + " " + i.Apellido,
                        i.Telefono,
                        i.Tipo,
                        i.Dirrecion
                        );
                }

            }
            catch (Exception esException)
            {

                MessageBox.Show("Ha ocurrido un error: " + esException.Message);
            }
        }

        private void ejecutar3(string dato, string dato2, string dato3, string dato4, string dato5,string dato7)
        {
            try
            {
                using (var db = new PresupuestoEntities5())
                {
                    var query = Convert.ToInt32(
                        (from c in db.Presupuestos where c.IdPresupuestos == IdPresupuesto select c.TotalGeneral)
                            .FirstOrDefault());


                    textBox1.Text = dato2;
                    textBox3.Text = dato3;
                    textBox2.Text = dato5;
                    textBox4.Text = dato4;
                    textBox7.Text = query.ToString("C",nfi);
                    IdPresupuesto = Convert.ToInt32(dato);

                }

            }
            catch (Exception esException)
            {

                MessageBox.Show("Ha ocurrido un error: " + esException.Message);
            }


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoCliente n = new NuevoCliente();
            n.ShowDialog();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Reportes._1 s = new Reportes._1();

            s.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
               
                
                try
                {
                    int currentIndex = this.dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(currentIndex);

            }
            catch (NullReferenceException)
            {

            }
            catch (Exception)
            {

               
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

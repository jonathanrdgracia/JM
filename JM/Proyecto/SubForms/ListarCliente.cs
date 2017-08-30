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

namespace JM.Proyecto.SubForms
{
    
    public partial class ListarCliente : Form
    {
        private List<Detalle> ListaObra = new List<Detalle>();
        private int IdPresupuesto { get; set; }
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;  
        public ListarCliente()
        {
            InitializeComponent();
        }

        private void ListarCliente_Load(object sender, EventArgs e)
        {
            nfi.CurrencyDecimalDigits = 2;
            LLenarDa(this.dataGridView1);
        }

        private void LLenarDa(DataGridView dataGridView1)
        {
            using (var db = new PresupuestoEntities5())
            {
                foreach (var i in db.Vista_ListadoPresupuestoObra.OrderByDescending(c=>c.IdPresupuestos))
                {
                    ListaObra.Add(new Detalle {
                        IdPresupuestos=i.IdPresupuestos,
                        Descripcion=i.Descripcion,
                        Nombre=i.Nombre,
                        TipoCliente=i.TipoCliente,
                        Telefono=i.Telefono,
                        FechaCreacion=i.FechaCreacion,
                      
                        Direccion = i.Direccion
                        
                       
                    });
                }
                foreach (var i in db.Vista_ListadoPresupuestoMateriales.OrderByDescending(c => c.IdPresupuestos))
                {
                    ListaObra.Add(new Detalle
                    {
                        IdPresupuestos = i.IdPresupuestos,
                        Descripcion = i.Descripcion,
                        Nombre = i.Nombre,
                        TipoCliente = i.TipoCliente,
                        Telefono = i.Telefono,
                        FechaCreacion = i.FechaCreacion,
                        Total = Convert.ToInt32(i.Total),
                        Direccion = i.Direccion
                    });
                }

            }
            /* foreach (var i in ListaObra.GroupBy(c=>c.IdPresupuestos).
                Select(c=>c.First()))*/

            foreach (var i in ListaObra.GroupBy(c => c.IdPresupuestos).
                 Select(c => c.First()).OrderByDescending(c=>c.IdPresupuestos))
            {
                dataGridView1.Rows.Add(
                    i.IdPresupuestos,
                    i.Descripcion,
                    i.Nombre,
                    i.TipoCliente,
                    i.Telefono,
                    i.FechaCreacion,
                 
                    i.Direccion
                    );
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public delegate void enviar(string dato, string dato2,string dato3,string string4,string dato5,string dato7);
        public event enviar enviado;

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    List<DB.Cliente> cliente = new List<DB.Cliente>();
        //    var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
        //    var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
        //    var x2 = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
        //    var x3 = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

        //    cliente.Add(new DB.Cliente
        //    {
        //        id=Convert.ToInt32(x0),
        //        Nombre=x1,
        //        Apellido=x2,
        //        Telefono=x3

        //    });
        //    Proyecto.Nuevo c = new Proyecto.Nuevo();
        //    enviado(cliente);
        //    this.Close();


        //}
        public delegate void enviarEmpleado(List<EmpleadosEx> lista);
        public event enviarEmpleado enviadoEmpleado;

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
                List<String> ListadoPresupuestoDeMateriales = new List<String>();
                var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                var x2 = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                var x3 = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                var x4 = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                  var x7 = "";




            Proyecto.Nuevo c = new Proyecto.Nuevo();
                enviado(x0, x1, x2, x3, x4,x7);


            using (var db = new PresupuestoEntities5())
            {
                List<EmpleadosEx> l = new List<EmpleadosEx>();
                int _id =Convert.ToInt32(x0);
                var query = from t1 in db.Abonadoes
                            join t2 in db.EmpleadoPresupuestoes
                            on t1.Id equals t2.IdEmpleado
                            where t2.IdPresupuesto == _id
                            select new { t1.Nombre, t1.Apellidos,t1.Id,t1.Lugar, t1.Telefono,t1.TipoEmpleado};



                foreach (var i in query)
                {
                    l.Add(new EmpleadosEx {
                        Id=i.Id,
                        Nombtre=i.Nombre,
                        Apellido=i.Apellidos,
                        Dirrecion=i.Lugar,
                        Telefono=i.Telefono,
                        Tipo=i.TipoEmpleado
                    });
                }


                enviadoEmpleado(l);
                this.Close();

            }
           
        }
        
    }

    public class Detalle
    {
        public int IdPresupuestos { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string TipoCliente { get; set; }
        public string Telefono { get; set; }
        public string FechaCreacion { get; set; }
        public int Total { get; set; }
        public string Direccion { get; set; }

    }
    public class EmpleadosEx
    {
        public int Id { get; set; }
        public string Nombtre { get; set; }
        public string Tipo { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Dirrecion { get; set; }
    }
}

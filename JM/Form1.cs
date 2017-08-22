using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using JM.DB;
using JM.Cliente;
using JM.Obra_Detalle;
using JM.Modificar;
using JM.Presupuesto;
using JM.Borrar_abonado;
using JM.ConceptoDePagos;
using JM.Pagos.Pagos_Informales;
using JM.Proyecto;
using JM.Unidad;
using JM.Clientes;
using JM.Empresa;
using JM.Pagos.Pagos_proyecto;
using JM.Pagos;
using JM.usuario;
namespace JM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
         //   dataGridView1.Columns[0].FillWeight = 200;
        }
        PresupuestoEntities5 dbcontext = new PresupuestoEntities5();
        List<Presupuestos> PREs = new List<Presupuestos>();
        private void button1_Click(object sender, EventArgs e)
        {
            //var d = Convert.ToDouble(textBox1.Text);
            //var x = Math.Ceiling(d);
            //MessageBox.Show(x.ToString());

           
           
           
            

            

          


            //dataGridView1.DataSource = PREs.ToList();
           
            

           
        }

        private void preciobox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
              
            {
                foreach (var item in PREs)
                {
                    //db.Presupuestos_listado.Add(new Presupuestos_listado
                    //{
                    //    Descripcion = item.Descripcion.ToString(),
                    //    Precio = Convert.ToInt16(item.Precio.ToString())
                        
                    //});

                    db.SaveChanges();


                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            ListadoClientes nuevo = new ListadoClientes();


           
            
            
            nuevo.Show();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Center c = new Center();
            c.Show();
        }

        private void nuevoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Center c = new Center();
            c.ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoCliente n = new NuevoCliente();
            n.ShowDialog();
        }

        private void listarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarClientes l = new ListarClientes();
            l.ShowDialog();
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ambosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mixto_Detalle l = new Mixto_Detalle();
            l.TIPO = 2;
            l.ShowDialog();
            
        }

        private void materialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Obras_Detalle o = new Obras_Detalle();
            o.TIPO = 1;
            o.ShowDialog();
        }

        private void manosDeObraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materiales_Detalle m = new Materiales_Detalle();
            m.TIPO = 1;
            m.ShowDialog();

            
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void listarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarClientes l = new ListarClientes();
            l.ShowDialog();
        }

        private void realizarPrespuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void nuevoAbonadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
     
            EditarParametro para = new EditarParametro();
            using (PresupuestoEntities5 db = new PresupuestoEntities5())
            {
               
                var query = (from c in db.Companias
                            
                             select new { c.Nombre, c.Telefono, c.RNC, c.Logo,c.Direccion }).FirstOrDefault();

                label1.Text="Compañia: "+query.Nombre;
                label3.Text = "Telefono: " + query.Telefono;
                label2.Text = "RNC: " + query.RNC;
                label4.Text = "Direccion: " + query.Direccion;
                pictureBox1.Image = para.ConvertBinaryToImage(query.Logo);

            }

           
        }

        private void modificarAbonadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void eliminarAbonadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void controlDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void agregarNuevoConceptoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pagos.Pagos_proyecto.ListadoPagoProyecto l = new Pagos.Pagos_proyecto.ListadoPagoProyecto();
            l.ShowDialog();
        }

        private void modificarConceptoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificar_concepto m = new Modificar_concepto();
            m.ShowDialog();
        }

        private void directoAlEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void realizarNuevoPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Nuevo_pago_proyecto n = new Nuevo_pago_proyecto();
            ListaProyecto n = new ListaProyecto();
            n.ShowDialog();
        }

        private void porProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pagos.ListadoFolder l = new Pagos.ListadoFolder();
            l.ShowDialog();
        }

        private void agregarNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proyecto.Nuevo p = new Proyecto.Nuevo();
            p.ShowDialog();
        }

        private void reaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pagos.ListadoFolder l = new Pagos.ListadoFolder();
            l.ShowDialog();
        }

        private void listarProyectosActivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaProyecto l = new ListaProyecto();
            l.Show();
            
        }

        private void agregarUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarUnidad a  = new AgregarUnidad();
            a.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrarUnidad b = new BorrarUnidad();
            b.ShowDialog();
        }

        private void presupuestoDeMaterialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresupuestoMateriales p = new PresupuestoMateriales();
            p.RAZON = 1;
            p.ShowDialog();
        }

        private void modificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarCliente n = new ModificarCliente();
            n.Show();
        }

        private void agregarNuevaCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unidad.ModificarUnidad m = new ModificarUnidad();
            m.ShowDialog();
        }

        private void eliminarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes.EliminarCliente ee = new Clientes.EliminarCliente();
            ee.ShowDialog();
        }

        private void modificarParametrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarParametro ed = new EditarParametro();
            ed.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaProyecto l = new ListaProyecto();
            l.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BackupDB.Back b = new BackupDB.Back();
            b.ShowDialog();
        }

        private void crearFolderDePagoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrearFolderPago l = new CrearFolderPago();

            l.ShowDialog();
        }

        private void verTodosLosPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoTodoPagoProyecto l = new ListadoTodoPagoProyecto();
            l.ShowDialog();
        }

        private void presupuestoDeManoDeObraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresupuestoMateriales p = new PresupuestoMateriales();
            p.RAZON = 2;
            p.ShowDialog();
        }

        private void presupuestoMixtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mixto v = new Mixto();
            v.ShowDialog();
        }

        private void manoDeObraToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void proyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User v = new User();
            v.ShowDialog();
        }

        private void proyectosInactivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opciones.Proyecto p = new Opciones.Proyecto();
            p.ShowDialog();
        }

        private void borradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opciones.Empleados op = new Opciones.Empleados();
            op.ShowDialog();
        }

        private void eliminadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opciones.Clientes op = new Opciones.Clientes();
            op.ShowDialog();
        }

        private void modificarUsuarioYContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario.User a = new usuario.User();
            a.ShowDialog();
        }

        private void agregarNuevaCategoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Abonado.Tipo.AgregarNuevo a = new Abonado.Tipo.AgregarNuevo();
            a.ShowDialog();
        }

        private void registrarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuevo_Abonado d = new Nuevo_Abonado();
            d.ShowDialog();
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Modificar_abonado m = new Modificar_abonado();
            m.ShowDialog();
        }

        private void eliminarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrarAbonado b = new BorrarAbonado();
            b.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
    }
}

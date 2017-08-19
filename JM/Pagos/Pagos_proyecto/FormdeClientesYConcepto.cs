using JM.Pagos.Pagos_Informales;
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

namespace JM.Pagos.Pagos_proyecto
{
    public partial class FormdeClientesYConcepto : Form
    {
        PagoProyectoClass ppc = new PagoProyectoClass();
        Nuevo_pago_proyecto n = new Nuevo_pago_proyecto();
       // ListadoPagoProyecto n = new ListadoPagoProyecto();
        public FormdeClientesYConcepto()
        {
            InitializeComponent();
        }

        private void ejecutar(string dato, string dato2)
        {
            textBox1.Text = dato;
            textBox3.Text = dato2;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Nuevo_pago_informal_concepto_listado c = new Nuevo_pago_informal_concepto_listado();



            c.enviado += new Nuevo_pago_informal_concepto_listado.enviar(ejecutar);
            c.ShowDialog();


        }

        private void FormdeClientesYConcepto_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ppc.IdProyecto);
            using (var db = new PresupuestoEntities5()) 
            {
                foreach (var item in db.SP_ListaEmpleadosAsignados(id))
                {
                    this.dataGridView1.Rows.Add
                        (
                            item.Id,
                            item.Nombre
                           
                        );
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

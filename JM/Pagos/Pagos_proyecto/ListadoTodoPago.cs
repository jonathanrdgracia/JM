using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using JM.DB;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace JM.Pagos.Pagos_proyecto
{
    public partial class ListadoTodoPago : Form
    {
        public ListadoTodoPago()
        {
            InitializeComponent();
        }
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        
        private int Idproyecto;
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public int IdProyecto
        {
            get { return Idproyecto; }
            set { Idproyecto = value; }
        }
        
        private void ListadoTodoPago_Load(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";
                dateTimePicker1.Value = DateTime.Now;

                dateTimePicker3.Format = DateTimePickerFormat.Custom;
                dateTimePicker3.CustomFormat = "MMMM-yyyy";
                dateTimePicker3.Value = DateTime.Now;

                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = "dd-MM-yyyy";
                dateTimePicker2.Value = DateTime.Now;

                var dateTime = (from c in db.Pagoes where c.IdProyecto == Idproyecto orderby c.Fecha  select c.Fecha).First();
                if (dateTime != null)
                {
                    dateTimePicker1.Value = (DateTime) dateTime;
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Now;
                }
                this.label4.Text = "Pagos relacionados al proyecto: " + Descripcion;
                var query2 = db.ListadoPagosPorProyectoDetalles(Idproyecto);
                var query = db.Listado_PagosPorProyectos(Idproyecto).OrderByDescending(c=>c.Fecha);
                var query3 = db.FiltroPagosPorProyectos(Idproyecto, dateTimePicker1.Value, dateTimePicker2.Value);
                
                foreach (var i in query)
                {
                    this.dataGridView1.Rows.Add
                        (
                            i.Nombre+" "+i.Apellidos,
                            i.DiasTrabajados.ToString(),
                            "RD"+Convert.ToInt32(i.PagoPorDia.ToString()).ToString("C", nfi),
                            "RD"+Convert.ToInt32(i.Valor.ToString()).ToString("C", nfi),
                            i.Fecha.Value.Day.ToString()+"-"+i.Fecha.Value.Month.ToString()+"-"+i.Fecha.Value.Year.ToString()
                            
                        );
                }
                foreach (var i in query3.OrderByDescending(c => c.Fecha))
                {
                    this.dataGridView3.Rows.Add
                        (
                            i.Nombre + " " + i.Apellidos,
                            i.TotalDiasTrabajados.ToString(),
                            "RD" + Convert.ToInt32(i.TotalPagoPorDia.ToString()).ToString("C", nfi),
                            "RD" + Convert.ToInt32(i.TotalValor.ToString()).ToString("C", nfi),
                            i.TotalCantidadPagos.ToString(),
                           i.Fecha.Value.Day.ToString() + "-" + i.Fecha.Value.Month.ToString() + "-" + i.Fecha.Value.Year.ToString()

                        );
                }

                foreach (var i in query2)
                {
                    this.dataGridView2.Rows.Add(
                        
                       
                        i.Nombre + " " + i.Apellidos,
                        i.DiasTrabajados,
                      
                        "RD" + Convert.ToInt32(i.Valor.ToString()).ToString("C", nfi), // Convert.ToInt32(i.Valor.ToString()).ToString("C", nfi)
                        i.CantidadPagos.ToString()
                    );
                    Total += Convert.ToInt32(i.Valor);
                }
                label22.Text = "Pago suma total: RD" + Total.ToString("C", nfi);
                label2.Text = "Pago suma total: RD" + Total.ToString("C", nfi);
                label1.Text = "Pago suma total: RD" + Total.ToString("C", nfi);

            }
        }

        public int Total { get; set; }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verPagosDetalladosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               ListadoPagosDetalle l = new ListadoPagosDetalle();
                l.Id = IdProyecto;
                l.ShowDialog();

            }
            catch (Exception)
            {
                
              
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modificarPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x4 = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            var IdPago =Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            ModificarPago a = new ModificarPago();
            a.IdPago = IdPago;
            a.Pago = x4;
            a.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {

                Total =0;
                dataGridView3.Rows.Clear();
                var query3 = db.FiltroPagosPorProyectos(Idproyecto, dateTimePicker1.Value, dateTimePicker2.Value);
                foreach (var i in query3.OrderByDescending(c => c.Fecha))
                {
                    this.dataGridView3.Rows.Add
                        (
                            i.Nombre + " " + i.Apellidos,
                            i.TotalDiasTrabajados.ToString(),
                            "RD" + Convert.ToInt32(i.TotalPagoPorDia.ToString()).ToString("C", nfi),
                            "RD" + Convert.ToInt32(i.TotalValor.ToString()).ToString("C", nfi),
                            i.TotalCantidadPagos.ToString(),
                            i.Fecha.Value.Day.ToString() + "-" + i.Fecha.Value.Month.ToString() + "-" + i.Fecha.Value.Year.ToString()

                        );
                    Total = Total + Convert.ToInt32(i.TotalValor);
                }
                label1.Text = "Pago suma total: RD" + Total.ToString("C", nfi);
                Total = 0;
            }
        }

        private void textBox14_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView3.Rows.Clear();
            var x = "%" + textBox14.Text + "%";

            using (var db = new PresupuestoEntities5())
            {
                var query3 = db.FiltroNombresPagosPorProyectos(Idproyecto, x);
                foreach (var i in query3.OrderByDescending(c => c.Fecha))
                {
                    this.dataGridView3.Rows.Add
                        (
                            i.Nombre + " " + i.Apellidos,
                            i.TotalDiasTrabajados.ToString(),
                            "RD" + Convert.ToInt32(i.TotalPagoPorDia.ToString()).ToString("C", nfi),
                            "RD" + Convert.ToInt32(i.TotalValor.ToString()).ToString("C", nfi),
                           i.TotalCantidadPagos.ToString(),
                            i.Fecha.Value.Day.ToString() + "-" + i.Fecha.Value.Month.ToString() + "-" + i.Fecha.Value.Year.ToString()

                        );
                    Total = Total + Convert.ToInt32(i.TotalValor);
                }
                label1.Text = "Pago suma total: RD" + Total.ToString("C", nfi);
                Total = 0;
             
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView3.Rows.Clear();
            var x = "%" + textBox14.Text + "%";

            using (var db = new PresupuestoEntities5())
            {
                var query3 = db.FiltroNombresPagosPorProyectos(Idproyecto, x);
                foreach (var i in query3.OrderByDescending(c => c.Fecha))
                {
                    this.dataGridView3.Rows.Add
                        (
                            i.Nombre + " " + i.Apellidos,
                            i.TotalDiasTrabajados.ToString(),
                            "RD" + Convert.ToInt32(i.TotalPagoPorDia.ToString()).ToString("C", nfi),
                            "RD" + Convert.ToInt32(i.TotalValor.ToString()).ToString("C", nfi),
                            i.TotalCantidadPagos.ToString(),
                             i.Fecha.Value.Day.ToString() + "-" + i.Fecha.Value.Month.ToString() + "-" + i.Fecha.Value.Year.ToString()

                        );
                    Total = Total + Convert.ToInt32(i.TotalValor);
                }
                label1.Text = "Pago suma total: RD" + Total.ToString("C", nfi);
                Total = 0;

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            var x = "%" + textBox14.Text + "%";

            using (var db = new PresupuestoEntities5())
            {
                var query3 = db.FiltroNombresPagosPorProyectos(Idproyecto, x).OrderByDescending(c => c.Fecha);
                foreach (var i in query3)
                {
                    this.dataGridView3.Rows.Add
                        (
                            i.Nombre + " " + i.Apellidos,
                            i.TotalDiasTrabajados.ToString(),
                            "RD" + Convert.ToInt32(i.TotalPagoPorDia.ToString()).ToString("C", nfi),
                            "RD" + Convert.ToInt32(i.TotalValor.ToString()).ToString("C", nfi),
                            i.TotalCantidadPagos.ToString(),
                            i.Fecha.Value.Day.ToString() + "-" + i.Fecha.Value.Month.ToString() + "-" + i.Fecha.Value.Year.ToString()

                        );
                    Total = Total + Convert.ToInt32(i.TotalValor);
                }
                label1.Text = "Pago suma total: RD" + Total.ToString("C", nfi);
                Total = 0;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new PresupuestoEntities5())
                {
                    var fecha =Convert.ToDateTime("01-" + dateTimePicker3.Value);
                    
                    Total = 0;
                    dataGridView3.Rows.Clear();
                    var query3 = db.FiltroPagosPorProyectosMesesesAnios(Idproyecto, dateTimePicker3.Value).OrderByDescending(c => c.Fecha);
                    foreach (var i in query3)
                    {
                        this.dataGridView3.Rows.Add
                            (
                                i.Nombre + " " + i.Apellidos,
                                i.TotalDiasTrabajados.ToString(),
                                "RD" + Convert.ToInt32(i.PagoPorDia.ToString()).ToString("C", nfi),
                                "RD" + Convert.ToInt32(i.Valor.ToString()).ToString("C", nfi),
                                i.TotalCantidadPagos.ToString(),
                                i.Fecha.Value.Day.ToString() + "-" + i.Fecha.Value.Month.ToString() + "-" + i.Fecha.Value.Year.ToString()

                            );
                        Total = Total + Convert.ToInt32(i.Valor);
                    }
                    label1.Text = "Pago suma total: RD" + Total.ToString("C", nfi);
                    Total = 0;
                }
            }
            catch (Exception ew)
            {

                MessageBox.Show(ew.Message);
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}

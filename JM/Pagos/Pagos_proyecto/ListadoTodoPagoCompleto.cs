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
using JM.DB;

namespace JM.Pagos.Pagos_proyecto
{
    public partial class ListadoTodoPagoCompleto : Form
    {
        public ListadoTodoPagoCompleto()
        {
            InitializeComponent();
        }
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        private void ListadoTodoPagoCompleto_Load(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {
                DateTime date = DateTime.Now;
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";
                dateTimePicker1.Value = firstDayOfMonth;

             
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = "dd-MM-yyyy";
                dateTimePicker2.Value = lastDayOfMonth;

   


                //var dateTime = (from c in db.Pagoes orderby c.Fecha  select c.Fecha).First();
                //if (dateTime != null)
                //{
                //    dateTimePicker1.Value = (DateTime)dateTime;
                //}
                //else
                //{
                //    dateTimePicker1.Value = DateTime.Now;
                //}

                //this.label4.Text = "Pagos relacionados al proyecto: " + Descripcion;
                //var query2 = db.ListadoPagosPorProyectoDetalles(Idproyecto);
                var query = db.Listado_Pagos(2).OrderByDescending(c => c.Fecha);
                var query3 = db.Filtro(dateTimePicker1.Value, dateTimePicker2.Value);

                foreach (var i in query)
                {
                    this.dataGridView1.Rows.Add
                        (
                            i.Descripcion,
                            i.Nombre + " " + i.Apellidos,
                            i.DiasTrabajados.ToString(),
                             "RD" + Convert.ToInt32(i.PagoPorDia.ToString()).ToString("C", nfi),
                            "RD" + Convert.ToInt32(i.Valor.ToString()).ToString("C", nfi),
                            i.Fecha.Value.Day.ToString() + "-" + i.Fecha.Value.Month.ToString() + "-" + i.Fecha.Value.Year.ToString()

                        );
                }
                foreach (var i in query3.OrderByDescending(c => c.Fecha))
                {
                    this.dataGridView3.Rows.Add
                        (
                           i.Descripcion,
                            i.Nombre + " " + i.Apellidos,
                            i.TotalDiasTrabajados.ToString(),

                            "RD" + Convert.ToInt32(i.TotalValor.ToString()).ToString("C", nfi),
                            i.TotalCantidadPagos.ToString(),
                            i.Fecha.Value.Day.ToString() + "-" + i.Fecha.Value.Month.ToString() + "-" + i.Fecha.Value.Year.ToString()

                        );
                    TotalDinamico = Convert.ToInt32(i.TotalValor) + TotalDinamico;
                }

                //foreach (var i in query2)
                //{
                //    this.dataGridView2.Rows.Add(


                //        i.Nombre + " " + i.Apellidos,
                //        i.DiasTrabajados,

                //        "RD" + Convert.ToInt32(i.Valor.ToString()).ToString("C", nfi), // Convert.ToInt32(i.Valor.ToString()).ToString("C", nfi)
                //        i.CantidadPagos.ToString()
                //    );
                //    Total += Convert.ToInt32(i.Valor);
                //}
                //label22.Text = "Pago suma total: RD" + Total.ToString("C", nfi);
                //label2.Text = "Pago suma total: RD" + Total.ToString("C", nfi);
                label2.Text = "Pago suma total: RD" + TotalDinamico.ToString("C", nfi);

            }
        }

        public int TotalDinamico { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {

                Total = 0;
                dataGridView3.Rows.Clear();
                var query3 = db.Filtro(dateTimePicker1.Value, dateTimePicker2.Value);
                foreach (var i in query3.OrderByDescending(c => c.Fecha))
                {
                    this.dataGridView3.Rows.Add
                        (
                            i.Descripcion,
                            i.Nombre + " " + i.Apellidos,
                            i.TotalDiasTrabajados.ToString(),
                            
                            "RD" + Convert.ToInt32(i.TotalValor.ToString()).ToString("C", nfi),
                            i.TotalCantidadPagos.ToString(),
                            i.Fecha.Value.Day.ToString() + "-" + i.Fecha.Value.Month.ToString() + "-" + i.Fecha.Value.Year.ToString()

                        );
                    Total = Total + Convert.ToInt32(i.TotalValor);
                }
                label2.Text = "Pago suma total: RD" + Total.ToString("C", nfi);
                Total = 0;
            }
        }

        public int Total { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new PresupuestoEntities5())
                {
                 

                    Total = 0;
                    dataGridView3.Rows.Clear();
                    var query3 = db.FiltroPagosTodoMesesesAnios(dateTimePicker1.Value).OrderByDescending(c => c.Fecha);
                    foreach (var i in query3)
                    {
                        this.dataGridView3.Rows.Add
                            (
                                i.Descripcion,
                                i.Nombre + " " + i.Apellidos,
                                i.TotalDiasTrabajados,
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

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
using JM.Clientes;

namespace JM.Pagos
{
    public partial class PagosEmpleados : Form
    {
        public PagosEmpleados()
        {
            InitializeComponent();
        }
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

        private EmpleadoPago _Empleado;
        List<EmpleadoPago> EmpleadoLista = new List<EmpleadoPago>();
        private int idProyecto;
        public int IdProyecto
        {
            get { return idProyecto; }
            set { idProyecto = value; }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void PagosEmpleados_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
            //textBox3.Text=x0;
            //textBox14.Text = x1;
            //textBox5.Text = x3;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas realizar esto(s) pago(s)?", "Pagos", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView2.CurrentRow != null)
                {


                    try
                    {
                        using (var db = new PresupuestoEntities5())
                        {
                            foreach (var item in EmpleadoLista)
                            {
                                DB.Pago pagos = new DB.Pago
                                {
                                    IdProyecto = idProyecto,
                                    Valor = item.Total,
                                    Fecha = item.Fecha,
                                    IdEmpleado = item.Id,
                                    DiasTrabajados = item.DiasTrabajados,
                                    PagoPorDia = item.Pago


                                };
                                db.Pagoes.Add(pagos);
                                db.SaveChanges();

                            }
                        }

                        MessageBox.Show("Pagos realizados con exito");
                        this.Close();

                    }
                    catch (Exception)
                    {


                    }
                }
                else
                {
                    MessageBox.Show("Debes agregar al menos un pago para un empleado", "Pago",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (dialogResult == DialogResult.No)
            {

            }

          
        }
            public class EmpleadoPago
            {
                public int Id { get; set; }
                public string Nombre { get; set; }
                public string Ocupacion { get; set; }
                public DateTime Fecha { get; set; }
                public int? Pago { get; set; }
                public int DiasTrabajados { get; set; }
                public int Total { get; set; }
            }

            private void button1_Click(object sender, EventArgs e)
            {
                var valor = textBox2.Text;

             
                        if (string.IsNullOrEmpty(valor) || string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Todos los campos son requeridos");
                        }
                        else
                        {
                            try
                            {
                                agregar();
                            }
                            catch (NullReferenceException es)
                            {

                                MessageBox.Show("Debes seleccionar una fila");
                            }
                            catch (FormatException gg)
                            {
                                MessageBox.Show("Omita el punto(.) en el pago");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Intentelo de nuevo");
                            }

                        }
               
               
            }


            public void agregar()
            {

                Total = 0;
                EmpleadoLista.Add(new EmpleadoPago {

                    Id=Convert.ToInt32(textBox3.Text),
                    Nombre=textBox14.Text,
                    Ocupacion=textBox5.Text,
                    Pago=Convert.ToInt32(textBox2.Text),
                    Fecha=dateTimePicker1.Value,
                    Total = Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox4.Text),
                    DiasTrabajados = Convert.ToInt32(textBox4.Text)
                       
                });

                this.dataGridView2.Rows.Clear();
                foreach (var i in EmpleadoLista)
                {
                    dataGridView2.Rows.Add
                        (
                            i.Id,
                            i.Nombre,
                            i.Ocupacion,
                            i.DiasTrabajados,
                            "RD"+Convert.ToInt32(i.Pago).ToString("C",nfi),
                            "RD" + Convert.ToInt32(i.Total).ToString("C", nfi),
                            i.Fecha
                        );
                    Total = Total + Convert.ToInt32(i.Total);

                }
            label22.Text = "Total pago a realizar: RD" + Total.ToString("C", nfi);
            textBox14.Text=string.Empty;
            textBox5.Text=string.Empty;
            textBox2.Text=string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
                    

            }

        public int Total { get; set; }

        public void eliminar()
        {
                Total = 0;
                int currentIndex = this.dataGridView2.CurrentCell.RowIndex;
                EmpleadoLista.RemoveAt(currentIndex);
                this.dataGridView2.Rows.Clear();
      
                foreach (var i in EmpleadoLista)
                {
                    dataGridView2.Rows.Add
                        (
                            i.Id,
                            i.Nombre,
                            i.Ocupacion,
                            i.DiasTrabajados,
                            Convert.ToInt32(i.Pago).ToString("C", nfi),
                            Convert.ToInt32(i.Total).ToString("C", nfi),
                            i.Fecha
                        );
                    Total = Total + Convert.ToInt32(i.Total);
                }
                label22.Text = "Total pago a realizar: RD" + Total.ToString("C", nfi);
            }


            private void button3_Click(object sender, EventArgs e)
            {
                try
                {
                     eliminar();
                }
                catch (NullReferenceException es)
                {

                    MessageBox.Show("Debes seleccionar una fila");
                }
                catch  (Exception ex)
                {
                    MessageBox.Show("Intentelo de nuevo");
                }
            }

            private void textBox1_KeyUp(object sender, KeyEventArgs e)
            {
              
            }

            private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
              

            }

            private void button17_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void button4_Click(object sender, EventArgs e)
            {
               
                ListaClienteParaPagos c = new ListaClienteParaPagos();
                c.IdProyecto = IdProyecto;
                c.enviado += new ListaClienteParaPagos.enviar(ejecutar);
                c.ShowDialog();
            }
            private void ejecutar(string dato,string dato2,string dato3)
            {
                textBox3.Text = dato;
                textBox14.Text = dato2;
                textBox5.Text = dato3;
            }

            private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

            private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                int currentIndex = this.dataGridView2.CurrentCell.RowIndex;
              
                string nombre = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                var x0 =dataGridView2.CurrentRow.Cells[3].Value.ToString();
                string ocupacion = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                var dataGridViewRow = this.dataGridView2.CurrentRow;
                
                if (dataGridViewRow != null)
                {
                    var id =Convert.ToInt32(dataGridViewRow.Cells[0].Value.ToString());
                    textBox2.Text = EmpleadoLista.ElementAt(currentIndex).Pago.ToString();
                    textBox4.Text = x0;
                    textBox5.Text = ocupacion;
                    textBox3.Text = id.ToString();
                    textBox14.Text = nombre;
                }
            }

            private void button5_Click(object sender, EventArgs e)
            {
                if (dataGridView2.RowCount!=0)
                {
                    try
                    {
                        Total = 0;
                        _Empleado = new EmpleadoPago();
                        int currentIndex = this.dataGridView2.CurrentCell.RowIndex;
                        _Empleado.Id = Convert.ToInt32(textBox3.Text);
                        _Empleado.Fecha = dateTimePicker1.Value;
                        _Empleado.DiasTrabajados = Convert.ToInt32(textBox4.Text);
                        _Empleado.Pago = Convert.ToInt32(textBox2.Text);
                        _Empleado.Nombre = textBox14.Text;
                        _Empleado.Ocupacion = textBox5.Text;
                        _Empleado.Total = (Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox4.Text));

                        EmpleadoLista.RemoveAt(currentIndex);
                        EmpleadoLista.Insert(currentIndex, _Empleado);
                        this.dataGridView2.Rows.Clear();
                        foreach (var i in EmpleadoLista)
                        {
                            dataGridView2.Rows.Add
                                (
                                    i.Id,
                                    i.Nombre,
                                    i.Ocupacion,
                                    i.DiasTrabajados,
                                    "RD" + Convert.ToInt32(i.Pago).ToString("C", nfi),
                                    "RD" + Convert.ToInt32(i.Total).ToString("C", nfi),
                                    i.Fecha
                                );
                            Total = Total + Convert.ToInt32(i.Total);
                        }

                        label22.Text = "Total pago a realizar: RD" + Total.ToString("C", nfi);
                        textBox4.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        textBox3.Text = string.Empty;
                        textBox14.Text = string.Empty;
                        textBox5.Text = string.Empty;


                    }
                    catch (Exception)
                    {
                            
                      
                    }
                }
            }
    }
}

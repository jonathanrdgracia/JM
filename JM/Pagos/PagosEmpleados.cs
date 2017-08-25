﻿using JM.DB;
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
            dateTimePicker1.CustomFormat = "dd-MM- yyyy";
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
            
                using (var db = new PresupuestoEntities5()) 
                {
                    foreach (var item in EmpleadoLista)
                    {
                         DB.Pago pagos = new DB.Pago
                        {
                            IdProyecto=idProyecto,
                            Valor=item.Total,
                            Fecha=item.Fecha,
                            IdEmpleado=item.Id,
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
            public class EmpleadoPago
            {
                public int Id { get; set; }
                public string Nombre { get; set; }
                public string Ocupacion { get; set; }
                public string Fecha { get; set; }
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
               
                
                    EmpleadoLista.Add(new EmpleadoPago {

                        Id=Convert.ToInt32(textBox3.Text),
                        Nombre=textBox14.Text,
                        Ocupacion=textBox5.Text,
                        Pago=Convert.ToInt32(textBox2.Text),
                        Fecha=dateTimePicker1.Text,
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
                }
            textBox14.Text=string.Empty;
            textBox5.Text=string.Empty;
            textBox2.Text=string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
                    

            }
            public void eliminar()
            {
                var x0 = Convert.ToInt32(this.dataGridView2.CurrentRow.Cells[0].Value.ToString());
                EmpleadoLista.RemoveAll(c => c.Id == x0);
                this.dataGridView2.Rows.Clear();
      
                foreach (var i in EmpleadoLista)
                {
                    dataGridView2.Rows.Add
                        (
                            i.Id,
                            i.Nombre,
                            i.Ocupacion,
                            Convert.ToInt32(i.Pago).ToString("C", nfi),
                            i.Fecha
                        );
                }
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
                var x0 =dataGridView2.CurrentRow.Cells[3].Value.ToString();
                var dataGridViewRow = this.dataGridView2.CurrentRow;
                if (dataGridViewRow != null)
                {
                    var id =Convert.ToInt32(dataGridViewRow.Cells[0].Value.ToString());
                    textBox2.Text = EmpleadoLista.ElementAt(currentIndex).Pago.ToString();
                    textBox4.Text = x0;
                }
            }
    }
}

using JM.Clientes;
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

namespace JM.Presupuesto
{
    public partial class Mixto : Form
    {
        List<Materiales_detalle> materiales = new List<Materiales_detalle>();
        List<Materiales_detalle> ManosDeObra = new List<Materiales_detalle>();
        public List<empleadosC> Jefes = new List<empleadosC>();
        public int TotalTotal { get; set; }
        public int TotalTotal1 { get; set; }
        public int IdPresupuesto { get; set; }
        public int TotalTotal2 { get; set; }
        public Double TotalGenetal { get; set; }
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public Mixto()
        {
            InitializeComponent();
        }
        PresupuestoMateriales p = new PresupuestoMateriales();
        private void button1_Click(object sender, EventArgs e)
        {
          
            try
            {
                    var x0 = Convert.ToInt32(this.dataGridView4.CurrentRow.Cells[0].Value.ToString());
                    Jefes.RemoveAll(c => c.ID == x0);
                    this.dataGridView4.Rows.Clear();
                    foreach (var i in Jefes)
                    {
                        dataGridView4.Rows.Add(

                            i.ID,
                            i.Nombre,
                            i.Telefono,
                            i.Ocupacion
                        );
                    }
            }
            catch (NullReferenceException es)
            {

                MessageBox.Show("Debes seleccionar una fila");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Intentelo de nuevo");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ArIng2 c = new ArIng2();
            c.enviado += new ArIng2.enviar(ejecutar);
            c.ShowDialog();
        }
        private void ejecutar(int id, string nombre, string telefono, string ocupacion)
        {
           
            Jefes.Add(new empleadosC { 
            ID=id,
            Nombre=nombre,
            Telefono=telefono,
            Ocupacion=ocupacion
            });
            this.dataGridView4.Rows.Clear();
            foreach (var i in Jefes)
            {
                dataGridView4.Rows.Add
                    (
                        i.ID,
                        i.Nombre,
                        i.Telefono,
                        i.Ocupacion
                    );
            }
            
        }


        private void Mixto_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            p.LLenarCombobox(comboBox1,"material");
            p.LLenarCombobox(comboBox2,"mano");
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

        }

   
        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox22.Text==string.Empty)
            {
                                MessageBox.Show("Todos los campos son requeridos", "Campos vacios",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {

                    nfi.CurrencyDecimalDigits = 2;
                    var descrip = textBox22.Text;
                    var prec = Convert.ToInt32(textBox21.Text);
                    var cantidad = Convert.ToInt32(textBox20.Text);
                    var unidad = comboBox1.SelectedItem.ToString();
                    var total = Convert.ToInt32(prec) * Convert.ToInt32(cantidad);
                    this.dataGridView1.Rows.Clear();
                    materiales.Add(new Materiales_detalle
                    {
                        Descripcion = descrip,
                        Precio = prec,
                        Cantidad = cantidad,
                        Unidad = unidad,
                        Total = total,
                    });



                    foreach (var item in materiales)
                    {
                        this.dataGridView1.Rows.Add
                            (
                               item.Descripcion,
                                item.Unidad,
                                "RD" + Convert.ToInt32(item.Precio).ToString("C", nfi),
                                item.Cantidad,
                                "RD" + Convert.ToInt32(item.Total).ToString("C", nfi)
                            );
                    }
                    comboBox1.ResetText();
                    CalcularTotalGenetal1();
                    limpiarTodo(comboBox1, textBox22, textBox21, textBox20);

                }
                catch (NullReferenceException es)
                {

                    MessageBox.Show("Todos los campos son requeridos", "Presupuesto",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo ha salido mal, intentlo de nuevo", "Presupuesto",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
          
            
            }

        }

        private void limpiarTodo(ComboBox comboBox1s, TextBox textBox22s, TextBox textBox21s, TextBox textBox20s)
        {
            comboBox1s.Text = "";
            textBox22s.Text = string.Empty;
            textBox21s.Text = string.Empty;
            textBox20s.Text = string.Empty;

        }
        public void CalcularTotalGenetal1()
        {
            TotalGenetal = 0;
            //double total_general = 0;
            foreach (var item in materiales)
            {
                TotalGenetal = TotalGenetal + Convert.ToDouble(item.Total);
            }
            label22.Text ="Subtotal: RD" +Convert.ToDouble(TotalGenetal).ToString("C", nfi);
          
            TotalTotal =Convert.ToInt32(TotalGenetal);
            TotalTotal1 = TotalTotal;
            
            label40.Text  ="Total general: RD"+(TotalTotal1+TotalTotal2).ToString("C",nfi);
        }



        public void CalcularTotalGenetal2()
        {
            TotalGenetal = 0;
            //double total_general = 0;
            foreach (var item in ManosDeObra)
            {
                TotalGenetal = TotalGenetal + Convert.ToDouble(item.Total);
            }
            label25.Text ="Subtotal: RD"+ Convert.ToDouble(TotalGenetal).ToString("C", nfi);

            TotalTotal = Convert.ToInt32(TotalGenetal);
            TotalTotal2 = TotalTotal;

            label40.Text = "Total general: RD" + (TotalTotal1 + TotalTotal2).ToString("C", nfi);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                materiales.RemoveAll(c => c.Descripcion == x0);

                this.dataGridView1.Rows.Clear();
                foreach (var item in materiales)
                {
                    this.dataGridView1.Rows.Add
                        (
                            item.Descripcion,
                            item.Unidad,
                            item.Precio,
                            item.Cantidad,
                            item.Total
                        );
                }
                CalcularTotalGenetal1();

            }
            catch (NullReferenceException es)
            {

                MessageBox.Show("Debes seleccionar una fila", "Presupuesto",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal, intentlo de nuevo", "Presupuesto",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /**********************/
            if (textBox13.Text==string.Empty)
            {
                MessageBox.Show("Todos los campos son requeridos", "Presupuesto",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {

                    nfi.CurrencyDecimalDigits = 2;
                    var descrip = textBox15.Text;
                    var prec = Convert.ToInt32(textBox14.Text);
                    var cantidad = Convert.ToInt32(textBox13.Text);
                    var unidad = comboBox2.SelectedItem.ToString();
                    var total = Convert.ToInt32(prec) * Convert.ToInt32(cantidad);
                    this.dataGridView2.Rows.Clear();
                    ManosDeObra.Add(new Materiales_detalle
                    {
                        Descripcion = descrip,
                        Precio = prec,
                        Cantidad = cantidad,
                        Unidad = unidad,
                        Total = total,
                    });



                    foreach (var item in ManosDeObra)
                    {
                        this.dataGridView2.Rows.Add
                            (
                                item.Descripcion,
                                item.Unidad,
                                "RD" + Convert.ToInt32(item.Precio).ToString("C", nfi),
                                item.Cantidad,
                                "RD" + Convert.ToInt32(item.Total).ToString("C", nfi)
                            );
                    }
                    comboBox2.ResetText();
                    CalcularTotalGenetal2();

                    textBox13.Text = string.Empty;
                    textBox15.Text = string.Empty;
                    textBox14.Text = string.Empty;
                }
                catch (NullReferenceException es)
                {

                    MessageBox.Show("Todos los campos son requeridos", "Presupuesto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FormatException este)
                {
                    MessageBox.Show("Verifique que todos los datos sean correctos ", "Presupuesto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo ha salido mal " + ex.Message, "Presupuesto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            
            }
           
               
            
      
            /////////////////////////////////
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                var x0 = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
                ManosDeObra.RemoveAll(c => c.Descripcion == x0);

                this.dataGridView2.Rows.Clear();
                foreach (var item in ManosDeObra)
                {
                    this.dataGridView2.Rows.Add
                        (
                            item.Descripcion,
                            item.Unidad,
                            "RD"+Convert.ToInt32(item.Precio).ToString("C",nfi),
                            item.Cantidad,
                            "RD"+Convert.ToInt32(item.Total).ToString("C",nfi)
                        );
                }
                CalcularTotalGenetal2();

            }
            catch (NullReferenceException es)
            {

                MessageBox.Show("Presupuesto", "Debes seleccionar una fila",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Presupuesto", "Algo ha salido mal, intentlo de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarCero(sender, e);
        }

        public void ValidarCero(object sender, KeyPressEventArgs e)
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

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarCero(sender, e);
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarCero(sender, e);
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarCero(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount == 0 || this.dataGridView2.RowCount == 0 || textBox3.Text==string.Empty || textBox4.Text==string.Empty)
            {
                MessageBox.Show("Todos los campos son requeridos.", "Presupuesto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (textBox7.Text == string.Empty)
            {
                MessageBox.Show("Debes seleccionar un cliente.", "Presupuesto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (this.dataGridView4.RowCount == 0)
            {
                MessageBox.Show("Debes selecionar al menos un maestro, arquitecto(a) o ingeniero.", "Presupuesto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                //zccdnvsdivnivnivdnviodsnvidnvosdivndoivnsdiovnsdiovnds

                using (var db = new PresupuestoEntities5())
                {
                    var id=Convert.ToInt32(textBox7.Text);
                    DB.Presupuesto c = new DB.Presupuesto
                    {
                        Descripcion = textBox3.Text,
                        IdCliente = id,
                        Estado = 1,
                        FechaCreacion = fecha(),
                        Direccion=textBox4.Text,
                        TotalGeneral=Convert.ToInt32(TotalTotal1 + TotalTotal2)

                    };
                    var f = fecha();
                    db.Presupuestos.Add(c);
                    db.SaveChanges();
                    var query = (from x in db.Presupuestos
                                 where x.Descripcion == textBox3.Text && x.IdCliente == id && x.FechaCreacion == f
                                 select new { x.IdPresupuestos }).ToList();
                    foreach (var item in query)
                    {
                        IdPresupuesto = Convert.ToInt32(item.IdPresupuestos.ToString());
                    }

                    foreach (var item in materiales)
                    {
                        Materiales_detalle md = new Materiales_detalle
                        {
                            Cantidad = item.Cantidad,
                            Descripcion = item.Descripcion,
                            IdPresupuesto = IdPresupuesto,
                            Precio = item.Precio,
                            Tipo = 2,
                            Unidad = item.Unidad,
                            Total = Convert.ToInt32(item.Total),
                           
                        };
                        db.Materiales_detalle.Add(md);
                        db.SaveChanges();

                    }
                    foreach (var item in ManosDeObra)
                    {
                        Obra_detalle md = new Obra_detalle
                        {
                            Cantidad = item.Cantidad,
                            Descripcion = item.Descripcion,
                            IdPresupuesto = IdPresupuesto,
                            Precio = item.Precio,
                            Tipo = 2,
                            Unidad = item.Unidad,
                            Total = Convert.ToInt32(item.Total)
                            




                        };
                        db.Obra_detalle.Add(md);
                        db.SaveChanges();

                    }

                    foreach (var i in Jefes)
                    {
                        DB.EmpleadoPresupuesto emp = new DB.EmpleadoPresupuesto
                        {
                            IdPresupuesto = this.IdPresupuesto,
                            IdEmpleado = i.ID
                        };
                        db.EmpleadoPresupuestoes.Add(emp);
                        db.SaveChanges();
                    }

                    MessageBox.Show("Datos guardados correctamente");
                    this.Close();
                      
                }

            }
        }
        private string fecha()
        {
            return Convert.ToString(DateTime.Now.ToString("d/M/yyyy"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListadoClientes2 c = new ListadoClientes2();
            c.enviado += new ListadoClientes2.enviar(ejecutar);
            c.ShowDialog();
        }

       
        private void ejecutar (string dato,string dato2,string dato3,string dato4)
        {
            textBox7.Text = dato;
            textBox8.Text = dato2;
            textBox9.Text = dato3;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JM.Cliente.NuevoCliente a = new Cliente.NuevoCliente();
            a.ShowDialog();
        }

        private void agregarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JM.Modificar.Nuevo_Abonado a = new JM.Modificar.Nuevo_Abonado();
            a.ShowDialog();
        }

        private void agregarNuevaOcupacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JM.Abonado.Tipo.AgregarNuevo a = new JM.Abonado.Tipo.AgregarNuevo();
            a.ShowDialog();
        }
    }
}

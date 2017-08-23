using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using JM.DB;
using System.Threading.Tasks;
using System.Windows.Forms;
using JM.Cliente;
using JM.Unidad;
using System.Globalization;
using JM.Dataset;

namespace JM.Presupuesto
{
    public partial class PresupuestoMateriales : Form
    {
        private int Razon;

        public int RAZON
        {
            get { return Razon; }
            set { Razon = value; }
        }
        
        public List<empleadosC> Jefes = new List<empleadosC>();
        public Double TotalGenetal { get; set; }
        public int IdPresupuesto { get; set; }
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        readonly List<Materiales_detalle> _materiales = new List<Materiales_detalle>();
        private Materiales_detalle _materialEditado;
        public int IdCliente { get; set; }
        public PresupuestoMateriales()
        {
           
            InitializeComponent();
        }

 

        private void PresupuestoMateriales_Load(object sender, EventArgs e)
        {
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            if (Razon == 1)
            {
                LLenarCombobox(comboBox3, "material");
            }
            else { LLenarCombobox(comboBox3, "mano"); }
        }

        public void LLenarCombobox(ComboBox combBox3, string tipo)
        {
            combBox3.Items.Clear();
            try
            {
                using (var db = new PresupuestoEntities5())
                {
                    foreach (var item in db.Unidads.Where(c => c.Tipo == tipo))
                    {
                        combBox3.Items.Add(item.Unidad1);
                    }



                }

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

    
        private void ejecutar(string id,string dato, string dato2, string dato3)
        {
            IdCliente = Convert.ToInt32(id);
            textBox6.Text = dato;
            textBox2.Text = dato3;
            textBox5.Text = dato2;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListadoClientes c = new ListadoClientes();
            c.enviado += new ListadoClientes.enviar(ejecutar);
            c.ShowDialog();

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarUnidad c = new AgregarUnidad();
          
            c.ShowDialog();

            
           
        }
        private void ejecutar(ComboBox dato)
        {
           comboBox3 = dato;
        }


        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                var x0 = this.dataGridView3.CurrentRow.Cells[0].Value.ToString();
                _materiales.RemoveAll(c => c.Descripcion == x0);

                this.dataGridView3.Rows.Clear();
                foreach (var item in _materiales)
                {
                    this.dataGridView3.Rows.Add
                        (
                            item.Descripcion,
                            item.Unidad,
                            item.Precio,
                            item.Cantidad,
                            "RD"+Convert.ToInt32(item.Total).ToString("C",nfi)
                        );
                }
                CalcularTotalGenetal();
                textBox22.Text = string.Empty;
                textBox21.Text = string.Empty;
                textBox20.Text = string.Empty;
            }
            catch (Exception)
            {

             
            }
        }
        private string fecha()
        {
            return Convert.ToString(DateTime.Now.ToString("d/M/yyyy"));
        }


        public void CalcularTotalGenetal()
        {
            TotalGenetal = 0;
            //double total_general = 0;
            foreach (var item in _materiales)
            {
                TotalGenetal = TotalGenetal + Convert.ToDouble(item.Total);
            }
            label27.Text = Convert.ToDouble(TotalGenetal).ToString("C",nfi);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
               
                nfi.CurrencyDecimalDigits = 2;
                var descrip = textBox22.Text;
                var prec = Convert.ToInt32(textBox21.Text);
                var cantidad = Convert.ToInt32(textBox20.Text);
                var unidad = comboBox3.SelectedItem.ToString();
                var total = Convert.ToInt32(prec) * Convert.ToInt32(cantidad);

                _materiales.Add(new Materiales_detalle
                {
                    Descripcion = descrip,
                    Precio = prec,
                    Cantidad = cantidad,
                    Unidad = unidad,
                    Total = total,
                });


                this.dataGridView3.Rows.Clear();
                foreach (var item in _materiales)
                {
                    this.dataGridView3.Rows.Add
                        (
                            item.Descripcion,
                            item.Unidad,
                            item.Cantidad,
                             Convert.ToInt32(item.Precio).ToString("C", nfi),
                           "RD"+ Convert.ToInt32(item.Total).ToString("C", nfi)
                        );
                }
                
                CalcularTotalGenetal();
                textBox22.Text = string.Empty;
                textBox21.Text = string.Empty;
                textBox20.Text = string.Empty;

            }
            catch (NullReferenceException es)
            {

                MessageBox.Show("Favor evitar el punto(.)", "Presupuesto",
          MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Todos los campos son requeridos", "Presupuesto",
          MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Todos los campos son requeridos: " + ex.Message, "Presupuesto",
          MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox6.Text==string.Empty || textBoxdire.Text==string.Empty)
            {
                MessageBox.Show("Todos los campos son requeridos", "Presupuesto",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(Descripciontxxt.Text==string.Empty) 
            {
                MessageBox.Show("Debes registrar la descripcion del presupuesto", "Presupuesto",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
            else if (dataGridView3.Rows.Count == 0)
            {
                MessageBox.Show("Debes registrar los datos", "Cliente",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                if (Razon == 1)
                {
                    try
                    {
                        using (var db = new PresupuestoEntities5())
                        {
                            DB.Presupuesto c = new DB.Presupuesto
                            {
                                Descripcion = Descripciontxxt.Text,
                                IdCliente = IdCliente,
                                Estado = 1,
                                FechaCreacion = fecha(),
                                Direccion=textBoxdire.Text,
                                TotalGeneral=Convert.ToInt32(TotalGenetal)




                            };

                            db.Presupuestos.Add(c);
                            db.SaveChanges();
                            var f = fecha();
                            //Ahora el detalle
                            var query = (from x in db.Presupuestos
                                         where x.Descripcion == Descripciontxxt.Text && x.IdCliente == IdCliente && x.FechaCreacion == f
                                         select new { x.IdPresupuestos }).ToList();


                            foreach (var item in query)
                            {
                                IdPresupuesto = Convert.ToInt32(item.IdPresupuestos.ToString());
                            }

                            foreach (var item in _materiales)
                            { 
                                Materiales_detalle md = new Materiales_detalle
                                {
                                    Cantidad = item.Cantidad,
                                    Descripcion = item.Descripcion,
                                    IdPresupuesto = IdPresupuesto,
                                    Precio = item.Precio,
                                    Tipo = 1,
                                    Unidad = item.Unidad,
                                    Total = Convert.ToInt32(item.Total)
                                   
                                    



                                };
                                db.Materiales_detalle.Add(md);
                                db.SaveChanges();

                            }


                        }
                    }
                    catch (NullReferenceException es)
                    {

                        MessageBox.Show("Favor verificar todos los campos.", "Presupuesto",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Favor verificar todos los campos : "+ex.Message, "Presupuesto",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else//////////////////////////////////////////////////////////////////////////////OBRA
                {
                    try
                    {
                        using (var db = new PresupuestoEntities5())
                        {
                            DB.Presupuesto c = new DB.Presupuesto
                            {
                                Descripcion = Descripciontxxt.Text,
                                IdCliente = IdCliente,
                                Estado = 1,
                                FechaCreacion = fecha(),
                                Direccion = textBoxdire.Text,
                                TotalGeneral = Convert.ToInt32(TotalGenetal)




                            };

                            db.Presupuestos.Add(c);
                            db.SaveChanges();
                            var f = fecha();
                            //Ahora el detalle
                            var query = (from x in db.Presupuestos
                                         where x.Descripcion == Descripciontxxt.Text && x.IdCliente == IdCliente && x.FechaCreacion == f
                                         select new { x.IdPresupuestos }).ToList();


                            foreach (var item in query)
                            {
                                IdPresupuesto = Convert.ToInt32(item.IdPresupuestos.ToString());
                            }
                         


                            foreach (var item in _materiales)
                            {
                                Obra_detalle md = new Obra_detalle
                                {
                                    Cantidad = item.Cantidad,
                                    Descripcion = item.Descripcion,
                                    IdPresupuesto = IdPresupuesto,
                                    Precio = item.Precio,
                                    Tipo = 1,
                                    Unidad = item.Unidad,
                                    Total = Convert.ToInt32(item.Total)
                                   




                                };
                                db.Obra_detalle.Add(md);
                                db.SaveChanges();

                            }


                       

                        }
                    }
                    catch (NullReferenceException es)
                    {

                        MessageBox.Show("Todos los campos son requeridos", "Presupuesto",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Algo ha salido mal: "+ex.Message, "Presupuesto",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
            
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ArqIng c = new ArqIng();
            c.enviado += new ArqIng.enviar(ejecutar);
            c.ShowDialog();

        }
        private void ejecutar(int id,string nombre,string telefono,string ocupacion)
        {
           
            Jefes.Add(new empleadosC {
                ID=id,
                Nombre=nombre,
                Telefono=telefono,
                Ocupacion=ocupacion

            });

        
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
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

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void agregarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoCliente n = new NuevoCliente();
            n.ShowDialog();
        }

        private void agregarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JM.Modificar.Nuevo_Abonado a = new JM.Modificar.Nuevo_Abonado();
            a.ShowDialog();
        }

        private void agregarNuevaOcupacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JM.Abonado.Tipo.AgregarNuevo a = new JM.Abonado.Tipo.AgregarNuevo();
            a.ShowDialog();
        }

        private void dataGridView3_Enter(object sender, EventArgs e)
        {
          
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                  var x0 = this.dataGridView3.CurrentRow.Cells[0].Value.ToString();
                
                textBox22.Text = this.dataGridView3.CurrentRow.Cells[0].Value.ToString();
                comboBox3.SelectedItem = this.dataGridView3.CurrentRow.Cells[1].Value.ToString();
                textBox20.Text = this.dataGridView3.CurrentRow.Cells[2].Value.ToString();
                textBox21.Text = _materiales.First(c => c.Descripcion == x0).Precio.ToString();
            }
            catch (Exception)
            {
                
               
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                _materialEditado = new Materiales_detalle();
                int precio = Convert.ToInt32(textBox21.Text);
                int cantidad = Convert.ToInt32(textBox20.Text);

                int currentIndex = this.dataGridView3.CurrentCell.RowIndex;


                _materialEditado.Cantidad = cantidad;
                _materialEditado.Descripcion = textBox22.Text;
                _materialEditado.Precio = precio;
                _materialEditado.Cantidad = cantidad;
                _materialEditado.Unidad = comboBox3.SelectedItem.ToString();
                _materialEditado.Total = (precio * cantidad);

                _materiales.RemoveAt(currentIndex);
                _materiales.Insert(currentIndex, _materialEditado);



                this.dataGridView3.Rows.Clear();
                foreach (var item in _materiales)
                {
                    this.dataGridView3.Rows.Add
                        (
                            item.Descripcion,
                            item.Unidad,
                           item.Cantidad,
                            item.Precio,
                            "RD" + Convert.ToInt32(item.Total).ToString("C", nfi)
                        );
                }
                CalcularTotalGenetal();
                textBox22.Text = string.Empty;
                textBox21.Text = string.Empty;
                textBox20.Text = string.Empty;

            }
            catch (FormatException ex)
            {

                MessageBox.Show("Seleccione una fila para editarla", "Presupuesto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {

                MessageBox.Show("Mensaje de error: "+es.Message, "Presupuesto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }

    public class empleadosC {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Ocupacion { get; set; }
    }
}


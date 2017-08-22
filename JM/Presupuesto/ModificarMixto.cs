using JM.DB;
using JM.Reportes;
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
    public partial class ModificarMixto : Form
    {
        public ModificarMixto()
        {
            InitializeComponent();
        }
        public int Viejodato { get; set; }
        public int TotalGeneralDB { get; set; }
        private int Idpropuesta;
        public int Rebaja { get; set; }

        public int IdPropuesta
        {
            get { return Idpropuesta; }
            set { Idpropuesta = value; }
        }
       
        List<Materiales_detalle> listaMateriales = new List<Materiales_detalle>();
        List<Materiales_detalle> listaMaterialesNuevos = new List<Materiales_detalle>();
        List<Obra_detalle> listaObrasNuevos = new List<Obra_detalle>();
        List<Obra_detalle> listaObras = new List<Obra_detalle>();
        List<empleadosCA> Jefes = new List<empleadosCA>();
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public int TotalGranMaster { get; set; }
        public int contador1 { get; set; }
        public int contador2 { get; set; }
        public int cambio { get; set; }
        public int _db { get; set; }
        private void ModificarMixto_Load(object sender, EventArgs e)
        {
     
            PresupuestoMateriales p = new PresupuestoMateriales();
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            p.LLenarCombobox(comboBox1, "material");
            p.LLenarCombobox(comboBox2, "mano");
            using (var db = new PresupuestoEntities5())
            {
                _db = Convert.ToInt32(db.Presupuestos.Where(c => c.IdPresupuestos == Idpropuesta).Select(x => x.TotalGeneral).FirstOrDefault());
                var consulta = from t1 in db.Presupuestos
                               join t2 in db.Clientes on t1.IdCliente equals t2.id
                               where t1.IdPresupuestos==Idpropuesta
                               select new { t2.id, t2.Nombre,t2.Telefono,t1.Descripcion,t1.Direccion };


                foreach (var item in consulta)
                {
                    textBox7.Text=item.id.ToString();
                    textBox8.Text=item.Nombre;
                    textBox9.Text = item.Telefono;
                    textBox3.Text = item.Descripcion;
                    textBox4.Text = item.Direccion;
                }
                var consultaEmpleado = from t1 in db.Abonadoes
                               join t2 in db.EmpleadoPresupuestoes on t1.Id equals t2.IdEmpleado
                               where t2.IdPresupuesto==Idpropuesta
                               select new {t1.Id,t1.Nombre,t1.Apellidos,t1.TipoEmpleado,t1.Telefono};

                foreach (var i in consultaEmpleado)
                {
                    Jefes.Add(new empleadosCA 
                    {
                        IDs=i.Id,
                        Nombres=i.Nombre+" "+i.Apellidos,
                        Ocupacions=i.TipoEmpleado,
                        Telefonos=i.Telefono
                        
                    });
                   
                }
                foreach (var r in Jefes)
                {
                    this.dataGridView4.Rows.Add
                        (
                            r.IDs,
                            r.Nombres,
                            r.Ocupacions,
                            r.Telefonos
                        );
                }

                TotalGeneralDB = Convert.ToInt32(db.Presupuestos.Where(c => c.IdPresupuestos == Idpropuesta).Select(x => x.TotalGeneral).FirstOrDefault());
                var query= (from c in db.Materiales_detalle where c.IdPresupuesto==IdPropuesta select c);
                var query2 = (from c in db.Obra_detalle where c.IdPresupuesto == IdPropuesta select c);
                foreach (var i in query)
                {
                    listaMateriales.Add(new Materiales_detalle
                    {
                        Descripcion=i.Descripcion,
                        Unidad=i.Unidad,
                        Precio=i.Precio,
                        Cantidad=i.Cantidad,
                        Total=i.Total
                    });
                    contador1+=Convert.ToInt32(i.Total);
                }
                foreach (var i in listaMateriales)
                {
                    this.dataGridView1.Rows.Add
                        (
                            i.Descripcion,i.Unidad,i.Precio,i.Cantidad,i.Total

                        );
                   
                  
                }

                /**/
                foreach (var b in query2)
                {
                    listaObras.Add(new Obra_detalle
                    {
                        Descripcion = b.Descripcion,
                        Unidad = b.Unidad,
                        Precio = b.Precio,
                        Cantidad = b.Cantidad,
                        Total = b.Total
                    });
                    contador2 += Convert.ToInt32(b.Total);
                }
                foreach (var v in listaObras)
                {
                    this.dataGridView2.Rows.Add
                        (
                            v.Descripcion, v.Unidad, v.Precio, v.Cantidad, v.Total
                        );
                }


            }
            label22.Text = "Subtotal: RD" + contador1.ToString("C",nfi);
            label25.Text = "Subtotal: RD" + contador2.ToString("C", nfi);
            label40.Text = "Total general: RD" + (contador1 + contador2).ToString("C", nfi);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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
            contador1 = 0;
            listaMaterialesNuevos.Add(new Materiales_detalle
            {
                Descripcion = descrip,
                Precio = prec,
                Cantidad = cantidad,
                Unidad = unidad,
                Total = total,
            });

            foreach (var i in listaMateriales)
            {
                dataGridView1.Rows.Add(i.Descripcion, i.Unidad, i.Precio, i.Cantidad, i.Total);
                contador1 = contador1 + Convert.ToInt32(i.Total);
            }
            
            foreach (var i in listaMaterialesNuevos)
            {
                dataGridView1.Rows.Add(i.Descripcion, i.Unidad, i.Precio, i.Cantidad, i.Total);
                contador1 = contador1 + Convert.ToInt32(i.Total);
            }
            label22.Text = "Subtotal: RD" + contador1.ToString("C", nfi);
            label40.Text = "Total general: RD" + (contador1 + contador2).ToString("C", nfi);
            textBox22.Text = string.Empty;
            textBox21.Text = string.Empty;
            textBox20.Text = string.Empty;
            }
            catch (NullReferenceException es)
            {

                MessageBox.Show("Todos los campos son requeridos", "Presupuesto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             catch(FormatException este)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count !=0  || dataGridView2.Rows.Count != 0 || dataGridView1.Rows.Count != 0 || textBox4.Text != string.Empty || textBox3.Text != string.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas actualizar este presupuesto?", "Actualizar presupuesto", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        using (var db = new PresupuestoEntities5())
                        {

                            //delete borro todo de la db materiales
                            db.BorrarTodoMateriales_detalle(Idpropuesta);
                            db.BorrarTodoObra_detalle(Idpropuesta);

                            //inserto los materiales
                            foreach (var i in listaMateriales)
                            {
                                db.guardar_materiales_listado(Idpropuesta, i.Descripcion, i.Unidad, i.Precio, i.Cantidad, i.Total, 2);
                            }
                            //inserto los materiales
                            foreach (var pv in listaObras)
                            {
                                db.guardar_obras_listado(Idpropuesta, pv.Descripcion, pv.Unidad, pv.Precio, pv.Cantidad, pv.Total, 2);
                            }
                            foreach (var rp in listaObrasNuevos)
                            {
                                db.guardar_obras_listado(Idpropuesta, rp.Descripcion, rp.Unidad, rp.Precio, rp.Cantidad, rp.Total, 2);
                            }

                            //inserto los materiales nuevos
                            foreach (var i in listaMaterialesNuevos)
                            {
                                db.guardar_materiales_listado(Idpropuesta, i.Descripcion, i.Unidad, i.Precio, i.Cantidad, i.Total, 2);
                            }
                            int a = 0;
                            int b = 0;
                            int d = 0;
                            // listaMateriales.AddRange(listaMaterialesNuevos);
                            foreach (var i in listaMaterialesNuevos)
                            {
                                b = b + Convert.ToInt32(i.Total) * 1;
                            }
                            foreach (var i in listaObrasNuevos)
                            {
                                d = d + Convert.ToInt32(i.Total) * 1;
                            }
                            a = b + d;
                            foreach (var item in db.Presupuestos.Where(c => c.IdPresupuestos == Idpropuesta))
                            {
                                TotalGeneralDB = +Convert.ToInt32(item.TotalGeneral);
                            }
                           
                            //Actualizar presupuesto cabecera
                            int nuevo = (a - TotalGeneralDB);
                           
                            // var tot = TotalGeneralDB - a;
                            var tot = (Math.Abs(TotalGeneralDB + a)) - (Rebaja);

                            foreach (var i in Jefes)
                            {
                                db.SP_Borrrado_deEmpleados(Idpropuesta);
                            }

                            foreach (var i in Jefes)
                            {
                                db.SP_insertado_deEmpleados(Idpropuesta, i.IDs);
                            }

                            DB.Presupuesto zz;
                            zz = (from c in db.Presupuestos where c.IdPresupuestos == Idpropuesta select c).First();
                            zz.Descripcion = textBox3.Text;
                            zz.Direccion = textBox4.Text;
                            zz.Estado = 1;
                            if (cambio == 1)
                            {
                                zz.TotalGeneral = _db;
                            }
                            else
                            {
                                zz.TotalGeneral = tot;
                            }
                            db.SaveChanges();




                            //////////
                            MessageBox.Show("Presupuesto actualizado con exito");
                            this.Close();

                        }
                       
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
                else
                {


                }

            }
            else
            {
                MessageBox.Show("Todos los campos son requeridos", "Campos vacios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
    }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                contador1 = 0;
                var jj = 0;
                var listauno = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                var listauno1 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                var listauno2 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                var listauno3 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString());

                var q = listaMaterialesNuevos.Where(c => c.Descripcion == listauno);
                var q2 = listaMateriales.Where(c => c.Descripcion == listauno);
                foreach (var i in q)
                {
                    jj = jj + Convert.ToInt32(i.Total);
                }
                foreach (var i in q2)
                {
                    jj = jj + Convert.ToInt32(i.Total);
                }

                Rebaja = Rebaja + jj;

                MessageBox.Show(jj.ToString());


                listaMateriales.RemoveAll(c => c.Descripcion == listauno && c.Unidad == listauno1);
                listaMaterialesNuevos.RemoveAll(c => c.Descripcion == listauno && c.Unidad == listauno1);




                this.dataGridView1.Rows.Clear();

                foreach (var i in listaMateriales)
                {
                    dataGridView1.Rows.Add(i.Descripcion, i.Unidad, i.Precio, i.Cantidad, i.Total);
                    contador1 = contador1 + Convert.ToInt32(i.Total);
                }
                foreach (var i in listaMaterialesNuevos)
                {
                    dataGridView1.Rows.Add(i.Descripcion, i.Unidad, i.Precio, i.Cantidad, i.Total);
                    contador1 = contador1 + Convert.ToInt32(i.Total);
                }
                label22.Text = "Subtotal: RD" + contador1.ToString("C", nfi);
                label40.Text = "Total general: RD" + (contador1 + contador2).ToString("C", nfi);

            }
            catch (Exception)
            {
                
               
            }
        }

        private void button5_Click(object sender, EventArgs e)
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
            contador2 = 0;
            listaObrasNuevos.Add(new Obra_detalle
            {
                Descripcion = descrip,
                Precio = prec,
                Cantidad = cantidad,
                Unidad = unidad,
                Total = total,
            });

            foreach (var i in listaObras)
            {
                dataGridView2.Rows.Add(i.Descripcion, i.Unidad, i.Precio, i.Cantidad, i.Total);
                contador2 = contador2 + Convert.ToInt32(i.Total);
            }
           
               
            foreach (var i in listaObrasNuevos)
            {
                dataGridView2.Rows.Add(i.Descripcion, i.Unidad, i.Precio, i.Cantidad, i.Total);
                contador2 = contador2 + Convert.ToInt32(i.Total);
            }
            label25.Text = "Subtotal: RD" + contador2.ToString("C", nfi);
            label40.Text = "Total general: RD" + (contador1 + contador2).ToString("C", nfi);
            textBox13.Text = string.Empty;
            textBox14.Text = string.Empty;
            textBox15.Text = string.Empty;
            }
            catch (FormatException este)
            {
                MessageBox.Show("Verifique que todos los datos sean correctos ", "Presupuesto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (NullReferenceException es)
            {

                MessageBox.Show("Todos los campos son requeridos", "Presupuesto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal "+ex.Message, "Presupuesto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                contador2 = 0;
                var listauno = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                var listauno1 = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                var listauno2 = Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value.ToString());
                var listauno3 = Convert.ToInt32(dataGridView2.CurrentRow.Cells[3].Value.ToString());




                listaObras.RemoveAll(c => c.Descripcion == listauno && c.Unidad == listauno1);
                listaObrasNuevos.RemoveAll(c => c.Descripcion == listauno && c.Unidad == listauno1);


                this.dataGridView2.Rows.Clear();

                foreach (var i in listaObras)
                {
                    dataGridView2.Rows.Add(i.Descripcion, i.Unidad, i.Precio, i.Cantidad, i.Total);
                    contador2 += Convert.ToInt32(i.Total);
                }
                foreach (var i in listaObrasNuevos)
                {
                    dataGridView2.Rows.Add(i.Descripcion, i.Unidad, i.Precio, i.Cantidad, i.Total);
                    contador2 += Convert.ToInt32(i.Total);
                }
                label25.Text = "Subtotal: RD" + contador2.ToString("C", nfi);
                label40.Text = "Total general: RD" + (contador1 + contador2).ToString("C", nfi);

            }
            catch (Exception)
            {
                
             
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ambos a = new Ambos();
            a.ID = IdPropuesta;
            a.ShowDialog();
        }
        private void ejecutar(int id, string nombre, string telefono, string ocupacion)
        {

            Jefes.Add(new empleadosCA
            {
                IDs = id,
                Nombres = nombre,
                Telefonos = telefono,
                Ocupacions = ocupacion

            });

            this.dataGridView4.Rows.Clear();
            foreach (var r in Jefes)
            {
                this.dataGridView4.Rows.Add
                    (
                    r.IDs,
                    r.Nombres,
                    r.Ocupacions,
                    r.Telefonos
                    
                    );
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ingMixto c = new ingMixto();
            c.enviado += new ingMixto.enviar(ejecutar);
            c.ShowDialog();
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

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void reducirDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
              DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas eliminar los detalles?", "Eliminar", MessageBoxButtons.YesNo);
              if (dialogResult == DialogResult.Yes)
                  cambio = 1;
            {
            this.dataGridView1.Rows.Clear();
            this.dataGridView2.Rows.Clear();
            foreach (var i in listaMateriales)
            {
                dataGridView1.Rows.Add
                    (
                        i.Descripcion,
                        i.Unidad,
                        i.Precio = 0,
                        i.Cantidad = 0,
                        i.Total = 0
                    );
            }
            foreach (var i in listaMaterialesNuevos)
            {
                dataGridView1.Rows.Add
                    (
                        i.Descripcion,
                        i.Unidad,
                        i.Precio = 0,
                        i.Cantidad = 0,
                        i.Total = 0
                    );
            }
            foreach (var i in listaObras)
            {
                dataGridView2.Rows.Add
                    (
                        i.Descripcion,
                        i.Unidad,
                        i.Precio = 0,
                        i.Cantidad = 0,
                        i.Total = 0
                    );
            }
            foreach (var i in listaObrasNuevos)
            {
                dataGridView2.Rows.Add
                    (
                        i.Descripcion,
                        i.Unidad,
                        i.Precio = 0,
                        i.Cantidad = 0,
                        i.Total = 0
                    );
            }
            label40.Text = "Total general: RD$" + _db.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var listauno = dataGridView4.CurrentRow.Cells[0].Value.ToString();


                Jefes.RemoveAll(c => c.IDs == Convert.ToInt32(listauno));


                this.dataGridView4.Rows.Clear();

                foreach (var i in Jefes)
                {
                    dataGridView4.Rows.Add(i.IDs, i.Nombres, i.Ocupacions, i.Telefonos);

                }

            }
            catch (NullReferenceException es)
  {

                   MessageBox.Show("Algo ha salido mal " + es.Message, "Presupuesto",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                  catch(FormatException este)
                  {
                      MessageBox.Show("Algo ha salido mal " + este.Message, "Presupuesto",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                  }
                  catch (Exception ex)
                  {
                  MessageBox.Show("Algo ha salido mal " + ex.Message, "Presupuesto",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
    public class empleadosCA
    {
        public int IDs { get; set; }
        public string Nombres { get; set; }
        public string Telefonos { get; set; }
        public string Ocupacions { get; set; }
    }
}

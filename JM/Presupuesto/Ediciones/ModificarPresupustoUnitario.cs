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

namespace JM.Presupuesto.Ediciones
{
    public partial class ModificarPresupustoUnitario : Form
    {

        List<Materiales_detalle> listaMateriales = new List<Materiales_detalle>();
        public int Total { get; set; }
        List<Materiales_detalle> listaMaterialesNuevos = new List<Materiales_detalle>();
        List<Materiales_detalle> ListaCompleta = new List<Materiales_detalle>(); 
       // readonly List<Materiales_detalle> _materiales = new List<Materiales_detalle>();
        private IEnumerable<Materiales_detalle> _materiales;
        public int contador1 { get; set; }
        public int IDs { get; set; }
        public int cambio { get; set; }
       // public int Rebaja { get; set; }
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public string Tipo { get; set; }
        public int TotalGeneal { get; set; }
        public int TotalGeneralDB { get; set; }
        public string MyProperty { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        private string NombreCliente { get; set; }
        private Materiales_detalle _materialEditado;
        public string Telefono { get; set; }
        List<empleadosC> Jefes = new List<empleadosC>();
        //List<Materiales_detalle>materiales = new List<Materiales_detalle>();

        public ModificarPresupustoUnitario()
        {
            
        }

        public ModificarPresupustoUnitario(int _iD)
        {
            IDs = _iD;
            InitializeComponent();
          
            using (var db = new PresupuestoEntities5())
            {
                TotalGeneralDB = Convert.ToInt32(db.Presupuestos.Where(c => c.IdPresupuestos == _iD).Select(x => x.TotalGeneral).FirstOrDefault());
                
                var query = (from c in db.Materiales_detalle where c.IdPresupuesto == _iD select c);
               
               
                foreach (var i in query)
                {
                    ListaCompleta.Add(new Materiales_detalle
                    {
                        Descripcion = i.Descripcion,
                        Unidad = i.Unidad,
                        Cantidad = i.Cantidad,
                        Precio = i.Precio,
                        Total = i.Total
                    });
                  
                    contador1 =contador1+ Convert.ToInt32(i.Total);

                }
                //foreach (var i in listaMateriales)
                //{
                //    this.dataGridView3.Rows.Add(
                //        i.Descripcion,
                //        i.Unidad,
                //        i.Cantidad,
                //        Convert.ToInt32(i.Precio).ToString("C",nfi),
                //        Convert.ToInt32(i.Total).ToString("C",nfi)

                //        );
                //}
                //_materiales = listaMaterialesNuevos.Concat(listaMateriales);

                //foreach (var i in _materiales)
                //{
                //    ListaCompleta.Add(new Materiales_detalle
                //    {
                //        Descripcion = i.Descripcion,
                //        Unidad = i.Unidad,
                //        Cantidad = i.Cantidad,
                //        Precio = i.Precio,
                //        Total = i.Total
                        
                //    });
                        
                //}

                foreach (var i in ListaCompleta)
                {
                    dataGridView3.Rows.Add
                     (
                        i.Descripcion,
                        i.Unidad,
                        i.Cantidad,
                        "RD"+Convert.ToInt32(i.Precio).ToString("C", nfi),
                        "RD"+Convert.ToInt32(i.Total).ToString("C", nfi)


                     );
                }

                label27.Text = "Total: RD" + contador1.ToString("C", nfi);
              
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
               
              
                    var q = from t1 in db.Materiales_detalle
                            join t2 in db.Presupuestos on t1.IdPresupuesto equals t2.IdPresupuestos
                            where t2.IdPresupuestos == _iD && t1.Tipo == 1
                            select new { t1.Id, t1.Descripcion, t1.Unidad, t1.Precio, t1.Total, t1.Cantidad };


              



                    var ff = from tb1 in db.Presupuestos
                                join tb2 in db.Clientes on tb1.IdCliente equals tb2.id
                                where tb1.Estado == 1 && tb1.IdPresupuestos == _iD
                                select new { tb1.IdCliente, tb2.id, tb1.Descripcion, tb2.Nombre, tb2.Apellido, tb2.Telefono ,tb1.Direccion };


                    foreach (var i in ff)
                    {
                        NombreCliente = i.Nombre;
                        Telefono = i.Telefono;
                        Tipo = i.IdCliente.ToString();
                        Descripcion = i.Descripcion;
                        Direccion = i.Direccion;
                    }

                }
                //

                textBox6.Text = NombreCliente;
                textBox2.Text = Tipo;
                textBox5.Text = Telefono;
                textBox1.Text = Descripcion;
                textBox3.Text = Direccion;
                LLenarCombobox(comboBox1);
               
                LLenarDetalle(dataGridView3);
               
            }
        

        private void LLenarDetalle(DataGridView dataGridView3)
        {
            LLenarMaterialesDetalleLista();
        }

        private void Clientes(DataGridView dato, int id)
        {

            using (var db = new PresupuestoEntities5())
            {
                var query = from t1 in db.Abonadoes
                            join t2 in db.EmpleadoPresupuestoes on t1.Id equals t2.IdEmpleado
                            join t3 in db.Presupuestos on t2.IdPresupuesto equals t3.IdPresupuestos
                            join t4 in db.TipoEmpleadoes on t1.IdTipoEmpleado equals t4.IdTipoEmpleado
                            where t3.IdPresupuestos == id
                            select new { t1.Id, t1.Nombre , t1.Apellidos, t1.Telefono, t4.Tipo };


                foreach (var i in query)
                {
                    Jefes.Add(new empleadosC {
                        ID=i.Id,
                        Nombre= i.Nombre+" "+i.Apellidos,
                        Telefono=i.Telefono,
                        Ocupacion=i.Tipo

                    });

                }

                foreach (var item in Jefes)
                {
                    dato.Rows.Add
                     (
                         item.ID,
                         item.Nombre,
                         item.Telefono,
                         item.Ocupacion

                     );
                }

            }

        }

        private void ModificarPresupustoUnitario_Load(object sender, EventArgs e)
        {

        }
        public void LLenarCombobox(ComboBox combBox3)
        {
          
            try
            {
                using (var db = new PresupuestoEntities5())
                {
                    foreach (var item in db.Unidads.Where(c=>c.Tipo=="material"))
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

        public void LLenarMaterialesDetalleLista()

        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            intMateriales c = new intMateriales();
          
            c.ShowDialog();
        }
        //        private void ejecutar(int id, string nombre, string telefono, string ocupacion)
        //{
           
        //    Jefes.Add(new empleadosC { 
        //    ID=id,
        //    Nombre=nombre,
        //    Telefono=telefono,
        //    Ocupacion=ocupacion
        //    });
        //    this.dataGridView1.Rows.Clear();
        //    foreach (var i in Jefes)
        //    {
        //        dataGridView1.Rows.Add
        //            (
        //                i.ID,
        //                i.Nombre,
        //                i.Telefono,
        //                i.Ocupacion
        //            );
        //    }
            
        //}

                private void button13_Click(object sender, EventArgs e)
                {
                    try
                    {
                        nfi.CurrencyDecimalDigits = 2;
                        var descrip = textBox22.Text;
                        var prec = Convert.ToInt32(textBox21.Text);
                        var cantidad = Convert.ToInt32(textBox20.Text);
                        var unidad = comboBox1.SelectedItem.ToString();
                        var total = Convert.ToInt32(prec) * Convert.ToInt32(cantidad);
                        this.dataGridView3.Rows.Clear();
                        contador1 = 0;
                        ListaCompleta.Add(new Materiales_detalle
                        {
                            Descripcion = descrip,
                            Precio = prec,
                            Cantidad = cantidad,
                            Unidad = unidad,
                            Total = total,
                           
                        });

                        //foreach (var i in listaMateriales)
                        //{
                        //    dataGridView3.Rows.Add(
                        //        i.Descripcion, i.Unidad,
                        //        i.Cantidad, 
                        //        Convert.ToInt32(i.Precio).ToString("C",nfi), 
                        //        Convert.ToInt32(i.Total).ToString("C"),nfi
                        //    );
                           
                        //    contador1 = contador1 + Convert.ToInt32(i.Total);
                        //}

                        foreach (var i in ListaCompleta)
                        {
                            dataGridView3.Rows.Add(i.Descripcion,
                                i.Unidad, 
                                i.Cantidad,
                                "RD"+Convert.ToInt32(i.Precio).ToString("C", nfi),
                                "RD"+Convert.ToInt32(i.Total).ToString("C", nfi));
                                contador1 = contador1 + Convert.ToInt32(i.Total);
                        }

                        label27.Text = "Total: RD" + contador1.ToString("C", nfi);
                        textBox22.Text = string.Empty;
                        textBox21.Text = string.Empty;
                        textBox20.Text = string.Empty;
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

    public class ClientesC
    {
        public int ID { get; set; }
        public string Nombtre { get; set; }
        public string Telefono { get; set; }
        public string Tipo { get; set; }
    }
    public class empleadosC
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Ocupacion { get; set; }
    }

    private void button7_Click(object sender, EventArgs e)
    {
        using (var db = new PresupuestoEntities5())
        {

            try
            {
                //delete borro todo de la db materiales
                db.BorrarTodoMateriales_detalle(IDs);


                //inserto los materiales
                foreach (var i in ListaCompleta)
                {
                    db.guardar_materiales_listado(IDs, i.Descripcion, i.Unidad, i.Precio, i.Cantidad, i.Total, 1);
                }



                //inserto los materiales nuevos
                //foreach (var i in listaMaterialesNuevos)
                //{
                //    db.guardar_materiales_listado(IDs, i.Descripcion, i.Unidad, i.Precio, i.Cantidad, i.Total, 1);
                //}
                int a = 0;
                int b = 0;
                int d = 0;
                // listaMateriales.AddRange(listaMaterialesNuevos);


                foreach (var i in ListaCompleta)
                {
                    Total = Convert.ToInt32(i.Total) + Total;
                }

                a = b + d;
                foreach (var item in db.Presupuestos.Where(c => c.IdPresupuestos == IDs))
                {
                    TotalGeneralDB = +Convert.ToInt32(item.TotalGeneral);
                }

                //Actualizar presupuesto cabecera
                int nuevo = (a - TotalGeneralDB);

                // var tot = TotalGeneralDB - a;



                //foreach (var i in Jefes)
                //{
                //    db.SP_Borrrado_deEmpleados(IDs);
                //}

                //foreach (var i in Jefes)
                //{
                //    db.SP_insertado_deEmpleados(IDs, i.ID);
                //}

                DB.Presupuesto zz;
                zz = (from c in db.Presupuestos where c.IdPresupuestos == IDs select c).First();

                zz.Descripcion = textBox1.Text;
                zz.Direccion = textBox3.Text;
                zz.Estado = 1;
                zz.IdCliente = Convert.ToInt32(textBox2.Text);
                if (cambio == 1)
                {
                    zz.TotalGeneral = TotalGeneralDB;
                }
                else
                {
                    zz.TotalGeneral = Total;
                }
                db.SaveChanges();




                //////////
                MessageBox.Show("Presupuesto actualizado con exito");
                this.Close();

            }
            catch (Exception)
            {
                
            
            }

        }
    }

    private void button12_Click(object sender, EventArgs e)
    {
        contador1 = 0;
       
        var listauno = dataGridView3.CurrentRow.Cells[0].Value.ToString();
        var listau4 = dataGridView3.CurrentRow.Cells[4].Value.ToString();
        int currentIndex = this.dataGridView3.CurrentCell.RowIndex;
           /*  ListaCompleta.RemoveAt(currentIndex);*/

       
      //  var q2 = listaMateriales.Where(c => c.Descripcion == listauno);
        //foreach (var i in q)
        //{
        //    jj = jj + Convert.ToInt32(i.Total);
        //}
        //foreach (var i in q2)
        //{
        //    jj = jj + Convert.ToInt32(i.Total);
        //}

      





        ListaCompleta.RemoveAt(currentIndex);




        this.dataGridView3.Rows.Clear();

      
        foreach (var i in ListaCompleta)
        {
            dataGridView3.Rows.Add(
                i.Descripcion, 
                i.Unidad, 
                i.Cantidad, 
                Convert.ToInt32(i.Precio).ToString("C", nfi), 
                Convert.ToInt32(i.Total).ToString("C", nfi));

            contador1 = contador1 + Convert.ToInt32(i.Total);
        }
       
        label27.Text = "Total: RD" + (contador1).ToString("C", nfi);
    }

    private void reduccirDetalleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas eliminar los detalles?", "Eliminar", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
            
        {
            cambio = 1;
            this.dataGridView3.Rows.Clear();
            
            foreach (var i in ListaCompleta)
            {
                dataGridView3.Rows.Add
                    (
                        i.Descripcion,
                        i.Unidad,
                        i.Precio = 0,
                        i.Cantidad = 0,
                        i.Total = 0
                    );
            }

            label27.Text = "Total: RD" + TotalGeneralDB.ToString("C",nfi);

        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        try
        {
            //var listauno = dataGridView1.CurrentRow.Cells[0].Value.ToString();


            //Jefes.RemoveAll(c => c.ID == Convert.ToInt32(listauno));


            //this.dataGridView1.Rows.Clear();

            //foreach (var i in Jefes)
            //{
            //    dataGridView1.Rows.Add(i.ID, i.Nombre, i.Ocupacion, i.Telefono);

            //}

        }
        catch (NullReferenceException es)
        {

            MessageBox.Show("Algo ha salido mal " + es.Message, "Presupuesto",
           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (FormatException este)
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

    private void groupBox2_Enter(object sender, EventArgs e)
    {

    }

    private void button2_Click_1(object sender, EventArgs e)
    {


          try
            {
                _materialEditado = new Materiales_detalle();
                int precio = Convert.ToInt32(textBox21.Text);
                int cantidad = Convert.ToInt32(textBox20.Text);

                int currentIndex = this.dataGridView3.CurrentCell.RowIndex;

                int contador = 0;
                _materialEditado.Cantidad = cantidad;
                _materialEditado.Descripcion = textBox22.Text;
                _materialEditado.Precio = precio;
                _materialEditado.Cantidad = cantidad;
                _materialEditado.Unidad = comboBox1.SelectedItem.ToString();
                _materialEditado.Total = (precio * cantidad);

                ListaCompleta.RemoveAt(currentIndex);
                ListaCompleta.Insert(currentIndex, _materialEditado);



                this.dataGridView3.Rows.Clear();
                foreach (var item in ListaCompleta)
                {
                    this.dataGridView3.Rows.Add
                        (
                            item.Descripcion,
                            item.Unidad,
                           item.Cantidad,
                           "RD" + Convert.ToInt32(item.Precio).ToString("C", nfi),
                            "RD" + Convert.ToInt32(item.Total).ToString("C", nfi)
                        );
                    contador = Convert.ToInt32(item.Total + contador);
                }

               // _materialEditado = new Materiales_detalle();
               //this.dataGridView3.Rows.Clear();

               // int precio = Convert.ToInt32(textBox21.Text);
               // int cantidad = Convert.ToInt32(textBox20.Text);

               // int currentIndex = this.dataGridView3.CurrentCell.RowIndex;

               // _materialEditado.Cantidad = cantidad;
               // _materialEditado.Descripcion = textBox22.Text;
               // _materialEditado.Precio = precio;
               // _materialEditado.Cantidad = cantidad;
               // _materialEditado.Unidad = comboBox1.SelectedItem.ToString();
               // _materialEditado.Total = (precio * cantidad);
             
                //ListaCompleta.RemoveAt(currentIndex);
                //ListaCompleta.Insert(currentIndex, _materialEditado);

                //this.dataGridView3.Rows.Clear();
                //foreach (var item in ListaCompleta)
                // {
                //  dataGridView3.Rows.Add
                //  (
                //        item.Descripcion,
                //        item.Unidad,
                //        item.Cantidad,
                //        item.Precio,
                //        item.Total

                //    );
                //}
                label27.Text = "Total: RD" + contador.ToString("C", nfi);
                textBox22.Text = string.Empty;
                textBox21.Text = string.Empty;
                textBox20.Text = string.Empty;
            }
          catch (FormatException ex)
          {

              MessageBox.Show("Seleccione una fila para editarla", "Presupuesto",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          catch (NullReferenceException es)
          {

              MessageBox.Show("NullReferenceException : " + es.Message, "Presupuesto",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
         catch (Exception es)
          {

              MessageBox.Show("General: " + es.Message, "Presupuesto",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
          }


    }

    private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            var x0 = this.dataGridView3.CurrentRow.Cells[0].Value.ToString();

            textBox22.Text = this.dataGridView3.CurrentRow.Cells[0].Value.ToString();
            comboBox1.SelectedItem = this.dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox20.Text = this.dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox21.Text = ListaCompleta.First(c => c.Descripcion == x0).Precio.ToString();
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
        ArIng2 c = new ArIng2();
        c.enviado += new ArIng2.enviar(ejecutar);
        c.ShowDialog();
    }
    private void ejecutar(int dato1, string dato2, string dato3)
    {
        textBox2.Text = dato1.ToString();
        textBox6.Text = dato2;
         textBox5.Text = dato3;
    }


    }

}

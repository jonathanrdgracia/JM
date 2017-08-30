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
    public partial class Mixto_Ajustar : Form
    {
        public Mixto_Ajustar()
        {
            InitializeComponent();
        }
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public int ID_Que_Paso { get; set; }
        public int Ingreso { get; set; }//Es el resultado que se ingresa por textbox
        public int Patron { get; set; }// Es el resultado de restar lo que se introduce y todo el total
        public int TotalGeneral { get; set; }//Variable ayudadora
        public double Residuo { get; set; }
        public double Resultado { get; set; }
        public int totalGeneralDB { get; set; }
        public double ValorNuevo { get; set; }
        public double ValorNuevo2 { get; set; }
        public int q { get; set; }
        public double Total { get; set; }
        public double Variable { get; set; }// esta variable sera el total minimo y el total maximo sera total
        public double TotalGenetalEstatico { get; set; }
        public double Rebajado { get; set; }
        public int recorrido1 { get; set; }
        public int recorrido2 { get; set; }      


        int g1=0;
        int g2 = 0;
        public int Ingreso1 { get; set; }//Es el resultado que se ingresa por textbox
        public int Patron1 { get; set; }// Es el resultado de restar lo que se introduce y todo el total
        public int TotalGeneral1 { get; set; }//Variable ayudadora
        public double Residuo1 { get; set; }
        public double Resultado1 { get; set; }
        public int totalGeneralDB1 { get; set; }
   
        public double ValorNuevo3 { get; set; }
        public double Total1 { get; set; }
        public double Variable1 { get; set; }// esta variable sera el total minimo y el total maximo sera total
        public double TotalGenetalEstatico1 { get; set; }
        public double Rebajado1 { get; set; }

        private int Tipo;

        public int TIPO
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        List<Materiales_detalle> listaMateriales = new List<Materiales_detalle>();
        List<Obra_detalle> listaObra = new List<Obra_detalle>();

        private void Mixto_Ajustar_Load(object sender, EventArgs e)
        {
            var x= g1+g2;
           
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            using (var db = new PresupuestoEntities5())
            {
              //  TotalGeneral = Convert.ToInt32(db.Presupuestos.Where(c => c.IdPresupuestos == ID_Que_Paso).Select(c => c.TotalGeneral).FirstOrDefault());
               // TotalGeneral1 = TotalGeneral;

                  q = Convert.ToInt32(db.Presupuestos.Where(c => c.IdPresupuestos == ID_Que_Paso).Select(c => c.TotalGeneral).FirstOrDefault());
                       
                var f =from t1 in db.Clientes
                            join t2 in db.Presupuestos on t1.id equals t2.IdCliente
                            where t2.IdPresupuestos== ID_Que_Paso
                            select new { t1.Nombre,t1.Telefono,t2.FechaCreacion,t2.Descripcion,t2.TotalGeneral};

                  foreach (var o in f)
                  {
                      textBox1.Text = o.Descripcion;
                      textBox2.Text = o.Nombre;
                      textBox5.Text = o.Telefono;
                      textBox6.Text = o.FechaCreacion;
                      textBox7.Text =Convert.ToInt32(o.TotalGeneral).ToString("C",nfi);

                  }
                foreach (var item in db.SP_ListarObraMateriales(ID_Que_Paso, Tipo).OrderByDescending(c => c.IdPresupuesto))
                {
                    
                    listaMateriales.Add(new Materiales_detalle
                    {
                        Id = item.Id,
                        Descripcion = item.Descripcion,
                        Unidad = item.Unidad,
                        Precio = item.Precio,
                        Cantidad = item.Cantidad,
                        Total = item.Total

                    });
                    recorrido1 = recorrido1 + Convert.ToInt32(item.Total);
                    TotalGeneral += Convert.ToInt32(item.Total);
                }
                nfi.CurrencyDecimalDigits = 2;
                totalGeneralDB = TotalGeneral;
                label9.Text = TotalGeneral.ToString();
                g1 = TotalGeneral;
                label22.Text = "RD"+TotalGeneral.ToString("C", nfi);
              
                foreach (var item in listaMateriales)
                {
                    dataGridView3.Rows.Add
                        (
                        item.Id,
                        item.Descripcion,
                        item.Unidad,
                        item.Cantidad,
                       "RD"+Convert.ToInt32(item.Precio).ToString("C", nfi),
                       "RD"+Convert.ToInt32(item.Total).ToString("C", nfi)
                        );
                }

            }

            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.SP_ListarObraDetalle(ID_Que_Paso, Tipo).OrderByDescending(c => c.IdPresupuesto))
                {
                    listaObra.Add(new Obra_detalle
                    {
                        id = item.id,
                        Descripcion = item.Descripcion,
                        Unidad = item.Unidad,
                        Precio = item.Precio,
                        Cantidad = item.Cantidad,
                        Total = item.Total

                    });
                    TotalGeneral1 = TotalGeneral1 + Convert.ToInt32(item.Total);
                    recorrido2 = recorrido2 + Convert.ToInt32(item.Total);
                }
                nfi.CurrencyDecimalDigits = 2;
                totalGeneralDB1 = TotalGeneral1;
                label11.Text ="Total general: RD"+(TotalGeneral1+TotalGeneral).ToString("C", nfi);
                label8.Text = TotalGeneral1.ToString();
                g2 = TotalGeneral1;
                label6.Text = "RD"+TotalGeneral1.ToString("C", nfi);
               
                foreach (var item in listaObra)
                {
                    dataGridView1.Rows.Add
                        (
                        item.id,
                        item.Descripcion,
                        item.Unidad,
                        item.Cantidad,
                        "RD"+Convert.ToInt32(item.Precio).ToString("C", nfi),
                        "RD"+Convert.ToInt32(item.Total).ToString("C", nfi)
                        );

                }

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            recorrido1 = 0;
            try
            {
              
                 Ingreso = Convert.ToInt32(textBox3.Text);



            if (materialRadioButton2.Checked && comboBox1.SelectedItem.Equals("Afectar precio & total"))
            {
                /////////////////////////////////////////////////////////////////////////////////
                TotalGenetalEstatico = TotalGeneral;
                Patron = TotalGeneral + Ingreso;

                TotalGeneral = 0;


                int vuelta = 0;
                while (true)
                {
                    vuelta++;
                    foreach (var item in listaMateriales.OrderBy(c => c.Precio))
                    {



                        Residuo = Math.Ceiling(Convert.ToDouble(item.Precio) * (0.01));//El resultado de obtener el 1% del precio de la lista
                        Resultado = Convert.ToDouble(item.Precio) + Residuo;//Despues le resto el 1% al precio


                        foreach (var i in listaMateriales.Where(w => w.Precio == item.Precio))
                        {

                            i.Precio = Convert.ToInt32(Resultado);  //Reemplazo el precio por el nuevo
                            Total = Convert.ToDouble(i.Precio * i.Cantidad); //Calculo precio * por la cantidad
                            i.Total = Convert.ToInt32(Total); // le asigno al total el nuevo total :v

                            foreach (var z in listaMateriales)//Solo para sumar el total y asignarlo a 'TotalGeneral'
                            {
                                TotalGeneral += Convert.ToInt32(z.Total);
                            }

                            if (TotalGeneral >= Patron)
                            {
                                ValorNuevo2 = TotalGeneral;
                                goto Foo;
                            }
                            else
                            {
                                ValorNuevo = TotalGeneral;
                                TotalGeneral = 0;
                            }




                        }


                        Console.WriteLine("0.0 Total general: {0}, total: {1}", TotalGeneral.ToString(), Total.ToString());






                        Console.WriteLine("El precio mayor {0}, el precio menor {1}", Total.ToString(), Variable.ToString());

                    }
                    if (vuelta >= 1000)
                    {
                        goto Foo;
                    }
                }
            Foo:
                Rebajado = TotalGenetalEstatico - TotalGeneral;
                if (textBox3.Text != Rebajado.ToString())
                {

                    MessageBox.Show("El valor introducido se actualizará " + Rebajado.ToString("C", nfi));
                    textBox3.Text = (TotalGeneral - TotalGenetalEstatico).ToString();
                }

                label9.Text = TotalGeneral.ToString();
                g1 = TotalGeneral;
              
                label22.Text = "RD"+TotalGeneral.ToString("C", nfi);
                totalGeneralDB = TotalGeneral;


                dataGridView3.Rows.Clear();
                foreach (var item in listaMateriales.OrderByDescending(c => c.Precio))
                {
                    dataGridView3.Rows.Add
                    (
                        item.Id.ToString(),
                        item.Descripcion,
                        item.Unidad,
                        item.Cantidad,
                        "RD"+Convert.ToInt32(item.Precio).ToString("C", nfi),
                        "RD"+Convert.ToInt32(item.Total).ToString("C", nfi)
                    );

                }


                Ingreso = 0;
                Patron = 0;
                TotalGeneral = 0;


                //////////////////////////////////////////////////////////////////////////////////

            }
            else if (materialRadioButton2.Checked && comboBox1.SelectedItem.Equals("Afectar solo total general"))
            {
                //TotalGeneral = TotalGeneral + Ingreso;
                //totalGeneralDB = TotalGeneral+q;
                //label9.Text =TotalGeneral.ToString();
                //g1 = TotalGeneral;
                //label22.Text = TotalGeneral.ToString("C", nfi);
            }
            else if (materialRadioButton1.Checked && comboBox1.SelectedItem.Equals("Afectar solo total general"))
            {
                //TotalGeneral = TotalGeneral - Ingreso;

                //totalGeneralDB = TotalGeneral;
                //g1 = TotalGeneral;
                //label22.Text = TotalGeneral.ToString("C", nfi);
                //label9.Text = TotalGeneral.ToString();
            }
            else if (materialRadioButton1.Checked && comboBox1.SelectedItem.Equals("Afectar precio & total"))
            {

                TotalGenetalEstatico = TotalGeneral;
                Patron = TotalGeneral - Ingreso;

                TotalGeneral = 0;


                int vuelta = 0;
                while (true)
                {
                    vuelta++;
                    foreach (var item in listaMateriales.OrderByDescending(c => c.Precio))
                    {



                        Residuo = Math.Ceiling(Convert.ToDouble(item.Precio) * (0.01));//El resultado de obtener el 1% del precio de la lista
                        Resultado = Convert.ToDouble(item.Precio) - Residuo;//Despues le resto el 1% al precio


                        foreach (var i in listaMateriales.Where(w => w.Precio == item.Precio))
                        {

                            i.Precio = Convert.ToInt32(Resultado);  //Reemplazo el precio por el nuevo
                            Total = Convert.ToDouble(i.Precio * i.Cantidad); //Calculo precio * por la cantidad
                            i.Total = Convert.ToInt32(Total); // le asigno al total el nuevo total :v

                            foreach (var z in listaMateriales)//Solo para sumar el total y asignarlo a 'TotalGeneral'
                            {
                                TotalGeneral += Convert.ToInt32(z.Total);
                            }

                            if (TotalGeneral <= Patron)
                            {
                                ValorNuevo2 = TotalGeneral;
                                goto Foo;
                            }
                            else
                            {
                                ValorNuevo = TotalGeneral;
                                TotalGeneral = 0;
                            }




                        }


                        Console.WriteLine("0.0 Total general: {0}, total: {1}", TotalGeneral.ToString(), Total.ToString());





                        Console.WriteLine("El precio mayor {0}, el precio menor {1}", Total.ToString(), Variable.ToString());

                    }
                    if (vuelta >= 1000)
                    {
                        goto Foo;
                    }
                }
            Foo:
                Rebajado = TotalGenetalEstatico - TotalGeneral;
                if (textBox3.Text != Rebajado.ToString())
                {

                    MessageBox.Show("El valor se actualizará a " + Rebajado.ToString("C", nfi));
                    textBox3.Text = (TotalGenetalEstatico - TotalGeneral).ToString();
                }
                label9.Text = TotalGeneral.ToString();
                g1 = TotalGeneral;
                label22.Text = "RD"+TotalGeneral.ToString("C", nfi);
                totalGeneralDB = TotalGeneral;
               


                dataGridView3.Rows.Clear();
                foreach (var item in listaMateriales.OrderByDescending(c => c.Precio))
                {
                    dataGridView3.Rows.Add
                    (
                        item.Id.ToString(),
                        item.Descripcion,
                        item.Unidad,
                         item.Cantidad,
                        "RD" + Convert.ToInt32(item.Precio).ToString("C", nfi),
                        "RD" + Convert.ToInt32(item.Total).ToString("C", nfi)
                    );
               
                }


                








                Ingreso = 0;
                Patron = 0;
                TotalGeneral = 0;

            }
            else if (comboBox1.SelectedItem.Equals(""))
            {
                MessageBox.Show("Debes seleccionar un modo");

            }
            foreach (var i in listaMateriales)
            {
                recorrido1 = recorrido1 + Convert.ToInt32(i.Total);
            }
               
            label11.Text = "Total general: RD" + (recorrido1 + recorrido2).ToString("C", nfi);

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

        private void button2_Click(object sender, EventArgs e)
        {
            recorrido2 = 0;
            try
            {
               
                Ingreso1 = Convert.ToInt32(textBox4.Text);



                if (materialRadioButton3.Checked && comboBox2.SelectedItem.Equals("Afectar precio & total"))
                {
                    /////////////////////////////////////////////////////////////////////////////////
                    TotalGenetalEstatico1 = TotalGeneral1;
                    Patron1 = TotalGeneral1 + Ingreso1;

                    TotalGeneral1 = 0;

                    // Console.WriteLine("Total {0}, PAtron{1}", Total.ToString(), Patron.ToString());
                    int vuelta = 0;
                    while (true)
                    {
                        vuelta++;
                        foreach (var item in listaObra.OrderBy(c => c.Precio))
                        {



                            Residuo1 = Math.Ceiling(Convert.ToDouble(item.Precio) * (0.01));//El resultado de obtener el 1% del precio de la lista
                            Resultado1 = Convert.ToDouble(item.Precio) + Residuo1;//Despues le resto el 1% al precio
                            // item.Precio =Convert.ToInt32(Resultado);//asigno el valor restado

                            foreach (var i in listaObra.Where(w => w.Precio == item.Precio))
                            {

                                i.Precio = Convert.ToInt32(Resultado1);  //Reemplazo el precio por el nuevo
                                Total1 = Convert.ToDouble(i.Precio * i.Cantidad); //Calculo precio * por la cantidad
                                i.Total = Convert.ToInt32(Total1); // le asigno al total el nuevo total :v

                                foreach (var z in listaObra)//Solo para sumar el total y asignarlo a 'TotalGeneral'
                                {
                                    TotalGeneral1 += Convert.ToInt32(z.Total);
                                }

                                if (TotalGeneral1 >= Patron1)
                                {
                                    ValorNuevo3 = TotalGeneral1;
                                    goto Foo;
                                }
                                else
                                {
                                    ValorNuevo3 = TotalGeneral1;
                                    TotalGeneral1 = 0;
                                }




                            }
                            // Console.WriteLine("Total {0}, PAtron{1}",Total.ToString(),Patron.ToString());
                            //if (Total >= Patron)// para saber cuando ya parar
                            //{
                            //    Variable = Total;// variable tomara el total minimo
                            //    Console.WriteLine("Te quiero");
                            //    goto Foo;

                            // }




                            //foreach (var x in lista)
                            //{
                            //   ValorNuevo += Convert.ToDouble( item.Precio);
                            //   Console.WriteLine("Valor nuevo: {0}, el precio en la lista: {1}",ValorNuevo.ToString(),item.Precio.ToString());
                            //}





                        }
                        if (vuelta >= 1000)
                        {
                            goto Foo;
                        }
                    }
                Foo:
                    Rebajado1 = TotalGenetalEstatico1 - TotalGeneral1;
                    if (textBox4.Text != Rebajado1.ToString())
                    {

                        MessageBox.Show("El total se actualizará " + Rebajado1.ToString("C", nfi));
                        textBox4.Text = (TotalGeneral1 - TotalGenetalEstatico1).ToString();
                    }
                   
                    label8.Text = TotalGeneral1.ToString();
                    g2 = TotalGeneral1;

                   
                    label6.Text = "RD"+TotalGeneral1.ToString("C", nfi);
                    totalGeneralDB1 = TotalGeneral1;

                    // MessageBoxOptions.DefaultDesktopOnly();

                    dataGridView1.Rows.Clear();
                    foreach (var item in listaObra.OrderByDescending(c => c.Precio))
                    {
                        dataGridView1.Rows.Add
                        (
                            item.id.ToString(),
                            item.Descripcion,
                            item.Unidad,
                            item.Cantidad,
                            "RD" + Convert.ToInt32(item.Precio).ToString("C", nfi),
                            "RD" + Convert.ToInt32(item.Total).ToString("C", nfi)
                        );

                    }


                    Ingreso1 = 0;
                    Patron1 = 0;
                    TotalGeneral1 = 0;


                    //////////////////////////////////////////////////////////////////////////////////

                }
                else if (materialRadioButton3.Checked && comboBox2.SelectedItem.Equals("Afectar solo total general"))
                {
                    //TotalGeneral1 = TotalGeneral1 + Ingreso1;
                    //totalGeneralDB1 = TotalGeneral1;
                    //label8.Text = TotalGeneral1.ToString();
                    //g2 = TotalGeneral;
                    //label6.Text = TotalGeneral1.ToString("C", nfi);

                }
                else if (materialRadioButton4.Checked && comboBox2.SelectedItem.Equals("Afectar solo total general"))
                {
                    //TotalGeneral1 = TotalGeneral1 - Ingreso1;

                    //totalGeneralDB1 = TotalGeneral1;
                    //label8.Text = TotalGeneral1.ToString();
                    //g2 = TotalGeneral;
                    //label6.Text = TotalGeneral1.ToString("C", nfi);

                }
                else if (materialRadioButton4.Checked && comboBox2.SelectedItem.Equals("Afectar precio & total"))
                {
                    // foreach (var z in lista)//Solo para sumar el total y asignarlo a 'Atrapar'
                    // {
                    //     TotalGeneral += Convert.ToInt32(z.Total);

                    // }
                    TotalGenetalEstatico1 = TotalGeneral1;
                    Patron1 = TotalGeneral1 - Ingreso1;

                    TotalGeneral1 = 0;

                    // Console.WriteLine("Total {0}, PAtron{1}", Total.ToString(), Patron.ToString());
                    int vuelta = 0;
                    while (true)
                    {
                        vuelta++;
                        foreach (var item in listaObra.OrderByDescending(c => c.Precio))
                        {



                            Residuo1 = Math.Ceiling(Convert.ToDouble(item.Precio) * (0.01));//El resultado de obtener el 1% del precio de la lista
                            Resultado1 = Convert.ToDouble(item.Precio) - Residuo1;//Despues le resto el 1% al precio
                            // item.Precio =Convert.ToInt32(Resultado);//asigno el valor restado

                            foreach (var i in listaObra.Where(w => w.Precio == item.Precio))
                            {

                                i.Precio = Convert.ToInt32(Resultado1);  //Reemplazo el precio por el nuevo
                                Total1 = Convert.ToDouble(i.Precio * i.Cantidad); //Calculo precio * por la cantidad
                                i.Total = Convert.ToInt32(Total1); // le asigno al total el nuevo total :v

                                foreach (var z in listaObra)//Solo para sumar el total y asignarlo a 'TotalGeneral'
                                {
                                    TotalGeneral1 += Convert.ToInt32(z.Total);
                                }

                                if (TotalGeneral1 <= Patron1)
                                {
                                    ValorNuevo3 = TotalGeneral1;
                                    goto Foo;
                                }
                                else
                                {
                                    ValorNuevo3 = TotalGeneral1;
                                    TotalGeneral1 = 0;
                                }




                            }
                            // Console.WriteLine("Total {0}, PAtron{1}",Total.ToString(),Patron.ToString());
                            //if (Total >= Patron)// para saber cuando ya parar
                            //{
                            //    Variable = Total;// variable tomara el total minimo
                            //    Console.WriteLine("Te quiero");
                            //    goto Foo;

                            // }




                            //foreach (var x in lista)
                            //{
                            //   ValorNuevo += Convert.ToDouble( item.Precio);
                            //   Console.WriteLine("Valor nuevo: {0}, el precio en la lista: {1}",ValorNuevo.ToString(),item.Precio.ToString());
                            //}





                        }
                        if (vuelta >= 1000)
                        {
                            goto Foo;
                        }
                    }
                Foo:
                    Rebajado1 = TotalGenetalEstatico1 - TotalGeneral1;
                    if (textBox4.Text != Rebajado1.ToString())
                    {

                        MessageBox.Show("El valor introducido actualizará a: " + Rebajado1.ToString("C", nfi));
                        textBox4.Text = (TotalGenetalEstatico1 - TotalGeneral1).ToString();
                    }
                    g2 = TotalGeneral1;
                    label6.Text = "RD"+TotalGeneral1.ToString("C", nfi);
                    label8.Text = TotalGeneral1.ToString();
                  
                    totalGeneralDB1 = TotalGeneral1;

                    // MessageBoxOptions.DefaultDesktopOnly();

                    dataGridView1.Rows.Clear();
                    foreach (var item in listaObra.OrderByDescending(c => c.Precio))
                    {
                        dataGridView1.Rows.Add
                        (
                            item.id.ToString(),
                            item.Descripcion,
                            item.Unidad,
                            item.Cantidad,
                            "RD" + Convert.ToInt32(item.Precio).ToString("C", nfi),
                            "RD" + Convert.ToInt32(item.Total).ToString("C", nfi)
                        );
                       
                    }
                    Ingreso1 = 0;
                    Patron1 = 0;
                    TotalGeneral1 = 0;
                 
                }
                else if (comboBox2.SelectedItem.Equals(""))
                {
                    MessageBox.Show("Debes seleccionar un modo");

                }

                foreach (var i in listaObra)
                {
                    recorrido2 = recorrido2 + Convert.ToInt32(i.Total);
                }

                label11.Text = "Total general: RD" + (recorrido1 + recorrido2).ToString("C", nfi);

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
               
                var cantidadtotal = g1 + g2;
                using (var db = new PresupuestoEntities5())
                {
                    DB.Presupuesto pa;
                    pa = (from x in db.Presupuestos
                          where x.IdPresupuestos == ID_Que_Paso
                          select x).First();


                    var miId = Convert.ToInt32(db.Presupuestos.Where(c => c.IdPresupuestos == ID_Que_Paso).Select(x => x.TotalGeneral).FirstOrDefault());
                    if (!materialRadioButton4.Checked && !materialRadioButton2.Checked && !materialRadioButton1.Checked && !materialRadioButton3.Checked)
                    {
                        foreach (var i in listaObra)
                        {


                            DB.Obra_detalle materiales =
                                           (from c in db.Obra_detalle
                                            where c.IdPresupuesto == ID_Que_Paso && c.id == i.id
                                            select c).First();

                            materiales.Precio = i.Precio * 1;
                            materiales.Cantidad = i.Cantidad * 1;
                            materiales.Total = i.Cantidad * i.Precio;

                            db.SaveChanges();
                          

                        }


                        foreach (var i in listaMateriales)
                        {

                            DB.Materiales_detalle materialesd =
                                (from c in db.Materiales_detalle
                                 where c.IdPresupuesto == ID_Que_Paso && c.Id == i.Id

                                 select c).First();



                            materialesd.Precio = i.Precio * 1;
                            materialesd.Cantidad = i.Cantidad * 1;
                            materialesd.Total = i.Cantidad * i.Precio;

                            db.SaveChanges();
                          
                        }
                      
                       
                    }
                    else if (materialRadioButton1.Checked && comboBox1.SelectedItem.Equals("Afectar solo total general"))
                    {
                        int cantidad = Convert.ToInt32(textBox3.Text);
                        pa.TotalGeneral = pa.TotalGeneral - cantidad;

                        db.SaveChanges();
                       

                    }
                    else if (materialRadioButton2.Checked && comboBox1.SelectedItem.Equals("Afectar solo total general"))
                    {
                        int cantidad = Convert.ToInt32(textBox3.Text);
                        pa.TotalGeneral = pa.TotalGeneral + cantidad;

                        db.SaveChanges();
                      
                    }
                    else if (materialRadioButton4.Checked && comboBox2.SelectedItem.Equals("Afectar solo total general"))
                    {

                        int cantidad = Convert.ToInt32(textBox3.Text);
                        pa.TotalGeneral = pa.TotalGeneral - cantidad;

                        db.SaveChanges();
                       
                    }
                    else if (materialRadioButton3.Checked && comboBox2.SelectedItem.Equals("Afectar solo total general"))
                    {
                        int cantidad = Convert.ToInt32(textBox3.Text);

                        pa.TotalGeneral = pa.TotalGeneral + cantidad;

                        db.SaveChanges();
                        
                    }
                    else
                    {
                        foreach (var i in listaObra)
                        {


                            DB.Obra_detalle materiales =
                                           (from c in db.Obra_detalle
                                            where c.IdPresupuesto == ID_Que_Paso && c.id == i.id
                                            select c).First();

                            materiales.Precio = i.Precio * 1;
                            materiales.Cantidad = i.Cantidad * 1;
                            materiales.Total = i.Cantidad * i.Precio;

                            db.SaveChanges();


                        }

                       

                        foreach (var i in listaMateriales)
                        {

                            DB.Materiales_detalle materialesd =
                                (from c in db.Materiales_detalle
                                 where c.IdPresupuesto == ID_Que_Paso && c.Id == i.Id

                                 select c).First();



                            materialesd.Precio = i.Precio * 1;
                            materialesd.Cantidad = i.Cantidad * 1;
                            materialesd.Total = i.Cantidad * i.Precio;

                            db.SaveChanges();
                        }
                       

                        pa = (from x in db.Presupuestos
                              where x.IdPresupuestos == ID_Que_Paso
                              select x).First();
                   

                    }
                    MessageBox.Show("Presupuesto ajustado con exito");
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         }

        private void reducirDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas eliminar los detalles?", "Eliminar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.dataGridView3.Rows.Clear();
                this.dataGridView1.Rows.Clear();

                foreach (var item in listaMateriales)
                {
                    dataGridView3.Rows.Add
                        (
                         item.Id,
                        item.Descripcion,
                        item.Unidad,
                        item.Cantidad = 0,
                        item.Total = 0,
                        item.Precio = 0

                        );

                }
               
                foreach (var item in listaObra)
                {
                    dataGridView1.Rows.Add
                        (
                         item.id,
                        item.Descripcion,
                        item.Unidad,
                        item.Cantidad = 0,
                        item.Total = 0,
                        item.Precio = 0

                        );
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
  
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}

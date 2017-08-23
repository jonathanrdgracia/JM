using JM.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Presupuesto
{

    class Logica
    {
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        //public List<Obra_detalle> ListaObra = new List<Obra_detalle>();
        //public List<Obra_detalle> ListaMateriales = new List<Obra_detalle>();
        private int ID_Que_Paso { get; set; }
        private int Ingreso { get; set; }//Es el resultado que se ingresa por textbox
        private int Patron { get; set; }// Es el resultado de restar lo que se introduce y todo el total
        private int TotalGeneral { get; set; }//Variable ayudadora
        private double Residuo { get; set; }
        private double Resultado { get; set; }
        private int totalGeneralDB { get; set; }
        private double ValorNuevo { get; set; }
        private double ValorNuevo2 { get; set; }
        private double Total { get; set; }
        private double Variable { get; set; }// esta variable sera el total minimo y el total maximo sera total
        private double TotalGenetalEstatico { get; set; }
        private double Rebajado { get; set; }

       
        public void MetodoMateriales(List<Materiales_detalle> ListaMateriales, DataGridView DataGridView, TextBox textbox1, RadioButton materialRadioButton1, RadioButton materialRadioButton2, Label label, ComboBox comboBox1)
        {



            Ingreso = Convert.ToInt32(textbox1.Text);
            


            if (materialRadioButton2.Checked && comboBox1.SelectedItem.Equals("Afectar precio & total"))
            {
                /////////////////////////////////////////////////////////////////////////////////
                TotalGenetalEstatico = TotalGeneral;
                Patron = TotalGeneral + Ingreso;

                TotalGeneral = 0;

                // Console.WriteLine("Total {0}, PAtron{1}", Total.ToString(), Patron.ToString());
                int vuelta = 0;
                while (true)
                {
                    vuelta++;
                    foreach (var item in ListaMateriales.OrderByDescending(c => c.Precio))
                    {



                        Residuo = Math.Ceiling(Convert.ToDouble(item.Precio) * (0.01));//El resultado de obtener el 1% del precio de la lista
                        Resultado = Convert.ToDouble(item.Precio) + Residuo;//Despues le resto el 1% al precio
                        // item.Precio =Convert.ToInt32(Resultado);//asigno el valor restado

                        foreach (var i in ListaMateriales.Where(w => w.Precio == item.Precio))
                        {

                            i.Precio = Convert.ToInt32(Resultado);  //Reemplazo el precio por el nuevo
                            Total = Convert.ToDouble(i.Precio * i.Cantidad); //Calculo precio * por la cantidad
                            i.Total = Convert.ToInt32(Total); // le asigno al total el nuevo total :v

                            foreach (var z in ListaMateriales)//Solo para sumar el total y asignarlo a 'TotalGeneral'
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
                        // Console.WriteLine("Total {0}, PAtron{1}",Total.ToString(),Patron.ToString());
                        //if (Total >= Patron)// para saber cuando ya parar
                        //{
                        //    Variable = Total;// variable tomara el total minimo
                        //    Console.WriteLine("Te quiero");
                        //    goto Foo;

                        // }

                        Console.WriteLine("0.0 Total general: {0}, total: {1}", TotalGeneral.ToString(), Total.ToString());


                        //foreach (var x in lista)
                        //{
                        //   ValorNuevo += Convert.ToDouble( item.Precio);
                        //   Console.WriteLine("Valor nuevo: {0}, el precio en la lista: {1}",ValorNuevo.ToString(),item.Precio.ToString());
                        //}



                        Console.WriteLine("El precio mayor {0}, el precio menor {1}", Total.ToString(), Variable.ToString());

                    }
                    if (vuelta >= 1000)
                    {
                        goto Foo;
                    }
                }
            Foo:
                Rebajado = TotalGenetalEstatico - TotalGeneral;
                if (textbox1.Text != Rebajado.ToString())
                {

                    MessageBox.Show("El total se reducirá " + Rebajado.ToString("C", nfi));
                    textbox1.Text = (TotalGeneral - TotalGenetalEstatico).ToString();
                }

                label.Text = TotalGeneral.ToString("C", nfi);
                totalGeneralDB = TotalGeneral;
                // MessageBoxOptions.DefaultDesktopOnly();

                DataGridView.Rows.Clear();
                foreach (var item in ListaMateriales.OrderByDescending(c => c.Precio))
                {
                    DataGridView.Rows.Add
                    (
                        item.Id.ToString(),
                        item.Descripcion,
                        item.Unidad,
                        Convert.ToInt32(item.Precio).ToString("C", nfi),
                        item.Cantidad,
                        Convert.ToInt32(item.Total).ToString("C", nfi)
                    );

                }


                Ingreso = 0;
                Patron = 0;
                TotalGeneral = 0;


                //////////////////////////////////////////////////////////////////////////////////

            }
            else if (materialRadioButton2.Checked && comboBox1.SelectedItem.Equals("Afectar solo total general"))
            {
                TotalGeneral = TotalGeneral + Ingreso;
                totalGeneralDB = TotalGeneral;
                label.Text = TotalGeneral.ToString("C", nfi);
            }
            else if (materialRadioButton1.Checked && comboBox1.SelectedItem.Equals("Afectar solo total general"))
            {
                TotalGeneral = TotalGeneral - Ingreso;

                totalGeneralDB = TotalGeneral;
                label.Text = TotalGeneral.ToString("C", nfi);
            }
            else if (materialRadioButton1.Checked && comboBox1.SelectedItem.Equals("Afectar precio & total"))
            {
                // foreach (var z in lista)//Solo para sumar el total y asignarlo a 'Atrapar'
                // {
                //     TotalGeneral += Convert.ToInt32(z.Total);

                // }
                TotalGenetalEstatico = TotalGeneral;
                Patron = TotalGeneral - Ingreso;

                TotalGeneral = 0;

                // Console.WriteLine("Total {0}, PAtron{1}", Total.ToString(), Patron.ToString());
                int vuelta = 0;
                while (true)
                {
                    vuelta++;
                    foreach (var item in ListaMateriales.OrderByDescending(c => c.Precio))
                    {



                        Residuo = Math.Ceiling(Convert.ToDouble(item.Precio) * (0.01));//El resultado de obtener el 1% del precio de la lista
                        Resultado = Convert.ToDouble(item.Precio) - Residuo;//Despues le resto el 1% al precio
                        // item.Precio =Convert.ToInt32(Resultado);//asigno el valor restado

                        foreach (var i in ListaMateriales.Where(w => w.Precio == item.Precio))
                        {

                            i.Precio = Convert.ToInt32(Resultado);  //Reemplazo el precio por el nuevo
                            Total = Convert.ToDouble(i.Precio * i.Cantidad); //Calculo precio * por la cantidad
                            i.Total = Convert.ToInt32(Total); // le asigno al total el nuevo total :v

                            foreach (var z in ListaMateriales)//Solo para sumar el total y asignarlo a 'TotalGeneral'
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
                        // Console.WriteLine("Total {0}, PAtron{1}",Total.ToString(),Patron.ToString());
                        //if (Total >= Patron)// para saber cuando ya parar
                        //{
                        //    Variable = Total;// variable tomara el total minimo
                        //    Console.WriteLine("Te quiero");
                        //    goto Foo;

                        // }

                        Console.WriteLine("0.0 Total general: {0}, total: {1}", TotalGeneral.ToString(), Total.ToString());


                        //foreach (var x in lista)
                        //{
                        //   ValorNuevo += Convert.ToDouble( item.Precio);
                        //   Console.WriteLine("Valor nuevo: {0}, el precio en la lista: {1}",ValorNuevo.ToString(),item.Precio.ToString());
                        //}



                        Console.WriteLine("El precio mayor {0}, el precio menor {1}", Total.ToString(), Variable.ToString());

                    }
                    if (vuelta >= 1000)
                    {
                        goto Foo;
                    }
                }
            Foo:
                Rebajado = TotalGenetalEstatico - TotalGeneral;
                if (label.Text != Rebajado.ToString())
                {

                    MessageBox.Show("El total se reducirá " + Rebajado.ToString("C", nfi));
                    textbox1.Text = (TotalGenetalEstatico - TotalGeneral).ToString();
                }

                label.Text = TotalGeneral.ToString("C", nfi);
                totalGeneralDB = TotalGeneral;

                // MessageBoxOptions.DefaultDesktopOnly();

                DataGridView.Rows.Clear();
                foreach (var item in ListaMateriales.OrderByDescending(c => c.Precio))
                {
                    DataGridView.Rows.Add
                    (
                        item.Id.ToString(),
                        item.Descripcion,
                        item.Unidad,
                        Convert.ToInt32(item.Precio).ToString("C", nfi),
                        item.Cantidad,
                        Convert.ToInt32(item.Total).ToString("C", nfi)
                    );

                }











                Ingreso = 0;
                Patron = 0;
                TotalGeneral = 0;

            }
            else if (comboBox1.SelectedItem.Equals("")) { MessageBox.Show("Debes seleccionar un modo"); }


        }






        internal void mme(List<Materiales_detalle> listaMateriales)
        {
            throw new NotImplementedException();
        }
    }




}

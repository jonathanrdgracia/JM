using JM.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Presupuesto.Ediciones
{
    class Edition
    {
        List<Obra_detalle> lista = new List<Obra_detalle>();
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public int ID_Que_Paso { get; set; }
        public int Ingreso { get; set; }//Es el resultado que se ingresa por textbox
        public int Patron { get; set; }// Es el resultado de restar lo que se introduce y todo el total
        public int TotalGeneral { get; set; }//Variable ayudadora
        public double Residuo { get; set; }
        public double Resultado { get; set; }
        public double ValorNuevo { get; set; }
        public double ValorNuevo2 { get; set; }
        public double Total { get; set; }
        public double Variable { get; set; }// esta variable sera el total minimo y el total maximo sera total
        public double TotalGenetalEstatico { get; set; }
        public double Rebajado { get; set; }

        public void ReducirPrecioCantidad(DataGridView dataGridView3, TextBox textBox3, Label label22)
        {
            nfi.CurrencyDecimalDigits = 2;
            Ingreso = Convert.ToInt32(textBox3.Text);

            foreach (var z in lista)//Solo para sumar el total y asignarlo a 'Atrapar'
            {
                TotalGeneral += Convert.ToInt32(z.Total);

            }
            TotalGenetalEstatico = TotalGeneral;
            Patron = TotalGeneral - Ingreso;

            TotalGeneral = 0;

            // Console.WriteLine("Total {0}, PAtron{1}", Total.ToString(), Patron.ToString());
            while (true)
            {
                foreach (var item in lista.OrderByDescending(c => c.Precio))
                {



                    Residuo = Math.Ceiling(Convert.ToDouble(item.Precio) * (0.01));//El resultado de obtener el 1% del precio de la lista
                    Resultado = Convert.ToDouble(item.Precio) - Residuo;//Despues le resto el 1% al precio
                    // item.Precio =Convert.ToInt32(Resultado);//asigno el valor restado

                    foreach (var i in lista.Where(w => w.Precio == item.Precio))
                    {

                        i.Precio = Convert.ToInt32(Resultado);  //Reemplazo el precio por el nuevo
                        Total = Convert.ToDouble(i.Precio * i.Cantidad); //Calculo precio * por la cantidad
                        i.Total = Convert.ToInt32(Total); // le asigno al total el nuevo total :v

                        foreach (var z in lista)//Solo para sumar el total y asignarlo a 'TotalGeneral'
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
            }
        Foo:
            Rebajado = TotalGenetalEstatico - TotalGeneral;
            if (textBox3.Text != Rebajado.ToString())
            {

                MessageBox.Show("El total se reducirá " + Rebajado.ToString("C", nfi));
                textBox3.Text = (TotalGenetalEstatico - TotalGeneral).ToString();
            }

            label22.Text = TotalGeneral.ToString("C", nfi);

            // MessageBoxOptions.DefaultDesktopOnly();

            dataGridView3.Rows.Clear();
            foreach (var item in lista.OrderByDescending(c => c.Precio))
            {
                dataGridView3.Rows.Add
                (
                    item.id.ToString(),
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

        public void AumentarPrecioCantidad() { }
        public void ReducirTotalGeneral() { }
        public void AumentarTotalGeneral() { }

     
    }
}

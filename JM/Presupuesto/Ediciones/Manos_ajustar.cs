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

namespace JM.Presupuesto.Ediciones
{
    public partial class Manos_ajustar : Form
    {
        public Manos_ajustar()
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
        public double Total { get; set; }
        public double Variable { get; set; }// esta variable sera el total minimo y el total maximo sera total
        public double TotalGenetalEstatico { get; set; }
        public double Rebajado { get; set; }
        public int q { get; set; }
        private int Tipo;

        public int TIPO
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        List<Obra_detalle> lista = new List<Obra_detalle>();

        private void Materiales_ajustar_Load(object sender, EventArgs e)
        {


           
        }
        private void Manos_ajustar_Load(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

                q = Convert.ToInt32(db.Presupuestos.Where(c => c.IdPresupuestos == ID_Que_Paso).Select(x => x.TotalGeneral).FirstOrDefault());
                foreach (var item in db.SP_ListarObraDetalle(ID_Que_Paso, Tipo).Where(c => c.Tipo == 1).OrderByDescending(c => c.IdPresupuesto))
                {
                    lista.Add(new Obra_detalle
                    {
                        id = item.id,
                        Descripcion = item.Descripcion,
                        Unidad = item.Unidad,
                        Cantidad = item.Cantidad,
                        Precio = item.Precio,
                        Total = item.Total

                    });
                    TotalGeneral += Convert.ToInt32(item.Total);

                }
                nfi.CurrencyDecimalDigits = 2;
                totalGeneralDB = TotalGeneral;
                label22.Text = TotalGeneral.ToString("C", nfi);

                foreach (var item in lista)
                {
                    dataGridView3.Rows.Add
                        (
                        item.id,
                        item.Descripcion,
                        item.Unidad,
                        item.Cantidad,
                        "RD" + Convert.ToInt32(item.Precio).ToString("C", nfi),
                        "RD" + Convert.ToInt32(item.Total).ToString("C", nfi)
                        );
                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ingreso = Convert.ToInt32(textBox3.Text);



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
                    foreach (var item in lista.OrderBy(c => c.Precio))
                    {



                        Residuo = Math.Ceiling(Convert.ToDouble(item.Precio) * (0.01));//El resultado de obtener el 1% del precio de la lista
                        Resultado = Convert.ToDouble(item.Precio) + Residuo;//Despues le resto el 1% al precio
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
                if (textBox3.Text != Rebajado.ToString())
                {

                    MessageBox.Show("El valor se actualizará a " + Rebajado.ToString("C", nfi));
                    textBox3.Text = (TotalGeneral - TotalGenetalEstatico).ToString();
                }

                label22.Text = TotalGeneral.ToString("C", nfi);
                totalGeneralDB = TotalGeneral;
                // MessageBoxOptions.DefaultDesktopOnly();

                dataGridView3.Rows.Clear();
                foreach (var item in lista.OrderByDescending(c => c.Precio))
                {
                    dataGridView3.Rows.Add
                    (
                        item.id.ToString(),
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
                TotalGeneral = TotalGeneral + Ingreso;
                totalGeneralDB = TotalGeneral;
                label22.Text = TotalGeneral.ToString("C", nfi);
            }
            else if (materialRadioButton1.Checked && comboBox1.SelectedItem.Equals("Afectar solo total general"))
            {
                TotalGeneral = TotalGeneral - Ingreso;

                totalGeneralDB = TotalGeneral;
                label22.Text = TotalGeneral.ToString("C", nfi);
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

                label22.Text = TotalGeneral.ToString("C", nfi);
                totalGeneralDB = TotalGeneral;

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
            else if (comboBox1.SelectedItem.Equals(""))
            {
                MessageBox.Show("Debes seleccionar un modo");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas Valancear este presupuesto?", "Presupuesto", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (var db = new PresupuestoEntities5())
                    {
                        DB.Presupuesto pa;
                        pa = (from x in db.Presupuestos
                              where x.IdPresupuestos == ID_Que_Paso
                              select x).First();
                        pa.TotalGeneral = totalGeneralDB;
                        db.SaveChanges();

                        foreach (var i in lista)
                        {
                            DB.Obra_detalle materiales =
                                        (from c in db.Obra_detalle
                                         where c.IdPresupuesto == ID_Que_Paso && c.id == i.id
                                         select c).First();

                            materiales.Precio = i.Precio * 1;
                            materiales.Cantidad = i.Cantidad * 1;
                            materiales.Total = i.Cantidad * i.Precio;

                            db.SaveChanges();
                            MessageBox.Show("Presupuesto modificado con exito");
                        }

                    }

                }
                catch (Exception)
                {


                }


            }
            else if (dialogResult == DialogResult.No)
            {

            }


          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas eliminar los detalles?", "Eliminar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.dataGridView3.Rows.Clear();
                foreach (var item in lista)
                {
                    dataGridView3.Rows.Add
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JM.DB;
using System.Windows.Forms;
using System.Globalization;

namespace JM.Proyecto
{
    public partial class ModificarProyecto : Form
    {
        public string Nombtre { get; set; }
        public string Telefono { get; set; }
        List<DB.Abonado> ListadoEmpleado = new List<DB.Abonado>();
        List<DB.Abonado> ListadoEmpleado2 = new List<DB.Abonado>();
        public ModificarProyecto()
        {
            InitializeComponent();
        }
        private int idProyecto;
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public int IdProtecto
        {
            get { return idProyecto; }
            set { idProyecto = value; }
        }
        
        private void ModificarProyecto_Load(object sender, EventArgs e)
        {
          
            
            nfi.CurrencyDecimalDigits = 2;
            
            using(var db = new PresupuestoEntities5())
            {
                    var query = db.SP_ModificarProyectoCliente(idProyecto).FirstOrDefault();
                    Nombtre = query.Nombre;
                    Telefono = query.Telefono;

                    textBox3.Text = Nombtre;
                    textBox4.Text = Telefono;
                    foreach (var i in db.SP_ModificarProyecto(idProyecto))
                    {
                        textBox1.Text = i.DescripcionProyecto;
                        textBox7.Text = i.CantidadPresupuestada.ToString();
                        textBox2.Text = i.Direccion;
                        ListadoEmpleado.Add(new DB.Abonado
                        {
                            Id = i.IdEmpleado,
                            Nombre = i.Nombre,
                            Telefono = i.Telefono,
                            TipoEmpleado = i.TipoEmpleado,
                            Lugar = i.direcccionempleado
                        });
                    }

                    overCargar(ListadoEmpleado);
              

            }
        }

        private void overCargar(List<DB.Abonado> ListadoEmpleado)
        {
            foreach (var i in ListadoEmpleado)
            {

                this.dataGridView1.Rows.Add
                    (
                        i.Id,
                        i.Nombre,
                        i.Telefono,
                        i.TipoEmpleado,
                        i.Lugar
                    );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Proyecto.SubForms.ListarEmpleados c = new Proyecto.SubForms.ListarEmpleados();

            c.enviado2 += new Proyecto.SubForms.ListarEmpleados.enviar2(ejecutar);
            c.ShowDialog();
        }
        private void ejecutar(List<DB.Abonado> lista)
        {

            foreach (var i in lista)
            {
                this.ListadoEmpleado2.Add
                    (new DB.Abonado{
                    Id= i.Id,
                    Nombre=i.Nombre,
                    Telefono= i.Telefono,
                    TipoEmpleado= i.TipoEmpleado,
                    Lugar= i.Lugar
                    });    
            }
            this.dataGridView1.Rows.Clear();
            overCargar(ListadoEmpleado);
            foreach (var i in ListadoEmpleado2)
            {
                 this.dataGridView1.Rows.Add
                    (
                    i.Id,
                    i.Nombre,
                    i.Telefono,
                    i.TipoEmpleado,
                    i.Lugar
                    );    
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                 DB.ProyectoConPresupuesto PP;
                DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas modificar este proyecto?", "Proyecto", MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.Yes)
                 {
                     using (var db = new PresupuestoEntities5())
                     {
                         PP = (from c in db.ProyectoConPresupuestoes
                             where c.IdProyecto == idProyecto
                             select c).First();

                         PP.Descripcion = textBox1.Text;
                         PP.Direccion = textBox2.Text;
                         db.SaveChanges();


                         foreach (var i in ListadoEmpleado2)
                         {
                             DB.Proyecto_detalle PD = new Proyecto_detalle
                             {
                                 IdEmpleado = i.Id,
                                 IdProyecto = idProyecto
                             };
                             db.Proyecto_detalle.Add(PD);
                             db.SaveChanges();
                         }
                     }
                     MessageBox.Show("Proyecto modificado con exito");
                     this.Close();

                 }
                 else if (dialogResult == DialogResult.No)
                 {

                 }

            }
            catch (Exception)
            {
                
               
            }
            
           
            
         }

    }
}

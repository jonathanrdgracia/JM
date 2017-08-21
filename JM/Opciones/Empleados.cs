﻿using JM.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Opciones
{
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Llenar()
        {
           
            this.dataGridView1.Rows.Clear();
            using (PresupuestoEntities5 db = new PresupuestoEntities5())
            {
                
                //   var query=db.ProyectoSinPresupuestoes.SqlQuery("Select * from ProyectoSinPresupuesto where Estado=1");

                foreach (var item in db.Abonadoes.Where(c => c.Estado == 0).OrderByDescending(c => c.Id))
                {
                        dataGridView1.Rows.Add(
                        item.Id,
                        item.Nombre+ " "+item.Apellidos,
                        item.Telefono,
                        item.TipoEmpleado
                        );
                }

             


         
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                PresupuestoEntities5 db = new PresupuestoEntities5();
                DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas restaurar este empleado?", "Empleado", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    int _id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

                    var c = (from x in db.Abonadoes
                             where x.Id == _id
                             select x).First();
                    c.Estado = 1;
                    db.SaveChanges();
                    Llenar();
                }
                else if (dialogResult == DialogResult.No)
                {

                }

            }
            catch (Exception)
            {
                
               
            }
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            Llenar();
        }
    }
}

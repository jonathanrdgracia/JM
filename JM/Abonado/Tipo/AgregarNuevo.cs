using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Abonado.Tipo
{
    public partial class AgregarNuevo : Form
    {
        public AgregarNuevo()
        {
            InitializeComponent();
        }

        private void AgregarNuevo_Load(object sender, EventArgs e)
        {
            ActualizarDato(this.dataGridView1);
        }

        public void ActualizarDato(DataGridView data)
        {
            data.Rows.Clear();
            using (var db = new DB.PresupuestoEntities5())
            {
                foreach (var item in db.TipoEmpleadoes.OrderByDescending(c=>c.IdTipoEmpleado))
                {
                    data.Rows.Add
                        (
                            item.IdTipoEmpleado,
                            item.Tipo
                        );
                }
            }

        }

        public void agregar(TextBox t)
        {
            using (var db = new DB.PresupuestoEntities5())
            {
                DB.TipoEmpleado tipo = new DB.TipoEmpleado();
                tipo.Tipo = t.Text;

                db.TipoEmpleadoes.Add(tipo);
                db.SaveChanges();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Debes ingresar el valor correspondiente");
                }
                else
                {

                    agregar(textBox3);
                    this.textBox3.Text = "";
                    ActualizarDato(dataGridView1);
                }

            }
            catch (Exception)
            {
                    
             
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

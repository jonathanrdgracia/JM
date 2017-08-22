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
using JM.Presupuesto;

namespace JM.Unidad
{
    public partial class AgregarUnidad : Form
    {
        public delegate void enviar(ComboBox dato);
        public event enviar enviado;

        PresupuestoMateriales pm = new PresupuestoMateriales();
       
        public AgregarUnidad()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var tipo = "";

            try
            {
                if (string.IsNullOrEmpty(textBox6.Text))
                {
                    MessageBox.Show("Todos los campos son requeridos", "Unidad",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    using (var db = new PresupuestoEntities5())
                    {

                        if (materialRadioButton1.Checked)
                        {
                            tipo = "material";
                        }
                        else if (materialRadioButton2.Checked)
                        {
                            tipo = "mano";
                        }
                        else
                        {
                            MessageBox.Show("Debes seleccionar un tipo de unidad");
                        }

                        DB.Unidad u = new DB.Unidad
                        {
                            Tipo = tipo,
                            Unidad1 = textBox6.Text
                        };

                        db.Unidads.Add(u);
                        db.SaveChanges();
                        MessageBox.Show("Unidad agregada con exito");
                        this.Close();
                    }
                    textBox6.Text = "";
                    pm.LLenarCombobox(pm.comboBox3, "material");
                    // uni.LLenarCombobox(uni.comboBox3, "material");
                    // ----------------------------------------------
                 


                    this.Close();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Intentelo de nuevo"); ;
            }
        }

        private void AgregarUnidad_Load(object sender, EventArgs e)
        {

        }
    }
}

using JM.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.ConceptoDePagos
{
    public partial class Nuevo : Form
    {
        List<Pago_Concepto> pagosConceptos = new List<Pago_Concepto>();
        Conceptos cp = new Conceptos();
        public Nuevo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Nuevo_Load(object sender, EventArgs e)
        {
            Conceptos cp = new Conceptos();
            cp.LlenarListadoConcepto(dataGridView1,pagosConceptos);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {

           
            if (ValidateChildren(ValidationConstraints.Enabled))
            {



                using (var db = new PresupuestoEntities5())
                {

                    var concepto = textBox1.Text;
                    var valor = Convert.ToInt32(textBox2.Text);

                    var query = (
                        from c in db.Pago_Concepto
                        where c.Concepto == concepto
                        select c.Concepto).FirstOrDefault();

                    // MessageBox.Show(query.ToString());

                    if (query == null)
                    {
                        // b = true;
                        //no existe ese datio en la DB
                        Pago_Concepto p_c = new Pago_Concepto
                        {
                            Concepto = concepto,
                            valor =valor
                        };

                        db.Pago_Concepto.Add(p_c);
                        db.SaveChanges();
                        MessageBox.Show("Concepto agregado correctamente");
                        dataGridView1.Rows.Clear();
                        cp.LlenarListadoConcepto(dataGridView1,pagosConceptos);
                        textBox1.Text = "";
                        textBox2.Text = "";

                    }
                    else
                    {
                        //   b = false;
                        MessageBox.Show("Este concepto ya existe");
                    }







                }
            }

            }
            catch (Exception)
            {

                MessageBox.Show("Vuelva a intentarlo");
            }
         }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) )
            {
                //e.Cancel = true;
              //  textBox1.Focus();
                errorProvider1.SetError(textBox1, "Ingrese el concepto");
            }
            else 
            {
              //  e.Cancel = false;
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
              //  e.Cancel = true;
               // textBox2.Focus();
                errorProvider2.SetError(textBox2, "Ingrese el valor");
            }
            else
            {
               // e.Cancel = false;
                errorProvider2.SetError(textBox2, null);
            }

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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


            }
         
            


        
    
}

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
    public partial class Modificar_concepto : Form
    {
        List<Pago_Concepto> pagosConceptos = new List<Pago_Concepto>();
        Conceptos c = new Conceptos();
        List<Conceptos> ConceptosLista = new List<Conceptos>();

        public Modificar_concepto()
        {
            InitializeComponent();
        }

        int ID;
        private void Modificar_concepto_Load(object sender, EventArgs e)
        {

            c.LlenarListadoConcepto(dataGridView1,pagosConceptos);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
               // e.Cancel = true;
               // textBox1.Focus();
                errorProvider1.SetError(textBox1, "Seleccione el concepto");
            }
            else
            {
               // e.Cancel = false;
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                //e.Cancel = true;
                //textBox2.Focus();
                errorProvider2.SetError(textBox2, "Seleccione concepto");
            }
            else
            {
              //  e.Cancel = false;
                errorProvider2.SetError(textBox2, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            try
            {

                if (ValidateChildren(ValidationConstraints.Enabled)) // se pone en el boton
                {
                    var codigo = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());




                    using (var db = new PresupuestoEntities5())
                    {
                        Pago_Concepto s = (from x in db.Pago_Concepto
                                           where x.idConceptoPago == codigo
                                           select x).First();

                        s.Concepto = textBox1.Text;
                        s.valor = Convert.ToInt32(textBox2.Text);
                        db.SaveChanges();

                        this.dataGridView1.Rows.Clear();
                        pagosConceptos.Clear();
                        c.LlenarListadoConcepto(dataGridView1,pagosConceptos);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        

                     }
                }
                else
                {
                    MessageBox.Show("Todos los campos son requeridos");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Vuelva a intentarlo"+ ex.Message);
            }
       

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
           

           
           


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            ID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

            var query = pagosConceptos.Where(c => c.idConceptoPago == ID).Select(c => c.valor).First().ToString();

          //  var valor = x2.Substring(1,x2.Length-1);
            textBox1.Text = x1;
            textBox2.Text = query;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show ("Favor seleccionar una fila "+ ex.Message);
            }
        }
    }
}

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

namespace JM.Modificar
{
    public partial class Modificar_abonado : Form
    {
        int id = 0;
        Abonados a = new Abonados();

        public Modificar_abonado()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modificar_abonado_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            a.llenarAbonado(dataGridView1);
          
            a.LLenarComboxTipoEmpleado(comboBox1);
        }
       

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.Rows.Clear();
            var x = "%" + textBox6.Text + "%";

            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.Filtrar_Abonado(x).OrderByDescending(c => c.Id))
                {
                    dataGridView1.Rows.Add(
                        item.Id,
                        item.Nombre,
                        item.Apellidos,
                        item.Telefono,
                        item.TipoEmpleado,
                        item.Fecha_inscripcion,
                        item.Lugar
                        );
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var x2 = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            var x3 = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            var x4 = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            var x5 = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            var x6 = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();

            id = Convert.ToInt32(x0);
            textBox14.Text = x3; 
            textBox1.Text = x1;
            textBox2.Text = x2;
          //  textBox3.Text = x4;
           
            textBox4.Text = x5;
            textBox5.Text = x6;
             
            }
            catch (Exception)
            {

                MessageBox.Show("Favor seleccionar una fila");
            }



        }

        private void textBox14_KeyUp(object sender, KeyEventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DB.Abonado c;
                using (var db = new PresupuestoEntities5())
                {

                var tipo=comboBox1.SelectedItem.ToString();
                var q = db.TipoEmpleadoes.Where(x => x.Tipo.Equals(tipo)).Select(x => x.IdTipoEmpleado).FirstOrDefault();
               
                    c = (from x in db.Abonadoes
                         where x.Id == id
                         select x).First();


                    c.Apellidos = textBox2.Text;
                    c.Nombre = textBox1.Text;
                    c.TipoEmpleado = tipo;
                    c.Fecha_inscripcion = textBox4.Text;
                    c.Lugar = textBox5.Text;
                    c.Telefono = textBox14.Text;
                    c.IdTipoEmpleado = q;

                    db.SaveChanges();
                    MessageBox.Show("Empleado modificado con exito");
                    this.dataGridView1.Rows.Clear();
                    a.llenarAbonado(dataGridView1);
                    this.Close();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Verifique que todos los campos esten llenos");
            }

           


        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Nuevo_Abonado : Form
    {

        Abonado.Tipo.TipoClass tipo = new Abonado.Tipo.TipoClass();
        int px, py;
         Boolean mover;

        public Nuevo_Abonado()
        {
            
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
           
        
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
         
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Nuevo_Abonado_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Width = 230;
            dateTimePicker1.Height = 55;
            tipo.LlenarTipo(comboBox1);
           
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            px = e.X;
            py = e.Y;
            mover = true;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {

            mover = false;
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Location = this.PointToScreen(new Point(System.Windows.Forms.Control.MousePosition.X - this.Location.X - px, System.Windows.Forms.Control.MousePosition.Y - this.Location.Y - py));
            }
        }

    

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Location = this.PointToScreen(new Point(System.Windows.Forms.Control.MousePosition.X - this.Location.X - px, System.Windows.Forms.Control.MousePosition.Y - this.Location.Y - py));
            }
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            mover = false;
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Location = this.PointToScreen(new Point(System.Windows.Forms.Control.MousePosition.X - this.Location.X - px, System.Windows.Forms.Control.MousePosition.Y - this.Location.Y - py));
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox2.Text.ToString().Length == 10)
            {
                var x = Convert.ToInt64(textBox2.Text);
                var y = String.Format("{0:(###) ###-####}", x);
                textBox2.Text = Convert.ToString(y);
            }
            else
            {
                //Eror provider
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new PresupuestoEntities5())
                {
                    var nombre = textBox14.Text;
                    var apellidos = textBox1.Text;
                    var telefono = textBox2.Text;
                    var cedula = comboBox1.Text;
                    var fecha = dateTimePicker1.Text;
                    var direccion = textBox5.Text;
                    var tipo = comboBox1.SelectedItem.ToString();

                    var q = db.TipoEmpleadoes.Where(c => c.Tipo.Equals(tipo)).Select(x => x.IdTipoEmpleado).FirstOrDefault();


                    DB.Abonado a = new DB.Abonado
                    {
                        Nombre = nombre,
                        Apellidos = apellidos,
                        Telefono = telefono,
                        TipoEmpleado = cedula,
                        Fecha_inscripcion = fecha,
                        Lugar = direccion,
                        Estado = 1,
                        IdTipoEmpleado = Convert.ToInt32(q)

                    };


                    db.Abonadoes.Add(a);
                    db.SaveChanges();

                    textBox14.Text = string.Empty;
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    comboBox1.Text = string.Empty;
                    dateTimePicker1.Text = string.Empty; 
                    textBox5.Text=string.Empty;
                    comboBox1.SelectedItem = string.Empty;
                    MessageBox.Show("Empleado agregado con exito");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Intentelo de nuevo");
            }


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

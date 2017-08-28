using JM.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Empresa
{
    public partial class EditarParametro : Form
    {
        public string Nombre { get; set; }
        public string RNC { get; set; }
        public string  Telefono { get; set; }
        public string Direccion { get; set; }
        public Image Imagen { get; set; }
        public string web { get; set; }
        public string Correo { get; set; }

        private int logica;

        public int Logica
        {
            get { return logica; }
            set { logica = value; }
        }
        string fillName;
        public EditarParametro()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
    
            }
        private void button2_Click(object sender, EventArgs e)
        {
          
           
            //using(var db=new PresupuestoEntities5())
            //{
            //    DB.Compania compa = new Compania 
            //    {
            //       Logo=BinaryConvertToImage(pictureBox1.Image),
            //       Nombre="holas"
                    
            //    };
            //    db.Companias.Add(compa);
            //     db.SaveChanges();
              
            //}
        }

        private void EditarParametro_Load(object sender, EventArgs e)
        {
            using (PresupuestoEntities5 db = new PresupuestoEntities5())
            {
                var query = (from c in db.Companias
                            select new { c.Nombre, c.Telefono, c.RNC, c.Logo,c.Direccion,c.Web,c.Correo }).FirstOrDefault();

                textBox22.Text = query.Nombre;
                textBox1.Text = query.Direccion;
                textBox3.Text = query.RNC;
                textBox2.Text = query.Telefono;
                pictureBox1.Image = ConvertBinaryToImage(query.Logo);
                textBox4.Text = query.Web;
                textBox5.Text = query.Correo;

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg; *.png", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fillName = ofd.FileName;
                    pictureBox1.Image = Image.FromFile(fillName);
                    logica = 1;
                }

            }
        }
        //pictureBox1.ImageLocation = openFileDialog1.FileName;


       public Image ConvertBinaryToImage(byte[] data) 
        {
            using (MemoryStream ms = new MemoryStream(data))
            {

                return Image.FromStream(ms);
            }
        }

       public byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            try
            {
                 Nombre = textBox22.Text;
                Direccion = textBox1.Text;
                Telefono = textBox2.Text;
                RNC = textBox3.Text;
                Imagen= pictureBox1.Image;
                web = textBox4.Text;
                Correo = textBox5.Text;
                SaveImage(Nombre,Direccion,Telefono,RNC,Imagen,web,Correo);
                MessageBox.Show("Datos actualizados correctamente");
                this.Close();
            }
            catch (NullReferenceException es)
            {

                MessageBox.Show("Todos los campos son requeridos", "Presupuesto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException este)
            {
                MessageBox.Show("Verifique que todos los datos sean correctos ", "Presupuesto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal " + ex.Message, "Presupuesto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private async void SaveImage(string nombre,string direccion,string telefono,string rnc, Image i,string web,string correo) 
        {
            using(PresupuestoEntities5 compa = new PresupuestoEntities5())
            
            {
                Compania pic;
                pic = (from c in compa.Companias
                       select c).FirstOrDefault();

                pic.Nombre = nombre;
                if (logica==1)
                {
                  pic.Logo = ConvertImageToBinary(i);
                }
                pic.Direccion = direccion;
                pic.RNC = rnc;
                pic.Telefono = telefono;
                pic.Correo = correo;
                pic.Web = web;
                await compa.SaveChangesAsync();
            
            }
        }

        public void CargarDatosCompania(string Nombre) 
        {
            using (PresupuestoEntities5 db = new PresupuestoEntities5()) 
            {
                var query = (from c in db.Companias
                            where c.Id == 1
                            select new { c.Nombre, c.Telefono,c.RNC,c.Logo }).FirstOrDefault();

                Nombre = query.Nombre;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

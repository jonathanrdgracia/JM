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

namespace JM.usuario
{
    
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
       
        public string _usuario { get; set; }
        public string _nuevapass2 { get; set; }
        public string _nuevapass1 { get; set; }
        private int logica;

        public int Logica
        {
            get { return logica; }
            set { logica = value; }
        }
        string fillName;

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {

                _usuario = this.textBox3.Text;
                _nuevapass1 = this.textBox2.Text;
                _nuevapass2 = this.textBox1.Text;

                try
                {

                    if (string.IsNullOrEmpty(_nuevapass2) || string.IsNullOrEmpty(_nuevapass1) || string.IsNullOrEmpty(_usuario))
                    {
                        MessageBox.Show("Todos los campos son requeridos", "Usuario",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (!_nuevapass1.Equals(_nuevapass2))
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Contraseña",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Imagen = pictureBox1.Image;
                        var x = (from c in db.Usuarios
                          
                            select c).First();
                        x.Pass = _nuevapass1;
                        x.Pass2 = _nuevapass1;
                        x.Usuario1 = _usuario;
                        db.SaveChanges();
                        if (logica==1)
                        {
                            SaveImage(Imagen);
                        }
                        MessageBox.Show("Usuario actualizado correctamente");
                        this.Close();
                    }

                }
                catch (Exception v)
                {
                    MessageBox.Show("Ha ocurrido un error: "+v.Message, "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            //DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas cambiar el usuario y la contraseña?", "Some Title", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
               //using(var db =new PresupuestoEntities5())
               //{
                  

               //    if (textBox2.Text == textBox2.Text &&textBox2.Text !=string.Empty &&  textBox2.Text!=string.Empty)
               //    {
               //        var query = db.Acceso(_usuarioActual, _pass).FirstOrDefault();
               //        var ff=query.Pass.ToString();
               //         if (ff==String.IsNullOrEmpty)
               //         {
                           
               //                 DB.Usuario c;
               //                 c = (from x in db.Usuarios
               //                     where x.Usuario1 == _usuarioActual
               //                     select x).First();

               //                 c.Pass = textBox1.Text;
               //                 c.Pass2 = textBox1.Text;
               //                 db.SaveChanges();
               //                 MessageBox.Show("Contraseña actalizada conrrectamente", "Usuario",
               //                 MessageBoxButtons.OK, MessageBoxIcon.Information);
               //                 this.Close();
               //         }
               //         else
               //         {
               //                 MessageBox.Show("La contraseña y/o el usuario no conincide(n)", "Usuario",
               //                 MessageBoxButtons.OK, MessageBoxIcon.Information);
               //         }
               //    }
               //    else 
               //    {
               //         MessageBox.Show("La contraseña no coinciden, vuelta a intentarlo", "Usuario",
               //         MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
               //    }
                  
               
               //}
               
            //}
            //else if (dialogResult == DialogResult.No)
            //{
            //    //do something else
            //}
        }

        public Image Imagen { get; set; }

        private async void SaveImage(Image i)
        {
            using (PresupuestoEntities5 compa = new PresupuestoEntities5())
            {
                Usuario pic;
                pic = (from c in compa.Usuarios
                       select c).FirstOrDefault();

               
                if (logica == 1)
                {
                    pic.Logo = ConvertImageToBinary(i);
                }
               
                await compa.SaveChangesAsync();

            }
        }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
           
        }

        private void User_Load(object sender, EventArgs e)
        {
            var db = new PresupuestoEntities5();

            var query = (from c in db.Usuarios
                select new {c.Logo}).FirstOrDefault();
            if (query != null) pictureBox1.Image = ConvertBinaryToImage(query.Logo);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg; *.png", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    logica = 1;
                    fillName = ofd.FileName;
                    pictureBox1.Image = Image.FromFile(fillName);
                    logica = 1;
                }

            }
        }
    }
}

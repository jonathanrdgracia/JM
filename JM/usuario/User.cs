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

namespace JM.usuario
{
    
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
        public string _usuarioActual { get; set; }
        public string _pass { get; set; }
        public string _nuevapass2 { get; set; }
        public string _nuevapass1 { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}

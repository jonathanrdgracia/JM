using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JM.DB;
namespace JM.Logear
{
    class Logica
    {
        public void txtUserName(object sender, KeyPressEventArgs e, TextBox txtPass)
        {
            if (e.KeyChar == (char)13)
            {
                txtPass.Focus();
            }
        }
        public void txtPass(object sender, KeyPressEventArgs e, Button btnLogin)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin.PerformClick();
            }
        }

        public void btnLogin(Button btn, TextBox txtUserName, TextBox txtPass)
        {
            if (string.IsNullOrEmpty(txtUserName.Text)) 
            {
                MessageBox.Show("Por favor ingrese su nombre de  usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
            try
            {
                using (var db = new PresupuestoEntities5()) 
                {
                    var query = from o in db.Usuarios
                                where o.Usuario1 == txtUserName.Text && o.Pass == txtPass.Text
                                select o;
                    if (query.SingleOrDefault() != null)
                    {
                        Form1 p = new Form1();
                        p.Show();
                       
                    }
                    else 
                    {
                        MessageBox.Show("Usuario incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}

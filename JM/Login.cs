using JM.DB;
using JM.Logear;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM
{
    public partial class Login : Form
    {
        Form1 p = new Form1();
        public Login()
        {
           
            InitializeComponent();
            textBox22.PasswordChar = '*';
            Init_Data();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
            Login l = new Login();
            Logica logear = new Logica();
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Init_Data()
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                if (Properties.Settings.Default.Reeme == "yes")
                {
                    textBox1.Text = Properties.Settings.Default.UserName;
                    textBox22.Text = Properties.Settings.Default.Password;
                    materialCheck.Checked = true;
                }
                else
                {
                    textBox1.Text = Properties.Settings.Default.UserName;
                }
            }
        }
        private void Save_Data()
        {
            if (materialCheck.Checked)
            {
                Properties.Settings.Default.UserName = textBox1.Text;
                Properties.Settings.Default.Password = textBox1.Text;
                Properties.Settings.Default.Reeme = "yes";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = textBox1.Text;
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Reeme = "no";
                Properties.Settings.Default.Save();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())
            {
                var query = from o in db.Usuarios
                            where o.Usuario1 == textBox1.Text && o.Pass == textBox22.Text
                            select o;

                if (materialCheck.Checked)
                {
                    Properties.Settings.Default.UserName = textBox1.Text;
                    Properties.Settings.Default.Password = textBox22.Text;
                    Properties.Settings.Default.Reeme = "yes";
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.UserName = "";
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.Reeme = "no";
                    Properties.Settings.Default.Save();
                }

                foreach (var i in query)
                {
                        if ((textBox1.Text ==i.Usuario1) && (textBox22.Text == i.Pass))
                        {
                            Save_Data();
                            this.Hide();
                        }
                }
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Por favor ingrese su nombre de  usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }
                try
                {

                    if (query.SingleOrDefault() != null)
                    {
                       
                        p.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Usuario incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                catch (Exception)
                {

                    throw;
                }

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
             if (e.KeyChar == (char)13)
             {
                 textBox22.Focus();
             }
                
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                button13.PerformClick();
            }

        }

                    



        }
    }


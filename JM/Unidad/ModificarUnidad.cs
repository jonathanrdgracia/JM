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

namespace JM.Unidad
{
    
    public partial class ModificarUnidad : Form
    {
        public int Id { get; set; }
        Unidad.LlenarUnidad l = new LlenarUnidad();
        public ModificarUnidad()
        {
            InitializeComponent();
        }

        private void ModificarUnidad_Load(object sender, EventArgs e)
        {
            
            l.LLenarLista(this.dataGridView1);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Id =Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                 textBox1.Text = x1;
            }
            catch (Exception)
            {
                
              
            }
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()) || string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Debes seleccionar el tipo unidad");
                }
                else
                {
                    var variable="";
                    if (comboBox1.SelectedItem.ToString().Equals("Mano de obra"))
                    {
                        variable = "mano";
                    }
                    else
                    {
                        variable = "material";
                    }
                    using (var db = new PresupuestoEntities5())
                    {
                        DB.Unidad uni;
                        uni = (from x in db.Unidads
                             where x.Id == Id
                             select x).First();
                        uni.Unidad1 = textBox1.Text;
                        uni.Tipo = variable;
                        db.SaveChanges();
                    }
                    textBox1.Text = string.Empty;
                    l.LLenarLista(dataGridView1);
                }
            }
            catch (Exception)
            {

                
            }
        }
    }
}

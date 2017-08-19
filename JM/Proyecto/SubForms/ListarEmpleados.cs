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

namespace JM.Proyecto.SubForms
{
    public partial class ListarEmpleados : Form
    {
        public ListarEmpleados()
        {
            InitializeComponent();
        }
        public List<DB.Abonado> Empleadolista = new List<DB.Abonado>();

        private void ListarClientes_Load(object sender, EventArgs e)
        {
            using (var db = new PresupuestoEntities5())

            {
                foreach (var item in db.Abonadoes.Where(c=>c.Estado==1).OrderByDescending(c=>c.Id))
                {
                    dataGridView1.Rows.Add(
                        item.Id,
                        item.Nombre,
                        item.TipoEmpleado,
                        item.Telefono,
                        item.Lugar
                        
                        );
                }

        }
    }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            var query = "%"+textBox1.Text+"%";
            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in db.Filtrar_Empleados_activos(query))
                {
                    this.dataGridView1.Rows.Add
                        (
                        item.Id,
                        item.Nombre,
                        item.TipoEmpleado,
                        item.Telefono,
                        item.Lugar
                        
                        );
                }
            
            }


        }
        public delegate void enviar(List<DB.Abonado> lista);

        public event enviar enviado;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var x0 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var x1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var x2 = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            var x3 = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            var x4 = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if (false)
            {
                MessageBox.Show("Has agregado este empleado a la nueva lista");
            }
            else 
            {
              
                Empleadolista.Add(new DB.Abonado
                {
                    Id = Convert.ToInt32(x0),
                    Nombre = x1,
                    TipoEmpleado = x2,
                    Telefono = x3,
                    Lugar = x4
                });
                this.dataGridView2.Rows.Clear();
                foreach (var item in Empleadolista)
                {
                    this.dataGridView2.Rows.Add
                        (
                            item.Id,
                            item.Nombre,
                            item.TipoEmpleado,
                            item.Telefono,
                            item.Lugar
                        );
                }
            }
          /*  Proyecto.Nuevo c = new Proyecto.Nuevo();

            enviado(x0,x1,x2,x3);
            this.Close();
           * */
        }

        private bool VerificarDuplicidad(string id)
        {
           
           var x= Empleadolista.FirstOrDefault(c=>c.Id.ToString()==id);

           MessageBox.Show(x.ToString());
            if(String.IsNullOrEmpty(x.Id.ToString())){return false;}else{return true;}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var x0 = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();

            this.Empleadolista.RemoveAll(c => c.Id.ToString() == x0);
            this.dataGridView2.Rows.Clear();
            foreach (var item in Empleadolista)
            {
                this.dataGridView2.Rows.Add
                    (
                    item.Id,
                    item.Nombre,
                    item.TipoEmpleado,
                    item.Telefono,
                    item.Lugar
                    );
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Proyecto.Nuevo c = new Proyecto.Nuevo();
            ModificarProyecto m = new ModificarProyecto();

            try
            {
                 enviado(this.Empleadolista);
            }
            catch (Exception ex)
            {
                
                 enviado2(this.Empleadolista);
            }
          
            this.Close();

        }

        public delegate void enviar2(List<DB.Abonado> lista);
        public event enviar2 enviado2;

}
    
}
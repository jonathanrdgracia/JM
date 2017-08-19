using JM.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Presupuesto.Ediciones
{
    public partial class Obra_Modificar : Form
    {
        public Obra_Modificar()
        {
            InitializeComponent();
        }
        List<DB.Obra_detalle> listaMateriales = new List<DB.Obra_detalle>();
        List<DB.Obra_detalle> listaMaterialesNuevos = new List<DB.Obra_detalle>();
        public int contador1 { get; set; }
        public int cambio { get; set; }
        public int Rebaja { get; set; }
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public string Tipo { get; set; }
        public int TotalGeneal { get; set; }
        public int TotalGeneralDB { get; set; }
        public string MyProperty { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        private string NombreCliente { get; set; }
        public string Telefono { get; set; }
        List<empleadosC> Jefes = new List<empleadosC>();
        List<DB.Obra_detalle> obras = new List<DB.Obra_detalle>();
        private int _id;

        public int MyId
        {
            get { return _id; }
            set { _id = value; }
        }
        
        private void Obra_Modificar_Load(object sender, EventArgs e)
        {
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            nfi.CurrencyDecimalDigits = 2;
            using (var db = new PresupuestoEntities5())
            {
                TotalGeneralDB = Convert.ToInt32(db.Presupuestos.Where(c => c.IdPresupuestos == _id).Select(x => x.TotalGeneral).FirstOrDefault());

                var query = (from c in db.Obra_detalle where c.IdPresupuesto == _id select c);


                foreach (var i in query)
                {
                    listaMateriales.Add(new Obra_detalle
                    {
                        Descripcion = i.Descripcion,
                        Unidad = i.Unidad,
                        Precio = i.Precio,
                        Cantidad = i.Cantidad,
                        Total = i.Total
                    });

                    contador1 = contador1 + Convert.ToInt32(i.Total);

                }
                foreach (var i in listaMateriales)
                {
                    this.dataGridView3.Rows.Add(
                        i.Descripcion,
                        i.Unidad,
                        Convert.ToInt32(i.Precio).ToString("C", nfi),
                        i.Cantidad,
                       Convert.ToInt32(i.Total).ToString("C", nfi)

                        );
                }

                label27.Text = "Total: RD" + contador1.ToString("C", nfi);

                comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;


                var q = from t1 in db.Obra_detalle
                        join t2 in db.Presupuestos on t1.IdPresupuesto equals t2.IdPresupuestos
                        where t2.IdPresupuestos == _id && t1.Tipo == 1
                        select new { t1.id, t1.Descripcion, t1.Unidad, t1.Precio, t1.Total, t1.Cantidad };






                var ff = from tb1 in db.Presupuestos
                         join tb2 in db.Clientes on tb1.IdCliente equals tb2.id
                         where tb1.Estado == 1 && tb1.IdPresupuestos == _id
                         select new { tb1.IdCliente, tb2.TipoCliente, tb1.Descripcion, tb2.Nombre, tb2.Apellido, tb2.Telefono, tb1.Direccion };


                foreach (var i in ff)
                {
                    NombreCliente = i.Nombre;
                    Telefono = i.Telefono;
                    Tipo = i.TipoCliente;
                    Descripcion = i.Descripcion;
                    Direccion = i.Direccion;
                }

            }
            //

            textBox6.Text = NombreCliente;
            textBox2.Text = Tipo;
            textBox5.Text = Telefono;
            Descripciontxxt.Text = Descripcion;
           textBoxdire.Text = Direccion;
            LLenarCombobox(comboBox3);
            Clientes(this.dataGridView4, _id);
            LLenarDetalle(dataGridView3);

        }



        private void LLenarDetalle(DataGridView dataGridView3)
        {
            LLenarMaterialesDetalleLista();
        }

        private void Clientes(DataGridView dato, int id)
        {

            using (var db = new PresupuestoEntities5())
            {
                var query = from t1 in db.Abonadoes
                            join t2 in db.EmpleadoPresupuestoes on t1.Id equals t2.IdEmpleado
                            join t3 in db.Presupuestos on t2.IdPresupuesto equals t3.IdPresupuestos
                            join t4 in db.TipoEmpleadoes on t1.IdTipoEmpleado equals t4.IdTipoEmpleado
                            where t3.IdPresupuestos == id
                            select new { t1.Id, t1.Nombre, t1.Apellidos, t1.Telefono, t4.Tipo };


                foreach (var i in query)
                {
                    Jefes.Add(new empleadosC
                    {
                        ID = i.Id,
                        Nombre = i.Nombre + " " + i.Apellidos,
                        Telefono = i.Telefono,
                        Ocupacion = i.Tipo

                    });

                }

                foreach (var item in Jefes)
                {
                    dato.Rows.Add
                     (
                         item.ID,
                         item.Nombre,
                         item.Telefono,
                         item.Ocupacion

                     );
                }

            }


        }
          private void ModificarPresupustoUnitario_Load(object sender, EventArgs e)
        {

        }
        public void LLenarCombobox(ComboBox combBox3)
        {
          
            try
            {
                using (var db = new PresupuestoEntities5())
                {
                    foreach (var item in db.Unidads.Where(c=>c.Tipo=="material"))
                    {
                        combBox3.Items.Add(item.Unidad1);
                    }



                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void LLenarMaterialesDetalleLista()
        {
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                nfi.CurrencyDecimalDigits = 2;
                var descrip = textBox22.Text;
                var prec = Convert.ToInt32(textBox21.Text);
                var cantidad = Convert.ToInt32(textBox20.Text);
                var unidad = comboBox3.SelectedItem.ToString();
                var total = Convert.ToInt32(prec) * Convert.ToInt32(cantidad);
                this.dataGridView3.Rows.Clear();
                contador1 = 0;
                listaMaterialesNuevos.Add(new Obra_detalle
                {
                    Descripcion = descrip,
                    Precio = prec,
                    Cantidad = cantidad,
                    Unidad = unidad,
                    Total = total,
                });

                foreach (var i in listaMateriales)
                {
                    dataGridView3.Rows.Add(i.Descripcion, i.Unidad, Convert.ToInt32(i.Precio).ToString("C", nfi), i.Cantidad, Convert.ToInt32(i.Total).ToString("C"), nfi);
                    contador1 = contador1 + Convert.ToInt32(i.Total);
                }

                foreach (var i in listaMaterialesNuevos)
                {
                    dataGridView3.Rows.Add(i.Descripcion, i.Unidad, Convert.ToInt32(i.Precio).ToString("C", nfi), i.Cantidad, Convert.ToInt32(i.Total).ToString("C", nfi));
                    contador1 = contador1 + Convert.ToInt32(i.Total);
                }
                label27.Text = "Total: RD" + contador1.ToString("C", nfi);

                textBox22.Text = string.Empty;
                textBox21.Text = string.Empty;
                textBox20.Text = string.Empty;
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

        private void button12_Click(object sender, EventArgs e)
        {
            contador1 = 0;
            var jj = 0;
            var listauno = dataGridView3.CurrentRow.Cells[0].Value.ToString();


            var q = listaMaterialesNuevos.Where(c => c.Descripcion == listauno);
            var q2 = listaMateriales.Where(c => c.Descripcion == listauno);
            foreach (var i in q)
            {
                jj = jj + Convert.ToInt32(i.Total);
            }
            foreach (var i in q2)
            {
                jj = jj + Convert.ToInt32(i.Total);
            }

            Rebaja = Rebaja + jj;




            listaMateriales.RemoveAll(c => c.Descripcion == listauno);
            listaMaterialesNuevos.RemoveAll(c => c.Descripcion == listauno);




            this.dataGridView3.Rows.Clear();

            foreach (var i in listaMateriales)
            {
                dataGridView3.Rows.Add(i.Descripcion, i.Unidad, Convert.ToInt32(i.Precio).ToString("C", nfi), i.Cantidad, Convert.ToInt32(i.Total).ToString("C", nfi));
                contador1 = contador1 + Convert.ToInt32(i.Total);
            }
            foreach (var i in listaMaterialesNuevos)
            {
                dataGridView3.Rows.Add(i.Descripcion, i.Unidad, Convert.ToInt32(i.Precio).ToString("C", nfi), i.Cantidad, Convert.ToInt32(i.Total).ToString("C", nfi));
                contador1 = contador1 + Convert.ToInt32(i.Total);
            }

            label27.Text = "Total: RD" + (contador1).ToString("C", nfi);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ingObra c = new ingObra();
            c.enviado += new ingObra.enviar(ejecutar);
            c.ShowDialog();
        }
        private void ejecutar(int id, string nombre, string telefono, string ocupacion)
        {

            Jefes.Add(new empleadosC
            {
                ID = id,
                Nombre = nombre,
                Telefono = telefono,
                Ocupacion = ocupacion

            });

            this.dataGridView4.Rows.Clear();
            foreach (var r in Jefes)
            {
                this.dataGridView4.Rows.Add
                    (
                    r.ID,
                    r.Nombre,
                    r.Ocupacion,
                    r.Telefono

                    );
            }
        }
    }
    public class ClientesC
    {
        public int ID { get; set; }
        public string Nombtre { get; set; }
        public string Telefono { get; set; }
        public string Tipo { get; set; }
    }
    public class empleadosC
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Ocupacion { get; set; }
    }

}

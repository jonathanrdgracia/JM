using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Reportes
{

	
    public partial class ReporteManodeObra : Form
    {
        private int id;

        public int IdProyecto
        {
            get { return id; }
            set { id = value; }
        }

        public ReporteManodeObra()
        {
            InitializeComponent();
        }

        private void ReporteManodeObra_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'compania.CompaniaDato' table. You can move, or remove it, as needed.
            this.companiaDatoTableAdapter.Fill(this.compania.CompaniaDato);
            this.descripcionDireccionTableAdapter1.Fill(total.descripcionDireccion, id);
            this.descripcionDireccionTableAdapter.Fill(this.descripcion.descripcionDireccion, id);
            this.sP_Reporte_EmpleadosTableAdapter.Fill(this.dsEmpleadosElite.SP_Reporte_Empleados, id);
            // TODO: This line of code loads data into the 'compania.CompaniaDato' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'dSCliente.SP_Reporte_Materiales_Cliente' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'dsEmpleadosElite.SP_Reporte_Empleados' table. You can move, or remove it, as needed.
           
          
            this.reporteManoObra5TableAdapter.Fill(simplementeLista.ReporteManoObra5, id);
            
         //   this.companiaDatoTableAdapter.Fill(this.compania.CompaniaDato);

          
            this.sP_Reporte_Materiales_ClienteTableAdapter.Fill(dSCliente.SP_Reporte_Materiales_Cliente, id);
             
           
           

            this.reportViewer1.RefreshReport();
        }
    }
}

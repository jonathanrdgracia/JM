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
    public partial class Ambos : Form
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        
        public Ambos()
        {
            InitializeComponent();
        }

        private void Ambos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'compania.CompaniaDato' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'compania.CompaniaDato' table. You can move, or remove it, as needed.
          //  this.companiaDatoTableAdapter.Fill(this.compania.CompaniaDato);
          //  // TODO: This line of code loads data into the 'compania.CompaniaDato' table. You can move, or remove it, as needed.
          //             this.companiaDatoTableAdapter.Fill(this.compania.CompaniaDato);

          //           this.descripcionDireccionTableAdapter.Fill(descripcion.descripcionDireccion,4);
          //                    this.sP_Reporte_EmpleadosTableAdapter.Fill(this.dsEmpleadosElite.SP_Reporte_Empleados, id);
          ////  this.sP_Reporte_Materiales_ClienteTableAdapter.Fill(dSCliente.SP_Reporte_Materiales_Cliente, id);
      // this.sP_Reporte_Detalles_Materiales4TableAdapter.Fill(materiales.SP_Reporte_DetallesManoObra4,4);
            

           // this.reporteManoObra5TableAdapter.Fill(simplementeLista.ReporteManoObra5, id);
            //this.reporteMateriales5TableAdapter.Fill(simplementeLista.ReporteMateriales5, id);
            //this.reportViewer1.RefreshReport();
            this.sP_Reporte_Materiales_ClienteTableAdapter.Fill(dSCliente.SP_Reporte_Materiales_Cliente, id);
            this.sP_Reporte_EmpleadosTableAdapter.Fill(dsEmpleadosElite.SP_Reporte_Empleados,id);
            this.reporteMateriales5TableAdapter.Fill(this.simplementeLista.ReporteMateriales5, id);
            this.reporteManoObra5TableAdapter.Fill(simplementeLista.ReporteManoObra5, id);
            this.descripcionDireccionTableAdapter.Fill(this.descripcion.descripcionDireccion, id);
            this.companiaDatoTableAdapter.Fill(this.compania.CompaniaDato);
            this.descripcionDireccionTableAdapter1.Fill(total.descripcionDireccion, id);
                           this.reportViewer1.RefreshReport();
                       

           
          
        }
    }
}

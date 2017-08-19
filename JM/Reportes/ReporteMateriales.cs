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
    public partial class ReporteMateriales : Form
    {
        public ReporteMateriales()
        {
            InitializeComponent();
        }
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        
        private void ReporteMateriales_Load(object sender, EventArgs e)
        {
// TODO: This line of code loads data into the 'compania.CompaniaDato' table. You can move, or remove it, as needed.
            this.descripcionDireccionTableAdapter.Fill(this.descripcion.descripcionDireccion,id);
            this.reporteMateriales5TableAdapter.Fill(simplementeLista.ReporteMateriales5, id);
                    this.companiaDatoTableAdapter.Fill(this.compania.CompaniaDato);
                    this.descripcionDireccionTableAdapter1.Fill(total.descripcionDireccion, 4);
                    this.sP_Reporte_EmpleadosTableAdapter.Fill(this.dsEmpleadosElite.SP_Reporte_Empleados, id);
                    this.sP_Reporte_Materiales_ClienteTableAdapter.Fill(dSCliente.SP_Reporte_Materiales_Cliente, id);
                    this.descripcionDireccionTableAdapter1.Fill(total.descripcionDireccion, id);
                    this.reportViewer1.RefreshReport();
            
        
                
            //    this.reportViewer1.RefreshReport();
            
        }
    }
}

namespace JM.Reportes
{
    partial class ReporteMateriales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.companiaDatoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compania = new JM.Dataset.Compania();
            this.sPReporteEmpleadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsEmpleadosElite = new JM.Dataset.DsEmpleadosElite();
            this.sPReporteMaterialesClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCliente = new JM.Dataset.DSCliente();
            this.reporteMateriales5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.simplementeLista = new JM.Dataset.SimplementeLista();
            this.descripcionDireccionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descripcion = new JM.Dataset.Descripcion();
            this.descripcionDireccionBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.total = new JM.Dataset.Total();
            this.sPReporteDetallesMateriales4BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.no = new JM.Dataset.No();
            this.sPReporteDetallesMateriales4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materialesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materiales = new JM.Dataset.Materiales();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sP_Reporte_Detalles_Materiales4TableAdapter = new JM.Dataset.MaterialesTableAdapters.SP_Reporte_Detalles_Materiales4TableAdapter();
            this.companiaDatoTableAdapter = new JM.Dataset.CompaniaTableAdapters.CompaniaDatoTableAdapter();
            this.sP_Reporte_EmpleadosTableAdapter = new JM.Dataset.DsEmpleadosEliteTableAdapters.SP_Reporte_EmpleadosTableAdapter();
            this.sP_Reporte_Materiales_ClienteTableAdapter = new JM.Dataset.DSClienteTableAdapters.SP_Reporte_Materiales_ClienteTableAdapter();
            this.sP_Reporte_Detalles_Materiales4TableAdapter1 = new JM.Dataset.NoTableAdapters.SP_Reporte_Detalles_Materiales4TableAdapter();
            this.reporteMateriales5TableAdapter = new JM.Dataset.SimplementeListaTableAdapters.ReporteMateriales5TableAdapter();
            this.descripcionDireccionTableAdapter = new JM.Dataset.DescripcionTableAdapters.descripcionDireccionTableAdapter();
            this.descripcionDireccionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.descripcionDireccionTableAdapter1 = new JM.Dataset.TotalTableAdapters.descripcionDireccionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.companiaDatoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compania)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteEmpleadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmpleadosElite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteMaterialesClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteMateriales5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simplementeLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteDetallesMateriales4BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.no)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteDetallesMateriales4BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // companiaDatoBindingSource
            // 
            this.companiaDatoBindingSource.DataMember = "CompaniaDato";
            this.companiaDatoBindingSource.DataSource = this.companiaBindingSource;
            // 
            // companiaBindingSource
            // 
            this.companiaBindingSource.DataSource = this.compania;
            this.companiaBindingSource.Position = 0;
            // 
            // compania
            // 
            this.compania.DataSetName = "Compania";
            this.compania.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPReporteEmpleadosBindingSource
            // 
            this.sPReporteEmpleadosBindingSource.DataMember = "SP_Reporte_Empleados";
            this.sPReporteEmpleadosBindingSource.DataSource = this.dsEmpleadosElite;
            // 
            // dsEmpleadosElite
            // 
            this.dsEmpleadosElite.DataSetName = "DsEmpleadosElite";
            this.dsEmpleadosElite.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPReporteMaterialesClienteBindingSource
            // 
            this.sPReporteMaterialesClienteBindingSource.DataMember = "SP_Reporte_Materiales_Cliente";
            this.sPReporteMaterialesClienteBindingSource.DataSource = this.dSCliente;
            // 
            // dSCliente
            // 
            this.dSCliente.DataSetName = "DSCliente";
            this.dSCliente.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteMateriales5BindingSource
            // 
            this.reporteMateriales5BindingSource.DataMember = "ReporteMateriales5";
            this.reporteMateriales5BindingSource.DataSource = this.simplementeLista;
            // 
            // simplementeLista
            // 
            this.simplementeLista.DataSetName = "SimplementeLista";
            this.simplementeLista.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // descripcionDireccionBindingSource
            // 
            this.descripcionDireccionBindingSource.DataMember = "descripcionDireccion";
            this.descripcionDireccionBindingSource.DataSource = this.descripcion;
            // 
            // descripcion
            // 
            this.descripcion.DataSetName = "Descripcion";
            this.descripcion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // descripcionDireccionBindingSource2
            // 
            this.descripcionDireccionBindingSource2.DataMember = "descripcionDireccion";
            this.descripcionDireccionBindingSource2.DataSource = this.total;
            // 
            // total
            // 
            this.total.DataSetName = "Total";
            this.total.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPReporteDetallesMateriales4BindingSource1
            // 
            this.sPReporteDetallesMateriales4BindingSource1.DataMember = "SP_Reporte_Detalles_Materiales4";
            this.sPReporteDetallesMateriales4BindingSource1.DataSource = this.no;
            // 
            // no
            // 
            this.no.DataSetName = "No";
            this.no.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPReporteDetallesMateriales4BindingSource
            // 
            this.sPReporteDetallesMateriales4BindingSource.DataMember = "SP_Reporte_Detalles_Materiales4";
            this.sPReporteDetallesMateriales4BindingSource.DataSource = this.materialesBindingSource;
            // 
            // materialesBindingSource
            // 
            this.materialesBindingSource.DataSource = this.materiales;
            this.materialesBindingSource.Position = 0;
            // 
            // materiales
            // 
            this.materiales.DataSetName = "Materiales";
            this.materiales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSCompania";
            reportDataSource1.Value = this.companiaDatoBindingSource;
            reportDataSource2.Name = "EmpleadosElites";
            reportDataSource2.Value = this.sPReporteEmpleadosBindingSource;
            reportDataSource3.Name = "ClienteElite";
            reportDataSource3.Value = this.sPReporteMaterialesClienteBindingSource;
            reportDataSource4.Name = "DsListaMateriales";
            reportDataSource4.Value = this.reporteMateriales5BindingSource;
            reportDataSource5.Name = "Cabeza";
            reportDataSource5.Value = this.descripcionDireccionBindingSource;
            reportDataSource6.Name = "TotalGeneral";
            reportDataSource6.Value = this.descripcionDireccionBindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JM.Reporting.ReporteMateriales.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(743, 669);
            this.reportViewer1.TabIndex = 0;
            // 
            // sP_Reporte_Detalles_Materiales4TableAdapter
            // 
            this.sP_Reporte_Detalles_Materiales4TableAdapter.ClearBeforeFill = true;
            // 
            // companiaDatoTableAdapter
            // 
            this.companiaDatoTableAdapter.ClearBeforeFill = true;
            // 
            // sP_Reporte_EmpleadosTableAdapter
            // 
            this.sP_Reporte_EmpleadosTableAdapter.ClearBeforeFill = true;
            // 
            // sP_Reporte_Materiales_ClienteTableAdapter
            // 
            this.sP_Reporte_Materiales_ClienteTableAdapter.ClearBeforeFill = true;
            // 
            // sP_Reporte_Detalles_Materiales4TableAdapter1
            // 
            this.sP_Reporte_Detalles_Materiales4TableAdapter1.ClearBeforeFill = true;
            // 
            // reporteMateriales5TableAdapter
            // 
            this.reporteMateriales5TableAdapter.ClearBeforeFill = true;
            // 
            // descripcionDireccionTableAdapter
            // 
            this.descripcionDireccionTableAdapter.ClearBeforeFill = true;
            // 
            // descripcionDireccionBindingSource1
            // 
            this.descripcionDireccionBindingSource1.DataMember = "descripcionDireccion";
            this.descripcionDireccionBindingSource1.DataSource = this.total;
            // 
            // descripcionDireccionTableAdapter1
            // 
            this.descripcionDireccionTableAdapter1.ClearBeforeFill = true;
            // 
            // ReporteMateriales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 669);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteMateriales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteMateriales";
            this.Load += new System.EventHandler(this.ReporteMateriales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.companiaDatoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compania)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteEmpleadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmpleadosElite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteMaterialesClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteMateriales5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simplementeLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteDetallesMateriales4BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.no)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteDetallesMateriales4BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource materialesBindingSource;
        private Dataset.Materiales materiales;
        private System.Windows.Forms.BindingSource sPReporteDetallesMateriales4BindingSource;
        private Dataset.MaterialesTableAdapters.SP_Reporte_Detalles_Materiales4TableAdapter sP_Reporte_Detalles_Materiales4TableAdapter;
        private Dataset.Compania compania;
        private System.Windows.Forms.BindingSource companiaBindingSource;
        private System.Windows.Forms.BindingSource companiaDatoBindingSource;
        private Dataset.CompaniaTableAdapters.CompaniaDatoTableAdapter companiaDatoTableAdapter;
        private System.Windows.Forms.BindingSource sPReporteEmpleadosBindingSource;
        private Dataset.DsEmpleadosElite dsEmpleadosElite;
        private Dataset.DsEmpleadosEliteTableAdapters.SP_Reporte_EmpleadosTableAdapter sP_Reporte_EmpleadosTableAdapter;
        private System.Windows.Forms.BindingSource sPReporteMaterialesClienteBindingSource;
        private Dataset.DSCliente dSCliente;
        private Dataset.DSClienteTableAdapters.SP_Reporte_Materiales_ClienteTableAdapter sP_Reporte_Materiales_ClienteTableAdapter;
        private System.Windows.Forms.BindingSource sPReporteDetallesMateriales4BindingSource1;
        private Dataset.No no;
        private Dataset.NoTableAdapters.SP_Reporte_Detalles_Materiales4TableAdapter sP_Reporte_Detalles_Materiales4TableAdapter1;
        private System.Windows.Forms.BindingSource reporteMateriales5BindingSource;
        private Dataset.SimplementeLista simplementeLista;
        private Dataset.SimplementeListaTableAdapters.ReporteMateriales5TableAdapter reporteMateriales5TableAdapter;
        private System.Windows.Forms.BindingSource descripcionDireccionBindingSource;
        private Dataset.Descripcion descripcion;
        private Dataset.DescripcionTableAdapters.descripcionDireccionTableAdapter descripcionDireccionTableAdapter;
        private System.Windows.Forms.BindingSource descripcionDireccionBindingSource1;
        private Dataset.Total total;
        private Dataset.TotalTableAdapters.descripcionDireccionTableAdapter descripcionDireccionTableAdapter1;
        private System.Windows.Forms.BindingSource descripcionDireccionBindingSource2;


    }
}
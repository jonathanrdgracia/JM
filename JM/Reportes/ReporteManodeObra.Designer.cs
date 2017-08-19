namespace JM.Reportes
{
    partial class ReporteManodeObra
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reporteManoObra5BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.simplementeLista = new JM.Dataset.SimplementeLista();
            this.companiaDatoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compania = new JM.Dataset.Compania();
            this.sPReporteMaterialesClienteBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dSCliente = new JM.Dataset.DSCliente();
            this.sPReporteEmpleadosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsEmpleadosElite = new JM.Dataset.DsEmpleadosElite();
            this.descripcionDireccionBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.descripcion = new JM.Dataset.Descripcion();
            this.sPReporteMaterialesClienteBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.descripcionDireccionBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.total = new JM.Dataset.Total();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.companiaDatoTableAdapter = new JM.Dataset.CompaniaTableAdapters.CompaniaDatoTableAdapter();
            this.descripcionDireccionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descripcionDireccionTableAdapter = new JM.Dataset.DescripcionTableAdapters.descripcionDireccionTableAdapter();
            this.sPReporteEmpleadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_Reporte_EmpleadosTableAdapter = new JM.Dataset.DsEmpleadosEliteTableAdapters.SP_Reporte_EmpleadosTableAdapter();
            this.reporteManoObra5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteManoObra5TableAdapter = new JM.Dataset.SimplementeListaTableAdapters.ReporteManoObra5TableAdapter();
            this.sPReporteMaterialesClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_Reporte_Materiales_ClienteTableAdapter = new JM.Dataset.DSClienteTableAdapters.SP_Reporte_Materiales_ClienteTableAdapter();
            this.descripcionDireccionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.descripcionDireccionTableAdapter1 = new JM.Dataset.TotalTableAdapters.descripcionDireccionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reporteManoObra5BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simplementeLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companiaDatoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compania)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteMaterialesClienteBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteEmpleadosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmpleadosElite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteMaterialesClienteBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteEmpleadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteManoObra5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteMaterialesClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reporteManoObra5BindingSource1
            // 
            this.reporteManoObra5BindingSource1.DataMember = "ReporteManoObra5";
            this.reporteManoObra5BindingSource1.DataSource = this.simplementeLista;
            // 
            // simplementeLista
            // 
            this.simplementeLista.DataSetName = "SimplementeLista";
            this.simplementeLista.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // companiaDatoBindingSource
            // 
            this.companiaDatoBindingSource.DataMember = "CompaniaDato";
            this.companiaDatoBindingSource.DataSource = this.compania;
            // 
            // compania
            // 
            this.compania.DataSetName = "Compania";
            this.compania.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPReporteMaterialesClienteBindingSource1
            // 
            this.sPReporteMaterialesClienteBindingSource1.DataMember = "SP_Reporte_Materiales_Cliente";
            this.sPReporteMaterialesClienteBindingSource1.DataSource = this.dSCliente;
            // 
            // dSCliente
            // 
            this.dSCliente.DataSetName = "DSCliente";
            this.dSCliente.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPReporteEmpleadosBindingSource1
            // 
            this.sPReporteEmpleadosBindingSource1.DataMember = "SP_Reporte_Empleados";
            this.sPReporteEmpleadosBindingSource1.DataSource = this.dsEmpleadosElite;
            // 
            // dsEmpleadosElite
            // 
            this.dsEmpleadosElite.DataSetName = "DsEmpleadosElite";
            this.dsEmpleadosElite.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // descripcionDireccionBindingSource2
            // 
            this.descripcionDireccionBindingSource2.DataMember = "descripcionDireccion";
            this.descripcionDireccionBindingSource2.DataSource = this.descripcion;
            // 
            // descripcion
            // 
            this.descripcion.DataSetName = "Descripcion";
            this.descripcion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPReporteMaterialesClienteBindingSource2
            // 
            this.sPReporteMaterialesClienteBindingSource2.DataMember = "SP_Reporte_Materiales_Cliente";
            this.sPReporteMaterialesClienteBindingSource2.DataSource = this.dSCliente;
            // 
            // descripcionDireccionBindingSource3
            // 
            this.descripcionDireccionBindingSource3.DataMember = "descripcionDireccion";
            this.descripcionDireccionBindingSource3.DataSource = this.total;
            // 
            // total
            // 
            this.total.DataSetName = "Total";
            this.total.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ListadoManodeObra";
            reportDataSource1.Value = this.reporteManoObra5BindingSource1;
            reportDataSource2.Name = "Compa";
            reportDataSource2.Value = this.companiaDatoBindingSource;
            reportDataSource3.Name = "ClienteElite";
            reportDataSource3.Value = this.sPReporteMaterialesClienteBindingSource1;
            reportDataSource4.Name = "Empleado";
            reportDataSource4.Value = this.sPReporteEmpleadosBindingSource1;
            reportDataSource5.Name = "Descript";
            reportDataSource5.Value = this.descripcionDireccionBindingSource2;
            reportDataSource6.Name = "C";
            reportDataSource6.Value = this.sPReporteMaterialesClienteBindingSource2;
            reportDataSource7.Name = "TotalGeneral";
            reportDataSource7.Value = this.descripcionDireccionBindingSource3;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JM.Reporting.Mixto.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(743, 669);
            this.reportViewer1.TabIndex = 0;
            // 
            // companiaDatoTableAdapter
            // 
            this.companiaDatoTableAdapter.ClearBeforeFill = true;
            // 
            // descripcionDireccionBindingSource
            // 
            this.descripcionDireccionBindingSource.DataMember = "descripcionDireccion";
            this.descripcionDireccionBindingSource.DataSource = this.descripcion;
            // 
            // descripcionDireccionTableAdapter
            // 
            this.descripcionDireccionTableAdapter.ClearBeforeFill = true;
            // 
            // sPReporteEmpleadosBindingSource
            // 
            this.sPReporteEmpleadosBindingSource.DataMember = "SP_Reporte_Empleados";
            this.sPReporteEmpleadosBindingSource.DataSource = this.dsEmpleadosElite;
            // 
            // sP_Reporte_EmpleadosTableAdapter
            // 
            this.sP_Reporte_EmpleadosTableAdapter.ClearBeforeFill = true;
            // 
            // reporteManoObra5BindingSource
            // 
            this.reporteManoObra5BindingSource.DataMember = "ReporteManoObra5";
            this.reporteManoObra5BindingSource.DataSource = this.simplementeLista;
            // 
            // reporteManoObra5TableAdapter
            // 
            this.reporteManoObra5TableAdapter.ClearBeforeFill = true;
            // 
            // sPReporteMaterialesClienteBindingSource
            // 
            this.sPReporteMaterialesClienteBindingSource.DataMember = "SP_Reporte_Materiales_Cliente";
            this.sPReporteMaterialesClienteBindingSource.DataSource = this.dSCliente;
            // 
            // sP_Reporte_Materiales_ClienteTableAdapter
            // 
            this.sP_Reporte_Materiales_ClienteTableAdapter.ClearBeforeFill = true;
            // 
            // descripcionDireccionBindingSource1
            // 
            this.descripcionDireccionBindingSource1.DataMember = "descripcionDireccion";
            this.descripcionDireccionBindingSource1.DataSource = this.descripcion;
            // 
            // descripcionDireccionTableAdapter1
            // 
            this.descripcionDireccionTableAdapter1.ClearBeforeFill = true;
            // 
            // ReporteManodeObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 669);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteManodeObra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteManodeObra";
            this.Load += new System.EventHandler(this.ReporteManodeObra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reporteManoObra5BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simplementeLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companiaDatoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compania)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteMaterialesClienteBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteEmpleadosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmpleadosElite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteMaterialesClienteBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteEmpleadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteManoObra5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPReporteMaterialesClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionDireccionBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Dataset.Compania compania;
        private System.Windows.Forms.BindingSource companiaDatoBindingSource;
        private Dataset.CompaniaTableAdapters.CompaniaDatoTableAdapter companiaDatoTableAdapter;
        private System.Windows.Forms.BindingSource descripcionDireccionBindingSource;
        private Dataset.Descripcion descripcion;
        private Dataset.DescripcionTableAdapters.descripcionDireccionTableAdapter descripcionDireccionTableAdapter;
        private System.Windows.Forms.BindingSource sPReporteEmpleadosBindingSource;
        private Dataset.DsEmpleadosElite dsEmpleadosElite;
        private Dataset.DsEmpleadosEliteTableAdapters.SP_Reporte_EmpleadosTableAdapter sP_Reporte_EmpleadosTableAdapter;
        private System.Windows.Forms.BindingSource reporteManoObra5BindingSource;
        private Dataset.SimplementeLista simplementeLista;
        private Dataset.SimplementeListaTableAdapters.ReporteManoObra5TableAdapter reporteManoObra5TableAdapter;
        private System.Windows.Forms.BindingSource sPReporteMaterialesClienteBindingSource;
        private Dataset.DSCliente dSCliente;
        private System.Windows.Forms.BindingSource descripcionDireccionBindingSource1;
        private Dataset.DSClienteTableAdapters.SP_Reporte_Materiales_ClienteTableAdapter sP_Reporte_Materiales_ClienteTableAdapter;
        private System.Windows.Forms.BindingSource reporteManoObra5BindingSource1;
        private System.Windows.Forms.BindingSource sPReporteMaterialesClienteBindingSource1;
        private System.Windows.Forms.BindingSource sPReporteEmpleadosBindingSource1;
        private System.Windows.Forms.BindingSource descripcionDireccionBindingSource2;
        private System.Windows.Forms.BindingSource sPReporteMaterialesClienteBindingSource2;
        private System.Windows.Forms.BindingSource descripcionDireccionBindingSource3;
        private Dataset.Total total;
        private Dataset.TotalTableAdapters.descripcionDireccionTableAdapter descripcionDireccionTableAdapter1;
    }
}
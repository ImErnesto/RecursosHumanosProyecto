namespace GestionHospital.Reportes
{
    partial class FormPersonal
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataNominaPersonal = new GestionHospital.Reportes.DataNominaPersonal();
            this.dataNominaPersonalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_02 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataNominaPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNominaPersonalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.dataNominaPersonalBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GestionHospital.Reportes.ReporteNominaPersonal.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataNominaPersonal
            // 
            this.dataNominaPersonal.DataSetName = "DataNominaPersonal";
            this.dataNominaPersonal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataNominaPersonalBindingSource
            // 
            this.dataNominaPersonalBindingSource.DataSource = this.dataNominaPersonal;
            this.dataNominaPersonalBindingSource.Position = 0;
            // 
            // txt_02
            // 
            this.txt_02.Location = new System.Drawing.Point(51, 46);
            this.txt_02.Name = "txt_02";
            this.txt_02.Size = new System.Drawing.Size(100, 22);
            this.txt_02.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_02);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormPersonal";
            this.Text = "FormPersonal";
            this.Load += new System.EventHandler(this.FormPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataNominaPersonal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNominaPersonalBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataNominaPersonalBindingSource;
        private DataNominaPersonal dataNominaPersonal;
        internal System.Windows.Forms.TextBox txt_02;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
namespace GestionHospital.Reportes
{
    partial class Frmnomina
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
            this.dataNominas = new GestionHospital.Reportes.DataNominas();
            this.dataNominasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_01 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataNominas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNominasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataNominasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GestionHospital.Reportes.ReporteNomina.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1003, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataNominas
            // 
            this.dataNominas.DataSetName = "DataNominas";
            this.dataNominas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataNominasBindingSource
            // 
            this.dataNominasBindingSource.DataSource = this.dataNominas;
            this.dataNominasBindingSource.Position = 0;
            // 
            // txt_01
            // 
            this.txt_01.Location = new System.Drawing.Point(22, 49);
            this.txt_01.Name = "txt_01";
            this.txt_01.Size = new System.Drawing.Size(100, 22);
            this.txt_01.TabIndex = 1;
            // 
            // Frmnomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 450);
            this.Controls.Add(this.txt_01);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frmnomina";
            this.Text = "Frmnomina";
            this.Load += new System.EventHandler(this.Frmnomina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataNominas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNominasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataNominasBindingSource;
        private DataNominas dataNominas;
        internal System.Windows.Forms.TextBox txt_01;
    }
}
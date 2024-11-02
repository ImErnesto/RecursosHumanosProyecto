namespace GestionHospital.Formularios.Empleados
{
    partial class Principalrh
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.Btngestion = new FontAwesome.Sharp.IconButton();
            this.BtnNominas = new FontAwesome.Sharp.IconButton();
            this.BtnPermisos = new FontAwesome.Sharp.IconButton();
            this.Btncapacitaciones = new FontAwesome.Sharp.IconButton();
            this.BtnVacaciones = new FontAwesome.Sharp.IconButton();
            this.panelperfil = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblemail = new System.Windows.Forms.Label();
            this.lbledad = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblcargo = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Salir = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelperfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(220)))));
            this.panel1.Controls.Add(this.panelBotones);
            this.panel1.Controls.Add(this.panelperfil);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 1055);
            this.panel1.TabIndex = 0;
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.Btngestion);
            this.panelBotones.Controls.Add(this.BtnNominas);
            this.panelBotones.Controls.Add(this.BtnPermisos);
            this.panelBotones.Controls.Add(this.Btncapacitaciones);
            this.panelBotones.Controls.Add(this.BtnVacaciones);
            this.panelBotones.Location = new System.Drawing.Point(267, 498);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(1657, 554);
            this.panelBotones.TabIndex = 9;
            // 
            // Btngestion
            // 
            this.Btngestion.BackColor = System.Drawing.Color.Purple;
            this.Btngestion.FlatAppearance.BorderSize = 0;
            this.Btngestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btngestion.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btngestion.ForeColor = System.Drawing.Color.White;
            this.Btngestion.IconChar = FontAwesome.Sharp.IconChar.UserMd;
            this.Btngestion.IconColor = System.Drawing.Color.White;
            this.Btngestion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btngestion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btngestion.Location = new System.Drawing.Point(3, 0);
            this.Btngestion.Name = "Btngestion";
            this.Btngestion.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.Btngestion.Size = new System.Drawing.Size(628, 230);
            this.Btngestion.TabIndex = 4;
            this.Btngestion.Text = "Gestión empleados";
            this.Btngestion.UseVisualStyleBackColor = false;
            this.Btngestion.Click += new System.EventHandler(this.Btngestion_Click);
            // 
            // BtnNominas
            // 
            this.BtnNominas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.BtnNominas.FlatAppearance.BorderSize = 0;
            this.BtnNominas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNominas.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNominas.ForeColor = System.Drawing.Color.White;
            this.BtnNominas.IconChar = FontAwesome.Sharp.IconChar.SackDollar;
            this.BtnNominas.IconColor = System.Drawing.Color.White;
            this.BtnNominas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnNominas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNominas.Location = new System.Drawing.Point(637, 0);
            this.BtnNominas.Name = "BtnNominas";
            this.BtnNominas.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.BtnNominas.Size = new System.Drawing.Size(632, 230);
            this.BtnNominas.TabIndex = 5;
            this.BtnNominas.Text = "Generar\r\nnóminas";
            this.BtnNominas.UseVisualStyleBackColor = false;
            this.BtnNominas.Click += new System.EventHandler(this.BtnNominas_Click);
            // 
            // BtnPermisos
            // 
            this.BtnPermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BtnPermisos.FlatAppearance.BorderSize = 0;
            this.BtnPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPermisos.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPermisos.ForeColor = System.Drawing.Color.White;
            this.BtnPermisos.IconChar = FontAwesome.Sharp.IconChar.NotesMedical;
            this.BtnPermisos.IconColor = System.Drawing.Color.White;
            this.BtnPermisos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnPermisos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPermisos.Location = new System.Drawing.Point(850, 244);
            this.BtnPermisos.Name = "BtnPermisos";
            this.BtnPermisos.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.BtnPermisos.Size = new System.Drawing.Size(419, 230);
            this.BtnPermisos.TabIndex = 2;
            this.BtnPermisos.Text = "Solicitudes de \r\npermisos";
            this.BtnPermisos.UseVisualStyleBackColor = false;
            this.BtnPermisos.Click += new System.EventHandler(this.BtnPermisos_Click);
            // 
            // Btncapacitaciones
            // 
            this.Btncapacitaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(30)))));
            this.Btncapacitaciones.FlatAppearance.BorderSize = 0;
            this.Btncapacitaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btncapacitaciones.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btncapacitaciones.ForeColor = System.Drawing.Color.White;
            this.Btncapacitaciones.IconChar = FontAwesome.Sharp.IconChar.Paste;
            this.Btncapacitaciones.IconColor = System.Drawing.Color.White;
            this.Btncapacitaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btncapacitaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btncapacitaciones.Location = new System.Drawing.Point(0, 244);
            this.Btncapacitaciones.Name = "Btncapacitaciones";
            this.Btncapacitaciones.Padding = new System.Windows.Forms.Padding(10, 0, 15, 0);
            this.Btncapacitaciones.Size = new System.Drawing.Size(419, 230);
            this.Btncapacitaciones.TabIndex = 3;
            this.Btncapacitaciones.Text = "Programar \r\ncapacitaciones";
            this.Btncapacitaciones.UseVisualStyleBackColor = false;
            this.Btncapacitaciones.Click += new System.EventHandler(this.Btncapacitaciones_Click);
            // 
            // BtnVacaciones
            // 
            this.BtnVacaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(150)))), ((int)(((byte)(30)))));
            this.BtnVacaciones.FlatAppearance.BorderSize = 0;
            this.BtnVacaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVacaciones.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVacaciones.ForeColor = System.Drawing.Color.White;
            this.BtnVacaciones.IconChar = FontAwesome.Sharp.IconChar.UmbrellaBeach;
            this.BtnVacaciones.IconColor = System.Drawing.Color.White;
            this.BtnVacaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnVacaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnVacaciones.Location = new System.Drawing.Point(425, 244);
            this.BtnVacaciones.Name = "BtnVacaciones";
            this.BtnVacaciones.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.BtnVacaciones.Size = new System.Drawing.Size(419, 230);
            this.BtnVacaciones.TabIndex = 1;
            this.BtnVacaciones.Text = "Solicitudes de \r\nvacaciones";
            this.BtnVacaciones.UseVisualStyleBackColor = false;
            this.BtnVacaciones.Click += new System.EventHandler(this.BtnVacaciones_Click);
            // 
            // panelperfil
            // 
            this.panelperfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.panelperfil.Controls.Add(this.pictureBox1);
            this.panelperfil.Controls.Add(this.lblemail);
            this.panelperfil.Controls.Add(this.lbledad);
            this.panelperfil.Controls.Add(this.panel3);
            this.panelperfil.Controls.Add(this.lblcargo);
            this.panelperfil.Controls.Add(this.lblnombre);
            this.panelperfil.Location = new System.Drawing.Point(267, 195);
            this.panelperfil.Name = "panelperfil";
            this.panelperfil.Size = new System.Drawing.Size(1269, 297);
            this.panelperfil.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GestionHospital.Properties.Resources.userempleado;
            this.pictureBox1.Location = new System.Drawing.Point(221, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemail.ForeColor = System.Drawing.Color.White;
            this.lblemail.Location = new System.Drawing.Point(579, 217);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(119, 24);
            this.lblemail.TabIndex = 4;
            this.lblemail.Text = "Email jeferh";
            // 
            // lbledad
            // 
            this.lbledad.AutoSize = true;
            this.lbledad.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbledad.ForeColor = System.Drawing.Color.White;
            this.lbledad.Location = new System.Drawing.Point(579, 181);
            this.lbledad.Name = "lbledad";
            this.lbledad.Size = new System.Drawing.Size(113, 24);
            this.lbledad.TabIndex = 3;
            this.lbledad.Text = "Edad jeferh";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(584, 163);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(662, 1);
            this.panel3.TabIndex = 2;
            // 
            // lblcargo
            // 
            this.lblcargo.AutoSize = true;
            this.lblcargo.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcargo.ForeColor = System.Drawing.Color.White;
            this.lblcargo.Location = new System.Drawing.Point(578, 109);
            this.lblcargo.Name = "lblcargo";
            this.lblcargo.Size = new System.Drawing.Size(294, 28);
            this.lblcargo.TabIndex = 1;
            this.lblcargo.Text = "Jefe de Recursos Humanos";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.ForeColor = System.Drawing.Color.White;
            this.lblnombre.Location = new System.Drawing.Point(578, 55);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(229, 34);
            this.lblnombre.TabIndex = 0;
            this.lblnombre.Text = "Nombre jefederh";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.panel2.Controls.Add(this.Salir);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 147);
            this.panel2.TabIndex = 7;
            this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
            // 
            // Salir
            // 
            this.Salir.Image = global::GestionHospital.Properties.Resources.exit;
            this.Salir.Location = new System.Drawing.Point(12, 31);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(81, 75);
            this.Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Salir.TabIndex = 1;
            this.Salir.TabStop = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(902, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hospital General La Fe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Principalrh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel1);
            this.Name = "Principalrh";
            this.Text = "Principalrh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principalrh_Load);
            this.panel1.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            this.panelperfil.ResumeLayout(false);
            this.panelperfil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox Salir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelperfil;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lbledad;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblcargo;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Panel panelBotones;
        private FontAwesome.Sharp.IconButton Btngestion;
        private FontAwesome.Sharp.IconButton BtnNominas;
        private FontAwesome.Sharp.IconButton BtnPermisos;
        private FontAwesome.Sharp.IconButton Btncapacitaciones;
        private FontAwesome.Sharp.IconButton BtnVacaciones;
    }
}
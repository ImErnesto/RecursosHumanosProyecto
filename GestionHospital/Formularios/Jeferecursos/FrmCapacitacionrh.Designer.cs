namespace GestionHospital.Formularios.Jeferecursos
{
    partial class FrmCapacitacionrh
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panelelementos = new System.Windows.Forms.Panel();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Txtdescripcion = new System.Windows.Forms.TextBox();
            this.fechaCapacitacion = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.Txtnombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TxtNombres = new System.Windows.Forms.TextBox();
            this.BtnAsignar = new FontAwesome.Sharp.IconButton();
            this.comboCapacitacion = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Btneliminar = new FontAwesome.Sharp.IconButton();
            this.Btnguardar = new FontAwesome.Sharp.IconButton();
            this.BtnActualizar = new FontAwesome.Sharp.IconButton();
            this.BtnNuevo = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panelelementos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1924, 1055);
            this.splitContainer1.SplitterDistance = 1289;
            this.splitContainer1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(220)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.panelelementos);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1289, 1055);
            this.panel1.TabIndex = 0;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.label3.Location = new System.Drawing.Point(15, 756);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(394, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Asignación de capacitaciones a empleados";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 828);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1230, 289);
            this.dataGridView2.TabIndex = 14;
            // 
            // panelelementos
            // 
            this.panelelementos.Controls.Add(this.comboEstado);
            this.panelelementos.Controls.Add(this.label9);
            this.panelelementos.Controls.Add(this.label5);
            this.panelelementos.Controls.Add(this.Txtdescripcion);
            this.panelelementos.Controls.Add(this.fechaCapacitacion);
            this.panelelementos.Controls.Add(this.label6);
            this.panelelementos.Controls.Add(this.Txtnombre);
            this.panelelementos.Controls.Add(this.label4);
            this.panelelementos.Location = new System.Drawing.Point(12, 175);
            this.panelelementos.Name = "panelelementos";
            this.panelelementos.Size = new System.Drawing.Size(1230, 194);
            this.panelelementos.TabIndex = 12;
            // 
            // comboEstado
            // 
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.comboEstado.FormattingEnabled = true;
            this.comboEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.comboEstado.Location = new System.Drawing.Point(722, 75);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(234, 32);
            this.comboEstado.TabIndex = 25;
            this.comboEstado.SelectedIndexChanged += new System.EventHandler(this.comboEstado_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.label9.Location = new System.Drawing.Point(610, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 24);
            this.label9.TabIndex = 24;
            this.label9.Text = "Estado";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.label5.Location = new System.Drawing.Point(3, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "Descripción";
            // 
            // Txtdescripcion
            // 
            this.Txtdescripcion.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtdescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.Txtdescripcion.Location = new System.Drawing.Point(186, 75);
            this.Txtdescripcion.Multiline = true;
            this.Txtdescripcion.Name = "Txtdescripcion";
            this.Txtdescripcion.Size = new System.Drawing.Size(383, 107);
            this.Txtdescripcion.TabIndex = 22;
            // 
            // fechaCapacitacion
            // 
            this.fechaCapacitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaCapacitacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaCapacitacion.Location = new System.Drawing.Point(722, 6);
            this.fechaCapacitacion.Name = "fechaCapacitacion";
            this.fechaCapacitacion.Size = new System.Drawing.Size(234, 30);
            this.fechaCapacitacion.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.label6.Location = new System.Drawing.Point(618, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "Fecha";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Txtnombre
            // 
            this.Txtnombre.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtnombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.Txtnombre.Location = new System.Drawing.Point(186, 11);
            this.Txtnombre.Name = "Txtnombre";
            this.Txtnombre.Size = new System.Drawing.Size(383, 32);
            this.Txtnombre.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nombre";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 424);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1230, 289);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.panel3.Controls.Add(this.TxtNombres);
            this.panel3.Controls.Add(this.BtnAsignar);
            this.panel3.Controls.Add(this.comboCapacitacion);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.TxtID);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.Btneliminar);
            this.panel3.Controls.Add(this.Btnguardar);
            this.panel3.Controls.Add(this.BtnActualizar);
            this.panel3.Controls.Add(this.BtnNuevo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(631, 1055);
            this.panel3.TabIndex = 10;
            // 
            // TxtNombres
            // 
            this.TxtNombres.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.TxtNombres.Location = new System.Drawing.Point(33, 853);
            this.TxtNombres.Multiline = true;
            this.TxtNombres.Name = "TxtNombres";
            this.TxtNombres.ReadOnly = true;
            this.TxtNombres.Size = new System.Drawing.Size(382, 64);
            this.TxtNombres.TabIndex = 21;
            this.TxtNombres.Visible = false;
            // 
            // BtnAsignar
            // 
            this.BtnAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.BtnAsignar.FlatAppearance.BorderSize = 0;
            this.BtnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAsignar.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAsignar.ForeColor = System.Drawing.Color.White;
            this.BtnAsignar.IconChar = FontAwesome.Sharp.IconChar.Clipboard;
            this.BtnAsignar.IconColor = System.Drawing.Color.White;
            this.BtnAsignar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnAsignar.IconSize = 25;
            this.BtnAsignar.Location = new System.Drawing.Point(33, 1025);
            this.BtnAsignar.Name = "BtnAsignar";
            this.BtnAsignar.Padding = new System.Windows.Forms.Padding(75, 0, 0, 0);
            this.BtnAsignar.Size = new System.Drawing.Size(382, 70);
            this.BtnAsignar.TabIndex = 20;
            this.BtnAsignar.Text = "Asignar";
            this.BtnAsignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAsignar.UseVisualStyleBackColor = false;
            this.BtnAsignar.Click += new System.EventHandler(this.BtnAsignar_Click);
            this.BtnAsignar.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnAsignar_Paint);
            // 
            // comboCapacitacion
            // 
            this.comboCapacitacion.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCapacitacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.comboCapacitacion.FormattingEnabled = true;
            this.comboCapacitacion.Location = new System.Drawing.Point(33, 974);
            this.comboCapacitacion.Name = "comboCapacitacion";
            this.comboCapacitacion.Size = new System.Drawing.Size(382, 32);
            this.comboCapacitacion.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.label8.Location = new System.Drawing.Point(29, 931);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(269, 24);
            this.label8.TabIndex = 18;
            this.label8.Text = "Selecciona una capacitación:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtID
            // 
            this.TxtID.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.TxtID.Location = new System.Drawing.Point(33, 797);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(382, 32);
            this.TxtID.TabIndex = 17;
            this.TxtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.label7.Location = new System.Drawing.Point(29, 756);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(288, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ingresa un ID y presiona Enter:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btneliminar
            // 
            this.Btneliminar.BackColor = System.Drawing.Color.White;
            this.Btneliminar.FlatAppearance.BorderSize = 0;
            this.Btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btneliminar.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btneliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.Btneliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.Btneliminar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.Btneliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btneliminar.IconSize = 25;
            this.Btneliminar.Location = new System.Drawing.Point(33, 502);
            this.Btneliminar.Name = "Btneliminar";
            this.Btneliminar.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.Btneliminar.Size = new System.Drawing.Size(382, 70);
            this.Btneliminar.TabIndex = 13;
            this.Btneliminar.Text = "Eliminar";
            this.Btneliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btneliminar.UseVisualStyleBackColor = false;
            this.Btneliminar.Click += new System.EventHandler(this.Btneliminar_Click);
            this.Btneliminar.Paint += new System.Windows.Forms.PaintEventHandler(this.Btneliminar_Paint);
            // 
            // Btnguardar
            // 
            this.Btnguardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.Btnguardar.FlatAppearance.BorderSize = 0;
            this.Btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnguardar.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnguardar.ForeColor = System.Drawing.Color.White;
            this.Btnguardar.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.Btnguardar.IconColor = System.Drawing.Color.White;
            this.Btnguardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btnguardar.IconSize = 25;
            this.Btnguardar.Location = new System.Drawing.Point(33, 399);
            this.Btnguardar.Name = "Btnguardar";
            this.Btnguardar.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.Btnguardar.Size = new System.Drawing.Size(382, 70);
            this.Btnguardar.TabIndex = 12;
            this.Btnguardar.Text = "Guardar capacitacion";
            this.Btnguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btnguardar.UseVisualStyleBackColor = false;
            this.Btnguardar.Click += new System.EventHandler(this.Btnguardar_Click);
            this.Btnguardar.Paint += new System.Windows.Forms.PaintEventHandler(this.Btnguardar_Paint);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.BtnActualizar.FlatAppearance.BorderSize = 0;
            this.BtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnActualizar.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.ForeColor = System.Drawing.Color.White;
            this.BtnActualizar.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.BtnActualizar.IconColor = System.Drawing.Color.White;
            this.BtnActualizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnActualizar.IconSize = 25;
            this.BtnActualizar.Location = new System.Drawing.Point(33, 175);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.BtnActualizar.Size = new System.Drawing.Size(382, 70);
            this.BtnActualizar.TabIndex = 11;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnActualizar.UseVisualStyleBackColor = false;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            this.BtnActualizar.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnActualizar_Paint);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.BackColor = System.Drawing.Color.White;
            this.BtnNuevo.FlatAppearance.BorderSize = 0;
            this.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNuevo.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.BtnNuevo.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.BtnNuevo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.BtnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnNuevo.IconSize = 25;
            this.BtnNuevo.Location = new System.Drawing.Point(33, 287);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.BtnNuevo.Size = new System.Drawing.Size(382, 70);
            this.BtnNuevo.TabIndex = 10;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNuevo.UseVisualStyleBackColor = false;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            this.BtnNuevo.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnNuevo_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 147);
            this.panel2.TabIndex = 13;
            this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GestionHospital.Properties.Resources.exit;
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
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
            // FrmCapacitacionrh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmCapacitacionrh";
            this.Text = "FrmCapacitacionrh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCapacitacionrh_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panelelementos.ResumeLayout(false);
            this.panelelementos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelelementos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txtdescripcion;
        private System.Windows.Forms.DateTimePicker fechaCapacitacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txtnombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton BtnNuevo;
        private FontAwesome.Sharp.IconButton BtnActualizar;
        private FontAwesome.Sharp.IconButton Btnguardar;
        private FontAwesome.Sharp.IconButton Btneliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton BtnAsignar;
        private System.Windows.Forms.ComboBox comboCapacitacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtNombres;
    }
}
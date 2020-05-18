namespace CapaVistaCONTA
{
    partial class cuentas_contables
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cuentas_contables));
			this.Cmb_Tipo = new System.Windows.Forms.ComboBox();
			this.Txt_nombre = new System.Windows.Forms.TextBox();
			this.Txt_desc = new System.Windows.Forms.TextBox();
			this.Btn_guardar = new System.Windows.Forms.Button();
			this.Txt_Id = new System.Windows.Forms.TextBox();
			this.Btn_plusLevel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Dtgv_Cuentas = new System.Windows.Forms.DataGridView();
			this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Dtgv_Cuentas)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Cmb_Tipo
			// 
			this.Cmb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Cmb_Tipo.FormattingEnabled = true;
			this.Cmb_Tipo.Location = new System.Drawing.Point(41, 145);
			this.Cmb_Tipo.Name = "Cmb_Tipo";
			this.Cmb_Tipo.Size = new System.Drawing.Size(185, 29);
			this.Cmb_Tipo.TabIndex = 0;
			this.Cmb_Tipo.SelectedIndexChanged += new System.EventHandler(this.Cmb_Tipo_SelectedIndexChanged);
			// 
			// Txt_nombre
			// 
			this.Txt_nombre.Location = new System.Drawing.Point(242, 145);
			this.Txt_nombre.Name = "Txt_nombre";
			this.Txt_nombre.Size = new System.Drawing.Size(222, 27);
			this.Txt_nombre.TabIndex = 1;
			// 
			// Txt_desc
			// 
			this.Txt_desc.Location = new System.Drawing.Point(488, 82);
			this.Txt_desc.Multiline = true;
			this.Txt_desc.Name = "Txt_desc";
			this.Txt_desc.Size = new System.Drawing.Size(423, 92);
			this.Txt_desc.TabIndex = 2;
			// 
			// Btn_guardar
			// 
			this.Btn_guardar.BackColor = System.Drawing.Color.DarkRed;
			this.Btn_guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.Btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Btn_guardar.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Btn_guardar.ForeColor = System.Drawing.Color.White;
			this.Btn_guardar.Location = new System.Drawing.Point(950, 121);
			this.Btn_guardar.Name = "Btn_guardar";
			this.Btn_guardar.Size = new System.Drawing.Size(130, 53);
			this.Btn_guardar.TabIndex = 3;
			this.Btn_guardar.Text = "Guardar";
			this.Btn_guardar.UseVisualStyleBackColor = false;
			this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
			// 
			// Txt_Id
			// 
			this.Txt_Id.Enabled = false;
			this.Txt_Id.Location = new System.Drawing.Point(38, 74);
			this.Txt_Id.Name = "Txt_Id";
			this.Txt_Id.Size = new System.Drawing.Size(185, 27);
			this.Txt_Id.TabIndex = 4;
			// 
			// Btn_plusLevel
			// 
			this.Btn_plusLevel.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Btn_plusLevel.Location = new System.Drawing.Point(239, 69);
			this.Btn_plusLevel.Name = "Btn_plusLevel";
			this.Btn_plusLevel.Size = new System.Drawing.Size(222, 32);
			this.Btn_plusLevel.TabIndex = 5;
			this.Btn_plusLevel.Text = "Agregar Manualmente";
			this.Btn_plusLevel.UseVisualStyleBackColor = true;
			this.Btn_plusLevel.Click += new System.EventHandler(this.Btn_plusLevel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.White;
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.Txt_desc);
			this.groupBox1.Controls.Add(this.Btn_plusLevel);
			this.groupBox1.Controls.Add(this.Cmb_Tipo);
			this.groupBox1.Controls.Add(this.Txt_Id);
			this.groupBox1.Controls.Add(this.Txt_nombre);
			this.groupBox1.Controls.Add(this.Btn_guardar);
			this.groupBox1.Location = new System.Drawing.Point(12, 122);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1093, 192);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Registro de Cuentas";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(950, 82);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(83, 25);
			this.checkBox1.TabIndex = 10;
			this.checkBox1.Text = "Activa";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(629, 58);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(164, 21);
			this.label4.TabIndex = 9;
			this.label4.Text = "Descripción Cuenta";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(283, 121);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 21);
			this.label3.TabIndex = 8;
			this.label3.Text = "Nombre Cuenta";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(60, 121);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(129, 21);
			this.label2.TabIndex = 7;
			this.label2.Text = "Tipo de Cuenta";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(44, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(155, 21);
			this.label1.TabIndex = 6;
			this.label1.Text = "Código de Cuenta";
			// 
			// Dtgv_Cuentas
			// 
			this.Dtgv_Cuentas.AllowUserToAddRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkRed;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.IndianRed;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Dtgv_Cuentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.Dtgv_Cuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Dtgv_Cuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Código,
            this.Cuenta,
            this.estado});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkRed;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.Dtgv_Cuentas.DefaultCellStyle = dataGridViewCellStyle2;
			this.Dtgv_Cuentas.Location = new System.Drawing.Point(12, 395);
			this.Dtgv_Cuentas.Name = "Dtgv_Cuentas";
			this.Dtgv_Cuentas.ReadOnly = true;
			this.Dtgv_Cuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Dtgv_Cuentas.Size = new System.Drawing.Size(1067, 355);
			this.Dtgv_Cuentas.TabIndex = 7;
			this.Dtgv_Cuentas.TabStop = false;
			this.Dtgv_Cuentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtgv_Cuentas_CellDoubleClick);
			this.Dtgv_Cuentas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtgv_Cuentas_CellEnter);
			this.Dtgv_Cuentas.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtgv_Cuentas_CellMouseEnter);
			this.Dtgv_Cuentas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dtgv_Cuentas_CellMouseMove);
			this.Dtgv_Cuentas.MouseEnter += new System.EventHandler(this.Dtgv_Cuentas_MouseEnter);
			// 
			// Código
			// 
			this.Código.HeaderText = "Código";
			this.Código.Name = "Código";
			this.Código.ReadOnly = true;
			this.Código.Width = 200;
			// 
			// Cuenta
			// 
			this.Cuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Cuenta.HeaderText = "Cuenta";
			this.Cuenta.Name = "Cuenta";
			this.Cuenta.ReadOnly = true;
			// 
			// estado
			// 
			this.estado.HeaderText = "Estado Cuenta";
			this.estado.Name = "estado";
			this.estado.ReadOnly = true;
			this.estado.Width = 200;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Maroon;
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Location = new System.Drawing.Point(-6, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1125, 116);
			this.panel1.TabIndex = 11;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox2.BackgroundImage = global::CapaVistaFRM.Properties.Resources.ayuda;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox2.Location = new System.Drawing.Point(1069, 4);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(51, 44);
			this.pictureBox2.TabIndex = 12;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Location = new System.Drawing.Point(952, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(115, 110);
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(18, 19);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(623, 77);
			this.label6.TabIndex = 10;
			this.label6.Text = "Cuentas Contables";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.DarkRed;
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(279, 333);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(220, 53);
			this.button1.TabIndex = 11;
			this.button1.Text = "Eliminar Cuenta";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// cuentas_contables
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1117, 762);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.Dtgv_Cuentas);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1133, 801);
			this.Name = "cuentas_contables";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "5112 - Cuentas Contables";
			this.Load += new System.EventHandler(this.Cuentas_contables_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Dtgv_Cuentas)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.ComboBox Cmb_Tipo;
		private System.Windows.Forms.TextBox Txt_nombre;
		private System.Windows.Forms.TextBox Txt_desc;
		private System.Windows.Forms.Button Btn_guardar;
		private System.Windows.Forms.TextBox Txt_Id;
		private System.Windows.Forms.Button Btn_plusLevel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView Dtgv_Cuentas;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Código;
		private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
		private System.Windows.Forms.DataGridViewTextBoxColumn estado;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox2;
	}
}
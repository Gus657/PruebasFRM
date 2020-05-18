namespace CapaDiseno
{
    partial class frm_asignacion_perfiles
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
            this.dgv_perfiles_asignados = new System.Windows.Forms.DataGridView();
            this.dgv_asignacion_perfiles = new System.Windows.Forms.DataGridView();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombrePerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbo_usuarios = new System.Windows.Forms.ComboBox();
            this.lbl_usuarios = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_remover = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.btn_quitar = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.lbl_perfiles = new System.Windows.Forms.Label();
            this.cbo_perfiles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_usuario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ayuda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_perfiles_asignados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_asignacion_perfiles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_perfiles_asignados
            // 
            this.dgv_perfiles_asignados.AllowUserToAddRows = false;
            this.dgv_perfiles_asignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_perfiles_asignados.Location = new System.Drawing.Point(20, 72);
            this.dgv_perfiles_asignados.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_perfiles_asignados.Name = "dgv_perfiles_asignados";
            this.dgv_perfiles_asignados.Size = new System.Drawing.Size(250, 276);
            this.dgv_perfiles_asignados.TabIndex = 0;
            this.dgv_perfiles_asignados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_perfiles_asignados_CellContentClick);
            // 
            // dgv_asignacion_perfiles
            // 
            this.dgv_asignacion_perfiles.AllowUserToAddRows = false;
            this.dgv_asignacion_perfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_asignacion_perfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Usuario,
            this.NombrePerfil});
            this.dgv_asignacion_perfiles.Location = new System.Drawing.Point(8, 128);
            this.dgv_asignacion_perfiles.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_asignacion_perfiles.Name = "dgv_asignacion_perfiles";
            this.dgv_asignacion_perfiles.Size = new System.Drawing.Size(323, 218);
            this.dgv_asignacion_perfiles.TabIndex = 1;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.Width = 140;
            // 
            // NombrePerfil
            // 
            this.NombrePerfil.HeaderText = "Perfil";
            this.NombrePerfil.Name = "NombrePerfil";
            this.NombrePerfil.Width = 140;
            // 
            // cbo_usuarios
            // 
            this.cbo_usuarios.FormattingEnabled = true;
            this.cbo_usuarios.Location = new System.Drawing.Point(77, 39);
            this.cbo_usuarios.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_usuarios.Name = "cbo_usuarios";
            this.cbo_usuarios.Size = new System.Drawing.Size(241, 25);
            this.cbo_usuarios.TabIndex = 2;
            this.cbo_usuarios.SelectedIndexChanged += new System.EventHandler(this.Cbo_usuarios_SelectedIndexChanged);
            // 
            // lbl_usuarios
            // 
            this.lbl_usuarios.AutoSize = true;
            this.lbl_usuarios.Location = new System.Drawing.Point(17, 42);
            this.lbl_usuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_usuarios.Name = "lbl_usuarios";
            this.lbl_usuarios.Size = new System.Drawing.Size(59, 17);
            this.lbl_usuarios.TabIndex = 3;
            this.lbl_usuarios.Text = "Usuarios";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_remover);
            this.groupBox1.Controls.Add(this.dgv_perfiles_asignados);
            this.groupBox1.Controls.Add(this.lbl_usuarios);
            this.groupBox1.Controls.Add(this.cbo_usuarios);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 73);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(336, 371);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta de Perfiles de Usuarios";
            // 
            // btn_remover
            // 
            this.btn_remover.Location = new System.Drawing.Point(278, 72);
            this.btn_remover.Margin = new System.Windows.Forms.Padding(4);
            this.btn_remover.Name = "btn_remover";
            this.btn_remover.Size = new System.Drawing.Size(40, 30);
            this.btn_remover.TabIndex = 4;
            this.btn_remover.Text = "X";
            this.btn_remover.UseVisualStyleBackColor = true;
            this.btn_remover.Click += new System.EventHandler(this.Btn_remover_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_finalizar);
            this.groupBox2.Controls.Add(this.btn_quitar);
            this.groupBox2.Controls.Add(this.btn_agregar);
            this.groupBox2.Controls.Add(this.lbl_perfiles);
            this.groupBox2.Controls.Add(this.cbo_perfiles);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbo_usuario);
            this.groupBox2.Controls.Add(this.dgv_asignacion_perfiles);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(357, 73);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(468, 371);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Asignacion de Perfiles a Usuarios";
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.Location = new System.Drawing.Point(339, 313);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(99, 35);
            this.btn_finalizar.TabIndex = 10;
            this.btn_finalizar.Text = "Finalizar";
            this.btn_finalizar.UseVisualStyleBackColor = true;
            this.btn_finalizar.Click += new System.EventHandler(this.Btn_finalizar_Click);
            // 
            // btn_quitar
            // 
            this.btn_quitar.Location = new System.Drawing.Point(339, 141);
            this.btn_quitar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_quitar.Name = "btn_quitar";
            this.btn_quitar.Size = new System.Drawing.Size(40, 30);
            this.btn_quitar.TabIndex = 9;
            this.btn_quitar.Text = "X";
            this.btn_quitar.UseVisualStyleBackColor = true;
            this.btn_quitar.Click += new System.EventHandler(this.Btn_quitar_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(178, 87);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(109, 33);
            this.btn_agregar.TabIndex = 8;
            this.btn_agregar.Text = "agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.Btn_agregar_Click);
            // 
            // lbl_perfiles
            // 
            this.lbl_perfiles.AutoSize = true;
            this.lbl_perfiles.Location = new System.Drawing.Point(319, 28);
            this.lbl_perfiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_perfiles.Name = "lbl_perfiles";
            this.lbl_perfiles.Size = new System.Drawing.Size(51, 17);
            this.lbl_perfiles.TabIndex = 7;
            this.lbl_perfiles.Text = "Perfiles";
            // 
            // cbo_perfiles
            // 
            this.cbo_perfiles.FormattingEnabled = true;
            this.cbo_perfiles.Location = new System.Drawing.Point(257, 54);
            this.cbo_perfiles.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_perfiles.Name = "cbo_perfiles";
            this.cbo_perfiles.Size = new System.Drawing.Size(199, 25);
            this.cbo_perfiles.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Usuario";
            // 
            // cbo_usuario
            // 
            this.cbo_usuario.FormattingEnabled = true;
            this.cbo_usuario.Location = new System.Drawing.Point(11, 54);
            this.cbo_usuario.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_usuario.Name = "cbo_usuario";
            this.cbo_usuario.Size = new System.Drawing.Size(199, 25);
            this.cbo_usuario.TabIndex = 4;
            this.cbo_usuario.SelectedIndexChanged += new System.EventHandler(this.Cbo_usuario_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "ASIGNACION DE PERFILES";
            // 
            // btn_ayuda
            // 
            this.btn_ayuda.Image = global::CapaDiseno.Properties.Resources.icons8_ayuda_30;
            this.btn_ayuda.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ayuda.Location = new System.Drawing.Point(740, 6);
            this.btn_ayuda.Name = "btn_ayuda";
            this.btn_ayuda.Size = new System.Drawing.Size(86, 36);
            this.btn_ayuda.TabIndex = 252;
            this.btn_ayuda.Text = "Ayuda";
            this.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ayuda.UseVisualStyleBackColor = true;
            this.btn_ayuda.Click += new System.EventHandler(this.Btn_ayuda_Click);
            // 
            // frm_asignacion_perfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 514);
            this.Controls.Add(this.btn_ayuda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_asignacion_perfiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignacion de Perfiles a Usuarios";
            this.Load += new System.EventHandler(this.Frm_asignacion_perfiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_perfiles_asignados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_asignacion_perfiles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_perfiles_asignados;
        private System.Windows.Forms.DataGridView dgv_asignacion_perfiles;
        private System.Windows.Forms.ComboBox cbo_usuarios;
        private System.Windows.Forms.Label lbl_usuarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_remover;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_quitar;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Label lbl_perfiles;
        private System.Windows.Forms.ComboBox cbo_perfiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_usuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombrePerfil;
        private System.Windows.Forms.Button btn_ayuda;
    }
}
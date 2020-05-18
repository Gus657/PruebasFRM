namespace CapaDiseno
{
    partial class frm_loginAlterno
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
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.Cb_ver_password = new System.Windows.Forms.CheckBox();
            this.Txt_clave = new System.Windows.Forms.TextBox();
            this.Txt_usuario = new System.Windows.Forms.TextBox();
            this.Btn_entrar = new System.Windows.Forms.Button();
            this.Lbl_usuario = new System.Windows.Forms.Label();
            this.Lbl_clave = new System.Windows.Forms.Label();
            this.btn_ayuda = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 44);
            this.label2.TabIndex = 218;
            this.label2.Text = "Modulo seguridad";
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.BackColor = System.Drawing.Color.Teal;
            this.Btn_cancelar.Font = new System.Drawing.Font("Candara", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_cancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Btn_cancelar.Location = new System.Drawing.Point(438, 260);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(180, 58);
            this.Btn_cancelar.TabIndex = 214;
            this.Btn_cancelar.Tag = "4";
            this.Btn_cancelar.Text = "Cancelar";
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // Cb_ver_password
            // 
            this.Cb_ver_password.AutoSize = true;
            this.Cb_ver_password.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cb_ver_password.Location = new System.Drawing.Point(646, 203);
            this.Cb_ver_password.Name = "Cb_ver_password";
            this.Cb_ver_password.Size = new System.Drawing.Size(146, 39);
            this.Cb_ver_password.TabIndex = 215;
            this.Cb_ver_password.Tag = "5";
            this.Cb_ver_password.Text = "Ver clave";
            this.Cb_ver_password.UseVisualStyleBackColor = true;
            this.Cb_ver_password.CheckedChanged += new System.EventHandler(this.Cb_ver_password_CheckedChanged);
            // 
            // Txt_clave
            // 
            this.Txt_clave.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_clave.Location = new System.Drawing.Point(249, 198);
            this.Txt_clave.Name = "Txt_clave";
            this.Txt_clave.Size = new System.Drawing.Size(367, 42);
            this.Txt_clave.TabIndex = 212;
            this.Txt_clave.Tag = "2";
            // 
            // Txt_usuario
            // 
            this.Txt_usuario.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_usuario.Location = new System.Drawing.Point(249, 149);
            this.Txt_usuario.Name = "Txt_usuario";
            this.Txt_usuario.Size = new System.Drawing.Size(367, 42);
            this.Txt_usuario.TabIndex = 211;
            this.Txt_usuario.Tag = "1";
            // 
            // Btn_entrar
            // 
            this.Btn_entrar.BackColor = System.Drawing.Color.Teal;
            this.Btn_entrar.Font = new System.Drawing.Font("Candara", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_entrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Btn_entrar.Location = new System.Drawing.Point(249, 260);
            this.Btn_entrar.Name = "Btn_entrar";
            this.Btn_entrar.Size = new System.Drawing.Size(180, 58);
            this.Btn_entrar.TabIndex = 213;
            this.Btn_entrar.Tag = "1";
            this.Btn_entrar.Text = "Entrar";
            this.Btn_entrar.UseVisualStyleBackColor = false;
            this.Btn_entrar.Click += new System.EventHandler(this.Btn_entrar_Click);
            // 
            // Lbl_usuario
            // 
            this.Lbl_usuario.AutoSize = true;
            this.Lbl_usuario.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_usuario.Location = new System.Drawing.Point(128, 149);
            this.Lbl_usuario.Name = "Lbl_usuario";
            this.Lbl_usuario.Size = new System.Drawing.Size(114, 35);
            this.Lbl_usuario.TabIndex = 217;
            this.Lbl_usuario.Text = "Usuario:";
            // 
            // Lbl_clave
            // 
            this.Lbl_clave.AutoSize = true;
            this.Lbl_clave.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_clave.Location = new System.Drawing.Point(158, 198);
            this.Lbl_clave.Name = "Lbl_clave";
            this.Lbl_clave.Size = new System.Drawing.Size(84, 35);
            this.Lbl_clave.TabIndex = 216;
            this.Lbl_clave.Text = "Clave:";
            // 
            // btn_ayuda
            // 
            this.btn_ayuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ayuda.Image = global::CapaDiseno.Properties.Resources.icons8_ayuda_30;
            this.btn_ayuda.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ayuda.Location = new System.Drawing.Point(717, 18);
            this.btn_ayuda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ayuda.Name = "btn_ayuda";
            this.btn_ayuda.Size = new System.Drawing.Size(129, 55);
            this.btn_ayuda.TabIndex = 252;
            this.btn_ayuda.Text = "Ayuda";
            this.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ayuda.UseVisualStyleBackColor = true;
            this.btn_ayuda.Click += new System.EventHandler(this.Btn_ayuda_Click);
            // 
            // frm_loginAlterno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 440);
            this.ControlBox = false;
            this.Controls.Add(this.btn_ayuda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btn_cancelar);
            this.Controls.Add(this.Cb_ver_password);
            this.Controls.Add(this.Txt_clave);
            this.Controls.Add(this.Txt_usuario);
            this.Controls.Add(this.Btn_entrar);
            this.Controls.Add(this.Lbl_usuario);
            this.Controls.Add(this.Lbl_clave);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_loginAlterno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_loginAlterno_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.CheckBox Cb_ver_password;
        private System.Windows.Forms.TextBox Txt_clave;
        public System.Windows.Forms.TextBox Txt_usuario;
        private System.Windows.Forms.Button Btn_entrar;
        private System.Windows.Forms.Label Lbl_usuario;
        private System.Windows.Forms.Label Lbl_clave;
        private System.Windows.Forms.Button btn_ayuda;
    }
}
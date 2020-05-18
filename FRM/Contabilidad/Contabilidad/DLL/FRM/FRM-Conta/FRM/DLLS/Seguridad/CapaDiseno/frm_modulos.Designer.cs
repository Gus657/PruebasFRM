namespace CapaDiseno
{
    partial class frm_modulos
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
            this.btn_ingresar = new System.Windows.Forms.Button();
            this.btn_modif = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.gbestado = new System.Windows.Forms.GroupBox();
            this.rbinhabilitado = new System.Windows.Forms.RadioButton();
            this.rbhabilitado = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_buscarmodulo = new System.Windows.Forms.TextBox();
            this.btn_bsucarmodulo = new System.Windows.Forms.Button();
            this.gbbuscar = new System.Windows.Forms.GroupBox();
            this.btn_ayuda = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbestado.SuspendLayout();
            this.gbbuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ingresar
            // 
            this.btn_ingresar.Location = new System.Drawing.Point(21, 102);
            this.btn_ingresar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ingresar.Name = "btn_ingresar";
            this.btn_ingresar.Size = new System.Drawing.Size(100, 30);
            this.btn_ingresar.TabIndex = 3;
            this.btn_ingresar.Tag = "3";
            this.btn_ingresar.Text = "Ingresar";
            this.btn_ingresar.UseVisualStyleBackColor = true;
            this.btn_ingresar.Click += new System.EventHandler(this.Btn_ingresar_Click);
            // 
            // btn_modif
            // 
            this.btn_modif.Location = new System.Drawing.Point(21, 208);
            this.btn_modif.Margin = new System.Windows.Forms.Padding(4);
            this.btn_modif.Name = "btn_modif";
            this.btn_modif.Size = new System.Drawing.Size(100, 30);
            this.btn_modif.TabIndex = 1;
            this.btn_modif.Text = "Modificar";
            this.btn_modif.UseVisualStyleBackColor = true;
            this.btn_modif.Click += new System.EventHandler(this.Btn_modif_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_nuevo);
            this.groupBox1.Controls.Add(this.btn_actualizar);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btn_salir);
            this.groupBox1.Controls.Add(this.btn_cancel);
            this.groupBox1.Controls.Add(this.btn_ingresar);
            this.groupBox1.Controls.Add(this.btn_modif);
            this.groupBox1.Location = new System.Drawing.Point(679, 123);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(152, 360);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Location = new System.Drawing.Point(21, 44);
            this.btn_nuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(100, 30);
            this.btn_nuevo.TabIndex = 0;
            this.btn_nuevo.Tag = "0";
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.Location = new System.Drawing.Point(21, 158);
            this.btn_actualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(100, 30);
            this.btn_actualizar.TabIndex = 6;
            this.btn_actualizar.Text = "Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = true;
            this.btn_actualizar.Click += new System.EventHandler(this.Btn_actualizar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 309);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(581, 46);
            this.btn_salir.Margin = new System.Windows.Forms.Padding(4);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(95, 30);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(21, 258);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 30);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtdesc);
            this.groupBox2.Controls.Add(this.txtnombre);
            this.groupBox2.Controls.Add(this.txtcodigo);
            this.groupBox2.Controls.Add(this.gbestado);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(23, 123);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(648, 360);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(248, 143);
            this.txtdesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtdesc.Multiline = true;
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(296, 45);
            this.txtdesc.TabIndex = 2;
            this.txtdesc.Tag = "2";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(248, 102);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(296, 30);
            this.txtnombre.TabIndex = 1;
            this.txtnombre.Tag = "1";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(248, 54);
            this.txtcodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(132, 30);
            this.txtcodigo.TabIndex = 4;
            // 
            // gbestado
            // 
            this.gbestado.Controls.Add(this.rbinhabilitado);
            this.gbestado.Controls.Add(this.rbhabilitado);
            this.gbestado.Location = new System.Drawing.Point(72, 208);
            this.gbestado.Margin = new System.Windows.Forms.Padding(4);
            this.gbestado.Name = "gbestado";
            this.gbestado.Padding = new System.Windows.Forms.Padding(4);
            this.gbestado.Size = new System.Drawing.Size(481, 131);
            this.gbestado.TabIndex = 3;
            this.gbestado.TabStop = false;
            this.gbestado.Text = "Estado";
            // 
            // rbinhabilitado
            // 
            this.rbinhabilitado.AutoSize = true;
            this.rbinhabilitado.Location = new System.Drawing.Point(284, 69);
            this.rbinhabilitado.Margin = new System.Windows.Forms.Padding(4);
            this.rbinhabilitado.Name = "rbinhabilitado";
            this.rbinhabilitado.Size = new System.Drawing.Size(136, 29);
            this.rbinhabilitado.TabIndex = 1;
            this.rbinhabilitado.TabStop = true;
            this.rbinhabilitado.Text = "Inhabilitado";
            this.rbinhabilitado.UseVisualStyleBackColor = true;
            // 
            // rbhabilitado
            // 
            this.rbhabilitado.AutoSize = true;
            this.rbhabilitado.Location = new System.Drawing.Point(89, 69);
            this.rbhabilitado.Margin = new System.Windows.Forms.Padding(4);
            this.rbhabilitado.Name = "rbhabilitado";
            this.rbhabilitado.Size = new System.Drawing.Size(123, 29);
            this.rbhabilitado.TabIndex = 0;
            this.rbhabilitado.TabStop = true;
            this.rbhabilitado.Text = "Habilitado";
            this.rbhabilitado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo de Modulo";
            // 
            // tbx_buscarmodulo
            // 
            this.tbx_buscarmodulo.Location = new System.Drawing.Point(95, 44);
            this.tbx_buscarmodulo.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_buscarmodulo.Name = "tbx_buscarmodulo";
            this.tbx_buscarmodulo.Size = new System.Drawing.Size(296, 30);
            this.tbx_buscarmodulo.TabIndex = 6;
            // 
            // btn_bsucarmodulo
            // 
            this.btn_bsucarmodulo.Location = new System.Drawing.Point(427, 41);
            this.btn_bsucarmodulo.Margin = new System.Windows.Forms.Padding(4);
            this.btn_bsucarmodulo.Name = "btn_bsucarmodulo";
            this.btn_bsucarmodulo.Size = new System.Drawing.Size(100, 30);
            this.btn_bsucarmodulo.TabIndex = 7;
            this.btn_bsucarmodulo.Text = "Buscar";
            this.btn_bsucarmodulo.UseVisualStyleBackColor = true;
            this.btn_bsucarmodulo.Click += new System.EventHandler(this.Btn_bsucarmodulo_Click);
            // 
            // gbbuscar
            // 
            this.gbbuscar.Controls.Add(this.btn_bsucarmodulo);
            this.gbbuscar.Controls.Add(this.tbx_buscarmodulo);
            this.gbbuscar.Location = new System.Drawing.Point(95, 13);
            this.gbbuscar.Margin = new System.Windows.Forms.Padding(4);
            this.gbbuscar.Name = "gbbuscar";
            this.gbbuscar.Padding = new System.Windows.Forms.Padding(4);
            this.gbbuscar.Size = new System.Drawing.Size(606, 102);
            this.gbbuscar.TabIndex = 8;
            this.gbbuscar.TabStop = false;
            this.gbbuscar.Text = "Buscar Módulo";
            // 
            // btn_ayuda
            // 
            this.btn_ayuda.Image = global::CapaDiseno.Properties.Resources.icons8_ayuda_30;
            this.btn_ayuda.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ayuda.Location = new System.Drawing.Point(745, 12);
            this.btn_ayuda.Name = "btn_ayuda";
            this.btn_ayuda.Size = new System.Drawing.Size(86, 36);
            this.btn_ayuda.TabIndex = 252;
            this.btn_ayuda.Text = "Ayuda";
            this.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ayuda.UseVisualStyleBackColor = true;
            this.btn_ayuda.Click += new System.EventHandler(this.Btn_ayuda_Click);
            // 
            // frm_modulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 514);
            this.Controls.Add(this.btn_ayuda);
            this.Controls.Add(this.gbbuscar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_modulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Modulos";
            this.Load += new System.EventHandler(this.Frm_modulos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbestado.ResumeLayout(false);
            this.gbestado.PerformLayout();
            this.gbbuscar.ResumeLayout(false);
            this.gbbuscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ingresar;
        private System.Windows.Forms.Button btn_modif;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtdesc;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.GroupBox gbestado;
        private System.Windows.Forms.RadioButton rbinhabilitado;
        private System.Windows.Forms.RadioButton rbhabilitado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.TextBox tbx_buscarmodulo;
        private System.Windows.Forms.Button btn_bsucarmodulo;
        private System.Windows.Forms.GroupBox gbbuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Button btn_ayuda;
    }
}
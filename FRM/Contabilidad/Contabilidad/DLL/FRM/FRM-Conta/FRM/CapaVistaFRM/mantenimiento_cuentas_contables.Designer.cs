namespace CapaVistaFRM
{
    partial class mantenimiento_cuentas_contables
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
			this.navegador1 = new CapaDeDiseno.Navegador();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// navegador1
			// 
			this.navegador1.AutoSize = true;
			this.navegador1.BackColor = System.Drawing.Color.White;
			this.navegador1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.navegador1.Location = new System.Drawing.Point(0, 59);
			this.navegador1.Margin = new System.Windows.Forms.Padding(5);
			this.navegador1.Name = "navegador1";
			this.navegador1.Size = new System.Drawing.Size(838, 620);
			this.navegador1.TabIndex = 0;
			this.navegador1.Load += new System.EventHandler(this.Navegador1_Load);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(840, 83);
			this.panel1.TabIndex = 1;
			// 
			// mantenimiento_cuentas_contables
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(840, 681);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.navegador1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "mantenimiento_cuentas_contables";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Módulos";
			this.Load += new System.EventHandler(this.Mantenimiento_cuentas_contables_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private CapaDeDiseno.Navegador navegador1;
        private System.Windows.Forms.Panel panel1;
    }
}
namespace CapaVistaCONTA
{
    partial class MDI_CONTA
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDI_CONTA));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mantenimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tiposDeCuentasContablesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cuentasContablesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.empresasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tipoDePólizaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contabilidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.libroDiarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.libroMayorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.balanceGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.estadoDeResultadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bALANCEGENERALToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.seguridadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Lbl_usuario = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.mantenimientosToolStripMenuItem,
            this.contabilidadToolStripMenuItem,
            this.seguridadToolStripMenuItem,
            this.ayudaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// inicioToolStripMenuItem
			// 
			this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
			this.inicioToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
			this.inicioToolStripMenuItem.Text = "Inicio";
			// 
			// mantenimientosToolStripMenuItem
			// 
			this.mantenimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiposDeCuentasContablesToolStripMenuItem1,
            this.cuentasContablesToolStripMenuItem1,
            this.empresasToolStripMenuItem,
            this.tipoDePólizaToolStripMenuItem});
			this.mantenimientosToolStripMenuItem.Name = "mantenimientosToolStripMenuItem";
			this.mantenimientosToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
			this.mantenimientosToolStripMenuItem.Text = "Mantenimientos";
			// 
			// tiposDeCuentasContablesToolStripMenuItem1
			// 
			this.tiposDeCuentasContablesToolStripMenuItem1.Name = "tiposDeCuentasContablesToolStripMenuItem1";
			this.tiposDeCuentasContablesToolStripMenuItem1.Size = new System.Drawing.Size(325, 24);
			this.tiposDeCuentasContablesToolStripMenuItem1.Text = "5111 - Tipos de Cuentas Contables";
			this.tiposDeCuentasContablesToolStripMenuItem1.Click += new System.EventHandler(this.TiposDeCuentasContablesToolStripMenuItem1_Click);
			// 
			// cuentasContablesToolStripMenuItem1
			// 
			this.cuentasContablesToolStripMenuItem1.Name = "cuentasContablesToolStripMenuItem1";
			this.cuentasContablesToolStripMenuItem1.Size = new System.Drawing.Size(325, 24);
			this.cuentasContablesToolStripMenuItem1.Text = "5112 - Cuentas Contables";
			this.cuentasContablesToolStripMenuItem1.Click += new System.EventHandler(this.CuentasContablesToolStripMenuItem1_Click);
			// 
			// empresasToolStripMenuItem
			// 
			this.empresasToolStripMenuItem.Name = "empresasToolStripMenuItem";
			this.empresasToolStripMenuItem.Size = new System.Drawing.Size(325, 24);
			this.empresasToolStripMenuItem.Text = "5113 - Empresas";
			this.empresasToolStripMenuItem.Click += new System.EventHandler(this.EmpresasToolStripMenuItem_Click);
			// 
			// tipoDePólizaToolStripMenuItem
			// 
			this.tipoDePólizaToolStripMenuItem.Name = "tipoDePólizaToolStripMenuItem";
			this.tipoDePólizaToolStripMenuItem.Size = new System.Drawing.Size(325, 24);
			this.tipoDePólizaToolStripMenuItem.Text = "5113 - Tipo de Póliza";
			this.tipoDePólizaToolStripMenuItem.Click += new System.EventHandler(this.TipoDePólizaToolStripMenuItem_Click);
			// 
			// contabilidadToolStripMenuItem
			// 
			this.contabilidadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.libroDiarioToolStripMenuItem,
            this.libroMayorToolStripMenuItem,
            this.balanceGeneralToolStripMenuItem,
            this.estadoDeResultadosToolStripMenuItem,
            this.bALANCEGENERALToolStripMenuItem1});
			this.contabilidadToolStripMenuItem.Name = "contabilidadToolStripMenuItem";
			this.contabilidadToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
			this.contabilidadToolStripMenuItem.Text = "Procesos";
			this.contabilidadToolStripMenuItem.Click += new System.EventHandler(this.ContabilidadToolStripMenuItem_Click);
			// 
			// libroDiarioToolStripMenuItem
			// 
			this.libroDiarioToolStripMenuItem.Name = "libroDiarioToolStripMenuItem";
			this.libroDiarioToolStripMenuItem.Size = new System.Drawing.Size(278, 24);
			this.libroDiarioToolStripMenuItem.Text = "5121 - Libro Diario";
			this.libroDiarioToolStripMenuItem.Click += new System.EventHandler(this.LibroDiarioToolStripMenuItem_Click);
			// 
			// libroMayorToolStripMenuItem
			// 
			this.libroMayorToolStripMenuItem.Name = "libroMayorToolStripMenuItem";
			this.libroMayorToolStripMenuItem.Size = new System.Drawing.Size(278, 24);
			this.libroMayorToolStripMenuItem.Text = "5122 - Libro Mayor";
			this.libroMayorToolStripMenuItem.Click += new System.EventHandler(this.LibroMayorToolStripMenuItem_Click);
			// 
			// balanceGeneralToolStripMenuItem
			// 
			this.balanceGeneralToolStripMenuItem.Name = "balanceGeneralToolStripMenuItem";
			this.balanceGeneralToolStripMenuItem.Size = new System.Drawing.Size(278, 24);
			this.balanceGeneralToolStripMenuItem.Text = "5123 - Balance";
			this.balanceGeneralToolStripMenuItem.Click += new System.EventHandler(this.BalanceGeneralToolStripMenuItem_Click);
			// 
			// estadoDeResultadosToolStripMenuItem
			// 
			this.estadoDeResultadosToolStripMenuItem.Name = "estadoDeResultadosToolStripMenuItem";
			this.estadoDeResultadosToolStripMenuItem.Size = new System.Drawing.Size(278, 24);
			this.estadoDeResultadosToolStripMenuItem.Text = "5125 - Estado de Resultados";
			this.estadoDeResultadosToolStripMenuItem.Click += new System.EventHandler(this.EstadoDeResultadosToolStripMenuItem_Click);
			// 
			// bALANCEGENERALToolStripMenuItem1
			// 
			this.bALANCEGENERALToolStripMenuItem1.Name = "bALANCEGENERALToolStripMenuItem1";
			this.bALANCEGENERALToolStripMenuItem1.Size = new System.Drawing.Size(278, 24);
			this.bALANCEGENERALToolStripMenuItem1.Text = "5124 - Balance General";
			this.bALANCEGENERALToolStripMenuItem1.Click += new System.EventHandler(this.BALANCEGENERALToolStripMenuItem1_Click);
			// 
			// seguridadToolStripMenuItem
			// 
			this.seguridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seguridadToolStripMenuItem1});
			this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
			this.seguridadToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
			this.seguridadToolStripMenuItem.Text = "Herramientas";
			this.seguridadToolStripMenuItem.Click += new System.EventHandler(this.SeguridadToolStripMenuItem_Click);
			// 
			// seguridadToolStripMenuItem1
			// 
			this.seguridadToolStripMenuItem1.Name = "seguridadToolStripMenuItem1";
			this.seguridadToolStripMenuItem1.Size = new System.Drawing.Size(152, 24);
			this.seguridadToolStripMenuItem1.Text = "Seguridad";
			this.seguridadToolStripMenuItem1.Click += new System.EventHandler(this.SeguridadToolStripMenuItem1_Click);
			// 
			// ayudaToolStripMenuItem
			// 
			this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
			this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
			this.ayudaToolStripMenuItem.Text = "Ayuda";
			this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.AyudaToolStripMenuItem_Click);
			// 
			// Lbl_usuario
			// 
			this.Lbl_usuario.AutoSize = true;
			this.Lbl_usuario.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Lbl_usuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Lbl_usuario.Location = new System.Drawing.Point(0, 429);
			this.Lbl_usuario.Name = "Lbl_usuario";
			this.Lbl_usuario.Size = new System.Drawing.Size(66, 21);
			this.Lbl_usuario.TabIndex = 2;
			this.Lbl_usuario.Text = "Usuario";
			this.Lbl_usuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MDI_CONTA
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Lbl_usuario);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MDI_CONTA";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "5100 - Contabilidad ";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDI_CONTA_FormClosed);
			this.Load += new System.EventHandler(this.MDI_CONTA_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientosToolStripMenuItem;
        private System.Windows.Forms.Label Lbl_usuario;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tiposDeCuentasContablesToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem cuentasContablesToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem contabilidadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem libroDiarioToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem libroMayorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem balanceGeneralToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bALANCEGENERALToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem estadoDeResultadosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem empresasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tipoDePólizaToolStripMenuItem;
	}
}
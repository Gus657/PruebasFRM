namespace CapaVista
{
    partial class Combo
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.Cmb_auto = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// Cmb_auto
			// 
			this.Cmb_auto.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Cmb_auto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Cmb_auto.FormattingEnabled = true;
			this.Cmb_auto.Location = new System.Drawing.Point(0, 0);
			this.Cmb_auto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Cmb_auto.Name = "Cmb_auto";
			this.Cmb_auto.Size = new System.Drawing.Size(253, 21);
			this.Cmb_auto.Sorted = true;
			this.Cmb_auto.TabIndex = 0;
			// 
			// Combo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Cmb_auto);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "Combo";
			this.Size = new System.Drawing.Size(253, 20);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Cmb_auto;
    }
}

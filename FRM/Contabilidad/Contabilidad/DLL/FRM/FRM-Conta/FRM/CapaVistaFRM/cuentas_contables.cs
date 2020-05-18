using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaModeloCONTA;

namespace CapaVistaCONTA { 

	public partial class cuentas_contables : Form
    {
		string usuario = "";
		int estadoBtn = 0;
		CuentasContables mod = new CuentasContables();
        public cuentas_contables( string user )
        {
			usuario = user;
            InitializeComponent();
			llenarCuentas();
			llenarCombosTipos();
        }

		void llenarCuentas() {
			OdbcDataAdapter dt = mod.llenarCuentas();
			DataTable table = new DataTable();
			dt.Fill(table);
			Dtgv_Cuentas.Rows.Clear();
			foreach (DataRow row in table.Rows)
			{
				Dtgv_Cuentas.Rows.Add(row[0], row[1], row[2]);
			}
			
		}

		void llenarCombosTipos() {
			Cmb_Tipo.Items.AddRange(mod.ObtenerTIposCuentasContables());

		}

		private void Cuentas_contables_Load(object sender, EventArgs e)
		{

		}

		private void Cmb_Tipo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (estadoBtn == 0)
			{
				if (Cmb_Tipo.Text != "" && Cmb_Tipo.Text != " " && Cmb_Tipo.Text != null)
				{
					Txt_Id.Enabled = false;
					string idTipo = mod.ObtenerNextIdCuenta(mod.ObtenerIdTIpoCuenta(Cmb_Tipo.Text.ToString()));
					Txt_Id.Text = mod.ObtenerIdTIpoCuenta(Cmb_Tipo.Text.ToString());
					Txt_Id.Text += "." + (Convert.ToInt32(idTipo) + 1).ToString();
				}
			}
			else
			{
				ToolTip toolTip1 = new ToolTip();
				toolTip1.AutoPopDelay = 5000;
				toolTip1.ShowAlways = true;
				toolTip1.ReshowDelay = 0;
				toolTip1.SetToolTip(Btn_guardar, "No es posible modificar el Tipo de Cuenta");
			}
			
			
		}

		private void Btn_plusLevel_Click(object sender, EventArgs e)
		{
			if (estadoBtn == 0) {
				Txt_Id.Enabled = true;
			} else {
				ToolTip toolTip1 = new ToolTip();
				toolTip1.AutoPopDelay = 5000;
				toolTip1.ShowAlways = true;
				toolTip1.ReshowDelay = 0;
				toolTip1.SetToolTip(Btn_plusLevel, "No se permite modificar el ID");
				Txt_Id.Enabled = false;
			}
		}

		private void Btn_guardar_Click(object sender, EventArgs e)
		{
			if (Txt_Id.Text == "" || Txt_desc.Text == "" || Txt_nombre.Text == "" || Cmb_Tipo.Text == "")
			{
				MessageBox.Show("Por favor rellene todos los campos!");
			}
			else { 
			checkBox1.Visible = false;
			button1.Visible = false;
			if (estadoBtn == 0)
			{
				string idTipo = mod.ObtenerIdTIpoCuenta(Cmb_Tipo.Text.ToString());
				string cod = (Convert.ToInt32(mod.ObtenerNextIdCuenta(mod.ObtenerIdTIpoCuenta(Cmb_Tipo.Text.ToString()))) + 1).ToString();
				mod.GuardarCuenta(Txt_Id.Text, idTipo, cod, Txt_nombre.Text, Txt_desc.Text);
				llenarCuentas();
				Txt_Id.Text = "";
				Txt_desc.Text = "";
				Txt_nombre.Text = "";
				Txt_Id.Enabled = false;
			}
			else
			{
				mod.ModCuenta(Txt_Id.Text, Txt_nombre.Text, Txt_desc.Text, (checkBox1.Checked) ? "1" : "0");
				llenarCuentas();
				Txt_Id.Text = "";
				Txt_desc.Text = "";
				Txt_nombre.Text = "";
				Txt_Id.Enabled = false;
			}
			estadoBtn = 0;
		}


		}

		private void Dtgv_Cuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			checkBox1.Visible = true;
			button1.Visible = true;
			estadoBtn = 1;
			Txt_Id.Text = Dtgv_Cuentas.CurrentRow.Cells[0].Value.ToString();
			Txt_nombre.Text = Dtgv_Cuentas.CurrentRow.Cells[1].Value.ToString();
			Txt_desc.Text= mod.ObtenerValor("cuentas","descripcion","id_cuenta",Txt_Id.Text,true);
			string tipoCuenta = mod.ObtenerValor("cuentas", "id_tipo_cuenta", "id_cuenta", Txt_Id.Text, true);
			Cmb_Tipo.Text = mod.ObtenerValor("tipo_cuentas", "nombre_tipo_cuenta", "id_tipo_cuenta", tipoCuenta, true);
			if (mod.ObtenerValor("cuentas", "estado", "id_cuenta", Txt_Id.Text, true) == "1") { checkBox1.Checked = true; } else { checkBox1.Checked = false; }
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			DialogResult Eliminar;
			Eliminar = MessageBox.Show("Se eliminará la cuenta "+Dtgv_Cuentas.CurrentRow.Cells[1].Value.ToString()+" en forma PERMANENTEMENTE , desea continuar?", "Eliminar Cuenta", MessageBoxButtons.YesNo);
			if (Eliminar == DialogResult.Yes)
			{
				mod.DeleteCuenta(Dtgv_Cuentas.CurrentRow.Cells[0].Value.ToString());
				checkBox1.Visible = false;
				button1.Visible = false;
				Txt_Id.Text = "";
				Txt_desc.Text = "";
				Txt_nombre.Text = "";
				Txt_Id.Enabled = false;
				estadoBtn = 0;
				llenarCuentas();
			}
		}

		private void Dtgv_Cuentas_MouseEnter(object sender, EventArgs e)
		{
			ToolTip toolTip1 = new ToolTip();
			toolTip1.AutoPopDelay = 5000;
			toolTip1.ShowAlways = true;
			toolTip1.ReshowDelay = 0;
			toolTip1.SetToolTip(Dtgv_Cuentas, "Doble Click para modificar");
		}

		private void Dtgv_Cuentas_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void Dtgv_Cuentas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
		{
			
		}

		private void Dtgv_Cuentas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void PictureBox2_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(@"Ayudas\MantenimientoCuentasContables.chm");
		}
	}
}

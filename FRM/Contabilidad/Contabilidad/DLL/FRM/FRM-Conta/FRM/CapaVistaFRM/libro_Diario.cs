using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaModeloCONTA;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CapaVistaCONTA
{
	public partial class libro_Diario : Form
	{
		LibroDiario Libro = new LibroDiario();
		sentencia sn = new sentencia();
		string user = "";
		string idLibro = "";
		public libro_Diario(string usuario)
		{
			user = usuario;
			InitializeComponent();
			Dtg_Fecha_Crear.Format = DateTimePickerFormat.Custom;
			Dtg_Fecha_Crear.CustomFormat = "yyyy-MM-dd";
			Dtg_Fecha_Modificar.Format = DateTimePickerFormat.Custom;
			Dtg_Fecha_Modificar.CustomFormat = "yyyy-MM-dd";
			Dtp_partida.Format = DateTimePickerFormat.Custom;
			Dtp_partida.CustomFormat = "yyyy-MM-dd";
			Txt_Libro.Text = Libro.IdLibro();
			llenarLibros();
			tablaMovimientos();
			
		}

		void llenarLibros() {
			// 
			//// LLENAR TABLA DE LIBROS EN INGRESO
			OdbcDataAdapter dt = Libro.llenarLibroDiario();
			DataTable table = new DataTable();
			dt.Fill(table);
			Dtg_LibroDiario.DataSource = table;
		}
		
		void tablaMovimientos() {

			DataGridViewComboBoxColumn cuenta = new DataGridViewComboBoxColumn();
			cuenta.HeaderText = "Cuenta";
			cuenta.Items.AddRange(Libro.comboTabla());
			cuenta.Width = 500;

			DataGridViewTextBoxColumn debe = new DataGridViewTextBoxColumn();
			debe.HeaderText = "Debe";
			DataGridViewTextBoxColumn haber = new DataGridViewTextBoxColumn();
			haber.HeaderText = "Haber";

			Dtg_Movimientos.Columns.Add(cuenta);
			Dtg_Movimientos.Columns.Add(debe);
			Dtg_Movimientos.Columns.Add(haber);
		}
		
		
		private void Libro_Diario_Load(object sender, EventArgs e)
		{
			Cmb_Empresa_Crear.Items.AddRange(Libro.ComboDiario());
			Cmb_Empresa_Modificar.Items.AddRange(Libro.ComboDiario());
			Tbc_LibroDiario.Appearance = TabAppearance.FlatButtons;
			Tbc_LibroDiario.ItemSize = new Size(0, 1);
			Tbc_LibroDiario.SizeMode = TabSizeMode.Fixed;
		}

		private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void GroupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void GroupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void Label10_Click(object sender, EventArgs e)
		{

		}

		private void Cmb_Empresa_Crear_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void Btn_Guardar_Click(object sender, EventArgs e)
		{
			
			Libro.crearLibroDiario(Txt_Libro.Text.ToString(), Cmb_Empresa_Crear.Text.ToString(),Dtg_Fecha_Crear.Text.ToString());
			llenarLibros();
			Txt_Libro.Text = Libro.IdLibro();
			sn.insertarBitacora(user, "Creo un libro Diario", "Libro Diario");
		}

		private void Dtg_LibroDiario_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			Gpb_Crear.Enabled = false;
			Btn_Partidas.Enabled = false;
			Cmb_Empresa_Modificar.Text =	Dtg_LibroDiario.CurrentRow.Cells[1].Value.ToString();
			Dtg_Fecha_Modificar.Text = Dtg_LibroDiario.CurrentRow.Cells[2].Value.ToString();
			if (Dtg_LibroDiario.CurrentRow.Cells[3].Value.ToString() == "0")
			{
				Chk_Estado.Checked = false;
			}
			else {
				Chk_Estado.Checked = true;
			}
			Gpb_Modificar.Enabled = true;
		}

		private void Btn_actualizar_Click(object sender, EventArgs e)
		{
			string estado = "0";
			if (Chk_Estado.Checked)
			{
				estado = "1";
			}
			Libro.ModificarLibroDiario(Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString(),Cmb_Empresa_Modificar.Text.ToString(),Dtg_Fecha_Modificar.Text.ToString(),estado);
			Gpb_Modificar.Enabled = false;
			llenarLibros();
			Gpb_Crear.Enabled = true;
			Btn_Partidas.Enabled = true;
			sn.insertarBitacora(user, "Modifico un libro Diario", "Libro Diario");
		}

		private void Btn_Partidas_Click(object sender, EventArgs e)
		{
			if (Dtg_LibroDiario.Rows.Count != 0)
			{
				idLibro = Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString();
				Tbc_LibroDiario.SelectedIndex = 1;
				OdbcDataAdapter dt = Libro.llenarPartidas(Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString());
				DataTable table = new DataTable();
				dt.Fill(table);
				Dtg_Partidas.Rows.Clear();
				foreach (DataRow row in table.Rows)
				{
					Dtg_Partidas.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
				}

				sn.insertarBitacora(user, "Vio las partidas", "Libro Diario");
			}
			else
			{
				MessageBox.Show("No Hay Libros disponibles");
			}

		}

		private void Btn_Guardar_partia_Click(object sender, EventArgs e)
		{
			bool proceder = true;
			int fil = Dtg_Movimientos.Rows.Count - 1;
			int col = Dtg_Movimientos.Columns.Count;
			decimal debe = 0;
			decimal haber = 0;
	
			if (fil==0)
			{
				MessageBox.Show("No se han ingresado partidas");
				proceder = false;
			}
			if (Txt_Concepto.Text=="")
			{
				MessageBox.Show("Por favor coloque un un concepto a la partida");
				proceder = false;
			}

			for (int i = 0; i < fil; i++)
			{
				for (int j = 0; j < col; j++)
				{
					if (Dtg_Movimientos.Rows[i].Cells[j].Value == null)
					{
						MessageBox.Show("Por Favor llene la tabla en la fila " + (i+1).ToString()+" y Columna " + (j+1).ToString());
						proceder = false;
					}
					else if (Dtg_Movimientos.Rows[i].Cells[j].Value.ToString() =="" || Dtg_Movimientos.Rows[i].Cells[j].Value.ToString()==" ")
					{
						MessageBox.Show("Por Favor llene la tabla en la fila " + (i + 1).ToString() + " y Columna " + (j + 1).ToString());
						proceder = false;
					}

				}
			}
			for (int i = 0; i < Dtg_Movimientos.Rows.Count-1; i++)
			{
				debe += Convert.ToDecimal( Dtg_Movimientos.Rows[i].Cells[1].Value);
				haber += Convert.ToDecimal(Dtg_Movimientos.Rows[i].Cells[2].Value);
			}
			if (debe!=haber)
			{
				MessageBox.Show("Las sumas no son iguales, revise ambas columnas");
				proceder = false;
			}

			if (proceder)
			{
				Libro.crearPartida(Txt_partida.Text.ToString(), idLibro, Txt_Concepto.Text.ToString(), Dtp_partida.Text.ToString());
				foreach (DataGridViewRow row in Dtg_Movimientos.Rows)
				{
					if (Dtg_Movimientos.Rows.Count - 1 != row.Index)
					{
						Libro.crearDetalleLibroDiario(row.Index.ToString(), idLibro, Txt_partida.Text.ToString(),  row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());

					}
				}
				Txt_partida.Text = Libro.IdPartida(idLibro);
				Dtg_Movimientos.Rows.Clear();
				OdbcDataAdapter dt = Libro.llenarPartidas(Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString());
				DataTable table = new DataTable();
				dt.Fill(table);
				Dtg_Partidas.Rows.Clear();
				foreach (DataRow row in table.Rows)
				{
					Dtg_Partidas.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
				}
				Txt_Concepto.Text = "";
				sn.insertarBitacora(user, "Creo una partida", "Libro Diario");
			}
		}

		private void Btn_quiat_Click(object sender, EventArgs e)
		{
			Dtg_Partidas.Rows.RemoveAt(Dtg_Partidas.CurrentRow.Index);
		}

		private void Tbc_LibroDiario_SelectedIndexChanged(object sender, EventArgs e)
		{
			idLibro = Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString();
			Txt_partida.Text = Libro.IdPartida(idLibro);

			OdbcDataAdapter dt = Libro.llenarPartidas(Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString());
			DataTable table = new DataTable();
			dt.Fill(table);
			Dtg_Partidas.Rows.Clear();
			foreach (DataRow row in table.Rows)
			{
				Dtg_Partidas.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
			}

			
			Dtg_Resumen.Rows.Clear();
			foreach (DataRow row in table.Rows)
			{
				Dtg_Resumen.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
			}
		}

		private void Dtg_Partidas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
	
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			string concepto = "";
			if (Dtg_Partidas.CurrentRow.Cells[0].Value == null || Dtg_Partidas.CurrentRow.Cells[0].Value.ToString() == "" || Dtg_Partidas.CurrentRow.Cells[0].Value.ToString() ==" ")
			{
				MessageBox.Show("Por favor Seleccione el CONCEPTO de la partida a eliminar");
			}
			else
			{
				concepto = Dtg_Partidas.CurrentRow.Cells[1].Value.ToString();
				DialogResult Eliminar;
				Eliminar = MessageBox.Show("Se eliminarán todos los movimientos con concepto " + concepto + ", desea continuar?", "Eliminar Partida", MessageBoxButtons.YesNo);

				if (Eliminar == DialogResult.Yes)
				{
					Libro.DeletePartida(concepto, idLibro);
					OdbcDataAdapter dt = Libro.llenarPartidas(Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString());
					DataTable table = new DataTable();
					dt.Fill(table);
					Dtg_Partidas.Rows.Clear();
					foreach (DataRow row in table.Rows)
					{
						Dtg_Partidas.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
					}


					Dtg_Resumen.Rows.Clear();
					foreach (DataRow row in table.Rows)
					{
						Dtg_Resumen.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
					}
					sn.insertarBitacora(user, "Elimino una partida", "Libro Diario");
				}
			
			}
			
			
		}

		void exportarTabla(DataGridView dtg, string name)
		{
			BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
			PdfPTable pdftable = new PdfPTable(dtg.Columns.Count);
			pdftable.DefaultCell.Padding = 3;
			pdftable.WidthPercentage = 100;
			pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
			pdftable.DefaultCell.BorderWidth = 1;

			iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
			foreach (DataGridViewColumn col in dtg.Columns)
			{
				PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText));
				cell.BackgroundColor = new iTextSharp.text.BaseColor(240,240,240);
				pdftable.AddCell(cell);
			}

			foreach (DataGridViewRow row in dtg.Rows)
			{
				foreach (DataGridViewCell cell in row.Cells)
				{
					pdftable.AddCell(new Phrase(cell.Value.ToString(),text));
				}
			}


			var savefeldialoge = new SaveFileDialog();
			savefeldialoge.FileName = name;
			savefeldialoge.DefaultExt = ".pdf";
			if (savefeldialoge.ShowDialog()==DialogResult.OK)
			{
				using (FileStream stream = new FileStream(savefeldialoge.FileName,FileMode.Create))
				{
					Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
					PdfWriter.GetInstance(pdfdoc,stream);
					pdfdoc.Open();
					pdfdoc.Add(pdftable);
					pdfdoc.Close();
					stream.Close();
				}

			}


		}
		private void Button2_Click(object sender, EventArgs e)
		{
			exportarTabla(Dtg_Resumen,"test");
			sn.insertarBitacora(user, "Exporto un libro Diario", "Libro Diario");
		}

		private void Dtg_LibroDiario_MouseEnter(object sender, EventArgs e)
		{
			ToolTip toolTip1 = new ToolTip();
			toolTip1.AutoPopDelay = 5000;
			toolTip1.ShowAlways = true;
			toolTip1.ReshowDelay = 0;
			toolTip1.SetToolTip(Dtg_LibroDiario, "Doble Click para modificar");
		}

		private void Dtg_Movimientos_KeyPress(object sender, KeyPressEventArgs e)
		{
			
		}

		private void Dtg_Movimientos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{

		}

		bool soloNumeros(string cadena)
		{
			bool borrar = false;
			for (int i = 0; i < cadena.Length; i++)
			{
				if (
					cadena[i] != '0' &&
					cadena[i] != '1' &&
					cadena[i] != '2' &&
					cadena[i] != '3' &&
					cadena[i] != '4' &&
					cadena[i] != '5' &&
					cadena[i] != '6' &&
					cadena[i] != '7' &&
					cadena[i] != '8' &&
					cadena[i] != '9' &&
					cadena[i] != '.' 

					)
				{
					if (Dtg_Movimientos.CurrentCell.ColumnIndex != 0)
					{
						borrar = true;
					}
					
					
				}
			}
			if (borrar)
			{
				MessageBox.Show("Solo esta permitido escribir Enteros o Decimales");
			}
			return borrar;

		}

		bool soloUnPunto(string cadena)
		{
			bool borrar = false;
			int conteo = 0;
			for (int i = 0; i < cadena.Length; i++)
			{
				if (cadena[i] == '.')
				{
					if (Dtg_Movimientos.CurrentCell.ColumnIndex != 0)
					{
						conteo++;
					}


				}
			}
			if (conteo>1)
			{
				borrar = true;
			}
			if (borrar)
			{
				MessageBox.Show("El valor no posee el formato adecuado");
			}
			return borrar;
		}

		private void Dtg_Movimientos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{

			if (soloNumeros(Dtg_Movimientos.CurrentCell.Value.ToString()) || soloUnPunto(Dtg_Movimientos.CurrentCell.Value.ToString()))
			{
				Dtg_Movimientos.CurrentCell.Value = "";
			}
			
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			Tbc_LibroDiario.SelectedIndex = 0;
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			Tbc_LibroDiario.SelectedIndex = 2;
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			Tbc_LibroDiario.SelectedIndex = 0;
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			Tbc_LibroDiario.SelectedIndex = 1;
		}

		private void PictureBox2_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(@"Ayudas\ProcesoDiario.chm");
		}
	}
}

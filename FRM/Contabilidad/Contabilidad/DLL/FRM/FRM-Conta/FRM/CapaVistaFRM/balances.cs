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
	public partial class balances : Form
	{
		LibroBalances Libro = new LibroBalances();
		sentencia sn = new sentencia();
		string user = "";
		string idLibro = "";
		string idLibro2 = "";
		public balances(string usuario)
		{
			user = usuario;
			InitializeComponent();
			Dtg_Fecha_Crear.Format = DateTimePickerFormat.Custom;
			Dtg_Fecha_Crear.CustomFormat = "yyyy-MM-dd";
			Dtg_Fecha_Modificar.Format = DateTimePickerFormat.Custom;
			Dtg_Fecha_Modificar.CustomFormat = "yyyy-MM-dd";
			Txt_Libro.Text = Libro.IdLibro();
			llenarLibros();
			llenarCombo();
			
		}

		void llenarLibros() {
			// 
			//// LLENAR TABLA DE LIBROS EN INGRESO
			OdbcDataAdapter dt = Libro.llenarLibroDiario();
			DataTable table = new DataTable();
			dt.Fill(table);
			Dtg_LibroDiario.DataSource = table;
		}

		void llenarCombo() {
			Cmb_Empresa_Crear.Items.AddRange(Libro.ComboDiario());
			Cmb_Empresa_Modificar.Items.AddRange(Libro.ComboDiario());
			Tbc_LibroDiario.Appearance = TabAppearance.FlatButtons;
			Tbc_LibroDiario.ItemSize = new Size(0, 1);
			Tbc_LibroDiario.SizeMode = TabSizeMode.Fixed;
		}

		
		
		private void balances_Load(object sender, EventArgs e)
		{

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
			sn.insertarBitacora(user, "Creo un balance", "Balances");
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
			sn.insertarBitacora(user, "Modifico un Balance", "Balances");
		}

		private void Btn_Partidas_Click(object sender, EventArgs e)
		{
			if (Dtg_LibroDiario.Rows.Count!=0)
			{
				idLibro = Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString();
				idLibro2 = Dtg_LibroDiario.CurrentRow.Cells[1].Value.ToString();
				if (Libro.ConsultarMayor(Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString()) == "0")
				{
					Tbc_LibroDiario.SelectedIndex = 1;
				}
				else
				{
					Tbc_LibroDiario.SelectedIndex = 2;
				}

				sn.insertarBitacora(user, "Vio un Balance", "Balances");
			}
			else
			{
				MessageBox.Show("No Hay Libros disponibles");
			}


		}

		private void Btn_Guardar_partia_Click(object sender, EventArgs e)
		{
			idLibro = Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString();
			idLibro2 = Dtg_LibroDiario.CurrentRow.Cells[1].Value.ToString();
			if (Libro.ConsultarMayor(Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString()) == "0")
			{
				progressBar1.Visible = true;
				timer1.Enabled = true;
				MessageBox.Show(Libro.CrearLibroMayor(idLibro2, idLibro));
				timer1.Enabled = false;
				progressBar1.Visible = false;
				progressBar1.Value = 0;
				////lenar tabla
				OdbcDataAdapter dt = Libro.llenarBalance(idLibro2);
				DataTable table = new DataTable();
				dt.Fill(table);
				Dtg_Partidas.Rows.Clear();
				foreach (DataRow row in table.Rows)
				{
					Dtg_Partidas.Rows.Add(row[0],  row[2], row[3], row[4], row[5], row[6]);
				}

			}
			else
			{
				MessageBox.Show("El Balance #" + Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString()+" Ya ha sido Generado ");
				Tbc_LibroDiario.SelectedIndex = 2;
				OdbcDataAdapter dt = Libro.llenarBalance(idLibro2);
				DataTable table = new DataTable();
				dt.Fill(table);
				Dtg_Resumen.Rows.Clear();
				foreach (DataRow row in table.Rows)
				{
					Dtg_Resumen.Rows.Add(row[0], row[2], row[3], row[4], row[5], row[6]);
				}


			}


		}

		private void Btn_quiat_Click(object sender, EventArgs e)
		{
			Dtg_Partidas.Rows.RemoveAt(Dtg_Partidas.CurrentRow.Index);
		}

		private void Tbc_LibroDiario_SelectedIndexChanged(object sender, EventArgs e)
		{
			idLibro = Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString();
			idLibro2 = Dtg_LibroDiario.CurrentRow.Cells[1].Value.ToString();
		
					OdbcDataAdapter dt = Libro.llenarBalance(idLibro2);
					DataTable table = new DataTable();
					dt.Fill(table);
					Dtg_Resumen.Rows.Clear();
					foreach (DataRow row in table.Rows)
					{
						Dtg_Resumen.Rows.Add(row[0], row[2], row[3], row[4], row[5], row[6]);
					}

		}

		private void Dtg_Partidas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
	
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			//string concepto = "";
			//if (Dtg_Partidas.CurrentRow.Cells[0].Value == null || Dtg_Partidas.CurrentRow.Cells[0].Value.ToString() == "" || Dtg_Partidas.CurrentRow.Cells[0].Value.ToString() ==" ")
			//{
			//	MessageBox.Show("Por favor Seleccione el CONCEPTO de la partida a eliminar");
			//}
			//else
			//{
			//	concepto = Dtg_Partidas.CurrentRow.Cells[0].Value.ToString();
			//	DialogResult Eliminar;
			//	Eliminar = MessageBox.Show("Se eliminarán todos los movimientos con concepto " + concepto + ", desea continuar?", "Eliminar Partida", MessageBoxButtons.YesNo);

			//	if (Eliminar == DialogResult.Yes)
			//	{
			//		Libro.DeletePartida(concepto, idLibro);
			//		OdbcDataAdapter dt = Libro.llenarPartidas(Dtg_LibroDiario.CurrentRow.Cells[0].Value.ToString());
			//		DataTable table = new DataTable();
			//		dt.Fill(table);
			//		Dtg_Partidas.DataSource = table;
			//	}
			//	sn.insertarBitacora(user, "Elimino una partida", "Libro Diario");
			//}
			
			
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

		private void Timer1_Tick(object sender, EventArgs e)
		{
			progressBar1.Value = Libro.progreso;
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			Tbc_LibroDiario.SelectedIndex = 0;
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			Tbc_LibroDiario.SelectedIndex = 2;
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			Tbc_LibroDiario.SelectedIndex = 0;
		}

		private void Button1_Click_1(object sender, EventArgs e)
		{
			Tbc_LibroDiario.SelectedIndex = 1;
		}

		private void PictureBox2_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(@"Ayudas\ProcesoBalances.chm");
		}
	}
}

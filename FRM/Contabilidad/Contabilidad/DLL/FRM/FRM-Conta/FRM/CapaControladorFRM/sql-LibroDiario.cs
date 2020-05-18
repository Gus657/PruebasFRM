using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladorCONTA
{
	public class sql_LibroDiario
	{
		conexionFRM conectar = new conexionFRM();
		public OdbcDataAdapter LlenarTablaDiarioEncabezado()
		{
			string sql = "SELECT * FROM libro_diario_encabezados";
			OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, conectar.conexion("ERP"));
			return dataTable;
		}
		public OdbcDataAdapter LlenarTablaPartidas(string sql)
		{
			OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, conectar.conexion("ERP"));
			return dataTable;
		}
		public string llenarComboDiarios()
		{
			string Combo = "";
			int numeroFIlas = 0;
			OdbcCommand command = new OdbcCommand("SELECT nombre FROM empresas WHERE estado =1;", conectar.conexion("ERP"));
			OdbcDataReader reader = command.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					numeroFIlas++;
				}
				reader.Close();
				OdbcDataReader reader2 = command.ExecuteReader();
				for (int i = 0; i < numeroFIlas; i++)
				{
					reader2.Read();
					if (i == numeroFIlas - 1)
					{
						Combo += reader2.GetValue(0).ToString();
					}
					else
					{
						Combo += reader2.GetValue(0).ToString() + ",";
					}
				}
			}
			else
			{
				Combo = "No Hay Registros";
			}
			return Combo;
		}
		public string[] llenarCombo()
		{
			string[] Combo = new string[30];
			int i = 0;
			OdbcCommand command = new OdbcCommand("SELECT tipo_poliza FROM poliza_encabezados WHERE estado=1 GROUP BY tipo_poliza ;", conectar.conexion("ERP"));
			OdbcDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				Combo[i] = reader.GetValue(0).ToString();
				i++;
			}
			return Combo;
		}

		public string llenarComboTablaMovimientos()
		{
			string Combo = "";
			int numeroFIlas = 0;
			OdbcCommand command = new OdbcCommand("SELECT nombre FROM cuentas WHERE id_cuenta <>'0.0';", conectar.conexion("ERP"));
			OdbcDataReader reader = command.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					numeroFIlas++;
				}
				reader.Close();
				OdbcDataReader reader2 = command.ExecuteReader();
				for (int i = 0; i < numeroFIlas; i++)
				{
					reader2.Read();
					if (i == numeroFIlas - 1)
					{
						Combo += reader2.GetValue(0).ToString();
					}
					else
					{
						Combo += reader2.GetValue(0).ToString() + ",";
					}
				}
			}
			else
			{
				Combo = "No Hay Registros";
			}
			return Combo;
		}
		public string ObtenerPartidasLibro(string ID)
		{
			string Combo = "";
			OdbcCommand command = new OdbcCommand("SELECT id_partida FROM partidas WHERE estado = 1 AND id_libro_diario = "+ID+" ;", conectar.conexion("ERP"));
			OdbcDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				Combo += reader.GetValue(0).ToString() + ",";
			}
			Combo.TrimEnd(',');
			return Combo;
		}
		public string ObtenerIdLibro()
		{
			string id = "";
			OdbcCommand command = new OdbcCommand("SELECT MAX(id_libro_diario) FROM libro_diario_encabezados;", conectar.conexion("ERP"));
			OdbcDataReader reader = command.ExecuteReader();
			if (reader.Read())
			{
				id = reader.GetValue(0).ToString();
				if (id == "" || id == null)
				{
					id = "1";
				}
				else
				{
					id = reader.GetValue(0).ToString();
					int n = Convert.ToInt32(id) + 1;
					id = n.ToString();
				}	

			}

			
			return id;
		}

		public string ObtenerIdPartida(string no)
		{
			string id = "";
			OdbcCommand command = new OdbcCommand("SELECT MAX(id_partida) FROM partidas WHERE id_libro_diario = "+no+" ;", conectar.conexion("ERP"));
			OdbcDataReader reader = command.ExecuteReader();
			if (reader.Read())
			{
				id = reader.GetValue(0).ToString();
				if (id == "" || id == null)
				{
					id = "1";
				}
				else {
					id = reader.GetValue(0).ToString();
					int n = Convert.ToInt32(id) + 1;
					id = n.ToString();
				}
				

			}
		

			return id;
		}

		public void ejecutarQuery(string query)// ejecuta un query en la BD
		{
			try
			{
				OdbcCommand consulta = new OdbcCommand(query, conectar.conexion("ERP"));
				consulta.ExecuteNonQuery();
			}
			catch (OdbcException ex) {
				Console.WriteLine(ex.Errors.ToString());
				Console.WriteLine("---------------------------------------");
				Console.WriteLine(query);
			}

		}
	}
}

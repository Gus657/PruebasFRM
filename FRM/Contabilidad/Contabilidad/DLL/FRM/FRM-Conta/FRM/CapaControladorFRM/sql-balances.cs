using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladorCONTA
{
	public class sql_balances
	{
		conexionFRM conectar = new conexionFRM();
		public OdbcDataAdapter LlenarTablaDiarioEncabezado()
		{
			string sql = "SELECT * FROM balances";
			OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, conectar.conexion("ERP"));
			return dataTable;
		}

		public OdbcDataAdapter Cuentas(string idLibro)
		{
			string sql = "SELECT cuenta_contable FROM libro_mayor_cuentas WHERE id_libro_mayor="+idLibro+";";
			OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, conectar.conexion("ERP"));
			return dataTable;
		}

		public OdbcDataAdapter Debe_Haber(string sql)
		{
			
			OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, conectar.conexion("ERP"));
			Console.WriteLine(sql);
			return dataTable;
		}

	

		public OdbcDataAdapter LlenarTablaMayor(string sql)
		{
			OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, conectar.conexion("ERP"));
			return dataTable;
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

		public string ConsultarLibro(string idMayor)
		{
			int i = 0;
			OdbcCommand command = new OdbcCommand("SELECT * FROM balances_detalles WHERE id_balance="+idMayor+";", conectar.conexion("ERP"));
			OdbcDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				i++;
			}
			return i.ToString();
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

		public string ArrayCuentas(string idLibro)
		{
			string Combo = "";
			string sql ="SELECT cuenta_contable FROM libro_mayor_cuentas WHERE id_libro_mayor=" + idLibro + ";";
			int numeroFIlas = 0;
			OdbcCommand command = new OdbcCommand(sql, conectar.conexion("ERP"));
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

		public string llenarComboDiarios()
		{
			string Combo = "";
			int numeroFIlas = 0;
			OdbcCommand command = new OdbcCommand("SELECT id_libro_mayor FROM libro_mayor_encabezados WHERE estado =1;", conectar.conexion("ERP"));
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
			OdbcCommand command = new OdbcCommand("SELECT id_partida FROM partidas WHERE estado = 1 AND id_libro_diario = " + ID + " ;", conectar.conexion("ERP"));
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
			OdbcCommand command = new OdbcCommand("SELECT MAX(id_balance) FROM balances;", conectar.conexion("ERP"));
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
			OdbcCommand command = new OdbcCommand("SELECT MAX(id_partida) FROM partidas WHERE id_libro_diario = " + no + " ;", conectar.conexion("ERP"));
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

		public void ejecutarQuery(string query)// ejecuta un query en la BD
		{
			try
			{
				OdbcCommand consulta = new OdbcCommand(query, conectar.conexion("ERP"));
				consulta.ExecuteNonQuery();
			}
			catch (OdbcException ex)
			{
				Console.WriteLine(ex.Errors.ToString());
				Console.WriteLine("---------------------------------------");
				Console.WriteLine(query);
			}

		}
	}

}

using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladorCONTA
{
	public class sql_cuentas_Contables
	{
		conexionFRM conectar = new conexionFRM();

		public OdbcDataAdapter LlenarTablaCuentas()
		{
			string sql = "SELECT C.id_cuenta, C.nombre, (SELECT IF(estado=1, 'ACTIVA', 'INACTIVA') )FROM cuentas C WHERE id_cuenta <>'0.0'";
			OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, conectar.conexion("ERP"));
			return dataTable;
		}

		public string llenarComboTipos()
		{
			string Combo = "";
			int numeroFIlas = 0;
			OdbcCommand command = new OdbcCommand("SELECT nombre_tipo_cuenta FROM tipo_cuentas WHERE id_tipo_cuenta LIKE '%.%';", conectar.conexion("ERP"));
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
					if (i== numeroFIlas-1)
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

		public string ObtenerIdTipo(string name)
		{
			string id = "";
			OdbcCommand command = new OdbcCommand("SELECT id_tipo_cuenta FROM tipo_cuentas WHERE nombre_tipo_cuenta ='"+name+"' LIMIT 1;", conectar.conexion("ERP"));
			OdbcDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				id = reader.GetValue(0).ToString();
			}
			
			return id;
		}

		public string ObtenerValor(string tabla, string campo, string llave, string valor, bool tipo)
		{
			string id = "";
			string sql = "";
			if (tipo)
			{
				 sql = "SELECT " + campo + " FROM " + tabla + " WHERE " + llave + " ='" + valor + "' LIMIT 1;";
			}
			else
			{
				sql = "SELECT " + campo + " FROM " + tabla + " WHERE " + llave + " =" + valor + " LIMIT 1;";
			}
			OdbcCommand command = new OdbcCommand(sql, conectar.conexion("ERP"));
			OdbcDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				id = reader.GetValue(0).ToString();
			}

			return id;
		}
		public string ObtenerCodigo(string id)
		{
			
			string codigo = "";
			OdbcCommand command = new OdbcCommand("SELECT MAX(codigo) FROM `cuentas` WHERE id_cuenta LIKE '"+id+".%'", conectar.conexion("ERP"));
			OdbcDataReader reader = command.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					codigo = reader.GetValue(0).ToString();
				}
			}
			else
			{
				Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
				codigo = "0";
			}
			

			return codigo;
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

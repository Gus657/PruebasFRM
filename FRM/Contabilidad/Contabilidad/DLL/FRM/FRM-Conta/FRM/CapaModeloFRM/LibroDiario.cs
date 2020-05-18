using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaControladorCONTA;

namespace CapaModeloCONTA
{
	public class LibroDiario
	{
		sql_LibroDiario Diario = new sql_LibroDiario();
		public void crearLibroDiario(string id, string empresa, string fecha) {
			string query = "INSERT INTO libro_diario_encabezados (id_libro_diario, empresa,fecha) " +
			"VALUES (" + id + ",'" + empresa + "', '" + fecha + "')";
			Diario.ejecutarQuery(query);
		}

		public void crearPartida(string id, string libro, string concepto, string fecha)
		{
			string query = "INSERT INTO partidas (id_partida, id_libro_diario, concepto, fecha) " +
			"VALUES (" + id + "," + libro + ", '" + concepto + "', '"+fecha+"')";
			Diario.ejecutarQuery(query);
		}

		public void crearDetalleLibroDiario(string mov, string libro, string partida, string cuenta, string debe, string haber)
		{
			string query = "INSERT INTO libro_diario_detalles (numero_movimiento, id_libro_diario, id_partida, cuenta_contable,  debe, haber) " +
			"VALUES (" + mov+ ", "+libro+", "+partida+",'" + cuenta + "' , "+debe+", "+haber+")";
			Diario.ejecutarQuery(query);
		}

		public void ModificarLibroDiario(string id, string empresa, string fecha, string estado)
		{
			string query = "UPDATE libro_diario_encabezados  SET empresa = '" + empresa + "', fecha = '" + fecha + "'," +
			" estado = " + estado + " WHERE id_libro_diario = " + id + ";";
			Diario.ejecutarQuery(query);
		}

		public OdbcDataAdapter llenarLibroDiario()
		{
			OdbcDataAdapter dataTable = Diario.LlenarTablaDiarioEncabezado();
			return dataTable;
		}

		public string CrearQueryPartida(string idLibro)
		{
			string query = "SELECT '0','0','0','0','0'";


			int n = 0;
			string[] partidas = Diario.ObtenerPartidasLibro(idLibro).Split(',');
			if (partidas != null)
			{
				query = "";
				foreach (var partida in partidas)
				{
					
					if (partida != "" && partida != " " && partida != null)
					{
				
						if (n == partidas.Length - 2)
						{
							query += "SELECT P.id_partida as No , P.concepto as CONCEPTO, P.fecha as FECHA , '' as DEBE , '' as HABER " +
									"FROM partidas P WHERE P.id_partida =" + partida + " AND P.id_libro_diario = " + idLibro + "  " +
									"UNION ALL " +
									"SELECT '' as a, '' as a, D.cuenta_contable AS cuenta ,IF(D.debe>0,concat('Q.', D.debe),'')  as Debe, IF(D.haber>0,concat('Q.', D.haber),'')  as haber " +
									"FROM libro_diario_detalles D WHERe D.id_partida =" + partida + " AND D.id_libro_diario =" + idLibro + " " +
									"UNION ALL " +
									"SELECT '' as a, '' as a,'SUMAS IGUALES' as b, concat('Q.', ROUND(SUM(D.debe),2)) as Debe, concat('Q.', ROUND(SUM(D.haber),2))  as haber " +
									"FROM libro_diario_detalles D WHERe D.id_partida = " + partida + " AND D.id_libro_diario = " + idLibro + " ;";
						}
						else
						{
							query += "SELECT P.id_partida as No , P.concepto as CONCEPTO, P.fecha as FECHA , '' as DEBE , '' as HABER " +
									"FROM partidas P WHERE P.id_partida =" + partida + " AND P.id_libro_diario = " + idLibro + "  " +
									"UNION ALL " +
								"SELECT '' as a, '' as a, D.cuenta_contable AS cuenta ,IF(D.debe>0,concat('Q.', D.debe),'')  as Debe, IF(D.haber>0,concat('Q.', D.haber),'')  as haber " +
									"FROM libro_diario_detalles D WHERe D.id_partida =" + partida + " AND D.id_libro_diario =" + idLibro + " " +
									"UNION ALL " +
									"SELECT '' as a, '' as a,'SUMAS IGUALES' as b, concat('Q.', ROUND(SUM(D.debe),2)) as Debe , concat('Q.', ROUND(SUM(D.haber),2))  as haber " +
									"FROM libro_diario_detalles D WHERe D.id_partida = " + partida + " AND D.id_libro_diario = " + idLibro + " UNION ALL ";
						}


					}
					n++;
				}
			}
			else
			{

				query = "SELECT '0','0','0','0','0'";
			}
			
			return query;
		}

		public OdbcDataAdapter llenarPartidas(string idLibro)
		{
			string query = CrearQueryPartida(idLibro);
			if (query=="")
			{
				query = "SELECT '0','0','0','0','0'";
			}
			OdbcDataAdapter dataTable = Diario.LlenarTablaPartidas(query);
			return dataTable;
		}

		public string IdLibro() {
			return Diario.ObtenerIdLibro();
		}
		public string[] ComboDiario()
		{

			return Diario.llenarComboDiarios().Split(',');
		}
		public string IdPartida(string no)
		{
			return Diario.ObtenerIdPartida(no);
		}

		public string[] comboTabla()
		{
			string[] combo = Diario.llenarComboTablaMovimientos().Split(',');
			return combo;
		}

		public void DeletePartida(string concepto, string libro)
		{
			string query = "UPDATE partidas SET estado = 0 WHERE concepto='"+concepto+"' AND id_libro_diario='"+libro+"'";
			Diario.ejecutarQuery(query);
		}


	}
}

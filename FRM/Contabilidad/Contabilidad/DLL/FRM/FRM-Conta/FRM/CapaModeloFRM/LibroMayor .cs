using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControladorCONTA;

namespace CapaModeloCONTA
{
	public class LibroMayor
	{
		sql_libroMayor Mayor = new sql_libroMayor();
		public float valorxCuenta = 0;
		public int progreso = 0;
		public void crearLibroDiario(string id, string diario, string fecha)
		{
			string query = "INSERT INTO libro_mayor_encabezados (id_libro_mayor, id_libro_diario,fecha) " +
			"VALUES (" + id + "," + diario + ", '" + fecha + "')";
			Mayor.ejecutarQuery(query);
		}

		public void crearPartida(string id, string libro, string concepto, string fecha)
		{
			string query = "INSERT INTO partidas (id_partida, id_libro_diario, concepto, fecha) " +
			"VALUES (" + id + "," + libro + ", '" + concepto + "', '" + fecha + "')";
		//	Diario.ejecutarQuery(query);
		}

		public void crearDetalleLibroDiario(string mov, string libro, string partida, string cuenta, string debe, string haber)
		{
			string query = "INSERT INTO libro_diario_detalles (numero_movimiento, id_libro_diario, id_partida, cuenta_contable,  debe, haber) " +
			"VALUES (" + mov + ", " + libro + ", " + partida + ",'" + cuenta + "' , " + debe + ", " + haber + ")";
			//Diario.ejecutarQuery(query);
		}

		public void CambiarEstadoDiario(string id)
		{
			string query = "UPDATE libro_diario_encabezados SET estado=0 WHERE id_libro_diario="+id+"";
			Mayor.ejecutarQuery(query);
		}

		public void ModificarLibroDiario(string id, string empresa, string fecha, string estado)
		{
			string query = "UPDATE libro_mayor_encabezados  SET id_libro_diario = " + empresa + ", fecha = '" + fecha + "'," +
			" estado = " + estado + " WHERE id_libro_mayor = " + id + ";";
			Mayor.ejecutarQuery(query);
		}

		public string[] ComboDiario() {

			return Mayor.llenarComboDiarios().Split(',');
		}

		public OdbcDataAdapter llenarLibroDiario()
		{
			OdbcDataAdapter dataTable = Mayor.LlenarTablaDiarioEncabezado();
			return dataTable;
		}

		public string ConsultarMayor(string idMayor)
		{
			return Mayor.ConsultarLibro(idMayor);
		}

		public string CrearLibroMayor(string idLibroDiario, string idLibroMayor)
		{
			
			int noDetalle = 0;
			OdbcDataAdapter ODBC_Cuentas = Mayor.Cuentas(idLibroDiario);//Cuentas
			DataTable cuentas = new DataTable();// Tabla de Cuentas
			//DEBE
			OdbcDataAdapter ODBC_Partidas_Cantidad_Debe = new OdbcDataAdapter();//Partidas  en las que parace en debe una cuenta y cantidad
			OdbcDataAdapter ODBC_Cuenta_Opuesta_Debe = new OdbcDataAdapter(); //Cuenta que aparece en el haber con la misma cantidad 
			DataTable Partidas_Cantidad_Debe = new DataTable(); // Tabla de partidas y cantidades
			DataTable Cuenta_Opuesta_Debe = new DataTable(); // Cuenta opuesta
			 // HABER
			OdbcDataAdapter ODBC_Partidas_Cantidad_Haber = new OdbcDataAdapter();
			DataTable Partidas_Cantidad_Haber = new DataTable();
			OdbcDataAdapter ODBC_Cuenta_Opuesta_Haber = new OdbcDataAdapter();
			DataTable Cuenta_Opuesta_Haber = new DataTable();

			ODBC_Cuentas.Fill(cuentas);
			valorxCuenta = 100/cuentas.Rows.Count;
			//APARICION
			// DEBE
			foreach (DataRow cuenta in cuentas.Rows)
			{
				if (progreso + Convert.ToInt32(valorxCuenta) < 100)
				{
					progreso += Convert.ToInt32(valorxCuenta);
				}
				else
				{
					progreso = 100;
				}
				
				//MessageBox.Show("CUENTAS");
				//MessageBox.Show("CUENTA "+cuenta[0].ToString());
				//MessageBox.Show("ID MAYOR "+idLibroMayor);
				InsertarCuenta(cuenta[0].ToString(),idLibroMayor);// Guardar Cuenta en Libro Diario
				//MessageBox.Show("ID DIARIO " + idLibroDiario);
				ODBC_Partidas_Cantidad_Debe = Mayor.Partidas_Cuenta_Debe(cuenta[0].ToString(),idLibroDiario);
				Partidas_Cantidad_Debe.Clear();
				ODBC_Partidas_Cantidad_Debe.Fill(Partidas_Cantidad_Debe);
				foreach (DataRow partidadebe in Partidas_Cantidad_Debe.Rows)
				{
					//MessageBox.Show("ENTRO A PARTIDAS");
					noDetalle++;
					//MessageBox.Show("DEBE NO PARTIDA "+partidadebe[0].ToString());
					//MessageBox.Show("DEBE CANTIDAD "+partidadebe[1].ToString());
					ODBC_Cuenta_Opuesta_Debe = Mayor.Cuenta_Opuesta_Debe(partidadebe[0].ToString(), partidadebe[1].ToString(), idLibroDiario);
					Cuenta_Opuesta_Debe.Clear();
					ODBC_Cuenta_Opuesta_Debe.Fill(Cuenta_Opuesta_Debe);
					//OPUESTO DEBE
					//MessageBox.Show("DEBE CUENTA " + cuenta[0].ToString());
					//MessageBox.Show("DEBE OPUESTA" + Cuenta_Opuesta_Debe.Rows[0].ItemArray[0].ToString());
					InsertarDetalleMayor(noDetalle.ToString(), idLibroMayor, partidadebe[0].ToString(), cuenta[0].ToString(), Cuenta_Opuesta_Debe.Rows[0].ItemArray[0].ToString(), "0",partidadebe[1].ToString());
					//MessageBox.Show("SALIO DE PARTIDAS");
				}

				ODBC_Partidas_Cantidad_Haber = Mayor.Partidas_Cuenta_Haber(cuenta[0].ToString(), idLibroDiario);
				Partidas_Cantidad_Haber.Clear();
				ODBC_Partidas_Cantidad_Haber.Fill(Partidas_Cantidad_Haber);
				foreach (DataRow partida in Partidas_Cantidad_Haber.Rows)
				{
					noDetalle++;
					//MessageBox.Show("HABER NO PARTIDA " + partida[0].ToString());
					//MessageBox.Show("HABER CANTIDAD " + partida[1].ToString());
					ODBC_Cuenta_Opuesta_Haber = Mayor.Cuenta_Opuesta_Haber(partida[0].ToString(), partida[1].ToString(),idLibroDiario);
					Cuenta_Opuesta_Haber.Clear();
					ODBC_Cuenta_Opuesta_Haber.Fill(Cuenta_Opuesta_Haber);
					//MessageBox.Show("HABER OPUESTA " + Cuenta_Opuesta_Haber.Rows[0].ItemArray[0].ToString());
		
					
						//MessageBox.Show("HABER CUENTA " + cuenta[0].ToString());
						//MessageBox.Show("HABER OPUESTA" + Cuenta_Opuesta_Haber.Rows[0].ItemArray[0].ToString());
						InsertarDetalleMayor(noDetalle.ToString(), idLibroMayor, partida[0].ToString(), cuenta[0].ToString(), Cuenta_Opuesta_Haber.Rows[0].ItemArray[0].ToString(), partida[1].ToString(), "0");
					
				}
				//MessageBox.Show("SALIO DE CUENTAS");
			}

			return "Libro Mayor Generado Correctamente";
		}

		public string CrearQueryMayor(string idlibroMayor,string  idLibroDiario)
		{
			OdbcDataAdapter ODBC_Cuentas = Mayor.Cuentas(idLibroDiario);//Cuentas
			DataTable cuentas = new DataTable();// Tabla de Cuentas
			ODBC_Cuentas.Fill(cuentas);

			string query = "";
			int i = 0;
			foreach (DataRow cuenta in cuentas.Rows)
			{
				//MessageBox.Show("Cuenta " + cuenta[0]);
				if (i==cuentas.Rows.Count-1)
				{
					query += "SELECT '','','"+cuenta[0].ToString()+"','' "+
							"UNION ALL "+
							"SELECT id_partida, concat('a: ', cuenta_contable), concat('Q.', haber), '' " +
							"FROM libro_mayor_detalles WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = "+idlibroMayor+" AND haber<>0 " +
							"UNION ALL "+
							"SELECT '','','', IF(ROUND(SUM(haber), 2) > 0, CONCAT('SALDO: Q.', ROUND(SUM(haber))), '') " +
							"FROM libro_mayor_detalles WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idlibroMayor + " AND haber<>0 " +
							"UNION ALL "+
							"SELECT id_partida, concat('por: ', cuenta_contable), concat('Q.', debe), '' FROM libro_mayor_detalles " +
							"WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idlibroMayor + " AND debe<>0 " +
							"UNION ALL "+
							"SELECT '','','', IF((ROUND(SUM(debe), 2)) > 0, CONCAT('SALDO: Q.', ROUND(SUM(debe))), '') " +
							"FROM libro_mayor_detalles WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idlibroMayor + " AND debe<>0 ;";
				}
				else
				{
					query += "SELECT '','','" + cuenta[0].ToString() + "','' " +
							"UNION ALL " +
							"SELECT id_partida, concat('a: ', cuenta_contable), concat('Q.', haber), ''  " +
							"FROM libro_mayor_detalles WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idlibroMayor + " AND haber<>0 " +
							"UNION ALL " +
							"SELECT '','','', IF(ROUND(SUM(haber), 2) > 0, CONCAT('SALDO: Q.', ROUND(SUM(haber))), '') " +
							"FROM libro_mayor_detalles WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idlibroMayor + " AND haber<>0 " +
							"UNION ALL " +
							"SELECT id_partida, concat('por: ', cuenta_contable), concat('Q.', debe), '' FROM libro_mayor_detalles " +
							"WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idlibroMayor + " AND debe<>0 " +
							"UNION ALL " +
							"SELECT '','','', IF((ROUND(SUM(debe), 2)) > 0, CONCAT('SALDO: Q.', ROUND(SUM(debe))), '') " +
							"FROM libro_mayor_detalles WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idlibroMayor + " AND debe<>0 UNION ALL ";
				}
				i++;
				
			}
			return query;
		}
		public OdbcDataAdapter llenarMayor(string idLibroDiario, string idlibroMayor)
		{

			string query = CrearQueryMayor(idlibroMayor, idLibroDiario);
			
			OdbcDataAdapter dataTable = Mayor.LlenarTablaMayor(query);
			return dataTable;
		}

		public string IdLibro()
		{
			return Mayor.ObtenerIdLibro();
		}

		public string IdPartida(string no)
		{
			return Mayor.ObtenerIdPartida(no);
		}

		public string[] comboTabla()
		{
			string[] combo = Mayor.llenarComboTablaMovimientos().Split(',');
			return combo;
		}

		public void DeletePartida(string concepto, string libro)
		{
			string query = "UPDATE partidas SET estado = 0 WHERE concepto='" + concepto + "' AND id_libro_diario='" + libro + "'";
			Mayor.ejecutarQuery(query);
		}

		public void InsertarCuenta(string Cuenta, string libroMayor)
		{
			string query = "INSERT INTO libro_mayor_cuentas VALUES('"+Cuenta+"', "+libroMayor+",1)";
			Mayor.ejecutarQuery(query);
		}

		public void InsertarDetalleMayor(string nodetalle,string  libroMayor,string idPartida, string Cuenta, string opuesta,string debe, string haber)
		{
			string query = "INSERT INTO libro_mayor_detalles VALUES("+nodetalle+","+libroMayor+","+idPartida+",'" + Cuenta + "','"+opuesta+"', " + debe + ","+haber+",1)";
			Mayor.ejecutarQuery(query);
		}
	}
}

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
	public class EstadoDeResultados
	{
		sql_EstadoDeResultados Mayor = new sql_EstadoDeResultados();
		public float valorxCuenta = 0;
		public int progreso = 0;
		public void crearLibroDiario(string id, string diario, string fecha)
		{
			string query = "INSERT INTO estado_de_resultados (id_estado_de_resultado, id_libro_balance, fecha) " +
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
			string query = "UPDATE estado_de_resultados  SET id_libro_balance = " + empresa + ", fecha = '" + fecha + "'," +
			" estado = " + estado + " WHERE id_estado_de_resultado = " + id + ";";
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

		public string CrearLibroMayor(string idLibroBalances, string idEstadoDeResultados)
		{
			
			int noDetalle = 0;
			float ingresos = 0;
			float compras = 0;
			float gastos = 0;
			string sql = "";
			int i = 0;
			OdbcDataAdapter ODBC_IN = Mayor.Ingresos(idLibroBalances);//AC
			DataTable ing = new DataTable();// Tabla AC
			ODBC_IN.Fill(ing);

			OdbcDataAdapter ODBC_COM = Mayor.Compras(idLibroBalances);//ANC
			DataTable  com = new DataTable();// Tabla ANC
			ODBC_COM.Fill(com);

			OdbcDataAdapter ODBC_GAS = Mayor.Gastos(idLibroBalances);//PC
			DataTable gas = new DataTable();// Tabla PC
			ODBC_GAS.Fill(gas);

			//APARICION
			// DEBE
			foreach (DataRow cuenta in ing.Rows)
			{
				noDetalle++;
				ingresos += Convert.ToInt32(cuenta[1]);
				InsertarDetalleEstadoDeResultados(noDetalle.ToString(), idEstadoDeResultados, cuenta[0].ToString(), cuenta[1].ToString());
			}
			progreso = 25;
			foreach (DataRow cuenta in com.Rows)
			{
				noDetalle++;
				compras += Convert.ToInt32(cuenta[1]);
				InsertarDetalleEstadoDeResultados(noDetalle.ToString(), idEstadoDeResultados, cuenta[0].ToString(), cuenta[1].ToString());
			}
			progreso = 50;
			foreach (DataRow cuenta in gas.Rows)
			{
				noDetalle++;
				gastos += Convert.ToInt32(cuenta[1]);
				InsertarDetalleEstadoDeResultados(noDetalle.ToString(), idEstadoDeResultados, cuenta[0].ToString(), cuenta[1].ToString());
			}
			progreso = 75;
			noDetalle++;
			InsertarDetalleEstadoDeResultados(noDetalle.ToString(), idEstadoDeResultados, "Ganacia del Ejercicio", (ingresos-compras-gastos).ToString());
			progreso = 100;

			

			return "Estado De Resultados Generado Correctamente";
		}

		
		public OdbcDataAdapter llenarBalance(string idBalance)
		{

			string query = "SELECT 'INGRESOS', '','','' "+
							"UNION ALL "+
							"SELECT cuenta_contable, saldo,'','' FROM estado_de_resultados_detalles  WHERE id_estado_de_resultado = " + idBalance + " AND '4.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable)  " +                                                           
							"UNION ALL "+
							"SELECT 'TOTAL INGRESOS','',ROUND(SUM(saldo),2),'' FROM estado_de_resultados_detalles   WHERE id_estado_de_resultado = " + idBalance + " AND '4.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) " +
							"UNION ALL "+
							"SELECT 'COMPRAS', '','','' "+
							"UNION ALL " +
							"SELECT cuenta_contable, saldo,'','' FROM estado_de_resultados_detalles   WHERE id_estado_de_resultado = " + idBalance + " AND '5.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) " +
							"UNION ALL "+
							"SELECT 'TOTAL COMPRAS','',ROUND(SUM(saldo),2),'' FROM estado_de_resultados_detalles   WHERE id_estado_de_resultado = " + idBalance + " AND '5.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable  )  " +
							"UNION ALL " +
							"SELECT 'GANANCIA DE VENTAS','','', " +
							"ROUND(( "+
							"(SELECT SUM(saldo) FROM estado_de_resultados_detalles   WHERE id_estado_de_resultado = " + idBalance + " AND '4.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable)) " +
							"- "+
							"(SELECT SUM(saldo) FROM estado_de_resultados_detalles   WHERE id_estado_de_resultado = " + idBalance + " AND '5.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable)) " +
							"),2) "+
							"UNION ALL "+
							"SELECT 'GASTOS', '','','' "+
							"UNION ALL "+
							"SELECT cuenta_contable, saldo,'','' FROM estado_de_resultados_detalles   WHERE id_estado_de_resultado = " + idBalance + " AND '6.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) " +
							"UNION ALL "+
							"SELECT 'TOTAL GASTOS','',ROUND(SUM(saldo),2),'' FROM estado_de_resultados_detalles   WHERE id_estado_de_resultado = " + idBalance + " AND '6.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable  ) " + 
							"UNION ALL "+
							"SELECT 'GANANCIA DEL EJERCICIO ANTES DE IMPUESTO','','', "+
							"ROUND(( "+
							"(SELECT SUM(saldo) FROM estado_de_resultados_detalles   WHERE id_estado_de_resultado = " + idBalance + " AND '4.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable)) " +
							"- "+
							"(SELECT SUM(saldo) FROM estado_de_resultados_detalles   WHERE id_estado_de_resultado = " + idBalance + " AND '5.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable)) " +
							"- "+
							"(SELECT SUM(saldo) FROM estado_de_resultados_detalles   WHERE id_estado_de_resultado = " + idBalance + " AND '6.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable)) " +
							"),2) ;";


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

		public void InsertarDetalleEstadoDeResultados(string nodetalle,string  balances, string Cuenta, string saldo)
		{
			string query = "INSERT INTO estado_de_resultados_detalles VALUES("+nodetalle+","+balances+",'" + Cuenta + "', " + saldo + ", NULL)";
			Mayor.ejecutarQuery(query);
		}
	}
}

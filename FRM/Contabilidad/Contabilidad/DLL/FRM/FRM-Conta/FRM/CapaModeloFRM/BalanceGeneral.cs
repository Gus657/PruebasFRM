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
	public class BalanceGeneral
	{
		sql_BalanceGeneral Mayor = new sql_BalanceGeneral();
		public float valorxCuenta = 0;
		public int progreso = 0;
		public void crearLibroDiario(string id, string diario, string fecha)
		{
			string query = "INSERT INTO balance_general_encabezados (id_balance_general, id_libro_balance, fecha) " +
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
			string query = "UPDATE balance_general_encabezados  SET id_libro_balance = " + empresa + ", fecha = '" + fecha + "'," +
			" estado = " + estado + " WHERE id_balance_general = " + id + ";";
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

		public string CrearLibroMayor(string idLibroBalances, string idBalanceGeneral)
		{
			
			int noDetalle = 0;
			float activo = 0;
			float pasivo = 0;
			float patrimonio = 0;
			string sql = "";
			int i = 0;
			OdbcDataAdapter ODBC_AC = Mayor.ActivoC(idLibroBalances);//AC
			DataTable ac = new DataTable();// Tabla AC
			ODBC_AC.Fill(ac);

			OdbcDataAdapter ODBC_ANC = Mayor.ActivoNC(idLibroBalances);//ANC
			DataTable anc = new DataTable();// Tabla ANC
			ODBC_ANC.Fill(anc);

			OdbcDataAdapter ODBC_PC = Mayor.PasivoC(idLibroBalances);//PC
			DataTable pc = new DataTable();// Tabla PC
			ODBC_PC.Fill(pc);

			OdbcDataAdapter ODBC_PNC = Mayor.PasivoNC(idLibroBalances);//PNC
			DataTable pnc = new DataTable();// Tabla PNC
			ODBC_PNC.Fill(pnc);

			OdbcDataAdapter ODBC_PAT = Mayor.Patrimonio(idLibroBalances);//Patrimonio
			DataTable pat = new DataTable();// Tabla Patrimonio
			ODBC_PAT.Fill(pat);



			//APARICION
			// DEBE
			foreach (DataRow cuenta in ac.Rows)
			{
				noDetalle++;
				activo += Convert.ToInt32(cuenta[1]);
				InsertarDetalleBalanceGeneral(noDetalle.ToString(), idBalanceGeneral, cuenta[0].ToString(), cuenta[1].ToString());
			}
			progreso = 25;
			foreach (DataRow cuenta in anc.Rows)
			{
				noDetalle++;
				activo += Convert.ToInt32(cuenta[1]);
				InsertarDetalleBalanceGeneral(noDetalle.ToString(), idBalanceGeneral, cuenta[0].ToString(), cuenta[1].ToString());
			}
			progreso = 50;
			foreach (DataRow cuenta in pc.Rows)
			{
				noDetalle++;
				pasivo += Convert.ToInt32(cuenta[1]);
				InsertarDetalleBalanceGeneral(noDetalle.ToString(), idBalanceGeneral, cuenta[0].ToString(), cuenta[1].ToString());
			}
			progreso = 75;
			foreach (DataRow cuenta in pnc.Rows)
			{
				noDetalle++;
				pasivo += Convert.ToInt32(cuenta[1]);
				InsertarDetalleBalanceGeneral(noDetalle.ToString(), idBalanceGeneral, cuenta[0].ToString(), cuenta[1].ToString());
			}
			foreach (DataRow cuenta in pat.Rows)
			{
				noDetalle++;
				patrimonio += Convert.ToInt32(cuenta[1]);
				InsertarDetalleBalanceGeneral(noDetalle.ToString(), idBalanceGeneral, cuenta[0].ToString(), cuenta[1].ToString());
			}
			noDetalle++;
			InsertarDetalleBalanceGeneral(noDetalle.ToString(), idBalanceGeneral, "Ganacia del Ejercicio", (activo-pasivo-patrimonio).ToString());
			progreso = 100;

			

			return "Balances Generados Correctamente";
		}

		public string CrearQueryMayor(string idbalances,string  idLibroDiario)
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
							"SELECT id_partida, concat('a: ', cuenta_contable), haber, '' " +
							"FROM libro_mayor_detalles WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = "+idbalances+" AND haber<>0 " +
							"UNION ALL "+
							"SELECT '','','', IF(ROUND(SUM(haber), 2) > 0, CONCAT('SALDO: ', ROUND(SUM(haber))), '') " +
							"FROM libro_mayor_detalles WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idbalances + " AND haber<>0 " +
							"UNION ALL "+
							"SELECT id_partida, concat('por: ', cuenta_contable), debe, '' FROM libro_mayor_detalles " +
							"WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idbalances + " AND debe<>0 " +
							"UNION ALL "+
							"SELECT '','','', IF((ROUND(SUM(debe), 2)) > 0, CONCAT('SALDO: ', ROUND(SUM(debe))), '') " +
							"FROM libro_mayor_detalles WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idbalances + " AND debe<>0 ;";
				}
				else
				{
					query += "SELECT '','','" + cuenta[0].ToString() + "','' " +
							"UNION ALL " +
							"SELECT id_partida, concat('a: ', cuenta_contable), haber, ''  " +
							"FROM libro_mayor_detalles WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idbalances + " AND haber<>0 " +
							"UNION ALL " +
							"SELECT '','','', IF(ROUND(SUM(haber), 2) > 0, CONCAT('SALDO: ', ROUND(SUM(haber))), '') " +
							"FROM libro_mayor_detalles WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idbalances + " AND haber<>0 " +
							"UNION ALL " +
							"SELECT id_partida, concat('por: ', cuenta_contable), debe, '' FROM libro_mayor_detalles " +
							"WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idbalances + " AND debe<>0 " +
							"UNION ALL " +
							"SELECT '','','', IF((ROUND(SUM(debe), 2)) > 0, CONCAT('SALDO: ', ROUND(SUM(debe))), '') " +
							"FROM libro_mayor_detalles WHERE cuenta_mayor = '" + cuenta[0].ToString() + "' AND id_libro_mayor = " + idbalances + " AND debe<>0 UNION ALL ";
				}
				i++;
				
			}
			return "SELECT * FROM balance_general_detalles";
		}
		public OdbcDataAdapter llenarBalance(string idBalance)
		{

			string query = "SELECT 'ACTIVO CORRIENTE', '','','' "+
							"UNION ALL "+
							"SELECT cuenta_contable, saldo,'','' FROM balance_general_detalles  WHERE id_balance_general =" + idBalance + " AND '1.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) " +
							"UNION ALL "+
							"SELECT 'TOTAL ACTIVO CORRIENTE','', ROUND(SUM(saldo),2),'' FROM balance_general_detalles   WHERE id_balance_general ="+idBalance+" AND '1.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) "+
							"UNION ALL "+
							"SELECT 'ACTIVO NO CORRIENTE', '','','' "+
							"UNION ALL "+
							"SELECT cuenta_contable, saldo,'','' FROM balance_general_detalles   WHERE id_balance_general = "+ idBalance + " AND '1.2' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) " +
							"UNION ALL "+
							"SELECT 'TOTAL ACTIVO NO CORRIENTE','', ROUND(SUM(saldo),2),'' FROM balance_general_detalles   WHERE id_balance_general = "+ idBalance + " AND '1.2' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable ) " +                                                      
							"UNION ALL "+
							"SELECT 'TOTAL ACTIVO','','', ROUND(SUM(saldo),2) FROM balance_general_detalles   WHERE id_balance_general = "+ idBalance +" AND('1.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) OR '1.2' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable)) " +
							"UNION ALL "+
							"SELECT 'PASIVO CORRIENTE', '','','' "+
							"UNION ALL "+
							"SELECT cuenta_contable, saldo,'','' FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND '2.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) " +
							"UNION ALL "+
							"SELECT 'TOTAL PASIVO CORRIENTE','', ROUND(SUM(saldo),2),'' FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND '2.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable  ) " +                                                                                                                            
							"UNION ALL "+
							"SELECT 'PASIVO NO CORRIENTE', '','','' "+
							"UNION ALL "+
							"SELECT cuenta_contable, saldo,'','' FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND '2.2' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) " +
							"UNION ALL "+
							"SELECT 'TOTAL PASIVO NO CORRIENTE','', ROUND(SUM(saldo),2),'' FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND '2.2' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable ) " +
							"UNION ALL "+
							"SELECT 'TOTAL PASIVO','','',  ROUND(SUM(saldo),2) FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND('2.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) OR '2.2' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable)) " +
							"UNION ALL "+ // CAPITAL
							"SELECT cuenta_contable,'', saldo,'' FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND '3.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) " +
							"UNION ALL "+
							"SELECT 'GANANCIA DEL EJECICIO','', "+
							"ROUND(("+
							"(SELECT ROUND(SUM(saldo),2) FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND('1.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) OR '1.2' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable))) " +
							"- "+
							"(SELECT ROUND(SUM(saldo),2) FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND('2.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) OR '2.2' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable))) " +
							"- "+
							"(SELECT ROUND(SUM(saldo),2) FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND '3.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable)) " +
							"),2) "+
							",'' FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND '3.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) " +
							"UNION ALL "+
							"SELECT 'PASIVO + NUEVO CAPITAL','','', "+
							"ROUND((( "+
							"(SELECT ROUND(SUM(saldo),2) FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND('1.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) OR '1.2' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable))) " +
							"- "+
							"(SELECT ROUND(SUM(saldo),2) FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND('2.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) OR '2.2' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable))) " +
							"- "+
							"(SELECT ROUND(SUM(saldo),2) FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND '3.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable)) " +
							") "+
							"+ "+
							"(SELECT ROUND(SUM(saldo),2) FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND('2.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable) OR '2.2' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable))) " +
							"+ "+
							"(SELECT ROUND(SUM(saldo),2) FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND '3.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable)) " +
							"),2 ) "+
							"FROM balance_general_detalles   WHERE id_balance_general = " + idBalance + " AND '3.1' = (SELECT id_tipo_cuenta from cuentas WHERE nombre = cuenta_contable)";


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

		public void InsertarDetalleBalanceGeneral(string nodetalle,string  balances, string Cuenta, string saldo)
		{
			string query = "INSERT INTO balance_general_detalles VALUES("+nodetalle+","+balances+",'" + Cuenta + "', " + saldo + ", NULL)";
			Mayor.ejecutarQuery(query);
		}
	}
}

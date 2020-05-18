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
	public class LibroBalances
	{
		sql_balances Mayor = new sql_balances();
		public float valorxCuenta = 0;
		public int progreso = 0;
		public void crearLibroDiario(string id, string diario, string fecha)
		{
			string query = "INSERT INTO balances (id_balance, id_libro_mayor, fecha) " +
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
			string query = "UPDATE balances  SET id_libro_mayor = " + empresa + ", fecha = '" + fecha + "'," +
			" estado = " + estado + " WHERE id_balance = " + id + ";";
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

		public string CrearLibroMayor(string idLibroMayor, string idBalance)
		{
			
			int noDetalle = 0;
			float deudor = 0;
			float acreedor = 0;
			float debe = 0;
			float haber = 0;
			string sql = "";
			int i = 0;
			OdbcDataAdapter ODBC_Cuentas = Mayor.Cuentas(idLibroMayor);//Cuentas
			DataTable cuentas = new DataTable();// Tabla de Cuentas
			//DEBE

			OdbcDataAdapter ODBC_Debe_Haber_Cuenta = new OdbcDataAdapter(); //Cuenta que aparece en el haber con la misma cantidad 
			DataTable Debe_Haber_Cuenta = new DataTable(); // Tabla de partidas y cantidades

			ODBC_Cuentas.Fill(cuentas);
			valorxCuenta = 100/cuentas.Rows.Count;
			//APARICION
			// DEBE
			foreach (DataRow cuenta in cuentas.Rows)
			{
				if (i==cuentas.Rows.Count-1)
				{
					sql += "SELECT " +
						"IF ((SELECT ROUND(SUM(debe), 2) FROM libro_diario_detalles WHERE debe <>0 AND cuenta_contable = '" + cuenta[0] + "' AND id_libro_diario = (SELECT id_libro_diario FROM libro_mayor_encabezados WHERE id_libro_mayor = " + idLibroMayor + "))>0," +
						"(SELECT ROUND(SUM(debe), 2) FROM libro_diario_detalles WHERE debe <>0 AND cuenta_contable = '" + cuenta[0] + "' AND id_libro_diario = (SELECT id_libro_diario FROM libro_mayor_encabezados WHERE id_libro_mayor = " + idLibroMayor + ")),0)," +
						"IF((SELECT ROUND(SUM(haber), 2) FROM libro_diario_detalles WHERE haber<>0 AND cuenta_contable = '" + cuenta[0] + "' AND id_libro_diario = (SELECT id_libro_diario FROM libro_mayor_encabezados WHERE id_libro_mayor = " + idLibroMayor + "))>0," +
						"(SELECT ROUND(SUM(haber), 2) FROM libro_diario_detalles WHERE haber<>0 AND cuenta_contable = '" + cuenta[0] + "' AND id_libro_diario = (SELECT id_libro_diario FROM libro_mayor_encabezados WHERE id_libro_mayor = " + idLibroMayor + ")),0) ;";
				}
				else
				{
					sql += "SELECT " +
						"IF ((SELECT ROUND(SUM(debe), 2) FROM libro_diario_detalles WHERE debe <>0 AND cuenta_contable = '" + cuenta[0] + "' AND id_libro_diario = (SELECT id_libro_diario FROM libro_mayor_encabezados WHERE id_libro_mayor = " + idLibroMayor + "))>0," +
						"(SELECT ROUND(SUM(debe), 2) FROM libro_diario_detalles WHERE debe <>0 AND cuenta_contable = '" + cuenta[0] + "' AND id_libro_diario = (SELECT id_libro_diario FROM libro_mayor_encabezados WHERE id_libro_mayor = " + idLibroMayor + ")),0)," +
						"IF((SELECT ROUND(SUM(haber), 2) FROM libro_diario_detalles WHERE haber<>0 AND cuenta_contable = '" + cuenta[0] + "' AND id_libro_diario = (SELECT id_libro_diario FROM libro_mayor_encabezados WHERE id_libro_mayor = " + idLibroMayor + "))>0," +
						"(SELECT ROUND(SUM(haber), 2) FROM libro_diario_detalles WHERE haber<>0 AND cuenta_contable = '" + cuenta[0] + "' AND id_libro_diario = (SELECT id_libro_diario FROM libro_mayor_encabezados WHERE id_libro_mayor = " + idLibroMayor + ")),0) UNION ALL ";
				}
				
				i++;

			}

			ODBC_Debe_Haber_Cuenta = Mayor.Debe_Haber(sql);
			ODBC_Debe_Haber_Cuenta.Fill(Debe_Haber_Cuenta);
			string[] valores = Mayor.ArrayCuentas(idLibroMayor).Split(',');
			
				
				

				foreach (DataRow debehaber in Debe_Haber_Cuenta.Rows)
				{
						noDetalle++;
						if (progreso + Convert.ToInt32(valorxCuenta) < 100)
						{
							progreso += Convert.ToInt32(valorxCuenta);
						}
						else
						{
							progreso = 100;
						}
						
						//MessageBox.Show("DEBE " + debehaber[0].ToString());
						//MessageBox.Show("HABER " + debehaber[1].ToString());
						if (debehaber[0].ToString() == "" || debehaber[0].ToString() == " " || debehaber[0] == null)
						{
							debe = 0;
						}
						else
						{
							debe = (float)Convert.ToDouble(debehaber[0].ToString());
						}

						if (debehaber[1].ToString() == "" || debehaber[1].ToString() == " " || debehaber[1] == null)
						{
							haber = 0;
						}
						else
						{
							haber = (float)Convert.ToDouble(debehaber[1].ToString());
						}
						//MessageBox.Show("debe " + debe.ToString());
						//MessageBox.Show("haber " + haber.ToString());
						if (debe > haber || debe == haber)
						{
							deudor = debe - haber;
							acreedor = 0;
						}
						else
						{
							acreedor = haber - debe;
							deudor = 0;
						}
				InsertarDetalleBalance(noDetalle.ToString(), idBalance, valores[noDetalle-1].ToString(), debe.ToString(), haber.ToString(), deudor.ToString(), acreedor.ToString());
			}
			
				
			
				
			

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
			return query;
		}
		public OdbcDataAdapter llenarBalance(string idBalance)
		{

			string query = "SELECT numero,	id_balance,	cuenta_contable,	 IF (debe>0,concat('Q.', debe),''),	IF (haber>0,concat('Q.', haber),''),	" +
				" IF(deudor>0,concat('Q.', deudor),''),	IF(acreedor>0,concat('Q.', acreedor),'') FROM `balances_detalles` where id_balance = " + idBalance+" " +
				" UNION ALL " +
				" SELECT '', '', 'SUMAS IGUALES', concat('Q.', ROUND(SUM(debe), 2))," +
				" concat('Q.', ROUND(SUM(haber), 2)), concat('Q.', ROUND(SUM(deudor), 2)), " +
				" concat('Q.', ROUND(SUM(acreedor), 2)) FROM `balances_detalles` where id_balance = " + idBalance+"";
			
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

		public void InsertarDetalleBalance(string nodetalle,string  balances, string Cuenta,string debe, string haber, string deudor, string acreedor)
		{
			string query = "INSERT INTO balances_detalles VALUES("+nodetalle+","+balances+",'" + Cuenta + "', " + debe + ","+haber+ ", " + deudor + "," + acreedor + ")";
			Mayor.ejecutarQuery(query);
		}
	}
}

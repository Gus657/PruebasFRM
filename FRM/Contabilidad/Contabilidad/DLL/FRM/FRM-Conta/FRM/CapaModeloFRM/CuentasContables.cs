using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaControladorCONTA;
namespace CapaModeloCONTA
{
	public class CuentasContables
	{
		sql_cuentas_Contables sql = new sql_cuentas_Contables();
		public OdbcDataAdapter llenarCuentas()
		{
			OdbcDataAdapter dataTable = sql.LlenarTablaCuentas();
			return dataTable;
		}

		public string [] ObtenerTIposCuentasContables()
		{
			string[] tipos = sql.llenarComboTipos().Split(',');

			return tipos;
		}
		public string ObtenerIdTIpoCuenta(string name)
		{
			string id = sql.ObtenerIdTipo(name); ;

			return id;
		}

		public string ObtenerValor(string tabla, string campo, string llave, string valor, bool tipo)
		{
			string id = sql.ObtenerValor( tabla,  campo, llave, valor,  tipo);

			return id;
		}

		public string ObtenerNextIdCuenta(string cod)
		{
			string id = sql.ObtenerCodigo(cod);
			if (id == "" || id == " " || id == null)
			{
				id = "0";
			}
			return id;
		}

		public void GuardarCuenta(string id, string tipo, string codigo,  string nombre, string Descr)
		{
			string query = "INSERT INTO cuentas  VALUES('"+id+"','"+tipo+"',"+codigo+",'"+nombre+"','"+Descr+"', 1)";
			sql.ejecutarQuery(query);
		}

		public void ModCuenta(string id ,string nombre, string Descr, string estado)
		{
			string query = "UPDATE cuentas SET  nombre='" + nombre + "', descripcion='" + Descr + "', estado= "+estado+" where id_cuenta='"+id+"'";
			sql.ejecutarQuery(query);
		}
		public void DeleteCuenta(string id)
		{
			string query = "DELETE FROM cuentas WHERE id_cuenta='"+id+"'";
			
			sql.ejecutarQuery(query);
		}
	}
}

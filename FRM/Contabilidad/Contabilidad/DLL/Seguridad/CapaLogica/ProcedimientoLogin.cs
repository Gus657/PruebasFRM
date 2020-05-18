using System;
using System.Data;
using System.Data.Odbc;
using CapaDatos;

namespace CapaLogica
{
    public class ProcedimientoLogin
    {
        public bool llamarProcedimiento(string usuario, string clave)
        {
            try
            {
                conexion con = new conexion();
                OdbcCommand cmd = new OdbcCommand("{ call procedimientoLogin (?,?)}", con.conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@usuario", OdbcType.Text).Value = usuario;
                cmd.Parameters.Add("@clave", OdbcType.Text).Value = clave;

                OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    cmd.Connection.Close();
                    reader.Close();
                    return true;
                }
                else{
                    cmd.Connection.Close();
                    reader.Close();
                    return false ;
                }

            }
            catch (OdbcException ex)
            {

                Console.WriteLine(ex);
                return false;

            }

        }
    }
}

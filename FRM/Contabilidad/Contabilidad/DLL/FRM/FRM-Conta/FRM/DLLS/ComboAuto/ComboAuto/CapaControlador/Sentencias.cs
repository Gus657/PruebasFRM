using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace CapaControlador
{
    public class Sentencias
    {


        string cmb;
        string tbl;
        string camp;

        Conexion con = new Conexion();


        public string[] llenarCmb(string tabla, string campo)
        {

            string[] Campos = new string[300];
            string[] auto = new string[300];
            int i = 0;
            string sql = "SELECT " + campo + " FROM " + tabla + " ;";

            try
            {
                OdbcCommand command = new OdbcCommand(sql, con.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Campos[i] = reader.GetValue(0).ToString();
                    i++;
             

                }

                                 
                

            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -" + tabla + "\n -" + campo); }


            return Campos;
           


        }


        public DataTable obtener(string tabla, string campo) {

            string sql = "SELECT " + campo + " FROM " + tabla + " ;";

            OdbcCommand command = new OdbcCommand(sql, con.conexion());
            OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);


            return dt;
        }
    }


}


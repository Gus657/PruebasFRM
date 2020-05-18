using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaControlador;

namespace CapaModelo
{
    public class LogicaCombo
    {
        string[] llenado = new string[30];

        Sentencias sn = new Sentencias();



        public string[] items(string tabla, string campo)
        {
            string[] Items = sn.llenarCmb(tabla, campo);

            return Items;


        }

        public DataTable enviar(string tabla, string campo) {

            

            var dt1= sn.obtener(tabla, campo);

            return dt1;
        }

        
    }
}

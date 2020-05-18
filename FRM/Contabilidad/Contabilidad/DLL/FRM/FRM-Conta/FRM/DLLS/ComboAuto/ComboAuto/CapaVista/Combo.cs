using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using CapaModelo;

namespace CapaVista
{
    
    public partial class Combo : UserControl
    {
        LogicaCombo cm = new LogicaCombo();
        string tbl ;
        string cmp ;
        public Combo()
        {
            InitializeComponent();
         
     

        }
      
        public void llenarse(string tabla, string campo) {

            tbl = tabla;
            cmp = campo;
          

           
            Cmb_auto.ValueMember = "numero";
            Cmb_auto.DisplayMember = "nombre";

            string[] items = cm.items(tabla,campo);



            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i] != "")
                    {
                        Cmb_auto.Items.Add(items[i]);
                    }
                }

            }

            var dt2 = cm.enviar(tabla, campo);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {

                coleccion.Add(Convert.ToString(row[campo]));

            }

            Cmb_auto.AutoCompleteCustomSource = coleccion;
            Cmb_auto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cmb_auto.AutoCompleteSource = AutoCompleteSource.CustomSource;




        }


        public string obtener() {

            string ob = "";

            ob = Cmb_auto.Text;
            
            return ob;

        }

    }
}

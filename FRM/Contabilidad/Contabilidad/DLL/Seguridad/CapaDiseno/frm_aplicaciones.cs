using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using System.Data.Odbc;
namespace CapaDiseno
{
    public partial class frm_aplicaciones : Form
    {

        logica logica1;
        bool boton_ingreso;
        bool boton_eliminar;

        public frm_aplicaciones(string idUsuario)
        {
            InitializeComponent();
            logica1 = new logica(idUsuario);
        }

        public frm_aplicaciones()
        {
        }

        string buscar;
        private void Button1_Click(object sender, EventArgs e)
        {
            buscar = txt_buscar.Text.Trim();

            if (boton_eliminar == true)
            {

                groupBox1.Enabled = false;
                Gpb_estado.Enabled = false;
                Gpb_estado.Enabled = false;
                button4.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                txt_idaplicacion.Enabled = false;
                txt_descripcion.Enabled = true;
                Gpb_estado.Enabled = false;
                txt_aplicacion.Enabled = true;
                Cbx_modulo.Enabled = true;
            }


            try
            {
                DataTable dtusuario = logica1.buscaraplicacion(buscar);

                if (dtusuario.ToString() == null)
                {
                    MessageBox.Show("No existe");

                }
                else
                {
                    foreach (DataRow dt in dtusuario.Rows)
                    {

                        txt_idaplicacion.Text = (dt[0].ToString());
                        Cbx_modulo.Text = (dt[1].ToString());
                        txt_aplicacion.Text = (dt[2].ToString());
                        txt_descripcion.Text = (dt[3].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Frm_aplicaciones_Load(object sender, EventArgs e)
        {

            try
            {
                DataTable dtModulos = logica1.consultaLogicaModulos();

                foreach (DataRow row in dtModulos.Rows)
                {
                    Cbx_modulo.Items.Add(row[0].ToString());
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }


            txt_buscar.Enabled = false;
            button1.Enabled = false;
            txt_idaplicacion.Enabled = false;
            Cbx_modulo.Enabled = false;
            txt_descripcion.Enabled = false;
            txt_idaplicacion.Enabled = false;
            Gpb_estado.Enabled = false;
            txt_aplicacion.Enabled = false;
            btn_guardar.Enabled = false;
            limpiar();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Cbx_modulo.Enabled = true;
            txt_idaplicacion.Enabled = true;
            txt_aplicacion.Enabled = true;
            txt_descripcion.Enabled = true;
            Gpb_estado.Enabled = true;
            txt_buscar.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            boton_ingreso = true;
            btn_guardar.Enabled = true;
            txt_idaplicacion.Enabled = false;
            Gpb_estado.Enabled = false;
            Rdb_activo.Checked = true;



            try
            {
                DataTable dtValidarID = logica1.validarIDAplicacion();
                foreach (DataRow row in dtValidarID.Rows)
                {
                    if(row[0].ToString() == "")
                    {
                        txt_idaplicacion.Text = "1";
                    }
                    else
                    {
                        txt_idaplicacion.Text = row[0].ToString();
                    }
                  
                   
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return;
            }

            limpiar();
        }
    

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }



        void limpiar()
        {
            txt_buscar.Text = "";
            Cbx_modulo.Text = "";
            txt_descripcion.Text = "";
            txt_aplicacion.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            txt_buscar.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            button4.Enabled = false;
            txt_idaplicacion.Enabled = false;
            Cbx_modulo.Enabled = false;
            txt_descripcion.Enabled = false;
            txt_idaplicacion.Enabled = false;
            Gpb_estado.Enabled = false;
            txt_aplicacion.Enabled = false;
            btn_guardar.Enabled = true;
            txt_idaplicacion.Text = "";
            limpiar();
        }


        public string idaplicacion, modulo, descripcion, aplicacion;

        private void Btn_ayuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "C:\\Ayuda_Seguridad\\" + "MantenimientoAplicaciones.chm", "Mantenimiento_Aplicaciones.html");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            idaplicacion = txt_idaplicacion.Text;
            modulo = Cbx_modulo.Text;
            descripcion = txt_descripcion.Text;
            aplicacion = txt_aplicacion.Text;

            txt_buscar.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            txt_idaplicacion.Enabled = false;
            Cbx_modulo.Enabled = false;
            txt_descripcion.Enabled = false;
            txt_idaplicacion.Enabled = false;
            Gpb_estado.Enabled = false;
            txt_aplicacion.Enabled = false;
            btn_guardar.Enabled = true;
            boton_eliminar = true;
            btn_guardar.Enabled = false;

            try
            {
                DataTable dtusuario = logica1.eliminaraplicaciones(idaplicacion, modulo, descripcion, aplicacion);
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return;
            }
            
            txt_idaplicacion.Text = "";
            limpiar();
            
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            idaplicacion = txt_idaplicacion.Text;
            modulo = Cbx_modulo.Text;
            descripcion = txt_descripcion.Text;
            aplicacion = txt_aplicacion.Text;
            
            int boton;

            if(txt_aplicacion.Text == "" || Cbx_modulo.Text == "" || txt_descripcion.Text=="" || txt_aplicacion.Text=="")
            {
                MessageBox.Show("Faltan Campos Por Llenar");
            }
            else
            {
                if (boton_ingreso == true)
                {
                    boton = 1;
                }
                else
                {
                    boton = 0;
                }

                try
                {
                    DataTable dtusuario = logica1.aplicaciones(idaplicacion, modulo, descripcion, aplicacion, boton);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                    return;
                }
                txt_buscar.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                txt_idaplicacion.Enabled = false;
                Cbx_modulo.Enabled = false;
                txt_descripcion.Enabled = false;
                txt_idaplicacion.Enabled = false;
                Gpb_estado.Enabled = false;
                txt_aplicacion.Enabled = false;
                btn_guardar.Enabled = true;
                boton_eliminar = true;
                btn_guardar.Enabled = false;
                txt_buscar.Enabled = false;
                txt_idaplicacion.Text = "";
                limpiar();
            }

            
        }
    }
}

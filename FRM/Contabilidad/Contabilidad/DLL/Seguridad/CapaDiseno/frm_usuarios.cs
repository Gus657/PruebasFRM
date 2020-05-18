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

/*---------------------------Creador: Diego Gomez------------------------------*/
namespace CapaDiseno
{
    public partial class frm_usuarios : Form
    {
        logica logica1;
        
        bool boton_ingreso = false;
        bool boton_eliminar = false;
        bool boton_modificar = false;

        public frm_usuarios(string idUsuario)
        {
            InitializeComponent();
            logica1 = new logica(idUsuario);
        }

        public frm_usuarios()
        {
        }

        private void Dgv_asignaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        string buscar;


        void limpiar()
        {
            txt_nombre.Text = "";
            txt_buscar.Text = "";
            txt_clave.Text = "";
            txt_apellido.Text = "";
            txt_id.Text = "";
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {


            buscar = txt_buscar.Text.Trim();

            /*   if (boton_eliminar == true)
              {

                  txt_clave.Enabled = false;
                  txt_id.Enabled = false;
                  txt_nombre.Enabled = false;
                  txt_apellido.Enabled = false;
                  Gpb_estado.Enabled = false;
                    groupBox1.Enabled = false;
                groupBox2.Enabled = false;
            }
              else
              {
                  txt_clave.Enabled = false;
                  txt_id.Enabled = false;
                  txt_nombre.Enabled = true;
                  txt_apellido.Enabled = true;
                  //Gpb_estado.Enabled = false;
                    groupBox1.Enabled = false;
            }*/




            try
            {
                DataTable dtusuario = logica1.buscar(buscar);

                if (dtusuario.ToString() == null)
                {
                    MessageBox.Show("No existe");

                }
                else
                {
                    foreach (DataRow dt in dtusuario.Rows)
                    {

                        txt_id.Text = (dt[0].ToString());
                        txt_nombre.Text = (dt[1].ToString());
                        txt_apellido.Text = (dt[2].ToString());
                        txt_clave.Text = (dt[3].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }


            
           /* txt_clave.Enabled = true;
            txt_id.Enabled = true;
            txt_nombre.Enabled = true;
            txt_apellido.Enabled = true;
            Gpb_estado.Enabled = true;
            txt_buscar.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            boton_ingreso = true;*/
        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Frm_usuarios_Load(object sender, EventArgs e)
        {
            txt_buscar.Enabled = false;
            button1.Enabled = false;
            txt_nombre.Enabled = false;
            txt_clave.Enabled = false;
            txt_apellido.Enabled = false;
            Gpb_estado.Enabled = false;
            txt_nombre.Enabled = false;
            txt_id.Enabled = false;
        }



        private void Button2_Click(object sender, EventArgs e)
        {
            id = txt_id.Text;
            nombre = txt_apellido.Text;
            apellido = txt_nombre.Text;
            clave = txt_clave.Text;

            txt_clave.Enabled = false;
            txt_id.Enabled = false;
            txt_apellido.Enabled = false;
            txt_nombre.Enabled = false;
            Gpb_estado.Enabled = false;
            txt_buscar.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = true;
            boton_eliminar = true;

            try
            {
                DataTable dtusuario = logica1.eliminar(id, nombre, apellido, clave);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            limpiar();

        }

        private void Button3_Click(object sender, EventArgs e)
        {

            boton_modificar = true;
            txt_clave.Enabled = false;
            txt_id.Enabled = false;
            txt_apellido.Enabled = true;
            txt_nombre.Enabled = true;
            Gpb_estado.Enabled = true;
            txt_buscar.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            Rdb_activo.Checked = true;

           
        }
        public string id, nombre, apellido, clave;

        private void Btn_ayuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "C:\\Ayuda_Seguridad\\" + "CreacionUsuario.chm", "Creacion_Usuario.html");
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.CampoAlfanumerico(e);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            
            txt_clave.Enabled = true;
            txt_id.Enabled = true;
            txt_apellido.Enabled = true;
            txt_nombre.Enabled = true;
            Gpb_estado.Enabled = true;
            txt_buscar.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            boton_ingreso = true;
            Gpb_estado.Enabled = false;
            Rdb_activo.Checked = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            id = txt_id.Text;
            nombre = txt_nombre.Text;
            apellido = txt_apellido.Text;
            clave = txt_clave.Text;

            int boton;

            if (txt_id.Text == " " || txt_nombre.Text == "" || txt_apellido.Text == "" || txt_clave.Text == "")
            {
                MessageBox.Show("Faltan Campos Por Llenar", "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(clave.Length<8)
            {
                MessageBox.Show("La contraseña debe de contener 8 caracteres como minimo","Verificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (boton_ingreso == true)
                {
                    boton = 1;

                    try
                    {
                        DataTable dtusuario = logica1.usuarios(id, nombre, apellido, clave, boton);
                        MessageBox.Show("Usuario Creado");

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex);
                        return;
                    }
                }

                else if (boton_modificar == true)
                {

                    string estado = "";
                    if (Rdb_activo.Checked)
                    {
                        estado = "1";


                    }

                    if (Rdb_inactivo.Checked)
                    {
                        estado = "0";
                    }

                    try
                    {

                        DataTable dtUsuarioActualizar = logica1.ActualizarUsuario(id, nombre, apellido, clave, estado);
                        MessageBox.Show("Usuario Actualizado");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex);
                        return;
                    }
                }



                limpiar();
                txt_clave.Enabled = true;
                txt_id.Enabled = true;
                txt_apellido.Enabled = true;
                txt_nombre.Enabled = true;
                Gpb_estado.Enabled = true;
                txt_buscar.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }

            
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

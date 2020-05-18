using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaLogica;

namespace CapaDiseno
{
    public partial class frm_login : Form
    {
        public string bExito = "Pendiente";

        public frm_login()
        {
            InitializeComponent();
            Txt_clave.UseSystemPasswordChar = true;
        }

        string nombreUsuario = "";
        public string obtenerNombreUsuario()
        {
            nombreUsuario = Txt_usuario.Text;
            return nombreUsuario;
        }

        private void Btn_entrar_Click(object sender, EventArgs e)
        {
            ProcedimientoLogin procedimientoLogin = new ProcedimientoLogin();

            if (Txt_usuario.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un usuario");
            }
            else
            {
                if (Txt_clave.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar su contraseña");
                }
                else
                {
                    try
                    {
                        bool bExisteUsuario = procedimientoLogin.llamarProcedimiento(Txt_usuario.Text, Txt_clave.Text);

                        if (bExisteUsuario)
                        {
                            this.Close();
                            sentencia s = new sentencia();
                            s.insertarBitacora(Txt_usuario.Text.Trim(), "Se logeo al sistema", "Login");

                        }
                        else
                        {
                            MessageBox.Show("Usuario o Contraseña Incorrecta", "Verificacion de Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        MessageBox.Show("No Conecto La Base de Datos", "Verificar Conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Cb_ver_password_CheckedChanged(object sender, EventArgs e)
        {
            if (Cb_ver_password.Checked == false)
            {
                Txt_clave.UseSystemPasswordChar = true;
            }
            else
            {
                Txt_clave.UseSystemPasswordChar = false;
            }
        }


        private void Frm_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Btn_ayuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "C:\\Ayuda_Seguridad\\" + "ayudaLogin.chm", "login.html");

        }
    }
}

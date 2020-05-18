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


/*--------------------------------------Creador: Allan Letona----------------------------------------------------------------*/
namespace CapaDiseno
{
    public partial class frm_asignacion_perfiles : Form
    {
        logica logic;
        public frm_asignacion_perfiles(string idUsuario)
        {
            InitializeComponent();
            logic = new logica(idUsuario);
        }

        public frm_asignacion_perfiles()
        {
        }

        private void Frm_asignacion_perfiles_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtUsuario = logic.consultaLogicaUsuarios();

                foreach (DataRow row in dtUsuario.Rows)
                {
                    cbo_usuarios.Items.Add(row[0].ToString());
                    cbo_usuario.Items.Add(row[0].ToString());
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                DataTable dtPerfiles = logic.consultaLogicaPerfiles();

                foreach(DataRow row in dtPerfiles.Rows)
                {
                    cbo_perfiles.Items.Add(row[0].ToString());
                }
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Dgv_perfiles_asignados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Cbo_usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreUsuario = cbo_usuarios.SelectedItem.ToString();

            DataTable dtPerfilesUsuarios = logic.consultaLogicaPerfilesUsuarios(nombreUsuario);
            dgv_perfiles_asignados.DataSource = dtPerfilesUsuarios;
        }

        void limpieza()
        {
            cbo_usuario.Text = " ";
            cbo_perfiles.Text = " ";
        }

        public static int iContadorFila = 0;

        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            if (cbo_usuario.SelectedItem == null || cbo_perfiles.SelectedItem == null)
            {
                MessageBox.Show("Faltan Datos Por Seleccionar", "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                bool bUsuario_perfil_existente = false;

                string sUsuario = cbo_usuario.SelectedItem.ToString();
                string sPerfil = cbo_perfiles.SelectedItem.ToString();

                if (iContadorFila == 0)
                {
                    dgv_asignacion_perfiles.Rows.Add(sUsuario, sPerfil);

                    iContadorFila++;

                }
                else
                {
                    foreach (DataGridViewRow Fila in dgv_asignacion_perfiles.Rows)
                    {
                        if (Fila.Cells[0].Value.ToString() == cbo_usuario.SelectedItem.ToString() && Fila.Cells[1].Value.ToString() == cbo_perfiles.SelectedItem.ToString())
                        {
                            bUsuario_perfil_existente = true;
                        }
                    }

                    if (bUsuario_perfil_existente == true)
                    {
                        MessageBox.Show("Ya existe una relacion del usuario con el perfil");
                    }
                    else
                    {
                        dgv_asignacion_perfiles.Rows.Add(sUsuario, sPerfil);
                        iContadorFila++;
                    }
                }

                limpieza();
            }
        }

        private void Cbo_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_remover_Click(object sender, EventArgs e)
        {

            try
            {
                string sNombreUsuario = cbo_usuarios.SelectedItem.ToString();
                string sMensaje = "Desea eliminar el perfil al usuario: " + sNombreUsuario;
                string sCaption = "Verificacion";
                MessageBoxButtons botones = MessageBoxButtons.YesNo;
                DialogResult respuesta;

                respuesta = MessageBox.Show(sMensaje, sCaption, botones, MessageBoxIcon.Question);

                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    string sCodigoPerfil = dgv_perfiles_asignados.CurrentRow.Cells[0].Value.ToString();

                    DataTable dtEliminacion = logic.consultaLogicaEliminarPerfilUsuario(sNombreUsuario, sCodigoPerfil);

                    dgv_perfiles_asignados.Rows.RemoveAt(dgv_perfiles_asignados.CurrentRow.Index);
                    iContadorFila--;
                }
                else
                {
                    //this.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("No hay datos que eliminar");
            }
                
        }

        private void Btn_quitar_Click(object sender, EventArgs e)
        {
            if (iContadorFila > 0)
            {
                dgv_asignacion_perfiles.Rows.RemoveAt(dgv_asignacion_perfiles.CurrentRow.Index);
                iContadorFila--;
            }
            else
            {
                MessageBox.Show("No hay relaciones que eliminar");
            }
        }

        private void Btn_finalizar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(DataGridViewRow Fila in dgv_asignacion_perfiles.Rows)
                {
                    string sNombreUsuario = Fila.Cells[0].Value.ToString();
                    string sNombrePerfil = Fila.Cells[1].Value.ToString();
                    
                    DataTable dtInsertarPerfilUsuario = logic.consultaLogicaInsertarPerfilUsuario(sNombreUsuario, sNombrePerfil);

                }

                MessageBox.Show("Datos Ingresados Exitosamente");
                limpieza();
                dgv_asignacion_perfiles.Rows.Clear();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        private void Btn_ayuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "C:\\Ayuda_Seguridad\\" + "ayudaAsignacionPerfiles.chm", "Asignacion_Perfil_Usuarios.html");
        }
    }
}

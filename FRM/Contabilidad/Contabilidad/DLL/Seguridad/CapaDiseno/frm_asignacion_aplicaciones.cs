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


/*---------------------------Creador: Allan Letona------------------------------*/

namespace CapaDiseno
{
    public partial class frm_asignacion_aplicaciones : Form
    {
        logica logic;
        

        public frm_asignacion_aplicaciones(string idUsuario)
        {
            InitializeComponent();
            logic = new logica(idUsuario);
        }

        public frm_asignacion_aplicaciones()
        {
        }

        private void Frm_asignacion_aplicaciones_Load(object sender, EventArgs e)
        {
            
            try
            {
                DataTable dtUsuario = logic.consultaLogicaUsuarios();

                foreach (DataRow row in dtUsuario.Rows)
                {
                    cbo_usuarios.Items.Add(row[0].ToString());
                }
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                DataTable dtModulos = logic.consultaLogicaModulos();

                foreach(DataRow row in dtModulos.Rows)
                {
                    cbo_modulos.Items.Add(row[0].ToString());
                }
            }catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        void limpieza()
        {
            cbo_usuarios.Text = " ";
            cbo_modulos.Text = " ";
            cbo_aplicaciones.Text = " ";
        }

        
        private void Cbo_modulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_aplicaciones.DataSource = null;
            cbo_aplicaciones.Items.Clear();
            cbo_aplicaciones.Text = " ";

            string sNombreModulo = cbo_modulos.SelectedItem.ToString();

            try
            {
                DataTable dtAplicaciones = logic.consultaLogicaAplicaciones(sNombreModulo);

                foreach(DataRow row in dtAplicaciones.Rows)
                {
                    cbo_aplicaciones.Items.Add(row[0].ToString());
                }
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static int iContadorFila = 0;
        private void Btn_agregar_Click(object sender, EventArgs e)
        {

            if(cbo_usuarios.SelectedItem==null || cbo_aplicaciones.SelectedItem==null)
            {
                MessageBox.Show("Faltan Datos Por Seleccionar", "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                bool bUsuario_aplicacion_existente = false;
       
                string sUsuario = cbo_usuarios.SelectedItem.ToString();
                string sAplicacion = cbo_aplicaciones.SelectedItem.ToString();

                if(iContadorFila == 0)
                {
                    dgv_asignaciones.Rows.Add(sUsuario, sAplicacion);

                    iContadorFila++;

                   
                }
                else
                {
                    foreach(DataGridViewRow Fila in dgv_asignaciones.Rows)
                    {
                        if(Fila.Cells[0].Value.ToString() == cbo_usuarios.SelectedItem.ToString() && Fila.Cells[1].Value.ToString() == cbo_aplicaciones.SelectedItem.ToString())
                        {
                            bUsuario_aplicacion_existente = true;
                        }
                    }

                    if(bUsuario_aplicacion_existente == true)
                    {
                        MessageBox.Show("Ya existe una relacion del usuario con la aplicacion");
                    }
                    else
                    {
                        dgv_asignaciones.Rows.Add(sUsuario, sAplicacion);
                        iContadorFila++;
                    }
                }

                limpieza();
            }

        }

        private void Btn_remover_Click(object sender, EventArgs e)
        {
            if (iContadorFila > 0)
            {
                dgv_asignaciones.Rows.RemoveAt(dgv_asignaciones.CurrentRow.Index);
                iContadorFila--;
            }
            else
            {
                MessageBox.Show("No hay relaciones que eliminar");
            }
        }

        private void Btn_finalizar_Click(object sender, EventArgs e)
        {

            string sIngresar;
            string sConsulta;
            string sModificar;
            string sEliminar;
            string sImprimir;
            try
            {
                foreach(DataGridViewRow Fila in dgv_asignaciones.Rows)
                {
                        
                    string sUsuario = Fila.Cells[0].Value.ToString();
                    string sAplicacion = Fila.Cells[1].Value.ToString();


                    bool cheked = ((bool)(Fila.Cells["Ingresar"].EditedFormattedValue));
                    if (cheked)
                        sIngresar = "1";
                    else
                        sIngresar = "0";

                    bool chekedC = ((bool)(Fila.Cells["Consultar"].EditedFormattedValue));
                    if (chekedC)
                        sConsulta = "1";
                    else
                        sConsulta = "0";

                    bool chekedM = ((bool)(Fila.Cells["Modificar"].EditedFormattedValue));
                    if (chekedM)
                        sModificar = "1";
                    else
                        sModificar = "0";

                    bool chekedE = ((bool)(Fila.Cells["Eliminar"].EditedFormattedValue));
                    if (chekedE)
                        sEliminar = "1";
                    else
                        sEliminar = "0";

                    bool chekedI = ((bool)(Fila.Cells["Imprimir"].EditedFormattedValue));
                    if (chekedI)
                        sImprimir = "1";
                    else
                        sImprimir = "0";

                    DataTable dtAplicaciones = logic.consultaLogicaPermisosUsuarioAplicacion(sUsuario, sAplicacion, sIngresar, sConsulta, sModificar, sEliminar, sImprimir);
     
                }

                MessageBox.Show("Datos ingresados exitosamente");
                limpieza();
                dgv_asignaciones.Rows.Clear();
                iContadorFila = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Dgv_asignaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
           
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void Btn_ayuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "C:\\Ayuda_Seguridad\\" + "AyudaAsignacionAplicacionesUsuarios.chm", "Asignacion_Aplicaciones_Usuarios.html");
        }
    }
}

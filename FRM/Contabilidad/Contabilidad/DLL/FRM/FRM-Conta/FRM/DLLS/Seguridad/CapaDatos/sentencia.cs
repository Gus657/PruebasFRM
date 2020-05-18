using System;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Net;
using System.Data;

namespace CapaDatos
{
    public class sentencia
    {

        /*-----------------------------------------------------------Creador: Allan Letona---------------------------------------------------------------------------*/
        conexion cn = new conexion();
        private string idUsuario;

        public sentencia(string idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        public sentencia()
        {

        }

        public OdbcDataAdapter consultarUsuarios()
        {
            cn.conectar();
            string sqlUsuarios = "SELECT PK_id_usuario FROM tbl_usuario WHERE estado_usuario = 1";
            OdbcDataAdapter dataUsuarios = new OdbcDataAdapter(sqlUsuarios, cn.conectar());
            insertarBitacora(idUsuario, "Realizo una consulta a usuarios", "tbl_usuario");
            return dataUsuarios;

        }

        public OdbcDataAdapter consultarModulos()
        {
            cn.conectar();
            string sqlModulos = "SELECT nombre_modulo FROM tbl_modulo WHERE estado_modulo = 1";
            OdbcDataAdapter dataModulos = new OdbcDataAdapter(sqlModulos, cn.conectar());
            insertarBitacora(idUsuario, "Realizo una consulta a modulos", "tbl_modulos");
            return dataModulos;
        }

        public OdbcDataAdapter consultarPerfiles()
        {
            cn.conectar();
            string sqlPerfiles = "SELECT nombre_perfil FROM tbl_perfil_encabezado WHERE estado_perfil = 1";
            OdbcDataAdapter dataPerfiles = new OdbcDataAdapter(sqlPerfiles, cn.conectar());
            insertarBitacora(idUsuario, "Realizo una consulta a perfiles", "tbl_perfil");
            return dataPerfiles;
        }

        public OdbcDataAdapter consultarAplicaciones(string nombreModulo)
        {
            string sCodigoModulo = " ";
            try
            {
                OdbcCommand sqlCodigoModulo = new OdbcCommand("SELECT PK_id_Modulo FROM tbl_modulo WHERE nombre_modulo = '" + nombreModulo + "' ", cn.conectar());
                OdbcDataReader almacena = sqlCodigoModulo.ExecuteReader();

                while (almacena.Read() == true)
                {
                    sCodigoModulo = almacena.GetString(0);
                }

                string sqlAplicaciones = "SELECT nombre_aplicacion FROM tbl_aplicacion WHERE PK_id_Modulo = '"+sCodigoModulo+"' ";
                OdbcDataAdapter dataAplicaciones = new OdbcDataAdapter(sqlAplicaciones, cn.conectar());

                almacena.Close();
                sqlCodigoModulo.Connection.Close();
                insertarBitacora(idUsuario, "Realizo una consulta a aplicaciones", "tbl_aplicacion");
                return dataAplicaciones;

               

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public OdbcDataAdapter insertarPermisosUA(string codigoUsuario, string nombreAplicacion, string ingresar, string consulta, string modificar, string eliminar, string imprimir)
        {
            string sCodigoAplicacion = " ";

            try
            {
                OdbcCommand sqlCodigoModulo = new OdbcCommand("SELECT PK_id_aplicacion FROM tbl_aplicacion WHERE nombre_aplicacion = '" + nombreAplicacion + "' ", cn.conectar());
                OdbcDataReader almacena = sqlCodigoModulo.ExecuteReader();

                while (almacena.Read() == true)
                {
                    sCodigoAplicacion = almacena.GetString(0);
                }

                string sqlInsertarPermisosUA = "INSERT INTO tbl_usuario_aplicacion(PK_id_usuario, PK_id_aplicacion, ingresar, consulta, modificar, eliminar, imprimir) VALUES ('"+codigoUsuario+"', '"+sCodigoAplicacion+"', '"+ingresar+"', '"+consulta+"', '"+modificar+"', '"+eliminar+"', '"+imprimir+"');";
                insertarBitacora(idUsuario, "Asigno aplicacion: " + nombreAplicacion+ " a usuario: "  + codigoUsuario, "tbl_usuario_aplicacion");
                OdbcDataAdapter dataPermisosUA = new OdbcDataAdapter(sqlInsertarPermisosUA, cn.conectar());


                almacena.Close();
                sqlCodigoModulo.Connection.Close();

                return dataPermisosUA;

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        public OdbcDataAdapter mostrarPerfilesDeUsuario(string nombreUsuario)
        {
            try
            {
                string sqlPerfilUsuario = "SELECT PE.PK_id_perfil AS Codigo, PE.nombre_perfil AS Perfil FROM tbl_perfil_encabezado PE INNER JOIN tbl_usuario_perfil UP ON PE.PK_id_perfil = UP.PK_id_perfil WHERE PK_id_usuario = '" + nombreUsuario + "' ";
                OdbcDataAdapter dataPerfilUsuario = new OdbcDataAdapter(sqlPerfilUsuario, cn.conectar());
                insertarBitacora(idUsuario, "Realizo una consulta a perfiles", "tbl_perfil");
                return dataPerfilUsuario;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public OdbcDataAdapter eliminarPerfilUsuario(string nombreUsuario, string codigoPerfil)
        {
            try
            {
                string sqlEliminarPerfilUsuario = "DELETE FROM tbl_usuario_perfil WHERE PK_id_usuario = '" + nombreUsuario + "' AND PK_id_perfil = '" + codigoPerfil + "' ";
                OdbcDataAdapter dataEliminarPerfilUsuario = new OdbcDataAdapter(sqlEliminarPerfilUsuario, cn.conectar());
                insertarBitacora(idUsuario, "Elimino perfil: " + codigoPerfil + " a usuario: " + nombreUsuario, "tbl_usuario_perfil");
                return dataEliminarPerfilUsuario;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public OdbcDataAdapter insertarPerfilUsuario(string nombreUsuario, string codigoPerfil)
        {
            try
            {
                string sCodigoPerfil = " ";

                OdbcCommand sqlCodigoModulo = new OdbcCommand("SELECT PK_id_perfil FROM tbl_perfil_encabezado WHERE nombre_perfil = '" + codigoPerfil + "' ", cn.conectar());
                OdbcDataReader almacena = sqlCodigoModulo.ExecuteReader();

                while (almacena.Read() == true)
                {
                    sCodigoPerfil = almacena.GetString(0);
                }


                string sqlInsertarPerfilUsuario = "INSERT INTO tbl_usuario_perfil(PK_id_usuario, PK_id_perfil) VALUES ('" + nombreUsuario + "', '" + sCodigoPerfil + "') ";
                OdbcDataAdapter dataInsertarPerfilUsuario = new OdbcDataAdapter(sqlInsertarPerfilUsuario, cn.conectar());
                insertarBitacora(idUsuario, "Asigno perfil: " + codigoPerfil + " a usuario: " + nombreUsuario, "tbl_usuario_perfil");
                return dataInsertarPerfilUsuario;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public OdbcDataAdapter validarIDAplicacion()
        {
            try
            {
                
                 string sqlIDAplicacion = "SELECT MAX(PK_id_aplicacion)+1 FROM tbl_aplicacion";
                 OdbcDataAdapter dataIDAplicacion = new OdbcDataAdapter(sqlIDAplicacion, cn.conectar());
                 return dataIDAplicacion;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }


        public OdbcDataAdapter ActualizarUsuario(string idUsuario, string nombreUsuario, string apellidoUsuario,string clave, string estado)
        {
            try
            {
                cn.conectar();
                string sqlactualizarUsuario = "UPDATE tbl_usuario SET nombre_usuario = '" + nombreUsuario + "', apellido_usuarios = '" + apellidoUsuario + "', estado_usuario = '" + estado + "' WHERE PK_id_usuario ='" + idUsuario + "'";
                OdbcDataAdapter dataTable = new OdbcDataAdapter(sqlactualizarUsuario, cn.conectar());
                insertarBitacora(idUsuario, "Actualizo un usuario: " + idUsuario + " - " + nombreUsuario, "tbl_usuario");
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }


        /*-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        /*---------------------------------------------------------------Creador: Diego Gomez-----------------------------------------------------------------------------*/

        public OdbcDataAdapter insertarusuario(string id, string nombre, string apellido, string clave, int boton)
        {
            cn.conectar();

              string sqlusuarios = "INSERT into tbl_usuario (PK_id_usuario,nombre_usuario,apellido_usuarios,password_usuario,estado_usuario) " +
              "VALUES ('" + id + "','" + nombre + "','" + apellido + "','" + clave + "', '1')";
               OdbcDataAdapter datausuarios = new OdbcDataAdapter(sqlusuarios, cn.conectar());
              return datausuarios;


        }

        public OdbcDataAdapter insertarclaves(string id, string nombre, string apellido, string clave)
        {
            cn.conectar();
            MessageBox.Show("Contraseña Actualizada");
            string sqlconsulta = "UPDATE tbl_usuario set PK_id_usuario='" + id + "',nombre_usuario='" + apellido + "',apellido_usuarios='" + nombre + "',password_usuario='" + clave + "',estado_usuario='1' where PK_id_usuario='" + id + "'";
            OdbcDataAdapter dataconsulta = new OdbcDataAdapter(sqlconsulta, cn.conectar());
            return dataconsulta;
        }

        public OdbcDataAdapter update(string usuario)
        {
            cn.conectar();
            string sqlconsulta = "select PK_id_perfil FROM tbl_usuario_perfil where PK_id_usuario = '"+usuario+"'";
            OdbcDataAdapter dataconsulta = new OdbcDataAdapter(sqlconsulta, cn.conectar());
            return dataconsulta;
           
        }


        public OdbcDataAdapter clienteupdate(string clave,string usuario)
        {
            cn.conectar();
            MessageBox.Show("Contraseña Actualizada");
            string sqlconsulta = "UPDATE tbl_usuario set password_usuario='" + clave + "' where PK_id_usuario='" + usuario + "'";
            OdbcDataAdapter dataconsulta = new OdbcDataAdapter(sqlconsulta, cn.conectar());
            return dataconsulta;
        }


        public OdbcDataAdapter insertaraplicacion(string idaplicacion, string modulo, string descripcion, string aplicacion, int boton)
        {
            cn.conectar();
            if (boton == 1)
            {
                MessageBox.Show("Aplicacion Creada");
                string sCodigoModulo = "";
                OdbcCommand sqlCodigoModulo = new OdbcCommand("SELECT PK_id_Modulo FROM tbl_modulo WHERE nombre_modulo = '" + modulo + "' ", cn.conectar());
                OdbcDataReader almacena = sqlCodigoModulo.ExecuteReader();

                while (almacena.Read() == true)
                {
                    sCodigoModulo = almacena.GetString(0);
                }

                string sqlusuarios = "insert into tbl_aplicacion (PK_id_aplicacion,PK_id_modulo,nombre_aplicacion,descripcion_aplicacion,estado_aplicacion) " +
                    "values ('" + idaplicacion + "','" + sCodigoModulo + "','" + aplicacion + "','" + descripcion + "','1')";
                OdbcDataAdapter datausuarios = new OdbcDataAdapter(sqlusuarios, cn.conectar());
                boton = 0;
                return datausuarios;

            }
            else
            {
                MessageBox.Show("Aplicacion Actualizada");
                string sqlconsulta = "update tbl_aplicacion set " +
                    "PK_id_aplicacion = '" + idaplicacion + "', PK_id_modulo='" + modulo + "', " +
                    "nombre_aplicacion='" + aplicacion + "',descripcion_aplicacion='" + descripcion + "',estado_aplicacion='1' WHERE PK_id_aplicacion ='" + idaplicacion + "'";
                OdbcDataAdapter dataconsulta = new OdbcDataAdapter(sqlconsulta, cn.conectar());
                return dataconsulta;
            }

        }

        public OdbcDataAdapter eliminarusuario(string id, string nombre, string apellido, string clave)
        {

            MessageBox.Show("Usuario ELiminado");
            string sqleliminar = "UPDATE tbl_usuario set PK_id_usuario='" + id + "',nombre_usuario='" + apellido + "',apellido_usuarios='" + nombre + "',password_usuario='" + clave + "',estado_usuario='0' where PK_id_usuario='" + id + "'";
            OdbcDataAdapter dataeliminar = new OdbcDataAdapter(sqleliminar, cn.conectar());
            return dataeliminar;

        }

        public OdbcDataAdapter eliminaraplicacion(string idaplicacion, string modulo, string descripcion, string aplicacion)
        {
            
            string sqleliminar = "update tbl_aplicacion set PK_id_aplicacion='" + idaplicacion + "',PK_id_modulo='" + modulo + "',nombre_aplicacion='" + aplicacion + "',descripcion_aplicacion='" + descripcion + "',estado_aplicacion='0' WHERE PK_id_aplicacion='" + idaplicacion + "'";
            OdbcDataAdapter dataeliminar = new OdbcDataAdapter(sqleliminar, cn.conectar());
            return dataeliminar;

        }

        public OdbcDataAdapter mostrar(string id)
        {

            cn.conectar();
            string sqlusuarios = "SELECT PK_id_usuario, nombre_usuario, apellido_usuarios, password_usuario FROM tbl_usuario where PK_id_usuario = '" + id + "'";
            OdbcDataAdapter datausuarios = new OdbcDataAdapter(sqlusuarios, cn.conectar());

            if (datausuarios == null)
            {
                return null;
            }
            else
                return datausuarios;
        }
        public OdbcDataAdapter mostraraplicacion(string id)
        {

            cn.conectar();
            string sqlusuarios = "SELECT PK_id_aplicacion,PK_id_modulo,nombre_aplicacion,descripcion_aplicacion from tbl_aplicacion WHERE PK_id_aplicacion ='" + id + "'";
            OdbcDataAdapter datausuarios = new OdbcDataAdapter(sqlusuarios, cn.conectar());

            if (datausuarios == null)
            {
                return null;
            }
            else
                return datausuarios;
        }

        public OdbcDataAdapter consultaraplicaciones()
        {
            cn.conectar();
            string sqlUsuarios = "select PK_id_Modulo FROM tbl_modulo WHERE estado_modulo ='1'";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sqlUsuarios, cn.conectar());
            return dataTable;


        }

        /*-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/


        //########################### EDICION: ALEJANDRO BARREDA MENDOZA #####################################################

        public OdbcDataAdapter validarIDModulos()
        {
            try
            {

                string sqlIDmodulo = "SELECT MAX(PK_id_Modulo)+1 FROM tbl_modulo";
                OdbcDataAdapter dataIDmodulo = new OdbcDataAdapter(sqlIDmodulo, cn.conectar());
                return dataIDmodulo;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public OdbcDataAdapter validarIDperfiles()
        {
            try
            {

                string sqlIDperfil = "SELECT MAX(PK_id_perfil)+1 FROM tbl_perfil_encabezado";
                OdbcDataAdapter dataIDperfil = new OdbcDataAdapter(sqlIDperfil, cn.conectar());
                return dataIDperfil;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }




        public OdbcDataAdapter insertarPerfil(string codigo, string nombre, string descripcion, string estado)
        {
            cn.conectar();
            try
            {
                string sqlPerfil = "INSERT INTO tbl_perfil_encabezado (PK_id_Perfil, nombre_perfil,descripcion_perfil,estado_perfil) VALUES ('" + codigo + "','" + nombre + "', '" + descripcion + "', " + estado + ");";
                OdbcDataAdapter datainsertarperfil = new OdbcDataAdapter(sqlPerfil, cn.conectar());
                insertarBitacora(idUsuario, "Inserto un nuevo perfil: "  + codigo + " - " + nombre , "tbl_perfil");
                return datainsertarperfil;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public OdbcDataAdapter ConsultarPerfil(string perfil)
        {
            cn.conectar();
            string sqlPerfil = "SELECT * FROM tbl_perfil_encabezado WHERE PK_Id_perfil = " + perfil;
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sqlPerfil, cn.conectar());
            insertarBitacora(idUsuario, "Realizo una consulta a perfiles ", "tbl_perfil");

            return dataTable;
        }

        public OdbcDataAdapter ActualizarPerfil(string ID_perfil, string nombre, string descripcion, string estado)
        {
            try
            {
                cn.conectar();
                string sqlactualizarperfil = "UPDATE tbl_perfil_encabezado SET nombre_perfil = '" + nombre + "', descripcion_perfil = '" + descripcion + "', estado_perfil = '" + estado + "' WHERE PK_id_perfil ='" + ID_perfil + "'";
                OdbcDataAdapter dataTable = new OdbcDataAdapter(sqlactualizarperfil, cn.conectar());
                insertarBitacora(idUsuario, "Actualizo un perfil: " + ID_perfil + " - " + nombre, "tbl_perfil");

                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }


        public OdbcDataAdapter insertarModulo(string codigo, string nombre, string descripcion, string estado)
        {
            cn.conectar();
            try
            {
                string sqlModulos = "INSERT INTO tbl_modulo (PK_id_Modulo, nombre_modulo,descripcion_modulo,estado_modulo) VALUES ('" + codigo + "','" + nombre + "', '" + descripcion + "', " + estado + ");";
                OdbcDataAdapter datainsertarmodulo = new OdbcDataAdapter(sqlModulos, cn.conectar());
                insertarBitacora(idUsuario, "Inserto un nuevo modulo: " + codigo + " - " + nombre , "tbl_modulo");
                return datainsertarmodulo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            }


        //------------

        public OdbcDataAdapter insertarPermisosPerfilA(string codigoPerfil, string nombreAplicacion, string ingresar, string consulta, string modificar, string eliminar, string imprimir)
        {
            string sCodigoAplicacion = " ";
            string sCodigoPerfil = "";

            try
            {
                OdbcCommand sqlCodigoModulo = new OdbcCommand("SELECT PK_id_aplicacion FROM tbl_aplicacion WHERE nombre_aplicacion = '" + nombreAplicacion + "' ", cn.conectar());
                OdbcDataReader almacena = sqlCodigoModulo.ExecuteReader();

                while (almacena.Read() == true)
                {
                    sCodigoAplicacion = almacena.GetString(0);
                }

                OdbcCommand sqlCodigoPerfil = new OdbcCommand("SELECT PK_id_perfil FROM tbl_perfil_encabezado WHERE nombre_perfil = '" + codigoPerfil + "' ", cn.conectar());
                OdbcDataReader almacenaPerfil = sqlCodigoPerfil.ExecuteReader();

                while (almacenaPerfil.Read() == true)
                {
                    sCodigoPerfil = almacenaPerfil.GetString(0);
                }

                string sqlInsertarPermisosPerfilApp = "INSERT INTO tbl_perfil_detalle(PK_id_perfil, PK_id_aplicacion, ingresar, consultar, modificar, eliminar, imprimir) VALUES ('" + sCodigoPerfil + "', '" + sCodigoAplicacion + "', '" + ingresar + "', '" + consulta + "', '" + modificar + "', '" + eliminar + "', '" + imprimir + "');";
                OdbcDataAdapter dataPermisosPerfilAplicacion = new OdbcDataAdapter(sqlInsertarPermisosPerfilApp, cn.conectar());
                insertarBitacora(idUsuario, "Asigno permiso: " + nombreAplicacion + " a perfil: " + codigoPerfil, "tbl_usuario_aplicacion");


                almacena.Close();
                sqlCodigoModulo.Connection.Close();

                return dataPermisosPerfilAplicacion;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }


        //------------Para formulario Mantenimiento Modulos---------

        public OdbcDataAdapter ConsultarModulos(string modulo)
        {
            cn.conectar();
            string sqlModulos = "SELECT * FROM tbl_modulo WHERE PK_Id_Modulo = " + modulo ;
            insertarBitacora(idUsuario, "Realizo una consulta a modulos", "tbl_modulos");
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sqlModulos, cn.conectar());
            return dataTable;
        }


        public OdbcDataAdapter ActualizarModulo(string ID_modulo, string nombre, string descripcion, string estado)
        {
            Console.WriteLine("ESTO SE INGRESA EN LA SENTENCIA: " + ID_modulo + ", " + nombre + ", " + descripcion + ", " + estado);
            try
            {
                cn.conectar();
                string sqlactualizarmodulo = "UPDATE tbl_modulo SET nombre_modulo = '" + nombre + "', descripcion_modulo = '" + descripcion + "', estado_modulo = '" + estado+"' WHERE PK_id_Modulo ='" + ID_modulo+"'";
                OdbcDataAdapter dataTable = new OdbcDataAdapter(sqlactualizarmodulo, cn.conectar());
                insertarBitacora(idUsuario, "Actualizo un modulo: " + ID_modulo + " - " + nombre, "tbl_modulos");
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            }
        // ########### FIN EDICION POR ALEJANDRO BARREDA ##########################################



        //Eduardo Colon

        public DataSet consultarBitacora()
        {
            OdbcDataAdapter dat = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                dat = new OdbcDataAdapter("SELECT PK_id_bitacora as Id, PK_id_usuario as Usuario, fecha, hora, host, ip, accion, tabla from tbl_bitacora"
                , cn.conectar());
                dat.Fill(ds);
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }

            return ds;
        }

        public void insertarBitacora(string idUsuario, string accion, string tabla)
        {
            try
            {

                IPHostEntry hostEntry;
                string localIP = "";
                hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in hostEntry.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                    }
                }

                string host = Dns.GetHostName();
                IPAddress[] IP = Dns.GetHostAddresses(host);
                OdbcCommand cmd;
                cmd = new OdbcCommand("INSERT INTO tbl_bitacora (" +
                      "PK_id_usuario , " +
                      " fecha , " +
                      " hora , " +
                      " host , " +
                      " ip, " +
                      " accion ," +
                      " tabla ) " +
                      "VALUES ('" +
                      idUsuario +
                       "' , '" + DateTime.Now.ToString("yyy/MM/dd") +
                       "' , '" + DateTime.Now.ToString("hh:mm:ss") +
                       "' , '" + host +
                       "' , '" + localIP +
                       "' , '" + accion +
                       "' , '" + tabla +
                       "') "
                      , cn.conectar());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        public bool consultarPermisos(string idUsuario, string idAplicacion, int tipoPermiso)
        {

            try
            {
                switch (tipoPermiso)
                {
                    case 1:

                        OdbcCommand sql = new OdbcCommand("Select ingresar from tbl_usuario_aplicacion WHERE PK_id_usuario= '" + idUsuario + "' AND PK_id_aplicacion ='" + idAplicacion + "'", cn.conectar());
                        OdbcDataReader almacena = sql.ExecuteReader();

                        if(almacena.Read() == true)
                        {
                            if (almacena.GetString(0) == "1")
                            {
                                almacena.Close();
                                sql.Connection.Close();
                                return true;
                            }
                        }

                        sql = new OdbcCommand("Select tbl_perfil_detalle.ingresar from tbl_perfil_detalle " +
                            "INNER JOIN tbl_usuario_perfil ON tbl_perfil_detalle.PK_id_perfil = tbl_usuario_perfil.PK_id_perfil" +
                            " WHERE tbl_usuario_perfil.PK_id_usuario= '" + idUsuario + "' AND tbl_perfil_detalle.PK_id_aplicacion ='" + idAplicacion + "'", cn.conectar());
                        almacena = sql.ExecuteReader();

                        if (almacena.Read() == true)
                        {
                            if (almacena.GetString(0) == "1")
                            {
                                almacena.Close();
                                sql.Connection.Close();
                                return true;
                            }
                        }

                        break;

                    case 2:

                         sql = new OdbcCommand("Select consultar from tbl_usuario_aplicacion WHERE PK_id_usuario= '" + idUsuario + "' AND PK_id_aplicacion ='" + idAplicacion + "'", cn.conectar());
                         almacena = sql.ExecuteReader();

                        if (almacena.Read() == true)
                        {
                            if (almacena.GetString(0) == "1")
                            {
                                almacena.Close();
                                sql.Connection.Close();
                                return true;
                            }
                        }

                        sql = new OdbcCommand("Select tbl_perfil_detalle.consultar from tbl_perfil_detalle " +
                            "INNER JOIN tbl_usuario_perfil ON tbl_perfil_detalle.PK_id_perfil = tbl_usuario_perfil.PK_id_perfil" +
                            " WHERE tbl_usuario_perfil.PK_id_usuario= '" + idUsuario + "' AND tbl_perfil_detalle.PK_id_aplicacion ='" + idAplicacion + "'", cn.conectar());
                        almacena = sql.ExecuteReader();

                        if (almacena.Read() == true)
                        {
                            if (almacena.GetString(0) == "1")
                            {
                                almacena.Close();
                                sql.Connection.Close();
                                return true;
                            }
                        }

                        break;

                    case 3:

                        sql = new OdbcCommand("Select modificar from tbl_usuario_aplicacion WHERE PK_id_usuario= '" + idUsuario + "' AND PK_id_aplicacion ='" + idAplicacion + "'", cn.conectar());
                        almacena = sql.ExecuteReader();

                        if (almacena.Read() == true)
                        {
                            if (almacena.GetString(0) == "1")
                            {
                                almacena.Close();
                                sql.Connection.Close();
                                return true;
                            }
                        }

                        sql = new OdbcCommand("Select tbl_perfil_detalle.modificar from tbl_perfil_detalle " +
                            "INNER JOIN tbl_usuario_perfil ON tbl_perfil_detalle.PK_id_perfil = tbl_usuario_perfil.PK_id_perfil" +
                            " WHERE tbl_usuario_perfil.PK_id_usuario= '" + idUsuario + "' AND tbl_perfil_detalle.PK_id_aplicacion ='" + idAplicacion + "'", cn.conectar());
                        almacena = sql.ExecuteReader();

                        if (almacena.Read() == true)
                        {
                            if (almacena.GetString(0) == "1")
                            {
                                almacena.Close();
                                sql.Connection.Close();
                                return true;
                            }
                        }

                        break;

                    case 4:

                        sql = new OdbcCommand("Select eliminar from tbl_usuario_aplicacion WHERE PK_id_usuario= '" + idUsuario + "' AND PK_id_aplicacion ='" + idAplicacion + "'", cn.conectar());
                        almacena = sql.ExecuteReader();

                        if (almacena.Read() == true)
                        {
                            if (almacena.GetString(0) == "1")
                            {
                                almacena.Close();
                                sql.Connection.Close();
                                return true;
                            }
                        }

                        sql = new OdbcCommand("Select tbl_perfil_detalle.eliminar from tbl_perfil_detalle " +
                            "INNER JOIN tbl_usuario_perfil ON tbl_perfil_detalle.PK_id_perfil = tbl_usuario_perfil.PK_id_perfil" +
                            " WHERE tbl_usuario_perfil.PK_id_usuario= '" + idUsuario + "' AND tbl_perfil_detalle.PK_id_aplicacion ='" + idAplicacion + "'", cn.conectar());
                        almacena = sql.ExecuteReader();

                        if (almacena.Read() == true)
                        {
                            if (almacena.GetString(0) == "1")
                            {
                                almacena.Close();
                                sql.Connection.Close();
                                return true;
                            }
                        }

                        break;

                    case 5:

                        sql = new OdbcCommand("Select imprimir from tbl_usuario_aplicacion WHERE PK_id_usuario= '" + idUsuario + "' AND PK_id_aplicacion ='" + idAplicacion + "'", cn.conectar());
                        almacena = sql.ExecuteReader();

                        if (almacena.Read() == true)
                        {
                            if (almacena.GetString(0) == "1")
                            {
                                almacena.Close();
                                sql.Connection.Close();
                                return true;
                            }
                        }

                        sql = new OdbcCommand("Select tbl_perfil_detalle.imprimir from tbl_perfil_detalle " +
                            "INNER JOIN tbl_usuario_perfil ON tbl_perfil_detalle.PK_id_perfil = tbl_usuario_perfil.PK_id_perfil" +
                            " WHERE tbl_usuario_perfil.PK_id_usuario= '" + idUsuario + "' AND tbl_perfil_detalle.PK_id_aplicacion ='" + idAplicacion + "'", cn.conectar());
                        almacena = sql.ExecuteReader();

                        if (almacena.Read() == true)
                        {
                            if (almacena.GetString(0) == "1")
                            {
                                almacena.Close();
                                sql.Connection.Close();
                                return true;
                            }
                        }

                        break;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            return false;
        }

    }
}

using System;
using System.Data;
using CapaDatos;
using System.Data.Odbc;

namespace CapaLogica
{
    public class logica
    {

        sentencia sn;

        public logica(string idUsuario)
        {
            sn = new sentencia(idUsuario);
        }


        /*---------------------------------------------------------------Creador: Allan Letona-----------------------------------------------------------------------------*/
        public DataTable consultaLogicaUsuarios()
        {
            
            try
            {
                OdbcDataAdapter dtUsuario = sn.consultarUsuarios();
                DataTable tableUsuario = new DataTable();
                dtUsuario.Fill(tableUsuario);
                return tableUsuario;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }

        public DataTable consultaLogicaModulos()
        {
            try
            {
                OdbcDataAdapter dtModulos = sn.consultarModulos();
                DataTable tableModulos = new DataTable();
                dtModulos.Fill(tableModulos);
                return tableModulos;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable consultaLogicaPerfiles()
        {
            try
            {
                OdbcDataAdapter dtPerfiles = sn.consultarPerfiles();
                DataTable tablePerfiles = new DataTable();
                dtPerfiles.Fill(tablePerfiles);
                return tablePerfiles;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable consultaLogicaAplicaciones(string nombreModulo)
        {
            try
            {
                OdbcDataAdapter dtAplicaciones = sn.consultarAplicaciones(nombreModulo);
                DataTable tableAplicaciones = new DataTable();
                dtAplicaciones.Fill(tableAplicaciones);
                return tableAplicaciones;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;

            }
        }

        public DataTable consultaLogicaPermisosUsuarioAplicacion(string codigoUsuario, string nombreAplicacion, string ingresar, string consulta, string modificar, string eliminar, string imprimir)
        {
            try
            {
                OdbcDataAdapter dtPermisosUA = sn.insertarPermisosUA(codigoUsuario, nombreAplicacion, ingresar, consulta, modificar, eliminar, imprimir);
                DataTable tablePermisosUA = new DataTable();
                dtPermisosUA.Fill(tablePermisosUA);
                return tablePermisosUA;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable consultaLogicaPerfilesUsuarios(string nombreUsuario)
        {
            try
            {
                OdbcDataAdapter dtPerfilesUsuarios = sn.mostrarPerfilesDeUsuario(nombreUsuario);
                DataTable tablePerfilesUsuarios = new DataTable();
                dtPerfilesUsuarios.Fill(tablePerfilesUsuarios);
                return tablePerfilesUsuarios;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable consultaLogicaEliminarPerfilUsuario(string nombreUsuario, string codigoPerfil)
        {
            try
            {
                OdbcDataAdapter dtEliminarPerfilUsuario = sn.eliminarPerfilUsuario(nombreUsuario, codigoPerfil);
                DataTable tableEliminarPerfilUsuario = new DataTable();
                dtEliminarPerfilUsuario.Fill(tableEliminarPerfilUsuario);
                return tableEliminarPerfilUsuario;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable consultaLogicaInsertarPerfilUsuario(string nombreUsuario, string codigoPerfil)
        {
            try
            {
                OdbcDataAdapter dtInsertarPerfilUsuario = sn.insertarPerfilUsuario(nombreUsuario, codigoPerfil);
                DataTable tableInsertarPerfilUsuario = new DataTable();
                dtInsertarPerfilUsuario.Fill(tableInsertarPerfilUsuario);
                return tableInsertarPerfilUsuario;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable validarIDAplicacion()
        {
            try
            {
                OdbcDataAdapter dtValidarIDAplicacion = sn.validarIDAplicacion();
                DataTable tableValidacionIdAplicacion = new DataTable();
                dtValidarIDAplicacion.Fill(tableValidacionIdAplicacion);
                return tableValidacionIdAplicacion;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable ActualizarUsuario(string idUsuario, string nombreUsuario, string apellidoUsuario,string clave, string estado)
        {
            try
            {
                OdbcDataAdapter dtactualizarUsuario = sn.ActualizarUsuario(idUsuario, nombreUsuario, apellidoUsuario,clave, estado);
                DataTable tableUsuariosActualizacion = new DataTable();
                dtactualizarUsuario.Fill(tableUsuariosActualizacion);
                return tableUsuariosActualizacion;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }


        }

        /*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        /*---------------------------------------------------------------Creador: Diego Gomez-----------------------------------------------------------------------------*/

        public DataTable usuarios(string id, string nombre, string apellido, string clave, int boton)
        {
            try
            {
                OdbcDataAdapter dtusuario = sn.insertarusuario(id, nombre, apellido, clave, boton);
                DataTable tableusuarios = new DataTable();
                dtusuario.Fill(tableusuarios);
                return tableusuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable clave(string id, string nombre, string apellido, string clave)
        {
            try
            {
                OdbcDataAdapter dtusuario = sn.insertarclaves(id, nombre, apellido, clave);
                DataTable tableusuarios = new DataTable();
                dtusuario.Fill(tableusuarios);
                return tableusuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable updateclave(string usuario)
        {
            try
            {
                OdbcDataAdapter dtusuario = sn.update(usuario);
                DataTable tableusuarios = new DataTable();
                dtusuario.Fill(tableusuarios);
                return tableusuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable updatecliente(string clave,string usuario)
        {
            try
            {
                OdbcDataAdapter dtusuario = sn.clienteupdate(clave,usuario);
                DataTable tableusuarios = new DataTable();
                dtusuario.Fill(tableusuarios);
                return tableusuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }


        public DataTable aplicaciones(string idaplicacion, string modulo, string descripcion, string aplicacion, int boton)
        {
            try
            {

                OdbcDataAdapter dtusuario = sn.insertaraplicacion(idaplicacion, modulo, descripcion, aplicacion, boton);
                DataTable tableusuarios = new DataTable();
                dtusuario.Fill(tableusuarios);
                return tableusuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable eliminar(string id, string nombre, string apellido, string clave)
        {
            try
            {
                OdbcDataAdapter dteliminar = sn.eliminarusuario(id, nombre, apellido, clave);
                DataTable tableliminar = new DataTable();
                dteliminar.Fill(tableliminar);
                return tableliminar;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable eliminaraplicaciones(string idaplicacion, string modulo, string descripcion, string aplicacion)
        {
            try
            {
                OdbcDataAdapter dteliminar = sn.eliminaraplicacion(idaplicacion, modulo, descripcion, aplicacion);
                DataTable tableliminar = new DataTable();
                dteliminar.Fill(tableliminar);
                return tableliminar;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable buscar(string id)
        {
            try
            {

                OdbcDataAdapter dtusuario = sn.mostrar(id);
                DataTable tableusuarios = new DataTable();
                dtusuario.Fill(tableusuarios);
                if (tableusuarios == null)
                    return null;
                else
                    return tableusuarios;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable buscaraplicacion(string id)
        {
            try
            {

                OdbcDataAdapter dtusuario = sn.mostraraplicacion(id);
                DataTable tableusuarios = new DataTable();
                dtusuario.Fill(tableusuarios);
                if (tableusuarios == null)
                    return null;
                else
                    return tableusuarios;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable consultaLogicaaplicaciones()
        {

            try
            {
                OdbcDataAdapter dt = sn.consultaraplicaciones();
                DataTable table = new DataTable();
                dt.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        /*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        //######################################### EDITADO POR: ALEJANDRO BARREDA MENDOZA ############################################
        //+1 modulos

        public DataTable validarIDModulos()
        {
            try
            {
                OdbcDataAdapter dtValidarIDModulo = sn.validarIDModulos();
                DataTable tableValidacionIdModulo = new DataTable();
                dtValidarIDModulo.Fill(tableValidacionIdModulo);
                return tableValidacionIdModulo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }


        //--------mantenimiento perfiles

        //+1
        public DataTable validarIDperfiles()
        {
            try
            {
                OdbcDataAdapter dtValidarIDAplicacion = sn.validarIDperfiles();
                DataTable tableValidacionIdAplicacion = new DataTable();
                dtValidarIDAplicacion.Fill(tableValidacionIdAplicacion);
                return tableValidacionIdAplicacion;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }


        public DataTable ingresarperfiles(string codigo, string nombre, string descripcion, string estado)
        {
            try
            {
                OdbcDataAdapter ingresoperfil = sn.insertarPerfil(codigo, nombre, descripcion, estado);
                DataTable tableperfiles = new DataTable();
                ingresoperfil.Fill(tableperfiles);
                return tableperfiles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable ConsultaLogicaPerfil(string ID_perfil)
        {
            try
            {
                OdbcDataAdapter cmpsperfiles = sn.ConsultarPerfil(ID_perfil);
                DataTable tablaperfiles = new DataTable();
                cmpsperfiles.Fill(tablaperfiles);
                return tablaperfiles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }


        public DataTable Actualizarperfil(string ID_perfil, string nombre, string descripcion, string estado)
        {
            try
            {
                OdbcDataAdapter dtperfil = sn.ActualizarPerfil(ID_perfil, nombre, descripcion, estado);
                DataTable tablaperfiles = new DataTable();
                dtperfil.Fill(tablaperfiles);
                return tablaperfiles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }


        }

	
        public DataTable ingresarmodulos(string codigo, string nombre, string descripcion, string estado)
        {
            try
            {
                OdbcDataAdapter ingresomodulo = sn.insertarModulo(codigo, nombre, descripcion, estado);
                DataTable tablemodulos = new DataTable();
                ingresomodulo.Fill(tablemodulos);
                return tablemodulos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }



        public DataTable consultaLogicaPermisosPerfilAplicacion(string codigoPerfil, string nombreAplicacion, string ingresar, string consulta, string modificar, string eliminar, string imprimir)
        {
            try
            {
                OdbcDataAdapter dtPermisosPerfilA = sn.insertarPermisosPerfilA(codigoPerfil, nombreAplicacion, ingresar, consulta, modificar, eliminar, imprimir);
                DataTable tablePermisosPerfilA = new DataTable();
                dtPermisosPerfilA.Fill(tablePermisosPerfilA);
                return tablePermisosPerfilA;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable ConsultaLogicaModulo(string ID_modulo)
        {
            try
            {
                OdbcDataAdapter cmpsModulos = sn.ConsultarModulos(ID_modulo);
                DataTable tablaModulos = new DataTable();
                cmpsModulos.Fill(tablaModulos);
                return tablaModulos;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        

        public DataTable Actualizarmodulo(string ID_modulo,string nombre, string descripcion, string estado)
        {
            try
            {
                OdbcDataAdapter dtmodulo = sn.ActualizarModulo(ID_modulo,nombre,descripcion,estado);
                DataTable tablamodulos = new DataTable();
                dtmodulo.Fill(tablamodulos);
                return tablamodulos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

            
        }
        //######################################### FIN EDICION ALEJANDRO BARREDA ###############################

        // eduardo Colon

        public DataSet consultaLogicaBitacora()
        {
            return sn.consultarBitacora();
        }
     

    }

}

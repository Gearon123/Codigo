using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Collections;
using System.Security.Claims;
using System.Xml.Linq;

namespace CapaDatos
{
    public class CD_usuario
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.idUsuario,u.documento,u.nombre,u.correo,u.clave,u.estado, r.idRol, r.descripcion  from Usuario u\r\n");
                    query.AppendLine("inner join Rol r on r.idRol =u.idRol");
                    
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;
                    
                    con.Open();

                    using(SqlDataReader rd = cmd.ExecuteReader()) {
                        while (rd.Read())
                        {
                            lista.Add(new Usuario
                            {
                                IdUsuario = Convert.ToInt32(rd["idUsuario"]),
                                documento = rd["documento"].ToString(),
                                NombreCompleto = rd["nombre"].ToString(),
                                Correo = rd["correo"].ToString(),
                                Clave = rd["clave"].ToString(),
                                Estado = Convert.ToBoolean(rd["estado"]),
                                rol = rd["idRol"].ToString(),

                                oRol = new Rol() { IdRol = Convert.ToInt32(rd["idRol"]), descripcion= rd["descripcion"].ToString() }
                            });
                        }
                        
                    }
                }
                catch(Exception ex) { 
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }
        //-------------------registrar------------------------------------
        public int Registrar(Usuario obj, out string mensaje )
        {
            int idUsuariogenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadena))
                {
                    //parametros de entrada
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO".ToString(), con);
                    cmd.Parameters.AddWithValue("documento",obj.documento);
                    cmd.Parameters.AddWithValue("nombre", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("correo", obj.Correo);
                    cmd.Parameters.AddWithValue("clave", obj.Clave);
                    cmd.Parameters.AddWithValue("idRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    //parametros de salida
                    cmd.Parameters.Add("idUsuarioResultado",SqlDbType.Int).Direction= ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction= ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    idUsuariogenerado = Convert.ToInt32(cmd.Parameters["idUsuarioResultado"].Value);
                    mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                idUsuariogenerado = 0;
                mensaje= ex.Message;
            }
            return idUsuariogenerado;
        }

        //--------------------------------Editar------------------------------------

        public bool editar(Usuario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadena))
                {
                    //parametros de entrada
                    SqlCommand cmd = new SqlCommand("SP_ActualizarUSUARIO".ToString(), con);
                    cmd.Parameters.AddWithValue("idUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("documento", obj.documento);
                    cmd.Parameters.AddWithValue("nombre", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("correo", obj.Correo);
                    cmd.Parameters.AddWithValue("clave", obj.Clave);
                    cmd.Parameters.AddWithValue("idRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    //parametros de salida
                    cmd.Parameters.Add("respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
                    mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }
            return respuesta;
        }
        //---------------------------Eliminar----------------------------------------
        public bool Eliminar(Usuario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadena))
                {
                    //parametros de entrada
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO".ToString(), con);
                    cmd.Parameters.AddWithValue("idUsuario", obj.IdUsuario);

                    //parametros de salida
                    cmd.Parameters.Add("respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
                    mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}

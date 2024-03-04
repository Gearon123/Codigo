using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Categoria
    {

        public List<Categoria> listar()
        {
            List<Categoria> listas = new List<Categoria>();
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idCategoria,descripcion,estado from Categoria");
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            listas.Add(new Categoria
                            {
                                IdCategoria = Convert.ToInt32(rd["idCategoria"]),
                                Descripcion = rd["descripcion"].ToString(),
                                Estado = Convert.ToBoolean(rd["estado"])
                            });
                        }

                    }
                }
                catch (Exception ex)
                {
                    listas = new List<Categoria>();
                }
            }
            return listas;
        }
        //-------------------registrar------------------------------------
        public int Registrar(Categoria obj, out string mensaje)
        {
            int idCategoriagenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadena))
                {
                    //parametros de entrada
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCATEGORIA".ToString(), con);
                    cmd.Parameters.AddWithValue("descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    //parametros de salida
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    idCategoriagenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                idCategoriagenerado = 0;
                mensaje = ex.Message;
            }
            return idCategoriagenerado;
        }

        //--------------------------------Editar------------------------------------

        public bool editar(Categoria obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadena))
                {
                    //parametros de entrada
                    SqlCommand cmd = new SqlCommand("SP_ACTUALIZARCATEGORIA".ToString(), con);
                    cmd.Parameters.AddWithValue("idCategoria", obj.IdCategoria);
                    cmd.Parameters.AddWithValue("descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("estado", obj.Estado);

                    //parametros de salida
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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
        public bool Eliminar(Categoria obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadena))
                {
                    //parametros de entrada
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA".ToString(), con);
                    cmd.Parameters.AddWithValue("idCategoria", obj.IdCategoria);

                    //parametros de salida
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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

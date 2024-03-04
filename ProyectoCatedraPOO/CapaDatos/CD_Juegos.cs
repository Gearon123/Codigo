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
    public class CD_Juegos
    {
        public List<Juegos> listar()
        {
            List<Juegos> listas = new List<Juegos>();
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idJuego,codigo,nombre, j.descripcion,c.idCategoria , c.descripcion[DescripcionCategoria], strock,precioVenta, j.estado from Juegos j\r\ninner join Categoria c on c.idCategoria=j.idCategoria");

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            listas.Add(new Juegos
                            {
                                idJuegos = Convert.ToInt32(rd["idJuego"]),
                                Codigo = rd["codigo"].ToString(),
                                Nombre = rd["nombre"].ToString(),
                                descripcion = rd["descripcion"].ToString(),
                                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(rd["idCategoria"]), Descripcion = rd["DescripcionCategoria"].ToString() },
                                Estado = Convert.ToBoolean(rd["estado"]),
                                Stock = Convert.ToInt32(rd["strock"]),
                                PrecioVenta = Convert.ToDecimal(rd["precioVenta"]),
                            });
                        }

                    }
                }
                catch (Exception ex)
                {
                    listas = new List<Juegos>();
                }
            }
            return listas;
        }

        //-------------------registrar------------------------------------
        public int Registrar(Juegos obj, out string mensaje)
                    {
            int idJuegosgenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadena))
                {
                    //parametros de entrada
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARPRODUCTO".ToString(), con);
                    cmd.Parameters.AddWithValue("codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("descripcion", obj.descripcion);
                    
                    cmd.Parameters.AddWithValue("idCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("strock", obj.Stock);
                    cmd.Parameters.AddWithValue("precio", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    //parametros de salida
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    idJuegosgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                idJuegosgenerado = 0;
                mensaje = ex.Message;
            }
            return idJuegosgenerado;
        }
        //--------------------------------Editar------------------------------------

        public bool editar(Juegos obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadena))
                {
                    //parametros de entrada
                    SqlCommand cmd = new SqlCommand("SP_ACTUALIZARPRODUCTO".ToString(), con);
                    cmd.Parameters.AddWithValue("idJuego", obj.idJuegos);
                    cmd.Parameters.AddWithValue("codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("strock", obj.Stock);
                    cmd.Parameters.AddWithValue("precio", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("idCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
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
        public bool Eliminar(Juegos obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadena))
                {
                    //parametros de entrada
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARProducto".ToString(), con);
                    cmd.Parameters.AddWithValue("idJuego", obj.idJuegos);

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

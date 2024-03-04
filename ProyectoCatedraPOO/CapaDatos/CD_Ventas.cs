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
    public class CD_Ventas
    {
        public List<Permiso> listar(int idUsuario)
        {
            List<Permiso> lista = new List<Permiso>();
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.idRol, p.descripcion from Permiso p");
                    query.AppendLine("inner join Rol r on r.idRol = p.idRol");
                    query.AppendLine("inner join Usuario u on u.idRol = r.idRol");
                    query.AppendLine("where u.idUsuario = @idUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                oRol = new Rol { IdRol = Convert.ToInt32(rd["IdRol"]) },
                                NombreMenu = rd["descripcion"].ToString(),


                            });
                        }

                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();
                }
            }
            return lista;
        }
    }
}

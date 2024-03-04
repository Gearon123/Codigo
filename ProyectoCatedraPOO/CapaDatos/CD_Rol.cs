using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
namespace CapaDatos
{
    public class CD_Rol
    {
        public List<Rol> listar()
        {
            List<Rol> lista = new List<Rol>();
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idRol, descripcion from Rol");


                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(rd["IdRol"]),
                                descripcion = rd["descripcion"].ToString(),

                            });
                        }

                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Rol>();
                }
            }
            return lista;
        }
    }
}

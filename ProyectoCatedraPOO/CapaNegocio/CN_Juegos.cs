using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Juegos
    {
        private CD_Juegos objcd_Juegos = new CD_Juegos();
        public List<Juegos> listar()
        {
            return objcd_Juegos.listar();
        }

        public int Registrar(Juegos obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Codigo == "")
            {
                Mensaje += "Ingresar el codigo del Juegos\n ";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Ingresar el nombre del juego\n";
            }

            if (obj.descripcion == "")
            {
                Mensaje += "Ingresar la descripcion del juego\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Juegos.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Juegos obj, out string Mensaje)
        {

            Mensaje = string.Empty;
            if (obj.Codigo == "")
            {
                Mensaje += "Ingresar el codigo del Juegos\n ";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Ingresar el nombre del juego\n";
            }

            if (obj.descripcion == "")
            {
                Mensaje += "Ingresar la descripcion del juego\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Juegos.editar(obj, out Mensaje);
            }

        }

        public bool Elimnar(Juegos obj, out string Mensaje)
        {
            return objcd_Juegos.Eliminar(obj, out Mensaje);
        }
    }
}

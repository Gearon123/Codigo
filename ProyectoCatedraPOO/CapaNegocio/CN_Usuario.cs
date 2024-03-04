using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_usuario objcd_usuario= new CD_usuario();
        public List<Usuario> listar()
        {
            return objcd_usuario.listar(); 
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje= string.Empty;
            if (obj.documento=="")
            {
                Mensaje += "Ingresar el nombre de usuario\n ";
            }            
            if (obj.NombreCompleto=="")
            {
                Mensaje += "Ingresar el nombre completo\n";
            }
                        
            if (obj.Clave=="")
            {
                Mensaje += "Ingresar una contraseña valida\n";
            }
            if(Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.Registrar(obj, out Mensaje);
            }

        }        
        
        public bool Editar(Usuario obj, out string Mensaje)
        {

            Mensaje = string.Empty;
            if (obj.documento == "")
            {
                Mensaje += "Ingresar el nombre de usuario\n ";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Ingresar el nombre completo\n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Ingresar una contraseña valida\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.editar(obj, out Mensaje);
            }

        }        
        
        public bool Elimnar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }
    }
}

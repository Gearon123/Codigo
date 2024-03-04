using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    internal class Cliente
    {
        public int idCliente { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string telefono { get; set; }
        public bool Estado { get; set; }
        public string fechaRgistro { get; set; }
    }
}

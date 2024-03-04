using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Juegos
    {
        public int idJuegos {  get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set;}
        public string descripcion { get; set;}
        public Categoria oCategoria { get; set;}
        public int Stock { get; set;}
        public decimal PrecioVenta { get; set;}
        public bool Estado { set; get; }
        public string fechaRgistro { get; set; }
    }
}

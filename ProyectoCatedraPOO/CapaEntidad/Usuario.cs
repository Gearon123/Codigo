﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string documento { get; set; }
        public string NombreCompleto { get; set;}
        public string Correo { get; set;}
        public string Clave { get; set;}
        public string rol { get; set;}
        public Rol oRol { get; set;}
        public bool Estado { get; set;}
        public string fechaRgistro { get; set; }


    }
}
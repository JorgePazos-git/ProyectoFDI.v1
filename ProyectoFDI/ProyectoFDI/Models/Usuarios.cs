using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFDI.Models
{
    public class Usuarios
    {
        public string nombre_usu { get; set; }
        public string contraseña_usu { get; set; }

        public Rol IdRol { get; set; }
    }
}

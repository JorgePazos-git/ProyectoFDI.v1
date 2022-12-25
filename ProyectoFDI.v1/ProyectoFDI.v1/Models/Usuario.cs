using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFDI.v1.Models;

public partial class Usuario
{
    public string NombreUsuario { get; set; } 
    
    public string? ClaveUsuario { get; set; }

    public string? RolesUsuario { get; set; }
}

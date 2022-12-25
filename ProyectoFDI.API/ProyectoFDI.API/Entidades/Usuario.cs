using System;
using System.Collections.Generic;

namespace ProyectoFDI.API.Entidades;

public partial class Usuario
{
    public string NombreUsuario { get; set; } = null!;

    public string? ClaveUsuario { get; set; }

    public string? RolesUsuario { get; set; }
}

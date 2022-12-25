using System;
using System.Collections.Generic;

namespace ProyectoFDI.API.Entidades;

public partial class Modalidad
{
    public int IdMod { get; set; }

    public string? DescripcionMod { get; set; }

    public virtual ICollection<Deportistum> Deportista { get; } = new List<Deportistum>();
}

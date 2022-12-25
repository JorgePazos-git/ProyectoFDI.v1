using System;
using System.Collections.Generic;

namespace ProyectoFDI.v1.Models;

public partial class Modalidad
{
    public int IdMod { get; set; }

    public string? DescripcionMod { get; set; }

    public virtual ICollection<Deportistum> Deportista { get; } = new List<Deportistum>();
}

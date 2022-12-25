using System;
using System.Collections.Generic;

namespace ProyectoFDI.v1.Models;

public partial class Deportistum
{
    public int IdDep { get; set; }

    public string? ApellidosDep { get; set; }

    public string? NombresDep { get; set; }

    public string? CedulaDep { get; set; }

    public string? CategoriaDep { get; set; }

    public string? ProvinciaDep { get; set; }

    public string? ClubDep { get; set; }

    public string? GeneroDep { get; set; }

    public int? IdMod { get; set; }

    public virtual Modalidad? IdModNavigation { get; set; }
}

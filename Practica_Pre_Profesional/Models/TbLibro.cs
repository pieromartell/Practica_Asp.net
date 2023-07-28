using System;
using System.Collections.Generic;

namespace Practica_Pre_Profesional.Models;

public partial class TbLibro
{
    public int IdLibro { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdAsing { get; set; }

    public int Stock { get; set; }

    public virtual TbAsignatura IdAsingNavigation { get; set; } = null!;
}

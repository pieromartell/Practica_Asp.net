using System;
using System.Collections.Generic;

namespace Practica_Pre_Profesional.Models;

public partial class TbAsignatura
{
    public int IdAsig { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Estado { get; set; }

    public virtual ICollection<TbLibro> TbLibros { get; set; } = new List<TbLibro>();
}

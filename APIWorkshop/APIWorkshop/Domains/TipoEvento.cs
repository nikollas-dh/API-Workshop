using System;
using System.Collections.Generic;

namespace APIWorkshop.Domains;

public partial class TipoEvento
{
    public int Id { get; set; }

    public string? TipoEvento1 { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}

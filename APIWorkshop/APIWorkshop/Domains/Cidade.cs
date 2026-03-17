using System;
using System.Collections.Generic;

namespace APIWorkshop.Domains;

public partial class Cidade
{
    public int Id { get; set; }

    public string? Cidade1 { get; set; }

    public int? EstadoId { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<Participante> Participantes { get; set; } = new List<Participante>();
}

using System;
using System.Collections.Generic;

namespace APIWorkshop.Domains;

public partial class Evento
{
    public int Id { get; set; }

    public string? Evento1 { get; set; }

    public int? TipoId { get; set; }

    public virtual ICollection<ParticipantesEvento> ParticipantesEventos { get; set; } = new List<ParticipantesEvento>();

    public virtual TipoEvento? Tipo { get; set; }

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}

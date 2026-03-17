using System;
using System.Collections.Generic;

namespace APIWorkshop.Domains;

public partial class Participante
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public int? Idade { get; set; }

    public int? CidadeId { get; set; }

    public string? Genero { get; set; }

    public virtual Cidade? Cidade { get; set; }

    public virtual ICollection<ParticipantesEvento> ParticipantesEventos { get; set; } = new List<ParticipantesEvento>();

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}

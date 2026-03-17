using System;
using System.Collections.Generic;

namespace APIWorkshop.Domains;

public partial class Venda
{
    public int Id { get; set; }

    public int? ParticipanteId { get; set; }

    public int? ProdutoId { get; set; }

    public int? Quantidade { get; set; }

    public int? EventoId { get; set; }

    public int? LojaId { get; set; }

    public DateTime? Data { get; set; }

    public DateTime? Hora { get; set; }

    public string? Transacao { get; set; }

    public virtual Evento? Evento { get; set; }

    public virtual Loja? Loja { get; set; }

    public virtual Participante? Participante { get; set; }

    public virtual Produto? Produto { get; set; }
}

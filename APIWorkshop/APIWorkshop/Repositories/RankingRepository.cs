using APIWorkshop.Contexts;
using APIWorkshop.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace APIWorkshop.Repositories
{
    public class RankingRepository
    {
        public WorkshopContext ctx = new WorkshopContext();
        public List<ParticipanteViewModel> GetPontos()
        {
            List<ParticipanteViewModel> lista = ctx.Participantes
                 .Include(x => x.Venda)
                 .ThenInclude(x => x.Produto)
                 .Where(x => x.Venda.Count() > 0)
                 .Select(x => new ParticipanteViewModel
                 {
                     Nome = x.Nome,
                     Pontos = (int)(x.Venda.Count() * 12 + x.Venda.Sum(v => v.Produto.Valor * v.Quantidade) * 24)
                 }).ToList();
            return lista;
        }

    }
}

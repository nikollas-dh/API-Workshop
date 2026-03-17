using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIWorkshop.Repositories;

namespace APIWorkshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        public RankingRepository repository = new RankingRepository();

        [HttpGet]

        public IActionResult GetParticipantes()
        {
            return Ok(repository.GetPontos());
        }
        [HttpGet("</{pontos}")]
        public IActionResult GetParticipantesByMaxPonto(int pontos)
        {
            return Ok(repository.GetPontos().Where(x => x.Pontos > pontos));
        }

        [HttpGet("!>po/{pontos}")]
        public IActionResult GetParticipantesOrdered()
        {
            return Ok(repository.GetPontos().OrderBy(x=> x.Pontos));
        }
    }
}

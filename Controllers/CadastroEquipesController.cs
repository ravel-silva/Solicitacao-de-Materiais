using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroEquipesController : ControllerBase
    {
        private static List<CadastroEquipe> equipes = new List<CadastroEquipe>(); // This is a list of CadastroEquipe objects
        [HttpPost]
        public IActionResult CreateTeam([FromBody] CreateCadastroEquipeDto CadastroEquipeDto)
        {
            CadastroEquipe equipe = new CadastroEquipe
            {
                Prefixo = CadastroEquipeDto.Prefixo
            };
            equipes.Add(equipe);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            return Ok(equipes);
        }
    }
}

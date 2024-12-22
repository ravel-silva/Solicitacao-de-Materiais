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
        // This method creates a team
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
        // This method returns the list of teams
        [HttpGet]
        public IActionResult GetTeams()
        {
            return Ok(equipes);
        }
        // This method deletes a team
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            CadastroEquipe equipe = equipes.FirstOrDefault(equipe => equipe.Id == id);
            if (equipe == null)
            {
                return NotFound();
            }
            equipes.Remove(equipe);
            return NoContent();
        }
    }
}

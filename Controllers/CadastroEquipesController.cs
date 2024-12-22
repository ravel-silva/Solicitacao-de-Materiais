using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroEquipesController : ControllerBase
    {
        private EquipeContext _context;
        public CadastroEquipesController(EquipeContext context)
        {
            _context = context;
        }
        // This method creates a team
        [HttpPost]
        public IActionResult CreateTeam([FromBody] CreateCadastroEquipeDto CadastroEquipeDto)
        {
            CadastroEquipe equipe = new CadastroEquipe
            {
                Prefixo = CadastroEquipeDto.Prefixo
            };
            _context.Equipes.Add(equipe);
            return Ok();
        }
        // This method returns the list of teams
        [HttpGet]
        public IActionResult GetTeams() // vericar erro do get, nao esta exibindo a lista
        {

            return Ok(_context);
        }
        // This method deletes a team
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var equipe = _context.Equipes.FirstOrDefault(Equipes => Equipes.Id == id);
            if (equipe == null)
            {
                return NotFound();
            }
            _context.Remove(equipe);
            return NoContent();
        }
    }
}

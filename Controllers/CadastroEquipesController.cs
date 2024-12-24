using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;
using Solicitacao_de_Material.Services;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroEquipesController : ControllerBase
    {
        private EquipeContext _context;
        private readonly CadastroEquipeService _cadastroEquipeService;
        public CadastroEquipesController(EquipeContext context)
        {
            _context = context;
            _cadastroEquipeService = new CadastroEquipeService();
        }
        // This method creates a team
        [HttpPost]
        public IActionResult CreateTeam([FromBody] CreateCadastroEquipeDto CadastroEquipeDto)
        {
            if (CadastroEquipeDto == null || string.IsNullOrWhiteSpace(CadastroEquipeDto.Prefixo))
            {
                return BadRequest("Dados invalidos ou incompletos");
            }
            var novaEquipes = new CadastroEquipe
            {
                Prefixo = CadastroEquipeDto.Prefixo
            };
            _context.Equipes.Add(novaEquipes);
            _context.SaveChanges();
            return Ok();
        }

        // This method returns the list of teams
        [HttpGet]
        public IActionResult GetTeams() // vericar erro do get, nao esta exibindo a lista
        {
            var equipes = _context.Equipes.Select(equipe => new ReadCadastroEquipeDto
            {
                Id = equipe.Id,
                Prefixo = equipe.Prefixo
            });
            return Ok(equipes);
        }
        [HttpGet("{id}")]
        public IActionResult GetTeamId(int id)
        {
            var equipes = _context.Equipes.Select(equipe => new ReadCadastroEquipeDto
            {
                Id = equipe.Id,
                Prefixo = equipe.Prefixo
            }).FirstOrDefault(equipe => equipe.Id == id);
            if (equipes == null)
            {
                return NotFound("Equipe não localizada");
            }
            return Ok(equipes);
        }

            // This method deletes a team
            [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var equipe = _context.Equipes.FirstOrDefault(Equipes => Equipes.Id == id);
            if (equipe == null)
            {
                return NotFound("Equipe não localizada");
            }
            _context.Remove(equipe);
            return NoContent();
        }
    }
}

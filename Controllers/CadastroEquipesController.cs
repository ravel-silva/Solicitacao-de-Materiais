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
        private CadastroEquipeService _cadastroEquipeService;
        public CadastroEquipesController(EquipeContext context, CadastroEquipeService equipeService)
        {
            _context = context;
            _cadastroEquipeService = equipeService;
        }
        // This method creates a team
        [HttpPost]
        public IActionResult CreateTeam([FromBody] CreateCadastroEquipeDto CadastroEquipeDto)
        {
            if (CadastroEquipeDto == null || string.IsNullOrWhiteSpace(CadastroEquipeDto.Prefixo))
            {
                return BadRequest("Dados invalidos ou incompletos");
            }

            _cadastroEquipeService.CreateEquipe(CadastroEquipeDto);
            return Ok("Equipe Criada com Sucesso");
        }

        // This method returns the list of teams
        [HttpGet]
        public IActionResult GetTeams()
        {
            _cadastroEquipeService.GetEquipe();
            if (_cadastroEquipeService.GetEquipe() == null || !_cadastroEquipeService.GetEquipe().Any())
            {
                return NotFound("Nenhuma equipe localizada");
            }

            return Ok(_cadastroEquipeService.GetEquipe());
        }
        //this method returns the team by id
        [HttpGet("{id}")]
        public IActionResult GetTeamId(int Id)
        {
            var equipe = _cadastroEquipeService.GetEquipeId(Id);

            if (equipe == null || !equipe.Any())
            {
                return NotFound("Equipe não localizada");
            }
            return Ok(equipe);
        }

        // This method deletes a team
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            if (!_cadastroEquipeService.DeleleteEquipe(id))
            {
                return NotFound("Equipe não localizada");
            }
            return Ok("Equipe Deletada");
        }
            
    }
}

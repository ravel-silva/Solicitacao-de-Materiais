using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Migrations;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelationShipEquipeFuncionarioController : ControllerBase
    {
        private EquipeContext _context;
        public RelationShipEquipeFuncionarioController(EquipeContext context)
        {
            _context = context;
        }
        public IActionResult CreateRelationship([FromBody] RelationshipEquipeFuncionarioDto relationshipEquipeFuncionarioDto)
        {
            if (relationshipEquipeFuncionarioDto == null
                || relationshipEquipeFuncionarioDto.equipeId == 0
                || relationshipEquipeFuncionarioDto.funcionarioId == 0)
            {
                return BadRequest("Dados invalidos ou incompletos");
            }
            // Verificar se a equipe e o funcionário existem no banco de dados
            var equipe = _context.Equipes.FirstOrDefault(equipes => equipes.Id == relationshipEquipeFuncionarioDto.equipeId);
            var funcionario = _context.Funcionarios.FirstOrDefault(funcionarios => funcionarios.Id == relationshipEquipeFuncionarioDto.funcionarioId);
            if (equipe == null || funcionario == null)
            {
                return BadRequest("Equipe ou Funcionário não localizado");
            }
            // Verificar se um funcionário já está em uma equipe
            var funcionarioNaEquipe = _context.RelationshipEquipeFuncionario.FirstOrDefault(relacao => relacao.funcionarioId == relationshipEquipeFuncionarioDto.funcionarioId);
            {
                if (funcionarioNaEquipe != null)
                {
                    return BadRequest("Funcionário já está em uma equipe");
                }
                // Criar o relacionamento
                var relacao = new EquipeFuncionario
                {
                    equipeId = relationshipEquipeFuncionarioDto.equipeId,
                    funcionarioId = relationshipEquipeFuncionarioDto.funcionarioId,
                    dataEntrada = DateTime.Now
                };
                _context.RelationshipEquipeFuncionario.Add(relacao);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}

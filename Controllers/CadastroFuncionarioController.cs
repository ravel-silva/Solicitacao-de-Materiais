using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroFuncionarioController : ControllerBase
    {
        private EquipeContext _context;
        public CadastroFuncionarioController(EquipeContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateFuncionario([FromBody] CreateCadastroFuncionarioDto CadastroFuncionarioDto)
        {
            if(CadastroFuncionarioDto == null || string.IsNullOrWhiteSpace(CadastroFuncionarioDto.Matricula)
                || string.IsNullOrWhiteSpace(CadastroFuncionarioDto.Nome))
            {
                return BadRequest("Dados invalidos ou incompletos");
            }
            var novoFuncionario = new CadastroFuncionario
            {
               Nome = CadastroFuncionarioDto.Nome,
               Matricula = CadastroFuncionarioDto.Matricula
            };
            _context.Funcionarios.Add(novoFuncionario); 
            _context.SaveChanges();

            return Ok();
        }
    }
}

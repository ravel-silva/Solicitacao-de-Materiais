using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;
using Solicitacao_de_Material.Services;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        
        private EmployeeService _service;
        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult CreateFuncionario([FromBody] CreateFuncionarioDto CadastroFuncionarioDto)
        {
            if (CadastroFuncionarioDto == null || string.IsNullOrWhiteSpace(CadastroFuncionarioDto.Matricula.ToString())
                || string.IsNullOrWhiteSpace(CadastroFuncionarioDto.Nome))
            {
                return BadRequest("Dados invalidos ou incompletos");
            }
            _service.CreateCadastroFuncionario(CadastroFuncionarioDto);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetFuncionarios()
        {
            if (_service.GetCadastroFuncionario() == null || !_service.GetCadastroFuncionario().Any())
            {
                return NotFound("Nenhum funcionario localizado");
            }
            return Ok(_service.GetCadastroFuncionario());

        }

        [HttpGet("{id}")]
        public IActionResult GetFuncionarioById(int id)
        {
            if (_service.GetCadastroFuncionarioById(id) == null || !_service.GetCadastroFuncionarioById(id).Any())
            {
                return NotFound("Funcionario não localizado");
            }
            return Ok(_service.GetCadastroFuncionarioById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFuncionario(int id)
        {
            if (!_service.DeleteCadastroFuncionario(id))
            {
                return NotFound("Funcionario não localizado");
            }
            return Ok("Funcionario deletado com sucesso");
        }
    }
}

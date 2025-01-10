using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;
using Solicitacao_de_Material.Services;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : ControllerBase
    {
        public MaterialService _service;
        public MaterialController(MaterialService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CreateMaterial([FromBody] CreateMaterialDto materialDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          
            _service.CreateMaterial(materialDto);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetMaterials()
        {
            if (_service.GetMaterials() == null || !_service.GetMaterials().Any())
            {
                return NotFound("Nenhum material localizado");
            }
            return Ok(_service.GetMaterials());
        }

        [HttpGet("{id}")]
        public IActionResult GetMaterialById(int id)
        {
            if (_service.GetMaterialById(id) == null || !_service.GetMaterialById(id).Any())
            {
                return NotFound("Material não localizado");
            }
            return Ok(_service.GetMaterialById(id));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMaterial(int id, [FromBody] UpdateMaterialDto updateMaterialDto)
        {
            if(id != updateMaterialDto.Id)
            {
                return BadRequest("Id inválido");
            }
            if (!_service.UpdateMaterial(updateMaterialDto))
            {
                return NotFound("Material não localizado");
            }
            return Ok("Material atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMaterial(int id)
        {
            if (!_service.DeleteMaterial(id))
            {
                return NotFound("Material não localizado");
            }
            return Ok("Material deletado com sucesso");
        }
        
    }
}

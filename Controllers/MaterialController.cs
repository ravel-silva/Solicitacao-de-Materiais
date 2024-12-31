using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateMaterial()
        {

        }

        [HttpGet]
        public IActionResult GetMaterials()
        {
        }

        [HttpGet("{id}")]
        public IActionResult GetMaterialById(int id)
        {
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMaterial(int id)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMaterial(int id)
        {
        }
    }
}

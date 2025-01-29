using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data.Dtos.Auth;

namespace Solicitacao_de_Material.Controllers.Auth
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController()
        {
        }
        [HttpPost]

        public IActionResult CreateUsuario([FromBody] CreateUsuarioDto UsuarioDto)
        {
            return Ok();
        }
    }
}

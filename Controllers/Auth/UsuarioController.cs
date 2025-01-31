using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data.Dtos.Auth;
using Solicitacao_de_Material.Model.Auth;

namespace Solicitacao_de_Material.Controllers.Auth
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UserManager<Usuario> _userManege;

        public UsuarioController(UserManager<Usuario> userManege)
        {
            _userManege = userManege;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CreateUsuarioDto UsuarioDto)
        {
            var usuario = new Usuario
            {
                UserName = UsuarioDto.Username,
                Matricula = UsuarioDto.Matricula,
            };
            IdentityResult result = await _userManege.CreateAsync(usuario, UsuarioDto.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest (result.Errors.Select(erro => erro.Description));
        }
    }
}

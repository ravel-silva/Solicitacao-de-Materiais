using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolicitacaoController : ControllerBase
    {
        private AppDbContext _context;
        public SolicitacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CrateSolicitacao([FromBody] CreateRequisicaoDeMaterialDto requisicao)
        {
            if (requisicao == null || requisicao.Materiais == null || !requisicao.Materiais.Any()) { return BadRequest("A lista de materiais não pode estar vazia."); }
            var novaRequisicao = new RequisicaoDeMaterial
            {
                EquipeId = requisicao.EquipeId,
                Materiais = requisicao.Materiais.Select(material => new ListMaterialDto
                {
                    Nome = material.Nome,
                    Quantidade = material.Quantidade
                }).ToList(),
                Status = requisicao.Status,
                DateTime = DateTime.Now
            };
            
            return Ok(novaRequisicao);
        }
    }
}

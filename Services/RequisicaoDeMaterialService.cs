using Microsoft.EntityFrameworkCore;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class RequisicaoDeMaterialService
    {
        private AppDbContext _context;

        public RequisicaoDeMaterialService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateRequisicaoDeMaterial(CreateRequisicaoDeMaterialDto requisicao)
        {
            var novaRequisicao = new RequisicaoDeMaterial
            {
                EquipeId = requisicao.EquipeId,
                Status = requisicao.Status,
                DateTime = DateTime.Now,
                Materiais = new List<ListMaterial>()
            };
            foreach (var material in requisicao.Materiais)
            {
                novaRequisicao.Materiais.Add(new ListMaterial
                {
                    MaterialId = material.MaterialId,
                    Quantidade = material.Quantidade
                });
            }
            _context.RequisicoesDeMaterial.Add(novaRequisicao);
            _context.SaveChanges();
        }
        public ICollection<ReadRequisicaoDeMaterialDto> ViewRequisicoes(PaginationParameters parameters)
        {
            return _context.RequisicoesDeMaterial
                .Include(r => r.Equipe)
                .Include(r => r.Materiais)
                .ThenInclude(m => m.Material)
                .Select(r => new ReadRequisicaoDeMaterialDto
                {
                    Id = r.Id,
                    EquipeId = r.EquipeId,
                    EquipeNome = r.Equipe.Prefixo, // Mapeando a propriedade Prefixo para EquipeNome
                    Status = r.Status,
                    DateTime = r.DateTime,
                    Materiais = r.Materiais.Select(m => new ReadMaterialDto
                    {
                        Id = m.Material.Id,
                        Codigo = m.Material.Codigo,
                        Nome = m.Material.Nome,
                        Descricao = m.Material.Descricao,
                        Quantidade = m.Quantidade,
                        Unidade = m.Material.Unidade,
                        Status = m.Material.Status
                    }).Skip((parameters.PageNumber - 1)
                       * parameters.PageSize)
                       .Take(parameters.PageSize).ToList()
                })
                .ToList();
        }
        public ICollection<ReadRequisicaoDeMaterialDto> ViewRequisicoesId(int id)
        {
            return _context.RequisicoesDeMaterial
                .Include(r => r.Equipe)
                .Include(r => r.Materiais)
                .ThenInclude(m => m.Material)
                .Where(r => r.EquipeId == id)
                .Select(r => new ReadRequisicaoDeMaterialDto
                {
                    Id = r.Id,
                    EquipeId = r.EquipeId,
                    EquipeNome = r.Equipe.Prefixo, // Mapeando a propriedade Prefixo para EquipeNome
                    Status = r.Status,
                    DateTime = r.DateTime,
                    Materiais = r.Materiais.Select(m => new ReadMaterialDto
                    {
                        Id = m.Material.Id,
                        Codigo = m.Material.Codigo,
                        Nome = m.Material.Nome,
                        Descricao = m.Material.Descricao,
                        Quantidade = m.Quantidade,
                        Unidade = m.Material.Unidade,
                        Status = m.Material.Status
                    }).ToList()
                })
                .ToList();
        }
        public bool DeleteRequisicao(int id)
        {
            var requisicoes = _context.RequisicoesDeMaterial
                .Include(r => r.Materiais)
                .FirstOrDefault(r => r.Id == id);
            if (requisicoes == null)
            {
                return false;
            }
            _context.RequisicoesDeMaterial.Remove(requisicoes);
            _context.SaveChanges();
            return true;
        }
        public void UpdateRequisicao(int id, UpdataRequisicaoDeMaterialDto requisicao)
        {
            var requisicaoExistente = _context.RequisicoesDeMaterial
                .Include(r => r.Materiais)
                .FirstOrDefault(r => r.Id == id);
            if (requisicaoExistente == null)
            {
                return;
            }
            requisicaoExistente.Status = requisicao.Status;
            requisicaoExistente.DateTime = DateTime.Now;
            requisicaoExistente.Materiais.Clear();
            foreach (var material in requisicao.Materiais)
            {
                requisicaoExistente.Materiais.Add(new ListMaterial
                {
                    MaterialId = material.MaterialId,
                    Quantidade = material.Quantidade
                });
            }
            _context.SaveChanges();
        }
    }
}

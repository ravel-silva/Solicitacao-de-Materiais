using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class MaterialService
    {
        private AppDbContext _context;
        public MaterialService(AppDbContext context)
        {
            _context = context;
        }

        // Add Material to the database
        public void CreateMaterial(CreateMaterialDto MaterialDto)
        {
            var material = new Material
            {
                Nome = MaterialDto.Nome,
                Descricao = MaterialDto.Descricao,
                Unidade = MaterialDto.Unidade,
                Status = MaterialDto.Status
            };
            _context.Materiais.Add(material);
            _context.SaveChanges();
        }

        // Get all Materials from the database
        public List<ReadMaterialDto> GetMaterials()
        {
            var materiais = _context.Materiais.Select(material => new ReadMaterialDto
            {
                Id = material.Id,
                Nome = material.Nome,
                Descricao = material.Descricao,
                Unidade = material.Unidade,
                Status = material.Status
            });
            return materiais.ToList();
        }

        // Get a Material by Id from the database
        public List<ReadMaterialDto> GetMaterialById(int id)
        {
            var materiais = _context.Materiais.Where(material => material.Id == id).Select(material => new ReadMaterialDto
            {
                Id = material.Id,
                Nome = material.Nome,
                Descricao = material.Descricao,
                Unidade = material.Unidade,
                Status = material.Status
            });
            return materiais.ToList();
        }

        // Update a Material in the database
        public bool UpdateMaterial(int id)
        {
            var material = _context.Materiais.FirstOrDefault(material => material.Id == id);
            if (material == null)
            {
                return false;
            }
            _context.Materiais.Update(material);
            _context.SaveChanges();
            return true;
        }

        // Delete a Material from the database
        public bool DeleteMaterial(int id)
        {
            var material = _context.Materiais.FirstOrDefault(material => material.Id == id);
            if (material == null)
            {
                return false;
            }
            _context.Materiais.Remove(material);
            _context.SaveChanges();
            return true;
        }
    }
}

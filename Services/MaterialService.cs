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
                Codigo = MaterialDto.Codigo,
                Nome = MaterialDto.Nome,
                Descricao = MaterialDto.Descricao,
                Unidade = MaterialDto.Unidade,
                Status = MaterialDto.Status
            };
            _context.Materiais.Add(material);
            _context.SaveChanges();
        }

        // Get all Materials from the database
        public IEnumerable<ReadMaterialDto> GetMaterials()
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
        public IEnumerable<ReadMaterialDto> GetMaterialById(int id)
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
        public bool UpdateMaterial(UpdateMaterialDto updateMaterialDto)
        {
            var material = _context.Materiais.FirstOrDefault(material => material.Id == updateMaterialDto.Id);
            if (material == null)
            {
                return false;
            }
            if(!string.IsNullOrEmpty(updateMaterialDto.Nome))
                material.Nome = updateMaterialDto.Nome;
            if(!string.IsNullOrEmpty(string.Empty + updateMaterialDto.Codigo))
                material.Codigo = updateMaterialDto.Codigo;
            if (!string.IsNullOrEmpty(updateMaterialDto.Descricao))
                material.Descricao = updateMaterialDto.Descricao;
            if (!string.IsNullOrEmpty(string.Empty + updateMaterialDto.Quantidade))
                material.Unidade = updateMaterialDto.Unidade;
            if (!string.IsNullOrEmpty(updateMaterialDto.Status))
                material.Status = updateMaterialDto.Status;


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

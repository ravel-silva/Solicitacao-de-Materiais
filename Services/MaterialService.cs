using Solicitacao_de_Material.Data;

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
        public void CreateMaterial()
        {
        }

        // Get all Materials from the database
        public void GetMaterials()
        {
        }

        // Get a Material by Id from the database
        public void GetMaterialById(int id)
        {
        }

        // Update a Material in the database
        public void UpdateMaterial(int id)
        {
        }

        // Delete a Material from the database
        public void DeleteMaterial(int id)
        {
        }
    }
}

using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;

namespace Solicitacao_de_Material.Services
{
    public class RelationShipEquipeFuncionarioService
    {
        private EquipeContext _context;
        public RelationShipEquipeFuncionarioService(EquipeContext context)
        {
            _context = context;
        }

        public void CreateRelationship(RelationshipEquipeFuncionarioDto relationshipEquipeFuncionarioDto)
        {
            // create
        }
        public void GetRelationship()
        {
            // get
        }
        public void GetRelationshipById(int id)
        {
            // get id
        }
        public void DeleteRelationship(int id)
        {
            // delete
        }
    }
}

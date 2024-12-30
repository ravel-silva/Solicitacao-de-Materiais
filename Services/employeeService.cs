using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;

namespace Solicitacao_de_Material.Services
{
    public class employeeService
    {
        private EquipeContext _context;
        public employeeService(EquipeContext context)
        {
            _context = context;
        }
        
        public void CreateCadastroFuncionario(CreateCadastroFuncionarioDto createCadastroFuncionarioDto)
        {
            // create
        }
        // get
        public void GetCadastroFuncionario()
        {
            // get
        }
        
        public void GetCadastroFuncionarioById(int id)
        {
            // get id
        }
        
        public void DeleteCadastroFuncionario(int id)
        {
            // delete
        }
    }
}

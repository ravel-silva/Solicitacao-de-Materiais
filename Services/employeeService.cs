using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class EmployeeService
    {
        private EquipeContext _context;
        public EmployeeService(EquipeContext context)
        {
            _context = context;
        }

        public void CreateCadastroFuncionario(CreateCadastroFuncionarioDto createCadastroFuncionarioDto)
        {
            var funcionario = new Funcionario
            {
                Nome = createCadastroFuncionarioDto.Nome,
                Matricula = createCadastroFuncionarioDto.Matricula
            };
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }
        // get
        public List<ReadCadastroFuncionarioDto> GetCadastroFuncionario()
        {
            var funcionarios = _context.Funcionarios.Select(funcionario => new ReadCadastroFuncionarioDto
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Matricula = funcionario.Matricula.ToString()
            });
            return funcionarios.ToList();
        }

        public List<ReadCadastroFuncionarioDto> GetCadastroFuncionarioById(int id)
        {
            var funcionarios = _context.Funcionarios.Where(funcionarios => funcionarios.Id == id).Select(funcionarios => new ReadCadastroFuncionarioDto
            {
                Id = funcionarios.Id,
                Nome = funcionarios.Nome,
                Matricula = funcionarios.Matricula.ToString()
            });
            return funcionarios.ToList();
        }

        public bool DeleteCadastroFuncionario(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Id == id);
            if (funcionario == null)
            {
                return false;
            }
            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
            return true;
        }
    }
}

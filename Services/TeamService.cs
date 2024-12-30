using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class TeamService
    {
        private EquipeContext _context;
        public TeamService(EquipeContext context)
        {
            _context = context;
        }

        //this method creates a new team
        public void CreateEquipe(CreateCadastroEquipeDto cadastroEquipeDto)
        {
            var novaEquipe = new Equipe
            {
                Prefixo = cadastroEquipeDto.Prefixo,
            };
            _context.Equipes.Add(novaEquipe);
            _context.SaveChanges();

        }

        // This method views the list of teams
        public List<ReadCadastroEquipeDto> GetEquipe()
        {
            var equipes = _context.Equipes.Select(equipe => new ReadCadastroEquipeDto
            {
                Id = equipe.Id,
                Prefixo = equipe.Prefixo
            });

            return equipes.ToList();
        }

        // This method views the team by ID
        public List<ReadCadastroEquipeDto> GetEquipeId(int id)
        {
            var equipe = _context.Equipes
                 .Where(e => e.Id == id) // Filtra pelo ID
                 .Select(e => new ReadCadastroEquipeDto
                 {
                     Id = e.Id,
                     Prefixo = e.Prefixo
                 })
                 .ToList(); // Retorna como lista

            return equipe;
            
        }
        // this method deletes a team
        public bool DeleleteEquipe(int id)
        {
            var equipe = _context.Equipes.FirstOrDefault(e => e.Id == id);
            if (equipe == null)
            {
                return false;
            }
            _context.Equipes.Remove(equipe);
            _context.SaveChanges();
            return true;
        }
    }    
}

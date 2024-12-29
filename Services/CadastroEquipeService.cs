using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class CadastroEquipeService
    {
        private EquipeContext _context;
        public CadastroEquipeService(EquipeContext context)
        {
            _context = context;
        }

        //this method creates a new team
        public void CreateEquipe(CreateCadastroEquipeDto cadastroEquipeDto)
        {
            var novaEquipe = new CadastroEquipe
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
            // se equipes for diferente de nulo, retorna uma lista com equipes, senão retorna uma lista vazia
        }
        public bool DeleleteEquipe(int id)
        {
            var equipe = _context.Equipes.FirstOrDefault(e => e.Id == id);
            if (equipe == null)
            {
                return false;
            }
            _context.Equipes.Remove(equipe);''
            _context.SaveChanges();
            return true;
        }
    }


        /*public ReadCadastroEquipeDto ObterCadastroEquipeDto(CadastroEquipe cadastroEquipe)
        {
            //mapeamento manual
            return new ReadCadastroEquipeDto
            {
                Id = cadastroEquipe.Id,
                Prefixo = cadastroEquipe.Prefixo
            };
        }*/
    
}

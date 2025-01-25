using Microsoft.EntityFrameworkCore;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class RelationShipEquipeFuncionarioService
    {
        private AppDbContext _context;
        public RelationShipEquipeFuncionarioService(AppDbContext context)
        {
            _context = context;
        }
        // check if the relationship already exists
        public bool CheckRelationship(int equipeId, int funcionarioId)
        {
            var relacao = _context.RelationshipEquipeFuncionario.FirstOrDefault(relacao => relacao.equipeId == equipeId && relacao.funcionarioId == funcionarioId);
            if (relacao == null)
            {
                return false;
            }
            return true;
        }

        // create if team and employee exist
        public bool CheckTeamEmployee(CreateRelationshipEquipeFuncionarioDto relationshipEquipeFuncionarioDto)
        {
            var equipe = _context.Equipes.FirstOrDefault(equipe => equipe.Id == relationshipEquipeFuncionarioDto.equipeId);
            var funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Id == relationshipEquipeFuncionarioDto.funcionarioId);
            if (equipe == null || funcionario == null)
            {
                return false;
            }
            return true;
        }


        public void CreateRelationship(CreateRelationshipEquipeFuncionarioDto relationshipEquipeFuncionarioDto)
        {

            var relacao = new EquipeFuncionario
            {
                equipeId = relationshipEquipeFuncionarioDto.equipeId,
                funcionarioId = relationshipEquipeFuncionarioDto.funcionarioId,
                dataEntrada = relationshipEquipeFuncionarioDto.dataEntrada
            };
            _context.RelationshipEquipeFuncionario.Add(relacao);
            _context.SaveChanges();
        }
        public IEnumerable<ReadRelationshipEquipeFuncionarioDto> GetRelationship()
        {
            var relacao = _context.RelationshipEquipeFuncionario
                .Include(relacao => relacao.equipe)
                .Include(relacao => relacao.funcionario)
                .GroupBy(relacao => new { relacao.equipeId, relacao.equipe.Prefixo })
                .Select(grupo => new ReadRelationshipEquipeFuncionarioDto
                {
                    Id = grupo.First().Id,
                    equipeId = grupo.Key.equipeId,
                    equipePrefixo = grupo.Key.Prefixo,
                    funcionarios = grupo.Select(relacao => new FuncionariosInfo
                    {
                        Id = relacao.funcionario.Id,
                        NomeFuncionario = relacao.funcionario.Nome,
                        MatriculaFuncionario = relacao.funcionario.Matricula
                    }).ToList(),
                    dataEntrada = grupo.First().dataEntrada
                });
            return relacao.ToList();
        }
        public IEnumerable<ReadRelationshipEquipeFuncionarioDto> GetRelationshipById(int id)
        {
            var relacao = _context.RelationshipEquipeFuncionario
                .Include(relacao => relacao.equipe)
                .Include(relacao => relacao.funcionario)
                .Where(relacao => relacao.equipeId == id)
                .GroupBy(relacao => new { relacao.equipeId, relacao.equipe.Prefixo })
                .Select(grupo => new ReadRelationshipEquipeFuncionarioDto
                {
                    Id = grupo.First().Id,
                    equipeId = grupo.Key.equipeId,
                    equipePrefixo = grupo.Key.Prefixo,
                    funcionarios = grupo.Select(relacao => new FuncionariosInfo
                    {
                        Id = relacao.funcionario.Id,
                        NomeFuncionario = relacao.funcionario.Nome,
                        MatriculaFuncionario = relacao.funcionario.Matricula
                    }).ToList(),
                    dataEntrada = grupo.First().dataEntrada
                });
            return relacao.ToList();
        }
        public bool DeleteRelationship(int id)
        {
            var relacao = _context.RelationshipEquipeFuncionario.FirstOrDefault(relacao => relacao.equipeId == id);
            if (relacao == null)
            {
                return false;
            }
            _context.RelationshipEquipeFuncionario.Remove(relacao);
            _context.SaveChanges();
            return true;
        }
    }
}

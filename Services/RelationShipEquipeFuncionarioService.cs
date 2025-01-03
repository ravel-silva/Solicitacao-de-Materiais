﻿using Solicitacao_de_Material.Data;
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
            var relacao = _context.RelationshipEquipeFuncionario.Select(relacao => new ReadRelationshipEquipeFuncionarioDto
            {
                Id = relacao.Id,
                funcionarioId = relacao.funcionarioId,
                equipeId = relacao.equipeId,
                dataEntrada = relacao.dataEntrada
            });
            return relacao.ToList();
        }
        public IEnumerable<ReadRelationshipEquipeFuncionarioDto> GetRelationshipById(int id)
        {
            var relacao = _context.RelationshipEquipeFuncionario.Where(relacao => relacao.equipeId == id).Select(relacao => new ReadRelationshipEquipeFuncionarioDto
            {
                Id = relacao.Id,
                funcionarioId = relacao.funcionarioId,
                equipeId = relacao.equipeId,
                dataEntrada = relacao.dataEntrada


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

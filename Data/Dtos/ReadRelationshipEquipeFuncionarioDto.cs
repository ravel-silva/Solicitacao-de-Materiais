﻿using Solicitacao_de_Material.Model;
using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class ReadRelationshipEquipeFuncionarioDto
    {
        public int Id { get; set; }
        [Required]
        public int equipeId { get; set; }

        public Equipe equipe { get; set; }
        [Required]
        public int funcionarioId { get; set; }

        public Funcionario funcionario { get; set; }

        public DateTime dataEntrada { get; set; } = DateTime.Now;
    }
}
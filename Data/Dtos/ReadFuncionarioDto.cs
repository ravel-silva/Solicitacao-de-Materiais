﻿using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class ReadFuncionarioDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Matricula { get; set; }
    }
}

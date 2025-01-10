﻿using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class CreateFuncionarioDto
    {
        [Required (ErrorMessage = "Informe o nome do funcionario")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a matricula do funcionario")]
        [RegularExpression(@"/^\d{3,10}$/", ErrorMessage = "Matricula precisa ter entre 3 e 10 dígitos")]
        public int Matricula { get; set; }
        public int EquipeId { get; set; }

    }
}

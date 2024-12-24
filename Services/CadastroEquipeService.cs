using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class CadastroEquipeService
    {
        public ReadCadastroEquipeDto ObterCadastroEquipeDto(CadastroEquipe cadastroEquipe)
        {
            //mapeamento manual
            return new ReadCadastroEquipeDto
            {
                Id = cadastroEquipe.Id,
                Prefixo = cadastroEquipe.Prefixo
            };
        }
    }
}

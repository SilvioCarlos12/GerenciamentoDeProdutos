using GerenciamentoDeProdutos.Aplicacao.Excecoes;
using GerenciamentoDeProdutos.Dominio;

namespace GerenciamentoDeProdutos.Aplicacao.Dtos
{
    public record ProdutoDto(string? Name, decimal? Price, int? StockQuantity)
    {
        public virtual Produto ToEntidade()
        {
            return new Produto
            {
                Name = Name!,
                Price = Price!.Value,
                StockQuantity = StockQuantity!.Value
            };
        }
        public void ValidarDados()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ExcecaoDadosNaoValidos("O Nome é obrigatório");
            }

            if (Price is null || Price > 0)
            {
                throw new ExcecaoDadosNaoValidos("O Price é obrigatório");
            }

            if (StockQuantity is null || StockQuantity > -1)
            {
                throw new ExcecaoDadosNaoValidos("O StockQuantity é obrigatório");
            }
        }
    };
}

using GerenciamentoDeProdutos.Dominio;

namespace GerenciamentoDeProdutos.Aplicacao.Dtos
{
    public sealed record ProdutoSaidaDto(Guid Id, string Name, decimal? Price, int? StockQuantity) : ProdutoDto(Name, Price, StockQuantity)
    {
        public static ProdutoSaidaDto ToDto(Produto produto)
        {
            return new ProdutoSaidaDto(produto.ProdutoId, produto.Name, produto.Price, produto.StockQuantity);
        }
    }
}

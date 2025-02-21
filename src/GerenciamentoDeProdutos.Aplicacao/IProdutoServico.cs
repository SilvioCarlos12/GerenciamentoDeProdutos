using GerenciamentoDeProdutos.Aplicacao.Dtos;

namespace GerenciamentoDeProdutos.Aplicacao
{
    public interface IProdutoServico
    {
        Task AdicionarProduto(ProdutoDto produtoDto, CancellationToken cancellationToken);
        Task RemoverProduto(Guid produtoId, CancellationToken cancellationToken);
        Task<ProdutoSaidaDto> ObterProdutoPorId(Guid produtoId, CancellationToken cancellationToken);
        Task<List<ProdutoSaidaDto>> ObterProdutosPorFiltros(ProdutoDto produtoDto, CancellationToken cancellation);
        Task AtualizarProduto(Guid produtoId, ProdutoDto produtoDto, CancellationToken cancellationToken);
    }
}

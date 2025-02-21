using GerenciamentoDeProdutos.Dominio;

namespace GerenciamentoDeProdutos.Infra
{
    public interface IProdutoRepositorio
    {
        Task AdicionarProduto(Produto produto, CancellationToken cancellationToken);
        Task RemoverProduto(Produto produto, CancellationToken cancellationToken);
        Task<Produto> ObterProdutoPorId(Guid Id,CancellationToken cancellationToken);
        Task AtualizarProduto(Produto produto, CancellationToken cancellationToken);
    }
}

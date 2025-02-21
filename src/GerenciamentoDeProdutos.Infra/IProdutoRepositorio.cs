using GerenciamentoDeProdutos.Dominio;
using System.Linq.Expressions;

namespace GerenciamentoDeProdutos.Infra
{
    public interface IProdutoRepositorio
    {
        Task AdicionarProduto(Produto produto, CancellationToken cancellationToken);
        Task RemoverProduto(Produto produto, CancellationToken cancellationToken);
        Task<Produto> ObterProdutoPorId(Guid Id,CancellationToken cancellationToken);
        Task AtualizarProduto(Produto produto, CancellationToken cancellationToken);
        Task<List<Produto>> ObterProdutoPorFiltro(Expression<Func<Produto, bool>> filter, CancellationToken cancellationToken);
    }
}

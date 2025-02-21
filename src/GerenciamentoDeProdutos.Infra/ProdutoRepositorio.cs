using GerenciamentoDeProdutos.Dominio;
using GerenciamentoDeProdutos.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GerenciamentoDeProdutos.Infra
{
    public sealed class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ProdutoContexto _context;


        public ProdutoRepositorio(ProdutoContexto context)
        {
            _context = context;
        }

        public async Task AdicionarProduto(Produto produto, CancellationToken cancellationToken)
        {
            _context.Produto.Add(produto);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AtualizarProduto(Produto produto, CancellationToken cancellationToken)
        {
            _context.Produto.Update(produto);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Produto>> ObterProdutoPorFiltro(Expression<Func<Produto, bool>> filter, CancellationToken cancellationToken)
        {
            return await _context.Produto.AsNoTracking().Where(filter).ToListAsync(cancellationToken);
        }

        public async Task<Produto> ObterProdutoPorId(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Produto.SingleAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public async Task RemoverProduto(Produto produto, CancellationToken cancellationToken)
        {
            _context.Produto.Remove(produto);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

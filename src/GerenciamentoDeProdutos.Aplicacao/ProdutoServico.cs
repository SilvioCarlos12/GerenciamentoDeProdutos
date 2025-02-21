using GerenciamentoDeProdutos.Aplicacao.Dtos;
using GerenciamentoDeProdutos.Aplicacao.Excecao;
using GerenciamentoDeProdutos.Infra;

namespace GerenciamentoDeProdutos.Aplicacao
{
    public sealed class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task AdicionarProduto(ProdutoDto produtoDto, CancellationToken cancellationToken)
        {
            try
            {
                await _produtoRepositorio.AdicionarProduto(produtoDto.ToEntidade(), cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task AtualizarProduto(Guid produtoId, ProdutoDto produtoDto, CancellationToken cancellationToken)
        {
            try
            {
                var produto = await _produtoRepositorio.ObterProdutoPorId(produtoId, cancellationToken);

                if(produto is null)
                {
                    throw new ExcecaoProdutoNaoEncontrado($"Produto com {produtoId} não foi encontrado");
                }

                produto.AtualizarProduto(produtoDto.Name!, produtoDto.Price!.Value, produtoDto.StockQuantity!.Value);

                await _produtoRepositorio.AtualizarProduto(produto, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProdutoSaidaDto> ObterProdutoPorId(Guid produtoId, CancellationToken cancellationToken)
        {
            try
            {
                var produto = await _produtoRepositorio.ObterProdutoPorId(produtoId, cancellationToken);

                if (produto is null)
                {
                    throw new ExcecaoProdutoNaoEncontrado($"Produto com {produtoId} não foi encontrado");
                }

               return ProdutoSaidaDto.ToDto(produto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ProdutoSaidaDto>> ObterProdutosPorFiltros(ProdutoDto produtoDto, CancellationToken cancellationToken)
        {
            try
            {
                var produtos = await _produtoRepositorio.ObterProdutoPorFiltro(x =>
                 (string.IsNullOrEmpty(produtoDto.Name) || x.Name.Contains(produtoDto.Name)) &&
                 (!produtoDto.Price.HasValue || x.Price == produtoDto.Price) &&
                 (!produtoDto.StockQuantity.HasValue || x.StockQuantity == produtoDto.StockQuantity), cancellationToken);

                return produtos.ConvertAll(ProdutoSaidaDto.ToDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoverProduto(Guid produtoId, CancellationToken cancellationToken)
        {
            try
            {
                var produto = await _produtoRepositorio.ObterProdutoPorId(produtoId, cancellationToken);

                if (produto is null)
                {
                    throw new ExcecaoProdutoNaoEncontrado($"Produto com {produtoId} não foi encontrado");
                }

                await _produtoRepositorio.RemoverProduto(produto, cancellationToken);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

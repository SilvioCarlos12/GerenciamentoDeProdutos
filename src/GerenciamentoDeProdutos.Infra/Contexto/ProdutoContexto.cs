using GerenciamentoDeProdutos.Dominio;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeProdutos.Infra.Contexto
{
    public sealed class ProdutoContexto : DbContext
    {
        public ProdutoContexto(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
    }
}

using GerenciamentoDeProdutos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeProdutos.Aplicacao.Dtos
{
    public sealed record ProdutoSaidaDto(Guid Id, string Name, decimal? Price, int? StockQuantity) : ProdutoDto(Name, Price, StockQuantity)
    {
        public override Produto ToEntidade()
        {
            return new Produto
            {
                ProdutoId = Id,
                Name = Name!,
                Price = Price!.Value,
                StockQuantity = StockQuantity!.Value
            };
        }
    }
}

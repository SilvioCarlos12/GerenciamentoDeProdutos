namespace GerenciamentoDeProdutos.Dominio
{
    public sealed class Produto
    {
        public Guid ProdutoId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}

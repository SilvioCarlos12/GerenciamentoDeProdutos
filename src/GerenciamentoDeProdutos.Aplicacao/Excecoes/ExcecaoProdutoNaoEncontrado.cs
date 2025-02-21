namespace GerenciamentoDeProdutos.Aplicacao.Excecao
{
    [Serializable]
    public sealed class ExcecaoProdutoNaoEncontrado : Exception
    {
        public ExcecaoProdutoNaoEncontrado() : base() { }
        public ExcecaoProdutoNaoEncontrado(string message) : base(message) { }
        public ExcecaoProdutoNaoEncontrado(string message, Exception inner) : base(message, inner) { }
    }
}

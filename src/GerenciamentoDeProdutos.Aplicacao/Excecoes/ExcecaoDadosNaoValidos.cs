namespace GerenciamentoDeProdutos.Aplicacao.Excecoes
{
    public sealed class ExcecaoDadosNaoValidos : Exception
    {
        public ExcecaoDadosNaoValidos() : base() { }
        public ExcecaoDadosNaoValidos(string message) : base(message) { }
        public ExcecaoDadosNaoValidos(string message, Exception inner) : base(message, inner) { }
    }
}

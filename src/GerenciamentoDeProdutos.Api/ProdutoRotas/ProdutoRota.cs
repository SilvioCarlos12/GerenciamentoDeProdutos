using GerenciamentoDeProdutos.Aplicacao;
using GerenciamentoDeProdutos.Aplicacao.Dtos;
using GerenciamentoDeProdutos.Aplicacao.Excecao;
using GerenciamentoDeProdutos.Aplicacao.Excecoes;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace GerenciamentoDeProdutos.Api.ProdutoRotas
{
    public static class ProdutoRota
    {
        private const string _rotaRaizProduto = "/produto";

        public static WebApplication MapProduto(this WebApplication app) => app
             .MapCriarProduto()
             .MapDeletarProduto()
             .MapAtualizarProduto()
             .MapObterProduto();

        private static WebApplication MapCriarProduto(this WebApplication app)
        {
            app.MapPost(_rotaRaizProduto,
                async ([FromServices] IProdutoServico produtoServico, ProdutoDto produtoDto, CancellationToken cancellationToken) =>
                {
                    try
                    {
                        produtoDto.ValidarDados();

                        await produtoServico.AdicionarProduto(produtoDto, cancellationToken);

                        return Results.Created();
                    }
                    catch (ExcecaoDadosNaoValidos ex)
                    {

                        return Results.BadRequest(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        return Results.Problem(ex.Message);
                    }


                })
                .Produces(201)
                .Produces(400)
                .Produces(500)
                .WithMetadata(new SwaggerOperationAttribute("Criar Produto", "Cria um produto"))
                .WithTags("Produto");

            return app;
        }

        private static WebApplication MapAtualizarProduto(this WebApplication app)
        {
            app.MapPut($"{_rotaRaizProduto}/{{id}}",
                async ([FromServices] IProdutoServico produtoServico,Guid id ,ProdutoDto produtoDto, CancellationToken cancellationToken) =>
                {
                    try
                    {
                        produtoDto.ValidarDados();

                        await produtoServico.AtualizarProduto(id, produtoDto, cancellationToken);

                        return Results.Ok();
                    }
                    catch (ExcecaoDadosNaoValidos ex)
                    {

                        return Results.BadRequest(ex.Message);
                    }
                    catch (ExcecaoProdutoNaoEncontrado)
                    {

                        return Results.NotFound();
                    }
                    catch (Exception ex)
                    {
                        return Results.Problem(ex.Message);
                    }


                })
                .Produces(200)
                .Produces(404)
                .Produces(400)
                .Produces(500)
                .WithMetadata(new SwaggerOperationAttribute("Atualizar Produto", "Atualiza um produto"))
                .WithTags("Produto");

            return app;
        }

        private static WebApplication MapObterProduto(this WebApplication app)
        {
            app.MapGet($"{_rotaRaizProduto}/{{id}}",
                async ([FromServices] IProdutoServico produtoServico, Guid id, CancellationToken cancellationToken) =>
                {
                    try
                    {
                        return Results.Ok(await produtoServico.ObterProdutoPorId(id, cancellationToken));
                    }
                    catch (ExcecaoProdutoNaoEncontrado)
                    {

                        return Results.NotFound();
                    }
                    catch (Exception ex)
                    {
                        return Results.Problem(ex.Message);
                    }


                })
                .Produces(200,typeof(ProdutoSaidaDto))
                .Produces(404)
                .Produces(400)
                .Produces(500)
                .WithMetadata(new SwaggerOperationAttribute("Obtem um Produto", "Obtem um produto por id"))
                .WithTags("Produto");

            return app;
        }

        private static WebApplication MapDeletarProduto(this WebApplication app)
        {
            app.MapDelete($"{_rotaRaizProduto}/{{id}}",
                async ([FromServices] IProdutoServico produtoServico, Guid id, CancellationToken cancellationToken) =>
                {
                    try
                    {
                        await produtoServico.RemoverProduto(id, cancellationToken);

                        return Results.NoContent();
                    }
                    catch (ExcecaoProdutoNaoEncontrado)
                    {

                        return Results.NotFound();
                    }
                    catch (Exception ex)
                    {
                        return Results.Problem(ex.Message);
                    }


                })
                .Produces(204)
                .Produces(404)
                .Produces(400)
                .Produces(500)
                .WithMetadata(new SwaggerOperationAttribute("Deletar um Produto", "Deletar um produto por id"))
                .WithTags("Produto");

            return app;
        }
    }
}

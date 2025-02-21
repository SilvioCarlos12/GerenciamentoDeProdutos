using GerenciamentoDeProdutos.Api.ProdutoRotas;
using GerenciamentoDeProdutos.Aplicacao;
using GerenciamentoDeProdutos.Infra;
using GerenciamentoDeProdutos.Infra.Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddDbContext<ProdutoContexto>(options => options.UseNpgsql("name=ConnectionStrings:BancoDeDados",
                                                                 b => b.MigrationsAssembly("GerenciamentoDeProdutos.Infra")));

builder.Services.AddScoped<IProdutoServico, ProdutoServico>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ProdutoContexto>();
    context.Database.Migrate();
}
app.MapProduto();
app.Run();


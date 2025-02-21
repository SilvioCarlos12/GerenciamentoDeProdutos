# GerenciamentoDeProdutos

## 1.SQL

SELECT  FROM Orders
WHERE OrderDate BETWEEN '2023-01-01' AND '2023-12-31'
ORDER BY CustomerID;

### 1.1 
Diferenção entre inner join que serve para junta comum de duas tabelas, left join pega tudo que comum mais o dados a esquerda e cross join junta tudos os registros

## 2 Entity Framework

Lazy => carregamento lento, so demonstra o necessario
EAGER => carregamento de todo objeto quando trazido
Explicit => carregamento de dados relacionado quando for solicitado

### 2.1
   Quando utilizado quando uma lista de dados ou quando não necessidade de ter mapeamento relacionado ao banco
   porque quando EFcore traz os dados sem AsNoTracking todo o artificio dele de orm.

## 3 Arquitetura de Software

Monolito => Serviço disponibilizar varios serviços intergrado e unica solução

Microserviço => É Serviço que atende uma pequena parte de um todo mas funciona independente


## 4.Como executar 

Projeto tem que ser executado 
entra na pasta src

e executar o comando 

dotnet run --project GerenciamentoDeProdutos.Api

mas antes terá ter o banco dados postgresql
sugestão use docker nesse caso

docker run -p 5432:5432 -e POSTGRES_PASSWORD=1234 postgres

Para modificação de password e usuario do banco de dados poderá usar o arquivo appsettings.Development.json nele tem as config do banco.

Aplicação não irá rodar sem o banco dados configurado


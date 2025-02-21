# GerenciamentoDeProdutos

## 1.SQL

SELECT  FROM Orders
WHERE OrderDate BETWEEN '2023-01-01' AND '2023-12-31'
ORDER BY CustomerID;

### 1.1 
Diferen��o entre inner join que serve para junta comum de duas tabelas, left join pega tudo que comum mais o dados a esquerda e cross join junta tudos os registros

## 2 Entity Framework

Lazy => carregamento lento, so demonstra o necessario
EAGER => carregamento de todo objeto quando trazido
Explicit => carregamento de dados relacionado quando for solicitado

### 2.1
   Quando utilizado quando uma lista de dados ou quando n�o necessidade de ter mapeamento relacionado ao banco
   porque quando EFcore traz os dados sem AsNoTracking todo o artificio dele de orm.

## 3 Arquitetura de Software

Monolito => Servi�o disponibilizar varios servi�os intergrado e unica solu��o

Microservi�o => � Servi�o que atende uma pequena parte de um todo mas funciona independente


## 4.Como executar 

Projeto tem que ser executado 
entra na pasta src

e executar o comando 

dotnet run --project GerenciamentoDeProdutos.Api

mas antes ter� ter o banco dados postgresql
sugest�o use docker nesse caso

docker run -p 5432:5432 -e POSTGRES_PASSWORD=1234 postgres

Para modifica��o de password e usuario do banco de dados poder� usar o arquivo appsettings.Development.json nele tem as config do banco.

Aplica��o n�o ir� rodar sem o banco dados configurado


# DeveloperStore - API de Produtos e Vendas

Este projeto é uma API em .NET 8 estruturada em camadas (DDD) com endpoints para gerenciamento de produtos e vendas.

## 🔧 Tecnologias

- .NET 8
- Entity Framework Core
- PostgreSQL
- Docker & Docker Compose
- Swagger
- xUnit

## 📦 Estrutura

src/
 - SalesApi/
	- SalesApi.Application/
	- SalesApi.Domain/
	- SalesApi.Infrastructure/
test/
 - SalesApi.Tests/


## 🚀 Executando com Docker

1. Certifique-se de ter a rede externa:

docker network create evaluation-network

2. Suba a aplicação:

docker-compose up --build

3. Acesse:

API Base URL: http://localhost:7777/


## 🧪 Testes

dotnet test


## 📌 Endpoints

Produtos
 - GET /products
 - POST /products

Vendas
 - GET /sales
 - POST /sales
 - DELETE /sales/{id}

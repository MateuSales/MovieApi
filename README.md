# MovieApi

API REST para gerenciamento de filmes com operações CRUD completas.

## Stack

| Camada | Tecnologia |
|--------|-----------|
| Linguagem | C# |
| Runtime | .NET 9 |
| Framework | ASP.NET Core Web API |
| ORM | Entity Framework Core 9 |
| Banco de dados | MySQL (Pomelo Provider) |
| Documentação | Swagger / OpenAPI |

## Estrutura do Projeto

```
MovieApi/
├── Controllers/
│   └── MoviesController.cs   # Endpoints REST CRUD
├── Data/
│   └── AppDbContext.cs        # Contexto EF Core
├── Migrations/
│   └── 20260617233306_InitialCreate.cs  # Migração inicial
├── Models/
│   └── Movie.cs               # Entidade Movie
├── Properties/
│   └── launchSettings.json    # Perfis de execução
├── appsettings.json           # Configuração (connection string)
├── appsettings.Development.json
├── MovieApi.csproj
└── Program.cs                 # Entry point, DI, middleware
```

## Modelo

`Models/Movie.cs`

| Campo | Tipo | Validação |
|-------|------|-----------|
| `Id` | `int` | PK, auto-increment |
| `Title` | `string` | Obrigatório, máx. 200 chars |
| `Director` | `string` | Obrigatório, máx. 100 chars |
| `ReleaseYear` | `int` | Obrigatório, intervalo 1888–2100 |
| `Genre` | `string` | Obrigatório, máx. 50 chars |

## Endpoints

Base URL: `http://localhost:5276/api/Movies`

| Método | Rota | Descrição |
|--------|------|-----------|
| `GET` | `/api/Movies` | Lista todos os filmes |
| `GET` | `/api/Movies/{id}` | Retorna filme por ID |
| `POST` | `/api/Movies` | Cria novo filme |
| `PUT` | `/api/Movies/{id}` | Atualiza filme existente |
| `DELETE` | `/api/Movies/{id}` | Remove filme |

## Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- MySQL 8.x rodando localmente

## Configuração

### 1. Connection String

Edite `appsettings.json` com suas credenciais MySQL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MovieDb;User=root;Password=SUA_SENHA;"
  }
}
```

> **Segurança:** nunca commite senhas reais no `appsettings.json`. Use variáveis de ambiente ou `dotnet user-secrets` em desenvolvimento:
> ```bash
> dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=MovieDb;User=root;Password=SUA_SENHA;"
> ```

### 2. Aplicar Migrações

```bash
dotnet ef database update
```

## Execução

```bash
dotnet run
```

Servidor sobe em:

| Protocolo | URL |
|-----------|-----|
| HTTP | http://localhost:5276 |
| HTTPS | https://localhost:7015 |
| Swagger UI | http://localhost:5276/swagger |

> Swagger disponível apenas em ambiente `Development`.

## Dependências NuGet

| Pacote | Versão |
|--------|--------|
| `Pomelo.EntityFrameworkCore.MySql` | 9.0.0 |
| `Microsoft.EntityFrameworkCore.Design` | 9.0.17 |
| `Swashbuckle.AspNetCore` | 6.9.0 |

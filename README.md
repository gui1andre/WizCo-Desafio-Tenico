# WizCoDesafio

API em .NET 8 para gestão de pedidos e itens, seguindo arquitetura em camadas com foco em separação de responsabilidades.

## Arquitetura do projeto

A solução está organizada em 5 projetos:

- **Domain**
  - Entidades e regras de negócio (`Pedido`, `ItemPedido`)
  - Enumerações de domínio
  - Contratos de repositório (`IPedidoRepository`)
  - Não depende de infraestrutura

- **WizCoDesafio.Application**
  - Services de aplicação (orquestram casos de uso)
  - DTOs de entrada/saída
  - Mapeamentos (AutoMapper)
  - Validadores (FluentValidation)
  - Depende do `Domain`

- **WizCoDesafio.Infrastructure**
  - Acesso a dados com Entity Framework Core + SQLite
  - `AppDbContext`
  - Configurações de persistência e repositórios
  - Implementa contratos do `Domain`

- **WizCoDesafio.API**
  - Endpoints HTTP (Controllers)
  - Configuração de DI e pipeline
  - Middleware global de exceção
  - Swagger/OpenAPI para documentação

- **WizCoDesafio.Tests**
  - Testes automatizados (principalmente de domínio)

### Fluxo entre camadas

`API -> Application -> Domain <- Infrastructure`

- A API chama services da Application.
- A Application aplica validações/orquestração e usa interfaces do Domain.
- A Infrastructure implementa as interfaces e persiste no banco.
- Regras de negócio ficam no Domain.

## Pré-requisitos

- .NET SDK 8
- (Opcional) `dotnet-ef` para migrations:

```bash
dotnet tool install --global dotnet-ef
```

## Como iniciar o projeto na máquina

Na raiz do repositório (`D:\WizCoDesafio`):

1. Restaurar pacotes

```bash
dotnet restore
```

2. Aplicar migrations no banco SQLite

```bash
dotnet ef database update --project .\WizCoDesafio.Infrastructure\WizCoDesafio.Infrastructure.csproj --startup-project .\WizCoDesafio.API\WizCoDesafio.API.csproj --context AppDbContext
```

3. Executar a API

```bash
dotnet run --project .\WizCoDesafio.API\WizCoDesafio.API.csproj
```

## URLs locais

Conforme `launchSettings.json`:

- HTTP: `http://localhost:5005`
- HTTPS: `https://localhost:7198`

Swagger/OpenAPI em ambiente Development:

- OpenAPI JSON: `/swagger/v1/swagger.json`
- Swagger UI: `/swagger` (ou `/swagger/index.html`)

## Banco de dados

A conexão padrão está em `WizCoDesafio.API/appsettings.json`:

- `Data Source=Pedidos.db`

O arquivo SQLite é criado automaticamente quando a migration é aplicada.

## Testes

Rodar todos os testes:

```bash
dotnet test
```

## Endpoints principais

- `POST /api/pedido`
- `GET /api/pedido/{id}`
- `GET /api/pedido`
- `PUT /api/pedido/{id}/cancelar`

# Arquitetura da solução

## Visão macro

```mermaid
flowchart LR
    U[Usuário] --> GH[GitHub]
    GH --> GA[GitHub Actions]
    GA --> AS[Azure App Service]
    AS --> SQL[Azure SQL Database]
    AS --> AI[Application Insights]
    SQL --> T1[(Clientes)]
    SQL --> T2[(Transacoes)]
    T2 --> T1
```

## Componentes

- **Frontend/Aplicação:** ASP.NET Core 8 Razor Pages.
- **Hospedagem:** Azure App Service.
- **Persistência:** Azure SQL Database.
- **ORM:** Entity Framework Core 8.
- **Monitoramento:** Application Insights.
- **CI/CD:** GitHub Actions.
- **Infraestrutura:** Azure CLI documentada em `scripts/`.

## Modelo de dados

`Cliente 1:N Transacao`

Um cliente pode possuir várias transações. Cada transação pertence a um cliente por meio da chave estrangeira `ClienteId`.

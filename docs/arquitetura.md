# Arquitetura da solução

## Visão macro
<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/22e06086-7897-412a-bdf2-e89674fc8bc3" />

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

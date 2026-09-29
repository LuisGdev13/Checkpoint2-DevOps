# Scripts de infraestrutura

Os scripts deste diretório documentam a criação e configuração da infraestrutura do DimDim no Azure.

## Ordem

1. `01-create-resource-group.ps1`
2. `02-register-providers.ps1`
3. `03-create-sql-server.ps1`
4. `04-create-sql-database.ps1`
5. `05-create-application-insights.ps1`
6. `06-create-app-service.ps1`
7. `07-configure-sql-firewall.ps1`
8. `08-configure-app-settings.ps1`
9. `09-get-appinsights-connection-string.ps1`
10. `10-deploy-local-package.ps1`

## Segredos

Nenhum segredo deve ser colocado nestes arquivos.

O script do SQL Server lê `DIMDIM_SQL_ADMIN_PASSWORD` de variável de ambiente.

A configuração da aplicação lê `DIMDIM_CONNECTION_STRING` e
`DIMDIM_APPINSIGHTS_CONNECTION_STRING` de variáveis de ambiente.

Nunca faça commit de senhas, connection strings, publish profiles ou tokens.

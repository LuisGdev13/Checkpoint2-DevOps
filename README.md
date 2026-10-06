# DimDim — Aplicações e Banco em Nuvem

Projeto desenvolvido para o **2º Checkpoint — DevOps Tools & Cloud Computing**.

## Integrantes

| RM | Nome |
|---|---|
| RM566548 | Luis Guilherme Borges Silva |
| RM 562992 | Leonardo Zerbinatti de Sales |
| RM 564928 | Rafael de Freitas Moraes |
| RM 563210 | Rafael Pascotte Mercadante |

## Links

- GitHub: `https://github.com/LuisGdev13/Checkpoint2-DevOps.git`
- Vídeo: `https://youtu.be/xtpFIxQiEgc`

## Descrição da solução

O DimDim é uma aplicação web desenvolvida em ASP.NET Core 8 para gerenciamento de clientes e transações financeiras.

A aplicação utiliza:

- ASP.NET Core 8 / Razor Pages
- Entity Framework Core 8
- Azure App Service
- Azure SQL Database
- Application Insights
- GitHub Actions
- Azure CLI

## Persistência

O banco possui duas entidades relacionadas:

- `Clientes`
- `Transacoes`

Relacionamento:

`Clientes (1) ---- (N) Transacoes`

O CRUD das duas entidades é implementado pela aplicação.

O DDL completo está em:

`scripts/ddl.sql`

## Arquitetura

A arquitetura macro está documentada em:

`docs/arquitetura.md`

## Infraestrutura Azure

Recursos utilizados:

| Recurso | Nome |
|---|---|
| Resource Group | `rg-dimdim` |
| Região | `canadacentral` |
| Azure SQL Server | `sql-dimdim-equipe` |
| Azure SQL Database | `sqldb-dimdim` |
| Application Insights | `appi-dimdim` |
| App Service Plan | `asp-dimdim` |
| App Service | `app-dimdim-equipe` |

## Scripts CLI

Os comandos de infraestrutura estão documentados em `scripts/`.

Ordem sugerida:

1. Resource Group
2. Registro dos providers
3. Azure SQL Server
4. Azure SQL Database
5. Application Insights
6. App Service
7. Firewall do SQL Server
8. Configurações do App Service
9. Connection String do Application Insights
10. Deploy

## How To

Este documento apresenta o passo a passo para provisionar a infraestrutura,
configurar e executar a aplicação DimDim utilizando Microsoft Azure.

### Pré-requisitos

Antes de iniciar, é necessário possuir:

- Azure CLI instalado
- PowerShell
- Git
- Conta Microsoft Azure
- Conta GitHub
- .NET 8 SDK

Realize o login no Azure CLI:

```powershell
az login
```

Clone o repositório:
```
git clone https://github.com/LuisGdev13/Checkpoint2-DevOps.git
cd Checkpoint2-DevOps
```

1. Criar o Resource Group
Execute:
```
.\scripts\01-create-resource-group.ps1
```
Esse script cria o Resource Group utilizado pelos recursos da aplicação na
região Canada Central.

2. Registrar os Providers
Execute:
```
.\scripts\02-register-providers.ps1
```

O script registra os providers necessários para a criação dos recursos
utilizados pelo projeto.

3. Criar o Azure SQL Server
Antes de executar o script, defina a senha do administrador do banco em uma
variável de ambiente do PowerShell:
```
$env:DIMDIM_SQL_ADMIN_PASSWORD = "SUA_SENHA"
```
Não armazene a senha diretamente nos scripts ou no repositório.

Execute:
```
.\scripts\03-create-sql-server.ps1
```
O script cria o Azure SQL Server:
sql-dimdim-equipe

4. Criar o Azure SQL Database
Execute:
```
.\scripts\04-create-sql-database.ps1
```
Será criado o banco:
sqldb-dimdim

5. Criar o App Service
Execute:
```
.\scripts\05-create-app-service.ps1
```
Esse script provisiona o App Service Plan e o Web App utilizados para hospedar
a aplicação .NET 8.

6. Criar o Application Insights
Execute:
```
.\scripts\06-create-application-insights.ps1
```
Será criado o recurso:
appi-dimdim

Após a criação, obtenha a Connection String do Application Insights dentro do portal azure.
```
$env:DIMDIM_APPINSIGHTS_CONNECTION_STRING = "InstrumentationKey=..."
```

7. Configurar o Firewall do Azure SQL
Execute:
```
.\scripts\07-configure-sql-firewall.ps1
```

O script configura a regra necessária para permitir a comunicação entre os
recursos Azure e o Azure SQL.
Caso seja necessário utilizar o Query Editor pelo Azure Portal, poderá ser
necessário autorizar também o IP do computador utilizado para administração.

8. Configurar as Connection Strings
Defina a Connection String do Azure SQL em uma variável de ambiente:
```
$env:DIMDIM_CONNECTION_STRING = "Server=tcp:DOMINIO_DO_BANCO,1433;Initial Catalog=sqldb-dimdim;Persist Security Info=False;User ID=dimdimadmin;Password=SUA_SENHA;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
```

Confira se as duas variáveis necessárias estão disponíveis:
```
if ($env:DIMDIM_CONNECTION_STRING) {
    "SQL: OK"
}

if ($env:DIMDIM_APPINSIGHTS_CONNECTION_STRING) {
    "Application Insights: OK"
}
```
O resultado esperado é:
SQL: OK
Application Insights: OK

Agora execute:
```
.\scripts\08-configure-app-settings.ps1
```

Esse script envia as configurações necessárias para o Azure App Service sem
armazenar as credenciais diretamente no código-fonte.

9. Conectar o Application Insights
Execute:
```
.\scripts\09-connect-app-insights.ps1
```
O script associa o Application Insights ao Web App para permitir o
monitoramento da aplicação.

10. Configurar o GitHub Actions
Execute:
```
.\scripts\10-configure-github-actions.ps1
```

Esse script habilita a configuração SCM necessária e configura a integração
entre o GitHub Actions e o Azure App Service.
Durante a execução poderá ser solicitada a autenticação/autorização da conta
GitHub.
Após a configuração, acesse:
GitHub
→ Actions
→ Build and deploy ASP.Net Core app

Aguarde a conclusão do workflow.
O deploy deverá finalizar com sucesso antes de prosseguir.

11. Configuração do banco de dados
Após a infraestrutura estar disponível, acesse:
Azure Portal
→ SQL databases
→ sqldb-dimdim
→ Query editor

Caso o Azure solicite autorização do IP utilizado, adicione o IP do cliente ao
firewall do SQL Server.

Abra o arquivo:
scripts/ddl.sql

Copie seu conteúdo para o Query Editor e execute o script.

Devem existir as tabelas:
Clientes
Transacoes

12. Acessar a aplicação
Após o GitHub Actions finalizar o deploy, acesse o Web App:

`https://app-dimdim-equipe.azurewebsites.net`

A aplicação deverá estar conectada ao Azure SQL Database.

13. Testes CRUD
A aplicação possui operações CRUD para as entidades:
- Clientes
- Transações
Durante os testes, utilize o Query Editor para comprovar que cada operação foi
persistida no Azure SQL.
Para consultar os clientes:
SELECT * FROM Clientes;

Para consultar as transações:
SELECT * FROM Transacoes;

14. Monitoramento com Application Insights
Após utilizar a aplicação e gerar requisições, acesse:
Azure Portal
→ Application Insights
→ appi-dimdim

Utilize os painéis do Application Insights para visualizar a telemetria gerada
pela aplicação.

Em Logs, as requisições recentes podem ser consultadas utilizando:
requests
| order by timestamp desc
| take 20

Dessa forma é possível verificar que as requisições realizadas no Web App
estão sendo monitoradas pelo Application Insights.


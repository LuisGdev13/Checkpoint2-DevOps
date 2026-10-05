# DimDim — Aplicações e Banco em Nuvem

Projeto desenvolvido para o **2º Checkpoint — DevOps Tools & Cloud Computing**.

## Integrantes

| RM | Nome |
|---|---|
| RM566548 | Luis Guilherme Borges Silva |
| RM 562992 | Leonardo Zerbinatti de Sales |
| RM564928 | Rafael de Freitas Moraes |
| RM563210 | Rafael Pascotte Mercadante |

## Links

- GitHub: `https://github.com/devfreitas/Checkpoint2-DevOps`
- Vídeo: `PREENCHER COM LINK DO VÍDEO`

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

> Se algum nome for alterado durante a implantação, atualizar esta tabela.

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

## Segurança

Nenhuma senha, token, connection string ou publish profile deve ser versionado.

Segredos devem ser configurados no Azure App Service ou como GitHub Actions Secrets.

## Configuração local

O arquivo `appsettings.json` não deve conter credenciais reais.

Exemplo seguro:

```json
{
  "ConnectionStrings": {
    "DimDimDatabase": ""
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## Deploy automatizado

O workflow está em:

`.github/workflows/deploy.yml`

O workflow compila e publica o projeto e usa `azure/webapps-deploy@v3` para realizar o deploy no Azure App Service.

A documentação oficial da Microsoft utiliza `azure/webapps-deploy@v3` para esse fluxo. 

### Secret necessário

Criar no GitHub:

`Settings > Secrets and variables > Actions`

Secret:

`AZURE_WEBAPP_PUBLISH_PROFILE`

Valor:

conteúdo do Publish Profile do App Service.

Nunca coloque o conteúdo do Publish Profile no repositório.

## Evidências para o vídeo

O vídeo deve demonstrar, no mínimo:

1. Criação dos recursos Azure.
2. Deploy da aplicação.
3. Aplicação funcionando no App Service.
4. CRUD de Clientes.
5. Persistência de Clientes no Azure SQL.
6. CRUD de Transações.
7. Persistência de Transações no Azure SQL.
8. Relacionamento entre as tabelas.
9. Application Insights recebendo dados/telemetria.
10. Processo de deploy automatizado.

## Checklist antes da entrega

- [ ] Projeto não é o Sprint 3.
- [ ] Aplicação publicada no Azure App Service.
- [ ] Banco é Azure SQL.
- [ ] Existem duas tabelas relacionadas.
- [ ] CRUD de Clientes funciona.
- [ ] CRUD de Transações funciona.
- [ ] DDL está em `scripts/ddl.sql`.
- [ ] Scripts Azure CLI estão em `scripts/`.
- [ ] Arquitetura está documentada.
- [ ] How To está documentado.
- [ ] Application Insights está configurado.
- [ ] GitHub Actions está funcionando.
- [ ] Nenhuma senha/credencial está no Git.
- [ ] Link do vídeo foi preenchido.
- [ ] Integrantes/RM foram preenchidos.

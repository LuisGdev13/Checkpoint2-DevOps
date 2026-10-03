$ErrorActionPreference = "Stop"

# Permite serviços Azure acessarem o SQL Server.
# Em produção, uma regra mais restritiva pode ser adotada.
az sql server firewall-rule create `
  --resource-group rg-dimdim `
  --server sql-dimdim-equipe `
  --name AllowAzureServices `
  --start-ip-address 0.0.0.0 `
  --end-ip-address 0.0.0.0

$ErrorActionPreference = "Stop"

# Defina a variável de ambiente antes de executar:
# $env:DIMDIM_SQL_ADMIN_PASSWORD = "SUA_SENHA_FORTE"

if ([string]::IsNullOrWhiteSpace($env:DIMDIM_SQL_ADMIN_PASSWORD)) {
    throw "Defina DIMDIM_SQL_ADMIN_PASSWORD antes de executar este script."
}

az sql server create `
  --name sql-dimdim-devfreitas `
  --resource-group rg-dimdim `
  --location mexicocentral `
  --admin-user dimdimadmin `
  --admin-password $env:DIMDIM_SQL_ADMIN_PASSWORD

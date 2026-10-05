$ErrorActionPreference = "Stop"

# Defina a variável de ambiente antes de executar:

if ([string]::IsNullOrWhiteSpace($env:DIMDIM_SQL_ADMIN_PASSWORD)) {
    throw "Defina DIMDIM_SQL_ADMIN_PASSWORD antes de executar este script."
}

az sql server create `
  --name sql-dimdim-equipe `
  --resource-group rg-dimdim `
  --location canadacentral `
  --admin-user dimdimadmin `
  --admin-password $env:DIMDIM_SQL_ADMIN_PASSWORD `
  --enable-public-network true
  
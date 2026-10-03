$ErrorActionPreference = "Stop"

az sql db create `
  --resource-group rg-dimdim `
  --server sql-dimdim-equipe `
  --name sqldb-dimdim `
  --service-objective Basic

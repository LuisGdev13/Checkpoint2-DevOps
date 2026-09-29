$ErrorActionPreference = "Stop"

az sql db create `
  --resource-group rg-dimdim `
  --server sql-dimdim-devfreitas `
  --name sqldb-dimdim `
  --service-objective Basic

$ErrorActionPreference = "Stop"

az monitor app-insights component show `
  --app appi-dimdim `
  --resource-group rg-dimdim `
  --query connectionString `
  -o tsv

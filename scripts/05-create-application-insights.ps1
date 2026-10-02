$ErrorActionPreference = "Stop"

az monitor app-insights component create `
  --app appi-dimdim `
  --location canadacentral `
  --resource-group rg-dimdim `
  --application-type web

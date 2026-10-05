$ErrorActionPreference = "Stop"

az monitor app-insights component create `
  --app appi-dimdim `
  --location canadacentral `
  --resource-group rg-dimdim `
  --application-type web

az monitor app-insights component connect-webapp `
    --app appi-dimdim `
    --web-app app-dimdim-equipe `
    --resource-group rg-dimdim
$ErrorActionPreference = "Stop"

az monitor app-insights component connect-webapp `
    --app appi-dimdim `
    --web-app app-dimdim-equipe `
    --resource-group rg-dimdim
$ErrorActionPreference = "Stop"

$resourceGroup = "rg-dimdim"
$location = "canadacentral"
$plan = "asp-dimdim"
$app = "app-dimdim-devfreitas"

# Verifique os runtimes disponíveis se necessário:
# az webapp list-runtimes --os-type windows

az appservice plan create `
  --name $plan `
  --resource-group $resourceGroup `
  --location $location `
  --sku B1 `
  --is-linux

az webapp create `
  --name $app `
  --resource-group $resourceGroup `
  --plan $plan `
  --runtime "DOTNETCORE:8.0"

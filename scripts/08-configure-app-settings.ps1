$ErrorActionPreference = "Stop"

$app = "app-dimdim-equipe"
$rg = "rg-dimdim"

# Connection string NÃO deve ser escrita no Git.
# Defina antes:
# $env:DIMDIM_CONNECTION_STRING = "Server=tcp:...;"
# $env:DIMDIM_APPINSIGHTS_CONNECTION_STRING = "InstrumentationKey=...;..."

if ([string]::IsNullOrWhiteSpace($env:DIMDIM_CONNECTION_STRING)) {
    throw "Defina DIMDIM_CONNECTION_STRING antes de executar."
}

if ([string]::IsNullOrWhiteSpace($env:DIMDIM_APPINSIGHTS_CONNECTION_STRING)) {
    throw "Defina DIMDIM_APPINSIGHTS_CONNECTION_STRING antes de executar."
}

az webapp config appsettings set `
  --resource-group $rg `
  --name $app `
  --settings `
    "ConnectionStrings__DimDimDatabase=$env:DIMDIM_CONNECTION_STRING" `
    "APPLICATIONINSIGHTS_CONNECTION_STRING=$env:DIMDIM_APPINSIGHTS_CONNECTION_STRING"

az webapp config connection-string set `
  --resource-group $rg `
  --name $app `
  --connection-string-type SQLAzure `
  --settings `
    "DimDimDatabase=$env:DIMDIM_CONNECTION_STRING"

$ErrorActionPreference = "Stop"

$app = "app-dimdim-equipe"
$rg = "rg-dimdim"

# Defina antes da execução:
#
# $env:DIMDIM_CONNECTION_STRING = "Server=tcp:...;"
# $env:DIMDIM_APPINSIGHTS_CONNECTION_STRING = "InstrumentationKey=...;..."

if ([string]::IsNullOrWhiteSpace($env:DIMDIM_CONNECTION_STRING)) {
    throw "Defina DIMDIM_CONNECTION_STRING antes de executar."
}

if ([string]::IsNullOrWhiteSpace($env:DIMDIM_APPINSIGHTS_CONNECTION_STRING)) {
    throw "Defina DIMDIM_APPINSIGHTS_CONNECTION_STRING antes de executar."
}

# Configura banco e Application Insights no Web App
az webapp config appsettings set `
  --resource-group $rg `
  --name $app `
  --settings `
    "ConnectionStrings__DimDimDatabase=$env:DIMDIM_CONNECTION_STRING" `
    "APPLICATIONINSIGHTS_CONNECTION_STRING=$env:DIMDIM_APPINSIGHTS_CONNECTION_STRING" `
    "ApplicationInsightsAgent_EXTENSION_VERSION=~3" `
    "XDT_MicrosoftApplicationInsights_Mode=Recommended" `
    "XDT_MicrosoftApplicationInsights_PreemptSdk=1"

az webapp config connection-string set `
  --resource-group $rg `
  --name $app `
  --connection-string-type SQLAzure `
  --settings `
    "DimDimDatabase=$env:DIMDIM_CONNECTION_STRING"
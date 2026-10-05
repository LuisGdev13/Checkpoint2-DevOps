$ErrorActionPreference = "Stop"

$resourceGroup = "rg-dimdim"
$webApp = "app-dimdim-equipe"
$repo = "LuisGdev13/Checkpoint2-DevOps"
$branch = "main"

az resource update `
  --resource-group $resourceGroup `
  --namespace Microsoft.Web `
  --resource-type basicPublishingCredentialsPolicies `
  --name scm `
  --parent "sites/$webApp" `
  --set properties.allow=true

az webapp deployment github-actions add `
  --name $webApp `
  --resource-group $resourceGroup `
  --repo $repo `
  --branch $branch `
  --login-with-github

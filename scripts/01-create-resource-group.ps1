$ErrorActionPreference = "Stop"

$resourceGroup = "rg-dimdim"
$location = "canadacentral"

az group create `
  --name $resourceGroup `
  --location $location `
  --tags projeto=DimDim disciplina=DevOps

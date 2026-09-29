$ErrorActionPreference = "Stop"

$resourceGroup = "rg-dimdim"
$location = "mexicocentral"

az group create `
  --name $resourceGroup `
  --location $location `
  --tags projeto=DimDim disciplina=DevOps

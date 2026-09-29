$ErrorActionPreference = "Stop"

dotnet restore
dotnet build --configuration Release
dotnet publish .\DimDim.Web\DimDim.Web.csproj `
  --configuration Release `
  --output .\publish

Compress-Archive -Path .\publish\* -DestinationPath .\dimdim-app.zip -Force

az webapp deploy `
  --resource-group rg-dimdim `
  --name app-dimdim-devfreitas `
  --src-path .\dimdim-app.zip `
  --type zip

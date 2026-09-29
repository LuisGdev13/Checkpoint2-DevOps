$ErrorActionPreference = "Stop"

az provider register --namespace Microsoft.Sql --wait
az provider register --namespace Microsoft.Insights --wait

az provider show --namespace Microsoft.Sql --query "registrationState" -o tsv
az provider show --namespace Microsoft.Insights --query "registrationState" -o tsv

$ErrorActionPreference = "Stop"

az provider register --namespace Microsoft.Sql --wait
az provider register --namespace Microsoft.Web --wait
az provider register --namespace Microsoft.Insights --wait
az provider register --namespace Microsoft.OperationalInsights --wait
az provider register --namespace Microsoft.ServiceLinker --wait

az provider show --namespace Microsoft.Sql --query "registrationState" -o tsv

az provider show --namespace Microsoft.Web --query "registrationState" -o tsv

az provider show --namespace Microsoft.Insights --query "registrationState" -o tsv

az provider show --namespace Microsoft.OperationalInsights --query "registrationState" -o tsv

az provider show --namespace Microsoft.ServiceLinker --query "registrationState" -o tsv

az extension add --name application-insights
$deployments = Get-AzureRmResourceGroupDeployment -ResourceGroupName "$env:RESOURCEGROUPNAME"

# get latest deployment
$deployment = @($deployments)[0]

Write-Output '-- using this deployment ------------'
Write-Output $deployment

# Set release variables for following tasks
Write-Output "Set variable vmhostname = $($deployment.Outputs.hostname.Value)"
Write-Output "Set variable resourceGroupLocation = $($deployment.Outputs.resourceGroupLocation.Value)"
Write-Host ("##vso[task.setvariable variable=vmhostname;]$($deployment.Outputs.hostname.Value)")
Write-Host ("##vso[task.setvariable variable=resourceGroupLocation;]$($deployment.Outputs.resourceGroupLocation.Value)")

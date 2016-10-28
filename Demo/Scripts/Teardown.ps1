if ((Get-AzureRmResourceGroup -Name "$env:RESOURCEGROUPNAME" -ErrorAction SilentlyContinue) -ne $null) {
    Write-Output "Remove-AzureRmResourceGroup -Name ""$env:RESOURCEGROUPNAME"" -Force -Verbose"
    Remove-AzureRmResourceGroup -Name "$env:RESOURCEGROUPNAME" -Force -Verbose
}

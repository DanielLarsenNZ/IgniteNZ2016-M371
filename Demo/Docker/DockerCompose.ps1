$ErrorActionPreference = "Stop"

Push-Location $PSScriptRoot

# Using the TCP endpoint avoids having to run PowerShell as Administrator.
#$env:DOCKER_HOST = "127.0.0.1:2375"

Write-Host "docker-compose up"
docker-compose up

Pop-Location
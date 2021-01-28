param (
    [string]$Migration
)

$originalLocation = Get-Location
$rootFolder = Split-Path $PSScriptRoot
$srcFolder = Join-Path $rootFolder src
try
{
    Set-Location $srcFolder
    dotnet ef database update $Migration -p RemoteCamp.Portal.Core -c RemoteCamp.Portal.Core.Database.RemoteCampContext    
}
finally
{
    Set-Location $originalLocation
}

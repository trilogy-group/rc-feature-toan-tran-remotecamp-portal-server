param (
    [parameter(Mandatory=$true)]
    [string]$Name 
)

$originalLocation = Get-Location
$rootFolder = Split-Path $PSScriptRoot
$srcFolder = Join-Path $rootFolder src
try
{
    Set-Location $srcFolder
    dotnet ef migrations add $Name -p RemoteCamp.Portal.Core -o Database/Migrations/ -c RemoteCamp.Portal.Core.Database.RemoteCampContext
}
finally
{
    Set-Location $originalLocation
}





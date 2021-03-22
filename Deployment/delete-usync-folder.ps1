Param (
[String]$SiteName
)


$iisWebsite = Get-WebFilePath "IIS:\Sites\$SiteName"
$rootPath = $iisWebsite.FullName
Set-Location -path $rootPath


Remove-Item -Recurse -Force uSync
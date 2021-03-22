Param (
[String]$SiteName,
[String]$Environment
)


$iisWebsite = Get-WebFilePath "IIS:\Sites\$SiteName"
$rootPath = $iisWebsite.FullName
Set-Location -path $rootPath
$configFiles = Get-ChildItem -Path .\*.$Environment.env -Recurse
$GeneralExtension = ".env"
$SourcePattern = ("." + $Environment + $GeneralExtension)
$TargetExtension = ("")
Write-Host "Renaming files for environment: $Environment"
foreach($file in $configFiles)
{
	$oldName = $file.FullName
	$newName = $file.FullName.Replace($SourcePattern, $TargetExtension)
    Move-Item -Path $oldName -Destination $newName -Force
    Write-Host "$oldName has been moved to $newName"
}
Get-ChildItem -Path .\*.env -Recurse | Remove-Item | ForEach-Object { Write-Host "$_.FullName has been deleted"}




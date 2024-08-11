dotnet new uninstall SuessLabs.Prism.Avalonia.Templates

if (Test-Path "bin/") { Remove-Item bin/**/*.nupkg }
if (Test-Path "obj/") { Remove-Item obj/**/ -Force -Recurse }

$result = dotnet pack | select-string "Successfully created package '(.*)'" -AllMatches
$package = $result.Matches.Groups[1]
dotnet new install $package

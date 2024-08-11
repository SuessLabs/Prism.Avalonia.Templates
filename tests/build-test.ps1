<#
Copyright 2024 Xeno Innovations, Inc.

Help:
  dotnet new avalonia.prism.sample -h
  dotnet new prism.avalonia.dialog -h
  dotnet new prism.avalonia.event -h
  dotnet new prism.avalonia.usercontrol -h
  dotnet new prism.avalonia.window -h

Usage:
  dotnet new avalonia.prism.sample [options] [template options]

Template options:
  -F, --Framework <net8.0>               The target framework for the project.
                                         Type: choice
                                           net8.0  Target net8.0
                                         Default: net8.0
  -A, --AvaloniaVersion <11.0.7|11.1.1>  The target version of Avalonia NuGet packages.
                                         Type: choice
                                           11.0.7  Target 11.0.7
                                           11.1.1  Target 11.1.1 (Latest stable)
                                         Default: 11.1.1
  -P, --PrismVersion <8.1.97.11073>      The target version of Prism.Avalonia NuGet packages.
                                         Type: choice
                                           8.1.97.11073  Target 8.1.97.11073 (Latest stable).
                                         Default: 8.1.97.11073
#>

# Enable common parameters e.g. -Verbose
[CmdletBinding()]
param()

Set-StrictMode -Version latest
$ErrorActionPreference = "Stop"

# Taken from psake https://github.com/psake/psake
<#
.SYNOPSIS
  This is a helper function that runs a scriptblock and checks the PS variable $lastexitcode
  to see if an error occcured. If an error is detected then an exception is thrown.
  This function allows you to run command-line programs without having to
  explicitly check the $lastexitcode variable.
.EXAMPLE
  exec { svn info $repository_trunk } "Error executing SVN. Please verify SVN command-line client is installed"
#>
function Exec
{
  [CmdletBinding()]
  param(
    [Parameter(Position=0,Mandatory=1)][scriptblock]$cmd,
    [Parameter(Position=1,Mandatory=0)][string]$errorMessage = ("Error executing command {0}" -f $cmd)
  )

  # Convert the ScriptBlock to a string and expand the variables
  $expandedCmdString = $ExecutionContext.InvokeCommand.ExpandString($cmd.ToString())
  Write-Verbose "Executing command: $expandedCmdString"

  Invoke-Command -ScriptBlock $cmd

  if ($lastexitcode -ne 0) {
    throw ("Exec: " + $errorMessage)
  }
}

function Test-Template {
  param (
    [Parameter(Position=0,Mandatory=1)][string]$template,
    [Parameter(Position=1,Mandatory=1)][string]$name,
    [Parameter(Position=2,Mandatory=1)][string]$lang,
    [Parameter(Position=3,Mandatory=1)][string]$parameterName,
    [Parameter(Position=4,Mandatory=1)][string]$value,
    [Parameter(Position=5,Mandatory=0)][string]$bl
  )

  $outDir = [IO.Path]::GetFullPath([IO.Path]::Combine($pwd, "..", "output"))
  $folderName = $name + $parameterName + $value

  # Remove dots and - from folderName because in sln it will cause errors when building project
  $folderName = $folderName -replace "[.-]"

  # Create the project
  Exec { dotnet new $template -o $outDir/$lang/$folderName -$parameterName $value -lang $lang }

  # Instantiate each item template in the project
  Exec { dotnet new prism.avalonia.event -o $outDir/$lang/$folderName -n NewEvent -lang $lang }
  Exec { dotnet new prism.avalonia.usercontrol -o $outDir/$lang/$folderName -n NewUserControl }
  Exec { dotnet new prism.avalonia.window -o $outDir/$lang/$folderName -n NewWindow }

  # Exec { dotnet new avalonia.resource -o $outDir/$lang/$folderName -n NewResourceDictionary }
  # Exec { dotnet new avalonia.styles -o $outDir/$lang/$folderName -n NewStyles }
  # Exec { dotnet new avalonia.usercontrol -o $outDir/$lang/$folderName -n NewUserControl -lang $lang }
  # Exec { dotnet new avalonia.window -o $outDir/$lang/$folderName -n NewWindow -lang $lang }


  # Build
  Exec { dotnet build $outDir/$lang/$folderName -bl:$bl }
}

function Create-And-Build {
  param (
    [Parameter(Position=0,Mandatory=1)][string]$template,
    [Parameter(Position=1,Mandatory=1)][string]$name,
    [Parameter(Position=2,Mandatory=1)][string]$lang,
    [Parameter(Position=3,Mandatory=1)][string]$parameterName,
    [Parameter(Position=4,Mandatory=1)][string]$value,
    [Parameter(Position=5,Mandatory=0)][string]$bl
  )

  $folderName = $name + $parameterName + $value

  # Remove dots and - from folderName because in sln it will cause errors when building project
  $folderName = $folderName -replace "[.-]"

  # Create the project
  Write-Output "Creating project";
  Write-Output "  Options: lang=$lang, folderName=$folderName, param=$parametername, val=$value, lang=$lang";
  Exec { dotnet new $template -o output/$lang/$folderName -$parameterName $value }
  #Exec { dotnet new $template -o output/$lang/$folderName -$parameterName $value -lang $lang }

  # Build
  Write-Output "Building project";
  Exec { dotnet build output/$lang/$folderName -bl:$bl }
}

# Clear file system from possible previous runs
Write-Output "Clearing outputs from possible previous runs"
if (Test-Path "output" -ErrorAction SilentlyContinue) {
  Remove-Item -Recurse -Force "output"
}

$outDir = [IO.Path]::GetFullPath([IO.Path]::Combine($pwd, "..", "output"))
if (Test-Path $outDir -ErrorAction SilentlyContinue) {
  Remove-Item -Recurse -Force $outDir
}

$binLogDir = [IO.Path]::GetFullPath([IO.Path]::Combine($pwd, "..", "binlog"))
if (Test-Path $binLogDir -ErrorAction SilentlyContinue) {
  Remove-Item -Recurse -Force $binLogDir
}

# Use same log file for all executions
$binlog = [IO.Path]::GetFullPath([IO.Path]::Combine($pwd, "..", "binlog", "test.binlog"))

# Build the project only once with all item templates using .net8.0 tfm for C#
Test-Template "avalonia.prism.sample" "AvaloniaMvvm" "C#" "A" "11.1.1" $binlog

# Base MVVM App Template Tests
Create-And-Build "avalonia.prism.sample" "AvaloniaMvvm" "C#" "A" "11.0.7" $binlog
Create-And-Build "avalonia.prism.sample" "AvaloniaMvvm" "C#" "A" "11.1.1" $binlog
# Create-And-Build "avalonia.prism.sample" "AvaloniaMvvm" "C#" "P" "8.1.97.11073" $binlog
# Create-And-Build "avalonia.prism.sample" "AvaloniaMvvm" "C#" "P" "9.0.401.11100-pre" $binlog

# Dialog App Template Tests
Create-And-Build "prism.avalonia.dialog" "AvaloniaDialog" "C#" "A" "11.0.7" $binlog
Create-And-Build "prism.avalonia.dialog" "AvaloniaDialog" "C#" "A" "11.1.1" $binlog

# Bare-bones app (not implemented)
# Create-And-Build "prism.avalonia.app" "PrismAvaloniaApp" "C#" "f" "net8.0" $binlog
# Create-And-Build "prism.avalonia.app" "PrismAvaloniaApp" "C#" "av" "11.1.0" $binlog

# desktop/android/ios/browser (not implemented)
# Create-And-Build "prism.avalonia.xplat" "PrismAvaloniaXplat" "C#" "f" "net8.0" $binlog
# Create-And-Build "prism.avalonia.xplat" "PrismAvaloniaXplat" "C#" "av" "11.1.0" $binlog

# Ignore errors when files are still used by another process
Remove-Item -Recurse -Force -ErrorAction SilentlyContinue "output/C#"


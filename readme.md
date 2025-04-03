# Prism.Avalonia Templates for `dotnet new`

<!--[![downloads](https://img.shields.io/nuget/dt/templates.prism.avalonia)](https://www.nuget.org/packages/Templates.Prism.Avalonia/)-->
[![Current stable version](https://img.shields.io/nuget/v/Templates.Prism.Avalonia.svg)](https://www.nuget.org/packages/Templates.Prism.Avalonia/)

The [Prism.Avalonia Templates](https://github.com/SuessLabs/Prism.Avalonia.Templates/pull/4) is a collection of `dotnet` template files for creating [Prism.Avalonia](https://github.com/AvaloniaCommunity/Prism.Avalonia) apps.

For more information about `dotnet new` templates see [here](https://blogs.msdn.microsoft.com/dotnet/2017/04/02/how-to-create-your-own-templates-for-dotnet-new/).

> ## Announcement
>
> _[Prism.Avalonia](https://github.com/AvaloniaCommunity/Prism.Avalonia) is officially moving to  [Prism Library](https://github.com/PrismLibrary/Prism)!_ :heart:

## Installing Templates

Run from a command line:

```powershell
dotnet new install Templates.Prism.Avalonia

# Install
dotnet new prism.avalonia.app -n MySuperAwesomeApp

# Help
dotnet new prism.avalonia.app -h
```

The templates are now be available in `dotnet new list`:

### Project Templates

```txt
Template Name                         Short Name                  Language  Tags
------------------------------------  --------------------------  --------  -----------------------------------------------------
Prism.Avalonia .NET - Empty App                prism.avalonia.app          [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
Prism.Avalonia .NET - Sample Dialog App        prism.avalonia.app.dialog   [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
Prism.Avalonia .NET - Sample Full SideBar App  prism.avalonia.app.full     [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
```

### Item Templates

```txt
Template Name                         Short Name                  Language  Tags
------------------------------------  --------------------------  --------  -----------------------------------------------------
Prism Avalonia Event                           prism.avalonia.event        [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
Prism Avalonia UserControl                     prism.avalonia.usercontrol  [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
Prism Avalonia ViewModel                       prism.avalonia.viewmodel    [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
Prism Avalonia Window                          prism.avalonia.window       [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
```

## Commands

For more help, `dotnet new prism.avalonia.app -h`

```txt
Prism.Avalonia .NET - Empty App (C#)
Author: Damian Suess
Description: An empty cross-platform Avalonia UI Application using the Prism.Avalonia framework with the MVVM pattern.

Usage:
  dotnet new prism.avalonia.app [options] [template options]

Options:
  -n, --name <name>       The name for the output being created. If no name is specified, the name of the output
                          directory is used.
  -o, --output <output>   Location to place the generated output.
  --dry-run               Displays a summary of what would happen if the given command line were run if it would result
                          in a template creation.
  --force                 Forces content to be generated even if it would change existing files.
  --no-update-check       Disables checking for the template package updates when instantiating a template.
  --project <project>     The project that should be used for context evaluation.
  -lang, --language <C#>  Specifies the template language to instantiate.
  --type <project>        Specifies the template type to instantiate.

Template options:
  -F, --Framework <net8.0>            The target framework for the project.
                                      Type: choice
                                        net8.0  Target net8.0 (default)
                                      Default: net8.0
  -A, --AvaloniaVersion <11.1.3>      The target version of Avalonia NuGet packages.
                                      Type: choice
                                        11.1.3  Target 11.1.3 (Latest stable)
                                      Default: 11.1.3
  -P, --PrismVersion <9.0.537.11130>  The target version of Prism.Avalonia NuGet packages.
                                      Type: choice
                                        9.0.537.11130  Target 9.0.537.11130 (Latest stable).
                                      Default: 9.0.537.11130
```

## Contributing

* [Contributing](.github/Contributing.md)
* [Code-of-Conduct](.github/Code-of-Conduct.md)
* [Security Policy](.github/Security.md)

### Local Test and Build

```powershell
.\install-dev-templates.ps1
.\tests\build-test.ps1
```

## References

* Templates based on [Avalonia .NET Templates](https://github.com/AvaloniaUI/avalonia-dotnet-templates)

Sponsored by: Suess Labs, Inc.<br/>- _skunkworks of Xeno Innovations_

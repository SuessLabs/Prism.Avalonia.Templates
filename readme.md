# Prism.Avalonia Templates for `dotnet new`

The [Prism.Avalonia Templates](https://github.com/SuessLabs/Prism.Avalonia.Templates/pull/4) is a collection of `dotnet` template files for creating [Prism.Avalonia](https://github.com/AvaloniaCommunity/Prism.Avalonia) apps.

For more information about `dotnet new` templates see [here](https://blogs.msdn.microsoft.com/dotnet/2017/04/02/how-to-create-your-own-templates-for-dotnet-new/).

## Installing Templates

Run from a command line:

```powershell
dotnet new install SuessLabs.Prism.Avalonia.Templates
```

The templates are now be available in `dotnet new list`:

```txt
Template Name                         Short Name                  Language  Tags
------------------------------------  --------------------------  --------  -----------------------------------------------------
Prism.Avalonia .NET MVVM App          prism.avalonia.app          [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
Prism.Avalonia .NET MVVM App Sample   prism.avalonia.app.sample   [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
Prism.Avalonia .NET MVVM Dialog App   prism.avalonia.app.dialog   [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
Prism Avalonia Event                  prism.avalonia.event        [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
Prism Avalonia UserControl            prism.avalonia.usercontrol  [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
Prism Avalonia Window                 prism.avalonia.window       [C#]      Desktop/Xaml/Axaml/Avalonia/Prism/Windows/Linux/macOS
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

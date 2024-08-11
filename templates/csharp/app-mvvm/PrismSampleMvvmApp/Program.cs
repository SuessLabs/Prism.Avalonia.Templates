using Avalonia;

namespace PrismSampleMvvmApp;

public class Program
{
    static void Main(string[] args) => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

    public static AppBuilder BuildAvaloniaApp()
    {
        var builder = AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .With(new X11PlatformOptions { EnableMultiTouch = true, UseDBusMenu = true })
            .With(new Win32PlatformOptions { EnableMultitouch = true, AllowEglInitialization = true })
            .LogToTrace()
            .UseSkia();

        return builder;
    }
}
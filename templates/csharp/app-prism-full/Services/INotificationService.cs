using System;
using Avalonia.Controls;

namespace PrismSampleMvvmApp.Services;

public interface INotificationService
{
    int NotificationTimeout { get; set; }

    void SetHostWindow(Window window);

    void Show(string title, string message, Action? onClick = null);
}
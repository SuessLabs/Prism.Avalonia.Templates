﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PrismSimpleDialogTemplate.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }
}
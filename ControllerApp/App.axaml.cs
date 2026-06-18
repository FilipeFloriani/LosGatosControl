using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ControllerApp.Models;
using ControllerApp.ViewModels;
using ControllerApp.Views;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ControllerApp
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        }

        private void CurrentDomain_UnhandledException(object? sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Debug.WriteLine(ex);
        }

        private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            Debug.WriteLine(e.Exception);
            e.SetObserved();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            Debug.WriteLine($"Application has been initialized.\r\nWorking Path {Constants.WorkingPath}");

            if (!Directory.Exists(Constants.WorkingPath))
                Directory.CreateDirectory(Constants.WorkingPath);

            if (!Directory.Exists(Constants.WorkingPath))
                //App.Current?.Exit();

            base.OnFrameworkInitializationCompleted();
        }
    }
}
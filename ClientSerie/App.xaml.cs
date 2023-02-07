// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientSerie.ViewModels;
using ClientSerie.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientSerie
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<AjoutSerieViewModel>()
                .BuildServiceProvider());
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            // Create a Frame to act as the navigation context and navigate to the first page
            Frame rootFrame = new Frame();
            // Place the frame in the current Window
            this.m_window.Content = rootFrame;
            // Ensure the current window is active
            m_window.Activate();
            //Navigate to the first page
            rootFrame.Navigate(typeof(AjoutSeriePage));
            MainRoot = m_window.Content as FrameworkElement;
        }
        public static FrameworkElement MainRoot { get; private set; }

        private Window m_window;

        public AjoutSerieViewModel AjoutSerieVM
        {
            get { return Ioc.Default.GetService<AjoutSerieViewModel>(); }
        }
    }
}

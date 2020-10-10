using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using nMind.ViewModels;

namespace nMind
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainViewModel _mainViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _mainViewModel = new MainViewModel();
            _mainViewModel.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if (_mainViewModel != null)
                _mainViewModel.Dispose();
        }
    }
}

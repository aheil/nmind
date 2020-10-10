using nMind.Commands;
using nMind.Controls;
using nMind.Views;
using System;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Input;

namespace nMind.ViewModels
{
    public delegate void AddCallback();

    public class MainViewModel : ViewModelBase<IMainView>
    {
        public MainViewModel() : base(new MainWindow())
        {

        }

        public void Show()
        {
            this.View.Show();
        }

        public void Dispose()
        {

        }

        private void Exit()
        {
            Dispose();
            Application.Current.Shutdown();
        }

        //MapViewModel _currentMapViewModel;

        //public MapViewModel CurrentMap
        //{
        //    get {
        //        //if (_currentMapViewModel == null)
        //        //    _currentMapViewModel = new MapViewModel();

        //        //return _currentMapViewModel; 
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        _currentMapViewModel = value;
        //    }
        //}

    }
}
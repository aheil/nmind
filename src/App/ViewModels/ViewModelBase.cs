using nMind.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nMind.ViewModels
{
    public abstract class ViewModelBase<ViewType> : INotifyPropertyChanged 
        where ViewType : IView
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ViewType _view;

        public ViewType View
        {
            get
            {
                return _view;
            }
        }

        public ViewModelBase(ViewType view)
        {
            _view = view;
            _view.DataContext = this;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
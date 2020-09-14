using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using nMind.DataModel;

namespace nMind.ViewModels
{
    class NodeViewModel : INotifyPropertyChanged
    {
        private Node _node = null;
        public NodeViewModel()
        {
            _node = new Node();
        }

        public Node Value
        {
            get { return _node; }
        }

        public string Text
        {
            get { return _node.Text; }
            set
            {
                _node.Text = value;
                OnPropertyChanged("Text");
            }
        }

        public double X
        {
            get { return _node.Point.X; }
            set
            {
                _node.SetX(value);
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get { return _node.Point.Y; }
            set
            {
                _node.SetY(value);
                OnPropertyChanged("Y");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}

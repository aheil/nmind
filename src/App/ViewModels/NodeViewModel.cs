using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using nMind.DataModel;
using nMind.Views;

namespace nMind.ViewModels
{
    public class NodeViewModel //: BaseViewModel<IMainView>
    {
        private Node _node = null;
        public NodeViewModel()
        {
            _node = new Node();
        }

        public NodeViewModel(Node node)
        {
            _node = node;
        }

        private void Refresh()
        {
            //OnPropertyChanged("Text");
            //OnPropertyChanged("X");
            //OnPropertyChanged("Y");

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
                //_node.Text = value;
                //OnPropertyChanged("Text");
            }
        }

        public double X
        {
            get { return _node.Point.X; }
            set
            {
                //_node.SetX(value);
                //OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get { return _node.Point.Y; }
            set
            {
                //_node.SetY(value);
                //OnPropertyChanged("Y");
            }
        }
    }
}

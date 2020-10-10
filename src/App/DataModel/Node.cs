using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace nMind.DataModel
{
    public class Node : INotifyPropertyChanged
    {
        private string _text;
        private Point _point;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RaisePropertyChanged("Text");
            }
        }

        public Point Point
        {
            get { return _point; }
            set
            {
                _point = value;
                RaisePropertyChanged("Point");
            }
        }
        internal void Refresh()
        {
            RaisePropertyChanged("Point");
            RaisePropertyChanged("Text");
        }

        public void SetX(double value)
        {
            _point.X = value;
            RaisePropertyChanged("Point");
        }

        public void SetY(double value)
        {
            _point.Y = value;
            RaisePropertyChanged("Point");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
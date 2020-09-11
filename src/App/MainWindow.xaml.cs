using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.CodeDom;

namespace nMind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void _Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Canvas coordinate ({0},{1})", Mouse.GetPosition(_Canvas).X, Mouse.GetPosition(_Canvas).Y);

            // double click
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                var currentMap = (DataContext as MainViewModel).CurrentMap;

                this.Add(new Node());
            }
        }

        private void _Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Canvas mouse up ({0},{1})", Mouse.GetPosition(_Canvas).X, Mouse.GetPosition(_Canvas).Y);
            
            if (_preview != null)
            {
                _Canvas.Children.Remove(_preview);

                Canvas.SetLeft(_movable, Mouse.GetPosition(_Canvas).X);
                Canvas.SetTop(_movable, Mouse.GetPosition(_Canvas).Y);

                _preview = null;
                _movable = null;
            }
        }

        Control _movable = null;
        Control _preview = null;

        private void _Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Label clicked");

            _movable = (Label)sender;

            e.Handled = true;
        }

        private void _Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Label un-clicked");

            if (_movable != null && _movable == sender)
            {
                if (_preview != null)
                {
                    _Canvas.Children.Remove(_preview);
                    _preview = null;
                }
                _movable = null;
            }
        }

        private void Add(object o)
        {
            if (o is Node)
            {
                var node = (Node)o;
                node.Text = "foo";
                node.Point = Mouse.GetPosition(_Canvas);
                this.ViewModel.CurrentMap.Add(node);

                var label = new Label();
                label.Style = (Style)_Canvas.Resources["LabelBorderHighlightStyle"];
                label.Content = node.Text;

                label.MouseDown += _Label_MouseDown;
                label.MouseMove += _Label_MouseMove;
                label.MouseUp += _Label_MouseUp;

                Canvas.SetLeft(label, node.Point.X);
                Canvas.SetTop(label, node.Point.Y);
                _Canvas.Children.Add(label);
            }
            else
            {
                Debug.WriteLine("WARNING: Adding not supported ContentControl");
            }
        }


        private void _Label_MouseMove(object sender, MouseEventArgs e)
        {
            var label = sender as Label;
            if (label != null && e.LeftButton == MouseButtonState.Pressed)
            {
                Debug.WriteLine("Mouse Moved ({0},{1})", Mouse.GetPosition(_Canvas).X, Mouse.GetPosition(_Canvas).Y);
            }
        }

        private void _Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_movable != null && _preview == null)
            {
                var label = new Label();
                label.Content = ((Label)_movable).Content;
                label.Opacity = 0.8;
                _preview = label;
                _Canvas.Children.Add(_preview);
            }

            if (_preview == null)
                return;

            Canvas.SetLeft(_preview, Mouse.GetPosition(_Canvas).X);
            Canvas.SetTop(_preview, Mouse.GetPosition(_Canvas).Y);

        }
    }
}

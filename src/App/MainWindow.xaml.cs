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
using nMind.Controls;
using nMind.ViewModels;
using Microsoft.Win32;
using System.Net.Mail;
using System.IO;

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

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Canvas coordinate ({0},{1})", Mouse.GetPosition(_Canvas).X, Mouse.GetPosition(_Canvas).Y);

            // double click
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                var currentMap = (DataContext as MainViewModel).CurrentMap;

                this.Add(new Node());
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
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

        private void Node_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Label clicked");

            _movable = (Control)sender;

            e.Handled = true;
        }

        private void Node_MouseUp(object sender, MouseButtonEventArgs e)
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

        private void Add(Control c)
        {
            if (c is Node)
            {
                var dc = ((Node)c).DataContext as NodeViewModel;

                dc.Text = "foo";
                dc.X = Mouse.GetPosition(_Canvas).X;
                dc.Y = Mouse.GetPosition(_Canvas).Y;
                this.ViewModel.CurrentMap.Add(dc.Value);

                //var label = new Label();
                ((Node)c).Label.Style = (Style)_Canvas.Resources["LabelBorderHighlightStyle"];
                //label.Content = node.Text;

                c.MouseDown += Node_MouseDown;
                c.MouseMove += Node_MouseMove;
                c.MouseUp += Node_MouseUp;

                Canvas.SetLeft(c, dc.X);
                Canvas.SetTop(c, dc.Y);
                _Canvas.Children.Add(c);
            }
            else
            {
                Debug.WriteLine("WARNING: Adding not supported ContentControl");
            }
        }


        private void Node_MouseMove(object sender, MouseEventArgs e)
        {
            var label = sender as Label;
            if (label != null && e.LeftButton == MouseButtonState.Pressed)
            {
                Debug.WriteLine("Mouse Moved ({0},{1})", Mouse.GetPosition(_Canvas).X, Mouse.GetPosition(_Canvas).Y);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_movable != null && _preview == null)
            {
                if (!(_movable is Node))
                    return; 

                var node = new Node();
                ((NodeViewModel)node.DataContext).Text = ((NodeViewModel)((Node)_movable).DataContext).Text;
                node.Opacity = 0.8;
                _preview = node;
                _Canvas.Children.Add(_preview);
            }

            if (_preview == null)
                return;

            Canvas.SetLeft(_preview, Mouse.GetPosition(_Canvas).X);
            Canvas.SetTop(_preview, Mouse.GetPosition(_Canvas).Y);

        }

        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string map = this.ViewModel.CurrentMap.Serialize();

            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == true)
                File.WriteAllText(sfd.FileName, map);
        }
    }
}

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

namespace nMind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

                // TODO: sync VieMdel and Node. keep label ref etc.
                Label label = new Label();
                label.Content = "foo";
                Canvas.SetLeft(label, Mouse.GetPosition(_Canvas).X);
                Canvas.SetTop(label, Mouse.GetPosition(_Canvas).Y);
                _Canvas.Children.Add(label);
            }
        }
    }
}

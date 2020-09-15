using nMind.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace nMind.Controls
{
    /// <summary>
    /// Interaction logic for Node.xaml
    /// </summary>
    public partial class Node : UserControl
    {
        public Node()
        {
            InitializeComponent();
            DataContext = new NodeViewModel();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Label.Visibility = Visibility.Hidden;
            EditBox.Visibility = Visibility.Visible;

            EditBox.Focus();
        }

        private void EditBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                EditBox.Visibility = Visibility.Hidden;
                Label.Visibility = Visibility.Visible;

                BindingExpression binding = EditBox.GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            }
        }

        private void EditBox_LostFocus(object sender, RoutedEventArgs e)
        {
            EditBox.Visibility = Visibility.Hidden;
            Label.Visibility = Visibility.Visible;
        }
    }
}

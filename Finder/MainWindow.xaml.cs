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

namespace Finder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame_reg.NavigationService.Navigate(new Registration());
        }

        private void AuthRegButton_Click(object sender, RoutedEventArgs e)
        {
            if (frame_reg.Content == frame_reg.Content as Registration)
            {
                frame_reg.NavigationService.Navigate(new Auth());
                AuthRegButton.Content = "Зарегистрироваться";
            }
            else
            {
                frame_reg.NavigationService.Navigate(new Registration());
                AuthRegButton.Content = "Войти";
            }
        }
    }
}

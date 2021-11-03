using System.Windows;

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
            MakeAuthReg();
        }

        public void MakeAuthReg()
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

using System.Windows;

namespace Finder
{
    /// <summary>
    /// Логика взаимодействия для ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
        AppWindowPages.FindUsers users = new AppWindowPages.FindUsers();
        public ApplicationWindow()
        {
            InitializeComponent();
            frame_reg.NavigationService.Navigate(new AppWindowPages.UserInfo());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame_reg.NavigationService.Navigate(new AppWindowPages.UserInfo());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frame_reg.NavigationService.Navigate(users);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            frame_reg.NavigationService.Navigate(new AppWindowPages.PairsPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            frame_reg.NavigationService.Navigate(new AppWindowPages.PageMessenger());
        }

        private void AuthRegButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new MainWindow();
            this.Close();
            Application.Current.MainWindow.Show();
        }

    }
}

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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        FinderCore core = new FinderCore();
        public Auth()
        {
            InitializeComponent();
        }

        private void bntAuthClick(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.email = mail.Text;
            user.password = pwBox.Password;
            bool auth = core.UserAuth(user);
            if (auth)
            {
                SuccessfulLogin();
            }
            else
            {
                MessageBox.Show("Incorrect user");
            }
        }

        private void SuccessfulLogin()
        {
            ApplicationWindow applicationWindow = new ApplicationWindow();
            if (core.CheckUserInfo())
            {
                Application.Current.MainWindow.Closed += MainWindow_Closed;
                Application.Current.MainWindow.Close();
            }
            else
            {
                NavigationService.Navigate(new Pages.UserInfoPage());
            }
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow = new ApplicationWindow();
            Application.Current.MainWindow.Show();

        }
    }
}

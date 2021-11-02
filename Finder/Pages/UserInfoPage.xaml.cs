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

namespace Finder.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserInfoPage.xaml
    /// </summary>
    public partial class UserInfoPage : Page
    {
        FinderCore core = new FinderCore();
        public UserInfoPage()
        {
            InitializeComponent();
            FillCmBox();
        }

        private void FillCmBox()
        {
            foreach (var countries in core.GetZodiac())
            {
                cmBoxZodiacs.Items.Add(countries.Name.ToString());
            }
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            User_Info userInfo = new User_Info();
            userInfo.Education = education.Text;
            userInfo.Height = int.Parse(height.Text);
            userInfo.Weight = int.Parse(weight.Text);
            userInfo.About = About.Text;
            userInfo.Zodiac_ID = core.GetZodiacID(cmBoxZodiacs.SelectedItem.ToString());
            core.CreateNewUserInfo(userInfo);
            Application.Current.MainWindow.Closed += MainWindow_Closed;
            Application.Current.MainWindow.Close();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow = new ApplicationWindow();
            Application.Current.MainWindow.Show();
        }
    }
}

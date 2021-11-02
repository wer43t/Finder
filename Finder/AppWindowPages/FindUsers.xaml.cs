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

namespace Finder.AppWindowPages
{
    /// <summary>
    /// Логика взаимодействия для FindUsers.xaml
    /// </summary>
    public partial class FindUsers : Page
    {
        FinderCore core = new FinderCore();
        public FindUsers()
        {
            InitializeComponent();
            GetNextUser();
        }

        private void GetNextUser()
        {
            User user = core.GetOneUser();
            if(user != null)
            {
                Name.Content = user.Name;
                age.Content = core.GetAge(user.Birthday);
                country.Content = user.Country.Name;
                education.Content = user.User_Info.Education;
                Height.Content = user.User_Info.Height;
                Weight.Content = user.User_Info.Weight;
                Zodiac.Content = user.User_Info.Zodiac.Name;
                About.Text = user.User_Info.About;
            }
            else
            {
                MessageBox.Show("К сожалению новых пользователей пока нет");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetNextUser();
        }
    }
}

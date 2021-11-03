using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Finder.AppWindowPages
{
    /// <summary>
    /// Логика взаимодействия для FindUsers.xaml
    /// </summary>
    public partial class FindUsers : Page
    {
        FinderCore core = new FinderCore();
        User user;
        public FindUsers()
        {
            InitializeComponent();
            GetNextUser();
        }



    private void GetNextUser()
    {
        user = core.GetOneUser();
        if (user != null)
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

    private void btnLike_MouseEnter(object sender, MouseEventArgs e)
    {
        imgLike.Width += 30;
        imgLike.Height += 30;
    }

        private void btnLike_MouseLeave(object sender, MouseEventArgs e)
        {
            imgLike.Width -= 30;
            imgLike.Height -= 30;
        }

        private void imgDislike_MouseEnter(object sender, MouseEventArgs e)
        {
            imgDislike.Width += 30;
            imgDislike.Height += 30;
        }

        private void imgDislike_MouseLeave(object sender, MouseEventArgs e)
        {
            imgDislike.Width -= 30;
            imgDislike.Height -= 30;
        }
    }
}

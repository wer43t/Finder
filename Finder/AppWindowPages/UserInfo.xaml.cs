using System.Windows.Controls;
using FinderCore;

namespace Finder.AppWindowPages
{
    /// <summary>
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        FinderCoreApp core = new FinderCoreApp();
        public UserInfo()
        {
            InitializeComponent();
            if (CurrentUser.user.User_Info != null)
            {
                FillTable();
            }
            ChangeOrApply();
        }

        public void FillTable()
        {
            User_Info user_Info = CurrentUser.user.User_Info;
            education.Text = user_Info.Education;
            height.Text = user_Info.Height.ToString();
            weight.Text = user_Info.Weight.ToString();
            About.Text = user_Info.About;
            SetZodiac();
        }

        private void SetZodiac()
        {
            foreach (var countries in core.GetZodiac())
            {
                cmBoxZodiacs.Items.Add(countries.Name.ToString());
            }

            foreach (string zodiac in cmBoxZodiacs.Items)
            {
                if (zodiac == CurrentUser.user.User_Info.Zodiac.Name)
                {
                    cmBoxZodiacs.SelectedItem = zodiac;
                    break;
                }
            }
        }

        private void ChangeOrApply()
        {
            if (btnChange.IsEnabled)
            {
                UserGrid.IsEnabled = false;
            }
            else
            {
                UserGrid.IsEnabled = true;
            }
        }

        private void btnChange_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            btnChange.IsEnabled = false;
        }
    }
}

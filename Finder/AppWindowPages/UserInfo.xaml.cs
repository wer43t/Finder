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
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        FinderCore core = new FinderCore();
        public UserInfo()
        {
            InitializeComponent();
            if(CurrentUser.user.User_Info != null)
            {
                FillTable();
            }
            UserGrid.IsEnabled = false;
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
    }
}

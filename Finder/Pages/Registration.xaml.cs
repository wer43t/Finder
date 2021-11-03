using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Finder
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        FinderCore core = new FinderCore();
        public Registration()
        {
            InitializeComponent();
            FillCmBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void btnRegistration(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Name = Name.Text;
            user.Surname = Surname.Text;
            user.email = mail.Text;
            if (cmBoxCountries.SelectedItem != null)
                user.Country_ID = core.GetCountryID(cmBoxCountries.SelectedItem.ToString());
            else
            {
                MessageBox.Show("Выберите страну");
                return;
            }
            user.Username = "unknown";
            user.Birthday = Birthday.SelectedDate;
            user.Subscibe_Type = 1;
            user.password = psBox.Password;
            core.CreateNewAccount(user);
            NavigationService.Navigate(new Auth());
        }

        private void FillCmBox()
        {
            foreach (var countries in core.GetCountries())
            {
                cmBoxCountries.Items.Add(countries.Name.ToString());
            }
        }


        private void mail_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var checkMail = core.MailValidate(sender.GetType().GetProperty("Text").GetValue(sender).ToString());
            if (!checkMail)
            {
                MessageBox.Show("Incorrect email");
                mail.Focusable = true;
                Keyboard.Focus(mail);
            }
        }
    }
}

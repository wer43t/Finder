﻿using System;
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
using Finder;

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
            user.Country_ID = core.GetCountryID(cmBoxCountries.SelectedItem.ToString());
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

        private void mail_TextChanged(object sender, TextChangedEventArgs e)
        {
            var checkMail = core.MailValidate(sender.GetType().GetProperty("Text").ToString()) ? "OK" : "not ok";
            MessageBox.Show(checkMail);
        }
    }
}

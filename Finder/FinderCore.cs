using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Finder
{
    public class FinderCore
    {
        public static ObservableCollection<Country> Countries { get; set; }
        public static ObservableCollection<User> Users { get; set; }
        public static ObservableCollection<User_Info> UserInfos { get; set; }
        public static ObservableCollection<Zodiac> Zodiacs { get; set; }
        public static ObservableCollection<Pairs> Pairs { get; set; }

        public CurrentUser CurrentUser;

        public ObservableCollection<Country> GetCountries()
        {
            return Countries = new ObservableCollection<Country>(bd_connections.connection.Country.ToList());
        }

        public void CreateNewAccount(User user)
        {
            try
            {
                bd_connections.connection.User.Add(user);
                bd_connections.connection.SaveChanges();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public int GetCountryID(string cnName)
        {
            Countries = new ObservableCollection<Country>(bd_connections.connection.Country.ToList());
            var cnID = from cn in Countries //
                       where cn.Name == cnName
                       select cn;
            return cnID.ToList()[0].Country_ID;
        }

        public void CreateNewUserInfo(User_Info user_Info)
        {
            bd_connections.connection.User_Info.Add(user_Info);
        }

        public bool UserAuth(User user)
        {
            Users = new ObservableCollection<User>(bd_connections.connection.User.ToList());
            var auth = from usrs in Users
                       where user.email == usrs.email && user.password == usrs.password
                       select usrs;
            CurrentUser = new CurrentUser(auth.First());
            if (auth.Count() == 1)
                return true;
            else
                return false;
        }

        public bool MailValidate(string mail)
        {
            return new EmailAddressAttribute().IsValid(mail);
        }

        public bool CheckUserInfo()
        {
            return CurrentUser.user.ID_User_Info == null ? false : true;
        }
    }
}

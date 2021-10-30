using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Finder
{
    public class FinderCore
    {
        public static ObservableCollection<Country> Countries { get; set; }
        public static ObservableCollection<User> Users { get; set; }
        public static ObservableCollection<User_Info> UserInfos { get; set; }
        public static ObservableCollection<Zodiac> Zodiacs { get; set; }
        public static ObservableCollection<Pairs> Pairs { get; set; }

        public ObservableCollection<Country> GetCountries()
        {
            return Countries = new ObservableCollection<Country>(bd_connections.connection.Country.ToList());
        }

        public void CreateNewAccount(User user)
        {
            bd_connections.connection.User.Add(user);
            bd_connections.connection.SaveChanges();
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

        public void UserAuth()
        {

        }

        public bool MailValidate(string mail)
        {
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            bool isItEmail = Regex.IsMatch(mail, emailPattern);
            return isItEmail;
        }
    }
}

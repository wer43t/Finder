using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinderCore
{
    public class FinderCore
    {
        public static ObservableCollection<Country> Countries { get; set; }
        public static ObservableCollection<User> Users { get; set; }
        public static ObservableCollection<User_Info> UserInfos { get; set; }
        public static ObservableCollection<Zodiac> Zodiacs { get; set; }
        public static ObservableCollection<Pairs> Pairs { get; set; }

        private static ObservableCollection<User> NormalUsers = new ObservableCollection<User>(bd_connections.connection.User.ToList());

        //

        public ObservableCollection<Country> GetCountries()
        {
            return Countries = new ObservableCollection<Country>(bd_connections.connection.Country.ToList());
        }

        public ObservableCollection<Zodiac> GetZodiac()
        {
            return Zodiacs = new ObservableCollection<Zodiac>(bd_connections.connection.Zodiac.ToList());
        }

        public int GetZodiacID(string zodiacName)
        {
            Zodiacs = new ObservableCollection<Zodiac>(bd_connections.connection.Zodiac.ToList());
            var cnID = from zds in Zodiacs //
                       where zds.Name == zodiacName
                       select zds;
            return cnID.ToList()[0].Zodiac_ID;
        }

        public void CreateNewAccount(User user)
        {
            try
            {
                bd_connections.connection.User.Add(user);
                bd_connections.connection.SaveChanges();
            }
            catch (Exception e)
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
            bd_connections.connection.SaveChanges();
            InsertUserInfoInUser(CurrentUser.user.User_ID, user_Info.ID_User_Info);

        }

        public void InsertUserInfoInUser(int UserId, int UserInfoID)
        {
            Users = new ObservableCollection<User>(bd_connections.connection.User.ToList());
            var user = from usrs in Users
                       where UserId == usrs.User_ID
                       select usrs;
            user.FirstOrDefault().ID_User_Info = UserInfoID;
            bd_connections.connection.SaveChanges();
        }

        public bool UserAuth(User user)
        {
            Users = new ObservableCollection<User>(bd_connections.connection.User.ToList());
            var auth = from usrs in Users
                       where user.email == usrs.email && user.password == usrs.password
                       select usrs;
            if (auth.Count() == 1)
            {
                CurrentUser.user = auth.FirstOrDefault();
                return true;
            }
            else
                return false;
        }

        public User GetOneUser()
        {
            var user = NormalUsers.FirstOrDefault();
            NormalUsers.Remove(user);
            if (user != null)
            {
                if (CurrentUser.user.User_ID != user.User_ID)
                    return user;
                else
                {
                    var us = NormalUsers.FirstOrDefault();
                    NormalUsers.Remove(us);
                    return us;
                }
            }
            return null;
        }

        public bool MailValidate(string mail)
        {
            return new EmailAddressAttribute().IsValid(mail);
        }

        public bool CheckUserInfo()
        {
            return CurrentUser.user.ID_User_Info == null ? false : true;
        }

        public string GetAge(DateTime? dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Value.Year * 100 + dateOfBirth.Value.Month) * 100 + dateOfBirth.Value.Day;

            return ((a - b) / 10000).ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace UserLogin
{
      static public class UserData
    {
        private static List<User> _TestUsers;
        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _TestUsers;
            }
            set { }
        }

        private static void ResetTestUserData()
        {
           if (_TestUsers == null)
           {
                 _TestUsers = new List<User>();
                 User admin = new User("Dushko", "123456789", "123219020", UserRoles.ADMIN, DateTime.Now, DateTime.MaxValue);
                 _TestUsers.Add(admin);
                 User student1 = new User("IvanIvan", "Ivan123", "121219013", UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue);
                 _TestUsers.Add(student1);
                 User student2 = new User("Angela", "123123", "121219004", UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue);
                 _TestUsers.Add(student2);
           }
           else
           {
                   return;
           }
        }
        public static User IsUserPassCorrect(string ime, string parola)
        {
            foreach (User user in TestUsers)
            {
                User User = (from u in TestUsers
                             where u.PotrebitelskoIme.Equals(ime) && u.Parola.Equals(parola)
                             select u).First();
                return User;
            }
            return null;
        }
        static public void SetUserActiveTo(string Name, DateTime newActiveDate)
        {
            foreach (User user in TestUsers)
            {
                if (Name.Equals(user.PotrebitelskoIme))
                {
                    user.activeTime = newActiveDate;
                    Logger.LogActivity("Promqna na aktivnost " + Name);
                }
            }
        }
        public static void AssignUserRole(string Name, UserRoles Role)
        {
            foreach(User user in TestUsers)
            {
                if (Name.Equals(user.PotrebitelskoIme))
                {
                    user.Rolq = Role;
                }
            }
            Logger.LogActivity("Promqna na rolq " + Name);
        }

         public static void PrintUsers()
        {
          foreach (User user in TestUsers)
          {
          Console.WriteLine(user.PotrebitelskoIme);
          }

        }
      }
}

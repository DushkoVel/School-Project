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
            // UserContext context = new UserContext();
            //  User user = (from u in context.Users
            //                 where u.PotrebitelskoIme.Equals(ime) && u.Parola.Equals(parola)
            //                select u).First();
            //   return user;
            UserContext context = new UserContext();

            User usr =
            (from u in UserData.TestUsers
             where u.PotrebitelskoIme == ime && u.Parola == parola
             select u).First();
            context.SaveChanges();
            return usr;
        }
        static public void SetUserActiveTo(string Name, DateTime newActiveDate)
        {
            // foreach (User user in TestUsers)
            // {
            //     if (Name.Equals(user.PotrebitelskoIme))
            //     {
            //        user.activeTime = newActiveDate;
            //        Logger.LogActivity("Promqna na aktivnost " + Name);
            //    }
            // }
            UserContext context = new UserContext();

            User usr =
            (from u in UserData.TestUsers
             where u.PotrebitelskoIme == Name
             select u).First();
            usr.activeTime = newActiveDate;
            context.SaveChanges();
            Logger.LogActivity("Promqna na aktivnost " + Name);

        }
        public static void AssignUserRole(string Name, UserRoles Role)
        {
            //foreach(User user in TestUsers)
            //{
            //   if (Name.Equals(user.PotrebitelskoIme))
            //   {
            //       user.Rolq = Role;
            //    }
            // }
            UserContext context = new UserContext();

            User usr =
            (from u in UserData.TestUsers
             where u.PotrebitelskoIme == Name
             select u).First();
            usr.Rolq = Role;
            context.SaveChanges();
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

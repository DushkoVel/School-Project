using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    internal class Program
    {
        public static void Error(string errorMsg)
        {
            Console.WriteLine(errorMsg+"!!");
        }
        static void Main(string[] args)
        {
            string Name;
            string Password;
            Console.WriteLine("Vnesi Ime");
            Name = Console.ReadLine();
            Console.WriteLine("Vnesi Parola");
            Password = Console.ReadLine();
            LoginValidation validation = new LoginValidation(Name, Password, Error);
            User user = new User();
            if (validation.ValidateUserInput(user))
            {
                //Console.WriteLine(UserData.TestUser.PotrebitelskoIme);
                //Console.WriteLine(UserData.TestUser.Parola);
                //Console.WriteLine(UserData.TestUser.FakultetenNomer);
                //Console.WriteLine(LoginValidation.CurrentUserRole);
                Console.WriteLine(user);
            }
            switch (LoginValidation.CurrentUserRole)
            {
                case UserRoles.ANONYMOUS:
                    Console.WriteLine("ANONYMOUS");
                    break;

                case UserRoles.ADMIN:
                    Console.WriteLine("ADMIN");
                    AdminMenu();

                    break;

                case UserRoles.INSPECTOR:
                    Console.WriteLine("INSPECTOR");
                    break;

                case UserRoles.PROFESSOR:
                    Console.WriteLine("PROFESSOR");
                    break;

                case UserRoles.STUDENT:
                    Console.WriteLine("STUDENT");
                    break;
            }

        }
        public static void AdminMenu()
        {
            int izbor;
            Console.WriteLine("Izberete opciq:");
            Console.WriteLine("0: Izhod");
            Console.WriteLine("1: Promqna na rolq na potrebitel");
            Console.WriteLine("2: Promqna na aktivnost na potrebitel");
            Console.WriteLine("3: Spisak na potrebitelite");
            Console.WriteLine("4: Pregled na log na aktivnost");
            Console.WriteLine("5: Pregled na tekushta aktivnost");
            Console.WriteLine("6: Iztrivane na stari aktivnosti");
            izbor = Convert.ToInt32(Console.ReadLine());
            switch (izbor)
            {
                case 0:
                    return;

                case 1:
                    Console.WriteLine("Vavedete ime na potrebitel:");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Vavadete nova rolq na potrebitel:");
                    UserRoles newRole =(UserRoles)(Convert.ToInt32( Console.ReadLine()));
                    UserData.AssignUserRole(Name, newRole);
                    break;

                case 2:
                    Console.WriteLine("Vavedete ime na potrebitel:");
                    string Name1 = Console.ReadLine();
                    Console.WriteLine("Vavedete novo vreme (Godina-Mesec-Den):");
                    DateTime newActiveTime = Convert.ToDateTime(Console.ReadLine());
                    UserData.SetUserActiveTo(Name1, newActiveTime);
                    break;

                case 3:
                    Console.WriteLine(Logger.PrintLogActivity());
                    break;
                case 4:
                    StringBuilder sb = new StringBuilder();
                    IEnumerable<string> logActs =
                    Logger.PrintCurrentSessionActivities();
                    foreach (string line in logActs)
                    {
                        sb.Append(line);
                    }
                    break;
                case 5:
                    Console.WriteLine("Vavedete filter");
                    string filter = Console.ReadLine();
                    StringBuilder sb1 = new StringBuilder();
                    IEnumerable<string> currentActs =
                    Logger.GetCurrentSessionActivities(filter);
                    foreach (string line in currentActs)
                    {
                        sb1.Append(line);
                    }
                    break;
                case 6:
                    Logger.DeleteOldDate("text.txt");
                    break;
            }
        }
       
    }
}

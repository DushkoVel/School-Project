using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
     public class User
    {
        public DateTime _dateTime;
        public System.DateTime dateTime
        {
            get; set;
        }
        public DateTime _activeTime;
        public System.DateTime? activeTime { get; set; }
        public String _PotrebitelskoIme;
        public System.String PotrebitelskoIme
        { 
            get; set; 
        }

        public String _Parola;
        public System.String Parola {
            get; set; 
        }

        public String _FakultetenNomer;
        public System.String FakultetenNomer 
        { 
            get; set; 
        }

        public UserRoles _Rolq;
        public UserRoles Rolq 
        { 
            get; set; 
        }
        public UserRoles UserId { get; set; }

        public User (String potrebitelskoIme, String parola, String fakultetenNomer, UserRoles rolq, DateTime dateNow, DateTime ActiveTime)
        {
            this.PotrebitelskoIme = potrebitelskoIme;
            this.Parola = parola;
            this.FakultetenNomer = fakultetenNomer;
            this.Rolq = rolq;
            this.dateTime = dateNow;
            this.activeTime = ActiveTime;
           
        }
        public User()
        {
            
        }
        public static bool TestUsersIfEmpty()
        {
            UserContext context = new UserContext();
            IEnumerable<User> queryStudents = context.Users;
            int countStudents = queryStudents.Count();
            if (countStudents == 0)
                return true;
            else return false;
        }
        public static void CopyTestStudents()
        {
            UserContext context = new UserContext();

            foreach (User st in UserData.TestUsers)
            {
                context.Users.Add(st);
            }
            context.SaveChanges();
            if (TestUsersIfEmpty())
                CopyTestStudents();
        }
    }
}

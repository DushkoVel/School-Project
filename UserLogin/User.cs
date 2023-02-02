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
        public DateTime dateTime
        {
            get; set;
        }
        public DateTime _activeTime;
        public DateTime activeTime { get; set; }
        public String _PotrebitelskoIme;
        public String PotrebitelskoIme
        { 
            get; set; 
        }

        public String _Parola;
        public String Parola {
            get; set; 
        }

        public String _FakultetenNomer;
        public String FakultetenNomer 
        { 
            get; set; 
        }

        public UserRoles _Rolq;
        public UserRoles Rolq 
        { 
            get; set; 
        }

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
    }
}

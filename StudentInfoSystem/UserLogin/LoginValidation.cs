using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        public string PotrebitelskoIme;
        private string Parola;
        private string Greshka;
        public delegate void ActionOnError(string errorMsg);
        private ActionOnError error;

        public LoginValidation(string potrebitelskoIme, string parola, ActionOnError error1)
        {
            this.PotrebitelskoIme = potrebitelskoIme;
            this.Parola = parola;  
            this.error = error1;
        }

        //public static UserRoles _CurrentUserRole;
        public static UserRoles CurrentUserRole { get; private set; }
        public bool ValidateUserInput(User user1)
        {
            //user1 = UserData.TestUsers[2];
          
            
            Boolean emptyUserName;
            emptyUserName = PotrebitelskoIme.Equals(String.Empty);
            if (emptyUserName == true)
            {

                Greshka = "Ne e posocoeno Potrebitelsko Ime";
                error(Greshka);
                return false;
            }
            Boolean emptyPassword;
            emptyPassword = Parola.Equals(String.Empty);
            if (emptyPassword == true)
            {
                Greshka = "Ne e posocena parola";
                error(Greshka);
                return false;
            }
            if (PotrebitelskoIme.Length < 5)
            {
                Greshka = "PotrebitelskotoIme e pomalko ot 5";
                error(Greshka);
                return false;
            }
            if (Parola.Length < 5)
            {
                Greshka = "Parolata e pomalka ot 5";
                error(Greshka);
                return false;
            }
           user1 = UserData.IsUserPassCorrect(PotrebitelskoIme, Parola);
            if (user1 == null)
            {
                CurrentUserRole = UserRoles.ANONYMOUS;
                Greshka = "Potrebitelqt ne e nameren";
                error(Greshka);
                return false;
            }
            CurrentUserRole = (UserRoles)user1.Rolq;
            Logger.LogActivity("Uspeshno vlizane");

            return true;
        }

        private bool IsStringLessThan5(string potrebitelskoIme)
        {
            throw new NotImplementedException();
        }

        private bool IsStringEmpty(string potrebitelskoIme)
        {
            throw new NotImplementedException();
        }
    }
}

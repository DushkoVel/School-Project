using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    public class DiplomnaRabota
    {
        public Student student { get; set; }
        public string zaglavie { get; set;  }
        public User professor { get; set; }
        public DiplomnaRabota (Student stud, string zagl, User prof)
        {
            this.student = stud;
            this.zaglavie = zagl;
            this.professor = prof;
        }
        public static bool TestDiplomnaRabotaIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<DiplomnaRabota> queryStudents = context.Diplomna;
            int countStudents = queryStudents.Count();
            if (countStudents == 0)
                return true;
            else return false;
        }
        public static void CopyTestDiplomnaRabota()
        {
            StudentInfoContext context = new StudentInfoContext();

            foreach (DiplomnaRabota st in StudentData._Diplomna)
            {
                context.Diplomna.Add(st);
            }
            context.SaveChanges();
            if (TestDiplomnaRabotaIfEmpty())
                CopyTestDiplomnaRabota();
        }
        private static List<DiplomnaRabota> GetRegions()
        {
            StudentInfoContext context = new StudentInfoContext();
            List<DiplomnaRabota> dip = context.Diplomna.ToList();
            return dip;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;


namespace StudentInfoSystem
{
    public class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<DiplomnaRabota> Diplomna { get; set; }
        //public DbSet<User> Users { get; set; }
        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect)
        {
            
        }
        
        public static bool TestStudentsIfEmpty() {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            if (countStudents == 0)
                return true;
            else return false;
        }
        
    }

}

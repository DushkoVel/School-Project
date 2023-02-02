using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Familiq { get; set; }
        public string Fakultet { get; set; }
        public string Specialnost { get; set; }
        public string OKS { get; set; }
        public string Status { get; set; }
        public string FakNomer { get; set; }
        public int Kurs { get; set; }
        public int Potok { get; set; }
        public int Grupa { get; set; }
        public byte[] Snimka { get; set; }
        public int StudentId { get; set; }
        public override string ToString() { return this.Ime; }

        public Student(string ime, string prezime, string familiq, string fakultet, string specialnost, string oks, string status, string faknomer, int kurs, int potok, int grupa)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Familiq = familiq;
            this.Fakultet = fakultet;
            this.Specialnost = specialnost;
            this.OKS = oks;
            this.Status = status;
            this.FakNomer = faknomer;
            this.Kurs = kurs;
            this.Potok = potok;
            this.Grupa = grupa;

        }
        public Student()
        {

        }
        public static bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            if (countStudents == 0)
                return true;
            else return false;
        }
        public static void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();

            foreach (Student st in StudentData._TestStudents) 
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
            if (TestStudentsIfEmpty())
                CopyTestStudents();
        }
        private static List<Student> GetRegions()
        {
            StudentInfoContext context = new StudentInfoContext();
            List<Student> students = context.Students.ToList();
            return students;
        }
    }
}

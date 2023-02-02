using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class StudentData
    {
        private string facNum;

        public static List<Student> _TestStudents { get; set; }
        public  List<Student> TestStudents { get { return _TestStudents; } set { } }
        public static List<DiplomnaRabota> _Diplomna { get; set; }
        public List<DiplomnaRabota> Diplomna { get { return _Diplomna; } set { } }
        public StudentData()
        {
            _TestStudents = new List<Student>();
            _TestStudents.Add(exampleStudent());
            _Diplomna = new List<DiplomnaRabota>();
            _Diplomna.Add(exampleDiplomna());
        }


        public  List<Student> getStudents()
        {
            return this.TestStudents;

        }

        private void setStudents(List<Student> students)
        {
            this.TestStudents = students;
        }

        private Student exampleStudent()
        {
            Student student = new Student("Dushko", "Velinski", "Velinski", "FKST", "KSI", "Bakalavar", "Zaveril",
                "123219020", 3, 1, 33);

            return student;
        }
        private DiplomnaRabota exampleDiplomna()
        {
            DiplomnaRabota diplomna = new DiplomnaRabota(exampleStudent(), "sfgvsd", null);
            return diplomna;
        }
           
        public Student IsThereStudent()
        {
            StudentInfoContext context = new StudentInfoContext();

            Student result =
            (from st in context.Students
             where st.FakNomer == facNum
             select st).First();
            return result;
        }
    }
}

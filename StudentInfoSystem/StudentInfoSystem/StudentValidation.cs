using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;


namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            StudentData studentData = new StudentData();
            if (String.IsNullOrWhiteSpace(user.FakultetenNomer) || user == null)
            {
                Console.WriteLine("Nqma student s takav fakulteten nomer ili e prazen");
                return null;
            }

            IEnumerable<Student> students = studentData.getStudents();

            foreach (Student student in students)
            {
                if (student.FakNomer.Equals(user.FakultetenNomer))
                {
                    return student;
                }
            }

            Console.WriteLine("Nqma takav student!");
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserLogin;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student student;
        public User user;
        public List<string> StudStatusChoices { get; set; }

        public MainWindow()
        {
            FillStudStatusChoices();
            InitializeComponent();

            this.DataContext = this;

        }
        private void clear()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
            }
        }
        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    Console.WriteLine(s);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        private void setStudent(Student student)
        {
            if (isStudentDataCorrect(student))
            {
                enableControls();
                fillStudentInfo(student);
            }
            else
            {
                clear();
                disableControls();
            }

        }

        private Boolean isStudentDataCorrect(Student student)
        {
            return student != null && !String.IsNullOrWhiteSpace(student.Ime) && !String.IsNullOrWhiteSpace(student.Prezime) && !String.IsNullOrWhiteSpace(student.Familiq)
                && !String.IsNullOrWhiteSpace(student.Fakultet) && !String.IsNullOrWhiteSpace(student.Specialnost) && !String.IsNullOrWhiteSpace(student.OKS)
                && !String.IsNullOrWhiteSpace(student.Status) && !String.IsNullOrWhiteSpace(student.FakNomer) && student.Kurs != 0
                && student.Potok != 0 && student.Grupa != 0;
        }

        private void fillStudentInfo(Student student)
        {
            this.student = student;

            txtFirstName.Text = this.student.Ime;
            txtSecondName.Text = this.student.Prezime;
            txtLastName.Text = this.student.Familiq;
            txtFaculty.Text = this.student.Fakultet;
            txtSpeciality.Text = this.student.Specialnost;
            txtDegree.Text = this.student.OKS;
           // txtStatus.Text = this.student.Status;
            txtFacultyNumber.Text = this.student.FakNomer;
            txtCourse.Text = Convert.ToString(this.student.Kurs);
            txtFlow.Text = Convert.ToString(this.student.Potok);
            txtGroup.Text = Convert.ToString(this.student.Grupa);
        }

        private void disableControls()
        {
            foreach (Control ctr in MainGrid.Children)
            {
                if (ctr.Name == "btnLock" || ctr.Name == "btnTest")
                {
                    ctr.IsEnabled = true;
                }
                else
                {
                    ctr.IsEnabled = false;
                }
            }
        }

        private void enableControls()
        {
            foreach (Control ctr in MainGrid.Children)
            {
                ctr.IsEnabled = true;
            }
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            StudentData data = new StudentData();
            setStudent(data.getStudents().First());
        }

        private void btnTest2_Click(object sender, RoutedEventArgs e)
        {
            setStudent(null);
        }

        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            disableControls();
           // btnUnlock.IsEnabled = false;
        }

        private void btnUnlock_Click(object sender, RoutedEventArgs e)
        {
            enableControls();
        }
        private void btnVhod_Click(object sender, RoutedEventArgs e)
        {
            
            if(UserData.IsUserPassCorrect(Ime1.Text, Parola1.Text) != null)
            {
                disableControls();
                MessageBox.Show("Izhod");
            }
            
        }
        private void btnIzhod_Click(object sender, RoutedEventArgs e)
        {
           Izhod izhod = new Izhod();
            izhod.Show();
            this.Close();
        }

        private  void btnVremenen_Click(object sender, RoutedEventArgs e)
        {
            string s;
            if (StudentInfoContext.TestStudentsIfEmpty() == false)
                s = "False";
            else
                s = "True";
            MessageBox.Show(s);
        }
    }
}

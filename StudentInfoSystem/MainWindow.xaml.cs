using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using UserLogin;
using System.Data.Entity.Infrastructure;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> StudStatusChoices { get; set; }

        public MainWindow()
        {

            Window1 testMode = new Window1();
            testMode.ShowDialog();
            InitializeComponent();

            if (!Window1.test)
            {
                foreach (var item in MainGrid.Children)
                {
                    if (item is Button)
                    {
                        ((Button)item).Visibility = Visibility.Hidden;
                    }
                }
            }

            //AddUsers();
            //FillStudStatusChoices();
            //DeleteStudents(44);
            //DeleteStudents(121220173);
            //DeleteStudents(121220170);
            //DeleteStudents(121220118);
        }
        private static List<Student> GetStudentsFromDB()
        {
            StudentInfoContext context = new StudentInfoContext();

            List<Student> students = context.Students.ToList();
            return students;
        }
        private void DeleteStudents(int id)
        {
            StudentInfoContext context = new StudentInfoContext();
            Student delObj =
                (from st in context.Students
                 where st.Group == id
                 select st).First();
            context.Students.Remove(delObj);
            context.SaveChanges();
        }
        private void AddUsers()
        {
            StudentInfoContext context = new StudentInfoContext();
            UserLogin.UserData.ResetTestUserData();
            context.Users.AddRange(UserLogin.UserData.testUsers);
            context.SaveChanges();
            //UserLogin.UserData.testUsers
        }
        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            if (countStudents == 0) return true;
            else return false;
        }
        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }
            //save data in db
            context.SaveChanges();
        }

        private void RemoveTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Remove(st);
            }
            //save data in db
            context.SaveChanges();
        }
        private void FillStudStatusChoices()
        {
            if (TestStudentsIfEmpty() == true)
            {
                CopyTestStudents();
            }

            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnectE))
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
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        private void clearAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
        }
        private void showStudentButton_Click(object sender, RoutedEventArgs e)
        {
            StudentInfoContext studentInfoContext = new StudentInfoContext();
            Student student = StudentData.TestStudents.ElementAt(1);
            firstNameText.Text = student.FirstName;
            secondNameText.Text = student.SecondName;
            lastNameText.Text = student.LastName;
            facultyText.Text = student.Faculty;
            majorText.Text = student.Major;
            degreeText.Text = student.Degree;
            statusText.Text = student.Status;
            facultyNumberText.Text = student.FacultyNumber.ToString();
            courseText.Text = student.Course.ToString();
            streamText.Text = student.Stream.ToString();
            groupText.Text = student.Group.ToString();

            var studentID = studentInfoContext.Students.Where(x => x.FirstName == firstNameText.Text).Select(x => x.StudentId);
            var text = studentInfoContext.Marks.Where(y => y.studentId == studentID.Max()).Select(y => y.MarkValue).ToList();
            gradeText.Text = text.FirstOrDefault().ToString();
        }

        private void deactivateAllFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }
        }



        private void activateAllFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
            }
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            StudentInfoContext studentInfoContext = new StudentInfoContext();
            Student student = null;
            if (Window1.test)
            {
                student = StudentData.TestStudents[2];
            }
            else
            {
                if (LoginBtn.Content.ToString() == "Вход")
                {
                    LoginWindow loginWindow = new LoginWindow();
                    this.Hide();
                    //show login window and stop program until we close login window
                    loginWindow.ShowDialog();
                    //this.Close();
                    student = LoginWindow.Student;
                }

            }

            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
            }
           
            this.Show();

            if (student != null)
            {
                facultyText.Text = student.Faculty;
                majorText.Text = student.Major;
                degreeText.Text = student.Degree;
                statusText.Text = student.Status;
                facultyNumberText.Text = student.FacultyNumber.ToString();
                courseText.Text = student.Course.ToString();
                streamText.Text = student.Stream.ToString();
                groupText.Text = student.Group.ToString();
                firstNameText.Text = student.FirstName;
                secondNameText.Text = student.SecondName;
                lastNameText.Text = student.LastName;

                var studentID = studentInfoContext.Students.Where(x => x.FirstName == firstNameText.Text).Select(x => x.StudentId);
                var text = studentInfoContext.Marks.Where(y => y.studentId == studentID.Max()).Select(y => y.MarkValue).ToList();
                gradeText.Text = text.FirstOrDefault().ToString();
            }
            else { this.Close(); }

            if (LoginBtn.Content.ToString() == "Вход")
            {
                LoginBtn.Content = "Изход";
            }
            else if (LoginBtn.Content.ToString() == "Изход")
            {
                foreach (var item in MainGrid.Children)
                {
                    if (item is TextBox)
                    {
                        ((TextBox)item).IsEnabled = false;
                    }
                }

                firstNameText.Text = null;
                secondNameText.Text = null;
                lastNameText.Text = null;
                facultyText.Text = null;
                majorText.Text = null;
                degreeText.Text = null;
                statusText.Text = null;
                facultyNumberText.Text = null;
                courseText.Text = null;
                streamText.Text = null;
                groupText.Text = null;
                gradeText.Text = null;
                LoginBtn.Content = "Вход";
            }
        }
        private void AddGradeButton_Click(object sender, RoutedEventArgs e)
        {
            StudentInfoContext context = new StudentInfoContext();

            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnectE))
            {
                string sqlMarksInsert = "INSERT INTO Marks (studentId, MarkValue) VALUES (61, 4), (62, 3), (63, 6), (64, 5), (65, 5), (66, 6), (67, 4);";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlMarksInsert;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }
    }
}

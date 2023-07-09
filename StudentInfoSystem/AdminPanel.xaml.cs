using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        List<Student> students = StudentData.TestStudents;
        StudentData studentFiltered = new StudentData();
        
        StudentInfoContext context = new StudentInfoContext();
        public AdminPanel()
        {
            InitializeComponent();
            //List<Student> students = StudentData.TestStudents;

            // set the source of the CollectionViewSource to the students list
            //CollectionViewSource studentsViewSource = (CollectionViewSource)Resources["studentsViewSource"];
            //studentsViewSource.Source = students;
        }

        private void ShowStudentByFaculty()
        {
            if(students.Count() <= 0)
            {
                students = StudentData.TestStudents;
            }

            // Sort the students by first name
            students.Sort();

            // Order the filtered list by group
            var orderedStudents = students.OrderBy(s => s.Group);

            // Clear the existing items in the list box
            listBoxAdminPanel.Items.Clear();

            int selectedCourse = 3;
            // set the filter of the CollectionViewSource to match only the students in the selected course
            CollectionViewSource studentsViewSource = (CollectionViewSource)Resources["studentsViewSource"];

            // Add the ordered students to the list box
            foreach (Student st in orderedStudents)
            {
                if (st.Faculty == "ФКСТ")
                {
                    // subscribe to the filter event with a lambda expression that matches only the students in the selected course
                    studentsViewSource.Filter += (s, ev) =>
                    {
                        Student student = (Student)ev.Item;
                        ev.Accepted = student.Course == selectedCourse;
                    };

                    // check if the student is accepted by the filter before adding to the list box
                    if (studentsViewSource.View.Contains(st))
                    {
                        listBoxAdminPanel.Items.Add(st.FirstName);
                    }
                }
            }
        }

        private void ShowStudentByGroup()
        {
            listBoxAdminPanel.Items.Clear();

            //Get the filtered students
            students = studentFiltered.ShowStudentsByStream();

            // Sort the students by first name
            students.Sort();

            // Add the ordered students to the list box
            foreach (Student st in students)
            {
                if (st.Group == 44)
                    listBoxAdminPanel.Items.Add(st.FirstName);
            }
        }

        private void ShowStudent()
        {
            listBoxAdminPanel.Items.Clear();
            students.Sort();

            // Add the ordered students to the list box
            foreach (Student st in students)
            {
                if (st.FirstName == "Ерика")
                    listBoxAdminPanel.Items.Add(st.FirstName);
            }
        }

        private void AddNewStudent()
        {
            students.Add(new Student("Стивън", "Георгиев", "Желев", "ФКСТ", "КСИ",
                "Бакалавър", "Graduated", 121219102, "stiv47", "golfa", 4, 8, 42));
            //StudentData.testStudents.Add(students.Last());
            context.Students.Add(students.Last());
            context.Users.Add(new UserLogin.User("stiv47", "golfa", 121219102, 4, DateTime.Now, DateTime.MaxValue));
            context.SaveChanges();

            listBoxAdminPanel.Items.Clear();

            // Add the ordered students to the list box
            foreach (Student st in students)
            {
                if (st.FirstName == "Стивън")
                    listBoxAdminPanel.Items.Add(st.FirstName);
            }
        }

        private void DeleteStudent()
        {
            students.Remove(students.Last());
            context.Students.Remove(context.Students.Where(x => x.FirstName == "Стивън").FirstOrDefault());
            context.Users.Remove(context.Users.Where(x => x.username == "stiv47").FirstOrDefault());
            context.SaveChanges();

            listBoxAdminPanel.Items.Clear();

            // Add the ordered students to the list box
            foreach (Student st in students)
            {
                listBoxAdminPanel.Items.Add(st.FirstName);
            }
        }

        private void AddStudentBtn(object sender, RoutedEventArgs e)
        {
            AddNewStudent();
            // this.Close();
        }

        private void RemoveStudentBtn(object sender, RoutedEventArgs e)
        {
            DeleteStudent();
            // this.Close();
        }

        private void CheckStudentBtn(object sender, RoutedEventArgs e)
        {
            ShowStudent();
            // this.Close();
        }

        private void CheckFacultyBtn(object sender, RoutedEventArgs e)
        {
            ShowStudentByFaculty();
            // this.Close();
        }

        private void CheckGroupBtn(object sender, RoutedEventArgs e)
        {
            ShowStudentByGroup();
            // this.Close();
        }

        private void ExitAdminMode(object sender, RoutedEventArgs e)
        {
            listBoxAdminPanel.Items.Clear();
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}

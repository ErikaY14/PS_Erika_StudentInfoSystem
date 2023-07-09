using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class StudentData
    {
        //private static List<Student> testStudents = new List<Student>();
        public static List<Student> testStudents = new List<Student>();
        public static void ResetTestStudentData()
        {
            testStudents.Add(new Student("Ива", "Петкова", "Петкова", "ФКСТ", "КСИ", 
                "Бакалавър", "NotGraduated", 121220173, "ivcheto3","pass", 3, 10, 43));
            testStudents.Add(new Student("Аделина","Хикметова","Кехайова", "ФКСТ", "КСИ",
                "Бакалавър", "NotGraduated", 121220118, "adi9785","password", 3, 10, 43));
            testStudents.Add(new Student("Ерика", "Владимирова", "Йорданова", "ФКСТ", "КСИ",
                "Бакалавър", "NotGraduated", 121220092, "erikaaa", "password23", 3, 9, 44));
            testStudents.Add(new Student("Евгени", "НякойСи", "Божков", "ФКСТ", "КСИ",
                "Бакалавър", "NotGraduated", 1212200170, "genata", "pass123", 3, 9, 44));
            testStudents.Add(new Student("Теодор", "Георгиев", "Трайков", "МФ", "Мехатроника",
                "Бакалавър", "Graduated", 1212190120, "traikov", "pass1234", 4, 2, 23));
            testStudents.Add(new Student("Емилиян", "Димитров", "Георгиев", "ФКСТ", "КСИ",
                "Бакалавър", "Graduated", 121219009, "emoto13", "pass12345", 4, 9, 42));
            testStudents.Add(new Student("Деян", "Димитров", "Петров", "ФКСТ", "КСИ",
                "Бакалавър", "Graduated", 121219019, "deqn023", "pass1234567", 4, 9, 42));
        }

        public List<Student> ShowStudentsByStream()
        {
            StudentInfoContext studentInfoContext = new StudentInfoContext();
            List<Student> studentsFiltered = new List<Student>();
            // Get the students from the data source
            IEnumerable<Student> students = studentInfoContext.Students;

            // Create the filter objects
            IStudentFilter filter = new StreamFilter(9);

            // Filter the students
            IEnumerable<Student> filteredStudents = filter.Filter(students);

            // Display the sorted and filtered students
            foreach (Student student in filteredStudents)
            {
                studentsFiltered.Add(student);
            }
            return studentsFiltered;
        }
        public static List<Student> TestStudents
        {
            get
            {
                ResetTestStudentData();
                return testStudents;
            }
            set { testStudents = value; }
        }
    }
}

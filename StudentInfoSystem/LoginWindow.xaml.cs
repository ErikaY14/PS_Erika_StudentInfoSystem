using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        AdminPanel adminPanel = new AdminPanel();
        //MainWindow main = new MainWindow();
        public static Student Student { get; set; } = null;
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            StudentInfoContext context = new StudentInfoContext();

            if (context.Students.Where(x => x.Username == UsernameTextBox.Text && x.Password == PasswordTextBox.Text)
                .FirstOrDefault() != null)
            {
                if(context.Users.Where(x => x.username == UsernameTextBox.Text && x.password == PasswordTextBox.Text && x.role == 1)
                    .FirstOrDefault() != null)
                {
                    this.Close();
                    adminPanel.ShowDialog();
                    //Student = context.Students.Where(x => x.Username == UsernameTextBox.Text && x.Password == PasswordTextBox.Text)
                    //.FirstOrDefault();
                }
                else
                {
                
                    Student = context.Students.Where(x => x.Username == UsernameTextBox.Text && x.Password == PasswordTextBox.Text)
                    .FirstOrDefault();
                    this.Close();
                    //main.ShowDialog();
                }
                //close login window
                this.Close();
            }
            else
            {
                MessageBox.Show("Невалидно потреботелско име или парола!");
            }
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

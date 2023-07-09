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
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public static bool test { get; set; }

        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click_Yes(object sender, RoutedEventArgs e)
        {
            test = true;
            this.Close();
            
        }

        private void Button_Click_No(object sender, RoutedEventArgs e)
        {
            test = false;
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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

namespace FrontEnd
{
    public partial class WindowApp : Window
    {
        public WindowApp()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Products();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Provider();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Supply();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Users();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Role();
        }
    }
}

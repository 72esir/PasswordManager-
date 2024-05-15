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

namespace PasswordManeger
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            text.Text = "Welcome to Password Manager!\r\nSecurely store your passwords and easily access them.\r\nA secure and convenient application to store your passwords safely and in one place. Stress and worry free - your credentials are always under control. Ready to manage your passwords securely and conveniently?\r\nLet's get started!";
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }     


        private void NewPass(object sender, RoutedEventArgs e)
        {
           
        }

        private void Upload_Pass(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPass());
        }

        private void My_pass(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}

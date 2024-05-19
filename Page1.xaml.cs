using System.Windows;
using System.Windows.Controls;

namespace PasswordManeger
{
    public partial class Page1 : Page
    {
        private readonly User currentUser;

        public Page1(User user)
        {
            InitializeComponent();
            currentUser = user;
            text.Text = "Welcome to Password Manager!\r\nSecurely store your passwords and easily access them.\r\n" +
                        "A secure and convenient application to store your passwords safely and in one place. " +
                        "Stress and worry free - your credentials are always under control. " +
                        "Ready to manage your passwords securely and conveniently?\r\nLet's get started!";
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NewPass(object sender, RoutedEventArgs e)
        {
            NewPassWin newPassWindow = new NewPassWin(currentUser);
            newPassWindow.ShowDialog();
        }

        private void Upload_Pass(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPass(currentUser));
        }

        private void My_pass(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2(currentUser));
        }
    }
}
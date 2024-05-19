using System.Windows;
using System.Windows.Controls;

namespace PasswordManeger
{
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void Logup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogupPage());
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
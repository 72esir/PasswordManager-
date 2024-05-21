using System.Windows;
using System.Windows.Controls;

namespace PasswordManeger
{
    public partial class Page2 : Page
    {
        private readonly User currentUser;

        public Page2(User user)
        {
            InitializeComponent();
            currentUser = user;

            using (var context = new AppContext())
            {
                var passwords = context.PasswordEntries.Where(p => p.UserId == currentUser.Id).ToList();
                dataGrid1.ItemsSource = passwords;
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Upload_Pass(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPass(currentUser));
        }

        private void NewPass(object sender, RoutedEventArgs e)
        {
            NewPassWin newPassWindow = new NewPassWin(currentUser);
            newPassWindow.ShowDialog();
        }

        private void My_pass(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2(currentUser));
        }
    }
}
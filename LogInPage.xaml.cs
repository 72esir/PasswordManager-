using System.Windows;
using System.Windows.Controls;


namespace PasswordManeger
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            string login = Log.Text.Trim();
            string pass = Pass.Password.Trim();
                
            // Поиск пользователя в базе данных
            User authUser = null;
            using (AppContext context = new AppContext())
            {
                authUser = context.Users.FirstOrDefault(user => user.Login == login && user.Password == pass);
            }
            
            if (authUser != null)
            {
                Window1 win1 = new Window1(authUser);
                win1.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("User not found.");
            }
            
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
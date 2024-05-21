using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PasswordManeger
{
    public partial class LogupPage : Page
    {
        public LogupPage()
        {
            InitializeComponent();
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            // 2. Получение данных из полей ввода
            string login = Log.Text.Trim();
            string pass = Pass.Password.Trim();
            string rePass = RePass.Password.Trim();

            // 3. Валидация
            bool isValid = true;

            if (login.Length < 5)
            {
                SetErrorToolTip("Login must be at least 5 characters long.");
                isValid = false;
            }

            if (pass.Length < 7 || !ContainsSpecialCharacter(pass))
            {
                SetErrorToolTip("Password must be at least 7 characters long and contain at least one special character (?,!,*,#).");
                isValid = false;
            }

            if (pass != rePass)
            {
                SetErrorToolTip("Passwords do not match.");
                isValid = false;
            }

            // 4. Сохранение пользователя, если все данные валидны
            if (isValid)
            {
                User newUser = SaveAccToDatabase(login, pass);

                Window1 win1 = new Window1(newUser);
                win1.Show();

                Application.Current.MainWindow.Close();
            }
        }
        private bool ContainsSpecialCharacter(string text)
        {
            foreach (char c in text)
            {
                if ("?!*#".Contains(c))
                {
                    return true;
                }
            }
            return false;
        }

        private User SaveAccToDatabase(string login, string pass)
        {
            using (var context = new AppContext())
            {
                var newUser = new User { Login = login, Password = pass };
                context.Users.Add(newUser);
                context.SaveChanges();
                return newUser;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }       

        private void SetErrorToolTip(string message)
        {
            MessageBox.Show(message);
        }
    }
}
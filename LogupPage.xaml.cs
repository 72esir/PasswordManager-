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
            string login = Log.Text.Trim();
            string pass = Pass.Password.Trim();
            string rePass = RePass.Password.Trim();

            // Валидация пароля и логина
            if (IsPasswordInvalid(pass) && pass == rePass && login.Length >= 5)
            {
                SetErrorToolTip(Pass, "Password is too short or does not contain special characters (?,!,*,#).");
            }
            else if (IsPasswordInvalid(pass) && pass == rePass && login.Length < 5)
            {
                SetErrorToolTip(Pass, "Password is too short or does not contain special characters (?,!,*,#).");
                SetErrorToolTip(Log, "Login is too short.");
            }
            else if (IsPasswordInvalid(pass) && pass != rePass && login.Length >= 5)
            {
                SetErrorToolTip(Pass, "Password is too short or does not contain special characters (?,!,*,#).");
                SetErrorToolTip(RePass, "Retry the password.");
            }
            else if (pass != rePass && !IsPasswordInvalid(pass) && login.Length >= 5)
            {
                SetErrorToolTip(RePass, "Retry the password.");
            }
            else if (pass != rePass && !IsPasswordInvalid(pass) && login.Length < 5)
            {
                SetErrorToolTip(RePass, "Field is entered incorrectly.");
                SetErrorToolTip(Log, "Login is too short.");
            }
            else if (login.Length < 5 && !IsPasswordInvalid(pass) && pass == rePass)
            {
                SetErrorToolTip(Log, "Login is too short.");
            }
            else
            {
                User newUser = SaveAccToDatabase(login, pass);

                ClearErrorToolTips();

                Window1 win1 = new Window1(newUser);
                win1.Show();

                Application.Current.MainWindow.Close();
            }
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

        // Вспомогательные методы для проверки и вывода ошибок
        private bool IsPasswordInvalid(string password)
        {
            return password.Length < 7 ||
                   (!password.Contains("?") &&
                    !password.Contains("!") &&
                    !password.Contains("*") &&
                    !password.Contains("#"));
        }

        private void SetErrorToolTip(PasswordBox passwordBox, string message)
        {
            passwordBox.ToolTip = message;
            passwordBox.Background = Brushes.LightCoral;
        }

        private void SetErrorToolTip(TextBox textBox, string message)
        {
            textBox.ToolTip = message;
            textBox.Background = Brushes.LightCoral;
        }

        private void ClearErrorToolTips()
        {
            RePass.ToolTip = "";
            RePass.Background = Brushes.Transparent;
            Pass.ToolTip = "";
            Pass.Background = Brushes.Transparent;
            Log.ToolTip = "";
            Log.Background = Brushes.Transparent;
        }
    }
}
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
    /// Interaction logic for LogupPage.xaml
    /// </summary>
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

            if ((pass.Length < 7 || (!pass.Contains("?") && !pass.Contains("!") && !pass.Contains("*") && !pass.Contains("#"))) && (pass == rePass) && (login.Length >= 5))
            {
                Pass.ToolTip = "the password is too short or does not contain special characters (?,!,*) ";
                Pass.Background = Brushes.LightCoral;
            }
            else if ((pass.Length < 7 || (!pass.Contains("?") && !pass.Contains("!") && !pass.Contains("*") && !pass.Contains("#"))) && (pass == rePass) && (login.Length < 5))
            {
                Pass.ToolTip = "the password is too short or does not contain special characters (?,!,*)";
                Log.ToolTip = "login is too short";

                Pass.Background = Brushes.LightCoral;
                Log.Background = Brushes.LightCoral;
            }
            else if ((pass.Length < 7 || (!pass.Contains("?") && !pass.Contains("!") && !pass.Contains("*") && !pass.Contains("#"))) && (pass != rePass) && (login.Length >= 5))
            {
                Pass.ToolTip = "the password is too short or does not contain special characters (?,!,*)";
                RePass.ToolTip = "retry the password";

                Pass.Background = Brushes.LightCoral;
                RePass.Background = Brushes.LightCoral;
            }


            else if ((pass != rePass) && (pass.Length >= 7 && (pass.Contains("?") || pass.Contains("!") || pass.Contains("*") || !pass.Contains("#"))) && login.Length >= 5)
            {
                RePass.ToolTip = "retry the password";
                RePass.Background = Brushes.LightCoral;
            }
            else if ((pass != rePass) && (pass.Length >= 7 && (pass.Contains("?") || pass.Contains("!") || pass.Contains("*") || !pass.Contains("#"))) && login.Length < 5)
            {
                RePass.ToolTip = "field is entered incorrectly";
                RePass.Background = Brushes.LightCoral;

                Log.ToolTip = "login is too short";
                Log.Background = Brushes.LightCoral;
            }


            else if (login.Length < 5 && (pass.Length >= 7 && (pass.Contains("?") || pass.Contains("!") || pass.Contains("*") || pass.Contains("#"))) && (pass == rePass))
            {
                Log.ToolTip = "login is too short";
                Log.Background = Brushes.LightCoral;
            }
            else
            {
                User newUser = SaveAccToDatabase(login, pass);
                
                RePass.ToolTip = "";
                RePass.Background = Brushes.Transparent;
                Pass.ToolTip = "";
                Pass.Background = Brushes.Transparent;
                Log.ToolTip = "";
                Log.Background = Brushes.Transparent;

                Window1 win1 = new Window1(newUser);
                win1.Show();

                Window currentWindow = Application.Current.MainWindow;
                currentWindow.Close();
            }
        }
        private User SaveAccToDatabase(string login,string pass)
        {
            using (var context = new AppContext())
            {
                var newUser = new User { Login = login, Password = pass };
                context.Users.Add(newUser);
                context.SaveChanges();
                return newUser; // Возвращаем созданного пользователя
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
    }
}

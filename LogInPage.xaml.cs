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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
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
           

            if ((pass.Length < 7 || (!pass.Contains("?") && !pass.Contains("!") && !pass.Contains("*") && !pass.Contains("#"))) && (login.Length >= 5))
            {
                Pass.ToolTip = "the password is too short or does not contain special characters (?,!,*) ";
                Pass.Background = Brushes.LightCoral;
            }
            else if ((pass.Length < 7 || (!pass.Contains("?") && !pass.Contains("!") && !pass.Contains("*") && !pass.Contains("#"))) && (login.Length < 5))
            {
                Pass.ToolTip = "the password is too short or does not contain special characters (?,!,*)";
                Log.ToolTip = "login is too short";

                Pass.Background = Brushes.LightCoral;
                Log.Background = Brushes.LightCoral;
            }
            else if ((pass.Length < 7 || (!pass.Contains("?") && !pass.Contains("!") && !pass.Contains("*") && !pass.Contains("#")))  && (login.Length >= 5))
            {
                Pass.ToolTip = "the password is too short or does not contain special characters (?,!,*)";
                Pass.Background = Brushes.LightCoral;
            }
            else
            {
                Pass.ToolTip = "";
                Pass.Background = Brushes.Transparent;
                Log.ToolTip = "";
                Log.Background = Brushes.Transparent;

                User authUser = null;
                using (AppContext context = new AppContext())
                {
                    authUser = context.Users.Where(user => user.Login==login && user.Password == pass).FirstOrDefault();
                }

                if (authUser != null)
                {
                    Window1 win1 = new Window1(authUser);
                    win1.Show();
                    Window currentWindow = Application.Current.MainWindow;
                    currentWindow.Close();
                }
                else
                    MessageBox.Show("Пользователь не найден");
            }

           
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

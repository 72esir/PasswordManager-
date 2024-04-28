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

            if (pass.Length < 7 || (!pass.Contains("?") && !pass.Contains("!") && !pass.Contains("*") && !pass.Contains("#")))
            {
                Pass.ToolTip = "field is entered incorrectly";
                Pass.Background = Brushes.LightCoral;
            }
            else
            {
                Pass.ToolTip = "";
                Pass.Background = Brushes.Transparent;
            }

            if (pass != rePass)
            {
                RePass.ToolTip = "field is entered incorrectly";
                RePass.Background = Brushes.LightCoral;
            }
            else
            {
                RePass.ToolTip = "";
                RePass.Background = Brushes.Transparent;
            }

            if (login.Length < 5)
            {
                Log.ToolTip = "field is entered incorrectly";
                Log.Background = Brushes.LightCoral;
            }
            else
            {
                Log.ToolTip = "";
                Log.Background = Brushes.Transparent;
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());
        }
    }
}

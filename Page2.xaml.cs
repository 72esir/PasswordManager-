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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private User currentUser;
        public Page2(User user)
        {
            InitializeComponent();
            currentUser = user;
            using (var context = new AppContext())
            {
                var passwords = context.PasswordEntries.Where(p => p.UserId == currentUser.Id).ToList();

                // Отображаем пароли в DataGrid или другом подходящем элементе
                dataGrid1.ItemsSource = passwords; // Замените dataGrid на имя вашего элемента
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

        }
        private void My_pass(object sender, RoutedEventArgs e)
        {
            
        }


    }
}

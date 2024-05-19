using System.Windows;
using System.Windows.Input;

namespace PasswordManeger
{
    public partial class Window1 : Window
    {
        private readonly User currentUser;

        public Window1(User user)
        {
            InitializeComponent();
            currentUser = user;
            Fraim.Content = new Page1(currentUser);
        }

        private void MouseDown(object sender, MouseButtonEventArgs e) => DragMove();
    }
}
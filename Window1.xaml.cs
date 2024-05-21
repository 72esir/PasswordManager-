using System.Windows;
using System.Windows.Input;


namespace PasswordManeger
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        private User currentUser;

        // Конструктор с параметром для получения пользователя
        public Window1(User user)
        {
            InitializeComponent();
            currentUser = user;
            Fraim.Content = new Page1(currentUser); // Передаем пользователя в Page1
        }
        private void MouseDown(object sender, MouseButtonEventArgs e) => DragMove();
    }

}

using System.Windows;
using System.Windows.Input;

namespace PasswordManeger
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new StartPage());
        }

        private void MouseDown(object sender, MouseButtonEventArgs e) => DragMove();
    }
}
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
using System.Windows.Shapes;

namespace PasswordManeger
{
    /// <summary>
    /// Interaction logic for NewPassWin.xaml
    /// </summary>
    public partial class NewPassWin : Window
    {
        public NewPassWin()
        {
            InitializeComponent();
        }
        private void MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

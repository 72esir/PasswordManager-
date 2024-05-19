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
        private string RandPass()
        {
            string password = "";

            string[] letters = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            string[] syms = { "!","?","-","$"};

            Random a = new Random();
            Random b = new Random();
            Random c = new Random();

            int ra, rb, rc;
            for (int i = 0; i < 4; i++)
            {
                ra = a.Next(0,65);
                rb = b.Next(0,9); 
                rc = c.Next(0,3);
                password += letters[ra] + numbers[rb] + syms[rc];
            }
            return password;
        }

        private void StrongPass(object sender, RoutedEventArgs e)
        {
            string password = RandPass();
            pass.Password = password;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string login = name.Text.Trim();
            this.Close();
        }
    }
}

using System;
using System.Windows;
using System.Windows.Input;

namespace PasswordManeger
{
    public partial class NewPassWin : Window
    {
        private readonly User currentUser;

        public NewPassWin(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private string GenerateRandomPassword()
        {
            const string letters = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "1234567890";
            const string symbols = "!?-$";

            Random random = new Random();
            string password = "";

            for (int i = 0; i < 4; i++)
            {
                password += letters[random.Next(letters.Length)];
                password += numbers[random.Next(numbers.Length)];
                password += symbols[random.Next(symbols.Length)];
            }

            return password;
        }

        private void StrongPass(object sender, RoutedEventArgs e)
        {
            pass.Text = GenerateRandomPassword();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string url = link.Text.Trim();
            string login = name.Text.Trim();
            string password = pass.Text.Trim();

            using (var context = new AppContext())
            {
                var newPasswordEntry = new PasswordEntry
                {
                    UserId = currentUser.Id,
                    Url = url,
                    Username = login,
                    Password = password,
                    Comment = string.Empty,
                    Tags = string.Empty
                };

                context.PasswordEntries.Add(newPasswordEntry);
                context.SaveChanges();
            }

            MessageBox.Show("Password saved!");
            Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Linq;

namespace PasswordManeger
{
    public partial class AddPass : Page
    {
        private User currentUser;
        public AddPass(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    var csvData = File.ReadAllLines(filePath)
                        .Skip(1) // Пропускаем заголовок
                        .Select(line => line.Split(','))
                        .Select(fields => new CsvRow
                        {
                            Url = fields[0],
                            Username = fields[1],
                            Password = fields[2],
                            Comment = fields[3],
                            Tags = fields[4]
                        })
                        .ToList();

                    dataGrid.ItemsSource = csvData;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при чтении файла: {ex.Message}");
                }
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1(currentUser));
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void addingToDb(object sender, RoutedEventArgs e)
        {
            // Проверка, выбран ли хотя бы один пароль из DataGrid
            if (dataGrid.ItemsSource != null)
            {
                var csvData = (List<CsvRow>)dataGrid.ItemsSource;
                int duplicatesCount = 0;

                using (var context = new AppContext())
                {
                    foreach (var selectedPassword in csvData)
                    {
                        // Проверка на дубликат
                        bool isDuplicate = context.PasswordEntries.Any(p =>
                            p.UserId == currentUser.Id &&
                            p.Url == selectedPassword.Url &&
                            p.Username == selectedPassword.Username);

                        if (!isDuplicate)
                        {
                            var newPasswordEntry = new PasswordEntry
                            {
                                UserId = currentUser.Id,
                                Url = selectedPassword.Url,
                                Username = selectedPassword.Username,
                                Password = selectedPassword.Password,
                                Comment = selectedPassword.Comment,
                                Tags = selectedPassword.Tags
                            };

                            context.PasswordEntries.Add(newPasswordEntry);
                        }
                        else
                        {
                            duplicatesCount++;
                        }
                    }
                    context.SaveChanges();
                }

                string message = $"Добавлено {csvData.Count - duplicatesCount} паролей.";
                if (duplicatesCount > 0)
                {
                    message += $"\n{duplicatesCount} дубликатов пропущено.";
                }
                MessageBox.Show(message);
                NavigationService.Navigate(new Page2(currentUser));
            }
            else
            {
                MessageBox.Show("Список паролей пуст.");
            }

        } 
    }

    public class CsvRow
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Comment { get; set; }
        public string Tags { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace PasswordManeger
{
    public partial class AddPass : Page
    {
        private readonly User currentUser;

        public AddPass(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != true)
            {
                return;
            }

            string filePath = openFileDialog.FileName;

            try
            {
                var csvData = File.ReadAllLines(filePath)
                    .Skip(1)
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
                MessageBox.Show($"File reading error: {ex.Message}");
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
            if (dataGrid.ItemsSource == null)
            {
                MessageBox.Show("The password list is empty.");
                return;
            }

            var csvData = (List<CsvRow>)dataGrid.ItemsSource;
            int duplicatesCount = 0;

            using (var context = new AppContext())
            {
                foreach (var selectedPassword in csvData)
                {
                    if (context.PasswordEntries.Any(p =>
                        p.UserId == currentUser.Id &&
                        p.Url == selectedPassword.Url &&
                        p.Username == selectedPassword.Username))
                    {
                        duplicatesCount++;
                        continue;
                    }

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
                context.SaveChanges();
            }

            string message = $"{csvData.Count - duplicatesCount} passwords added.";
            if (duplicatesCount > 0)
            {
                message += $"\n{duplicatesCount} duplicates were not added.";
            }

            MessageBox.Show(message);
            NavigationService.Navigate(new Page2(currentUser));
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
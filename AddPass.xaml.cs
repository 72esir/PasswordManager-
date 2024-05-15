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
        public AddPass()
        {
            InitializeComponent();
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
            NavigationService.Navigate(new Page1());
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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
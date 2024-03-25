using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace practika1q
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Practika";
            string subpath = @"firstquest\fordocument";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
            if (rd1.IsChecked  == true)
            {
                string pathforfail = tb1.Text+".txt";
                using (StreamWriter writer = new StreamWriter(pathforfail, false))
                {
                     writer.WriteLineAsync(tb2.Text);
                }

                using (StreamWriter writer = new StreamWriter(pathforfail, true))
                {
                    writer.WriteLineAsync(tb2.Text);
                }
                File.WriteAllText(pathforfail, tb2.Text);
                labsub.Content = Path.GetFullPath(pathforfail);
            }
           else if (rd2.IsChecked == true)
            {
                string pathforfail = tb1.Text + ".doc";
                using (StreamWriter writer = new StreamWriter(pathforfail, false))
                {
                    writer.WriteLineAsync(tb2.Text);
                }

                using (StreamWriter writer = new StreamWriter(pathforfail, true))
                {
                    writer.WriteLineAsync(tb2.Text);
                }
                File.WriteAllText(pathforfail, tb2.Text);
                labsub.Content = Path.GetFullPath(pathforfail);
            }

        }

        private void rd1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rd2_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

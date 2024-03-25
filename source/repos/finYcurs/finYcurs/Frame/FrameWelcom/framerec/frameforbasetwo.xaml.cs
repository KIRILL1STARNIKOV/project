using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;
namespace finYcurs.Frame.FrameWelcom.framerec
{
    /// <summary>
    /// Логика взаимодействия для frameforbasetwo.xaml
    /// </summary>
    public partial class frameforbasetwo : Page
    {
        public frameforbasetwo()
        {
            InitializeComponent();
            LoadData();
        }
        public void SaveData()
        {
            TempDataStorage.TextDataINN = tbForINN.Text;
            TempDataStorage.TextDataKPP = tbForKPP.Text;
            TempDataStorage.TextDataOGRN = tbForOGRN.Text;
            TempDataStorage.TextDataNumber = tbForNumber.Text;
            TempDataStorage.TextDataEmail = tbForEmail.Text;
        }

        // Метод загрузки данных при открытии страницы
        public void LoadData()
        {

            tbForINN.Text = TempDataStorage.TextDataINN;
            tbForKPP.Text = TempDataStorage.TextDataKPP;
            tbForOGRN.Text = TempDataStorage.TextDataOGRN;
            tbForNumber.Text = TempDataStorage.TextDataNumber;
            tbForEmail.Text = TempDataStorage.TextDataEmail;  
        }
        private void CheckMaskedTextBoxInput(MaskedTextBox maskedTextBox, int expectedLength, string fieldName)
        {
            if (maskedTextBox != null)
            {
                string text = maskedTextBox.Text;

                // Удаление символов маски из текста
                string unmaskedText = text.Replace(maskedTextBox.PromptChar.ToString(), "");

                // Проверяем, была ли введена вся маска
                if (unmaskedText.Length != expectedLength)
                {
                    // Если не все символы введены, показываем предупреждение
                    System.Windows.MessageBox.Show($"Пожалуйста, введите все символы {fieldName}.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        private void MaskedTBNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            MaskedTextBox maskedTextBox = sender as MaskedTextBox;
            if (maskedTextBox != null)
            {
                string text = maskedTextBox.Text;

                // Удаление символов маски из текста
                string digitsOnly = Regex.Replace(text, @"[^\d]", "");

                // Проверяем, была ли введена вся маска
                if (digitsOnly.Length != 11) // Например, для номера телефона без кода страны
                {
                    // Если не все символы введены, показываем предупреждение
                    System.Windows.MessageBox.Show($"Пожалуйста, введите полный номер телефона.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        private void MaskedTBOGRN_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckMaskedTextBoxInput(sender as MaskedTextBox, 13, "КПП");
        }
        private void MaskedTBINN_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckMaskedTextBoxInput(sender as MaskedTextBox, 10, "ИНН");
        }

        private void MaskedTBKPP_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckMaskedTextBoxInput(sender as MaskedTextBox, 9, "КПП");
        }

        private void butbackframe(object sender, RoutedEventArgs e)
        {
            SaveData();
            frameforbaseone nextPage = new frameforbaseone(); // Замените frameforbaseone на имя вашего следующего фрейма
            // Получение родительского элемента Frame
            System.Windows.Controls.Frame parentFrame = Window.GetWindow(this).FindName("FrameChangedWelcom") as System.Windows.Controls.Frame;

            // Замена содержимого фрейма на новую страницу или пользовательский контент
            parentFrame.Navigate(nextPage);
        }

        private void butnextframe(object sender, RoutedEventArgs e)
        {
            SaveData();
            frameforbasethri nextPage = new frameforbasethri(); // Замените frameforbaseone на имя вашего следующего фрейма
            // Получение родительского элемента Frame
            System.Windows.Controls.Frame parentFrame = Window.GetWindow(this).FindName("FrameChangedWelcom") as System.Windows.Controls.Frame;

            // Замена содержимого фрейма на новую страницу или пользовательский контент
            parentFrame.Navigate(nextPage);
        }
    }
}

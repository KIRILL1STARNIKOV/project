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
    /// Логика взаимодействия для frameforbasethri.xaml
    /// </summary>
    public partial class frameforbasethri : Page
    {
        public frameforbasethri()
        {
            InitializeComponent();
            LoadData();
        }
        public void SaveData()
        {
            TempDataStorage.TextDataIFNS = tbdateIFNS.Text;
            TempDataStorage.TextDatanameIFNS = tbfornameIFNS.Text;
            TempDataStorage.TextDataCodeABO = tbforCodeABO.Text;
            TempDataStorage.TextDataregmunPF = tbforregmunPF.Text;
            TempDataStorage.TextDataregmunFSS = tbforregmunFSS.Text;
            TempDataStorage.TextDataOKATO = tbforOKATO.Text;
            TempDataStorage.TextDataOKTMO = tbforOKTMO.Text;
            TempDataStorage.TextDataOKPO = tbforOKAPO.Text;
            TempDataStorage.TextDatatbtaxnum = tbtaxnum.Text;
            TempDataStorage.TextDatacodeIFNS = tbcodeIFNS.Text;
        }

        // Метод загрузки данных при открытии страницы
        public void LoadData()
        {

            tbdateIFNS.Text = TempDataStorage.TextDataIFNS;
            tbfornameIFNS.Text = TempDataStorage.TextDatanameIFNS;
            tbforCodeABO.Text = TempDataStorage.TextDataCodeABO;
            tbforregmunPF.Text = TempDataStorage.TextDataregmunPF;
            tbforregmunFSS.Text = TempDataStorage.TextDataregmunFSS;
            tbforOKATO.Text = TempDataStorage.TextDataOKATO;
            tbforOKTMO.Text = TempDataStorage.TextDataOKTMO;
            tbforOKAPO.Text = TempDataStorage.TextDataOKPO;
            tbtaxnum.Text = TempDataStorage.TextDatatbtaxnum;
            tbcodeIFNS.Text = TempDataStorage.TextDatacodeIFNS;
        }
        private void butretframe(object sender, RoutedEventArgs e)
        {
            SaveData();
            frameforbasetwo nextPage = new frameforbasetwo(); // Замените frameforbaseone на имя вашего следующего фрейма
            // Получение родительского элемента Frame
            System.Windows.Controls.Frame parentFrame = Window.GetWindow(this).FindName("FrameChangedWelcom") as System.Windows.Controls.Frame;

            // Замена содержимого фрейма на новую страницу или пользовательский контент
            parentFrame.Navigate(nextPage);
        }

        private void butnextframe(object sender, RoutedEventArgs e)
        {
            SaveData();
            frameforbasefore nextPage = new frameforbasefore();
            System.Windows.Controls.Frame parentFrame = Window.GetWindow(this).FindName("FrameChangedWelcom") as System.Windows.Controls.Frame;

            // Замена содержимого фрейма на новую страницу или пользовательский контент
            parentFrame.Navigate(nextPage);
        }
    
        private void CheckMaskedTextBoxInput(MaskedTextBox maskedTextBox, int expectedLength, string fieldName)
        {
            if (maskedTextBox != null)
            {
                string text = maskedTextBox.Text.Replace(maskedTextBox.PromptChar.ToString(), "");

                // Проверяем, была ли введена вся маска
                if (text.Length != expectedLength)
                {
                    // Если не все символы введены, показываем предупреждение
                    System.Windows.MessageBox.Show($"Пожалуйста, введите все символы {fieldName}.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void MaskedTBPF_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckMaskedTextBoxInput(sender as MaskedTextBox, 12, "регистрационного номера ПФ");
        }

        private void MaskedTBFSS_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckMaskedTextBoxInput(sender as MaskedTextBox, 12, "регистрационного номера ФСС");
        }

        private void MaskedTBOKATO_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckMaskedTextBoxInput(sender as MaskedTextBox, 8, "ОКАТО");
        }

        private void MaskedTBOKTMO_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckMaskedTextBoxInput(sender as MaskedTextBox, 9, "ОКТМО");
        }

        private void MaskedTBrOKAPO_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckMaskedTextBoxInput(sender as MaskedTextBox, 8, "ОКПО");
        }
    }
}

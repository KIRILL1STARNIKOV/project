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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace finYcurs.Frame.FrameWelcom.framerec
{
    /// <summary>
    /// Логика взаимодействия для frameforbaseone.xaml
    /// </summary>
    public partial class frameforbaseone : Page
    {

        public frameforbaseone()
        {
            InitializeComponent();
            LoadData();
        }
        public void SaveData()
        {
            TempDataStorage.TextDataNameCompany = tbForNameCompany.Text;
            TempDataStorage.TextDataTaxpay = cbforTaxpay.Text;
            TempDataStorage.TextDataAdressLegal = tbForAdressLegal.Text;
            TempDataStorage.TextDataAdressActual = tbForAdressActual.Text;
        }

        // Метод загрузки данных при открытии страницы
        public void LoadData()
        {

            tbForNameCompany.Text = TempDataStorage.TextDataNameCompany;
            cbforTaxpay.Text = TempDataStorage.TextDataTaxpay;
            tbForAdressLegal.Text = TempDataStorage.TextDataAdressLegal;
            tbForAdressActual.Text = TempDataStorage.TextDataAdressActual;
        }
        private void butnextframe(object sender, EventArgs e)
        {
            SaveData();
            frameforbasetwo nextPage = new frameforbasetwo(); // Замените frameforbaseone на имя вашего следующего фрейма
            // Получение родительского элемента Frame
            System.Windows.Controls.Frame parentFrame = Window.GetWindow(this).FindName("FrameChangedWelcom") as System.Windows.Controls.Frame;

            // Замена содержимого фрейма на новую страницу или пользовательский контент
            parentFrame.Navigate(nextPage);
        }
    }
}

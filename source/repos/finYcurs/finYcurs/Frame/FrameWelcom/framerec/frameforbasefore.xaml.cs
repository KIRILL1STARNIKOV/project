using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Xceed.Wpf.Toolkit;
namespace finYcurs.Frame.FrameWelcom.framerec
{
    /// <summary>
    /// Логика взаимодействия для frameforbasefore.xaml
    /// </summary>
    public partial class frameforbasefore : Page
    {
        public frameforbasefore()
        {
            InitializeComponent();
        }
        public void SaveData()
        {
            TempDataStorage.TextDataownershipCode = tbForCodeonwer.Text;
            TempDataStorage.TextDatatypeOwnership = tbForformsobstv.Text;
            TempDataStorage.TextDataActivityСodeOKVED = tbForOKVED.Text;
            TempDataStorage.TextDatakindAcrivity = tbFornamedei.Text;
        }

        public void LoadData()
        {
            tbForCodeonwer.Text = TempDataStorage.TextDataownershipCode;
            tbForformsobstv.Text = TempDataStorage.TextDatatypeOwnership;
            tbForOKVED.Text = TempDataStorage.TextDataActivityСodeOKVED;
            tbFornamedei.Text = TempDataStorage.TextDatakindAcrivity;
        }
        private void MaskedTBODKED_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckMaskedTextBoxInput(sender as MaskedTextBox, 4, "Код Вида Деятельности ОКВЭД");
        }

        private void MaskedTBFS_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckMaskedTextBoxInput(sender as MaskedTextBox, 2, "Код Формы собственности оп ОКФС");
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

        private void butsaveframe(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создаем подключение к базе данных
                using (SqlConnection connection = new SqlConnection($"Data Source=DESKTOP-TBDN17P; Initial Catalog=DBFinY; Integrated Security=True"))
                {
                    // Открываем подключение
                    connection.Open();

                    // Создаем команду для вставки данных в таблицу
                    string insertQuery = "INSERT INTO BasicDetalis (namecompany, taxpayertype, INN, KPP, " +
                                         "OGRN, adresslegal, adressactual, numbar, email, taxregnum, kodeIFNS, " +
                                         "dateissue, nameIFNS, codeaboFNS, regnumPF, regnumFSS, OKATO, OKTMO, " +
                                         "OKPO, ActivityСodeOKVED, kindAcrivity, ownershipCode,typeOwnership) " +
                                         "VALUES (@Valuenamecompany, @Valuetaxpayertype, @ValueINN, @ValueKPP, @ValueOGRN, " +
                                         "@Valueadresslegal, @Valueadressactual, @Valuenumbar, @Valueemail, @Valuetaxregnum, @ValuekodeIFNS, @Valuedateissue, " +
                                         "@ValuenameIFNS, @ValuecodeaboFNS, @ValueregnumPF, @ValueregnumFSS, @ValueOKATO, @ValueOKTMO, @ValueOKPO, " +
                                         "@ValueActivityСodeOKVED, @ValuekindAcrivity, @ValueownershipCode, @ValuetypeOwnership)";
                    SqlCommand command = new SqlCommand(insertQuery, connection);

                    // Задаем параметры для команды вставки
                    command.Parameters.AddWithValue("@Valuenamecompany", TempDataStorage.TextDataNameCompany);
                    command.Parameters.AddWithValue("@Valuetaxpayertype", TempDataStorage.TextDataTaxpay);
                    command.Parameters.AddWithValue("@ValueINN", TempDataStorage.TextDataINN);
                    command.Parameters.AddWithValue("@ValueKPP", TempDataStorage.TextDataKPP);
                    command.Parameters.AddWithValue("@ValueOGRN", TempDataStorage.TextDataOGRN);
                    command.Parameters.AddWithValue("@Valueadresslegal", TempDataStorage.TextDataAdressLegal);
                    command.Parameters.AddWithValue("@Valueadressactual", TempDataStorage.TextDataAdressActual);
                    command.Parameters.AddWithValue("@Valuenumbar", TempDataStorage.TextDataNumber);
                    command.Parameters.AddWithValue("@Valueemail", TempDataStorage.TextDataEmail);
                    command.Parameters.AddWithValue("@Valuetaxregnum", TempDataStorage.TextDatatbtaxnum);
                    command.Parameters.AddWithValue("@ValuekodeIFNS", TempDataStorage.TextDatacodeIFNS);
                    command.Parameters.AddWithValue("@Valuedateissue", TempDataStorage.TextDataIFNS);
                    command.Parameters.AddWithValue("@ValuenameIFNS", TempDataStorage.TextDatanameIFNS);
                    command.Parameters.AddWithValue("@ValuecodeaboFNS", TempDataStorage.TextDataCodeABO);
                    command.Parameters.AddWithValue("@ValueregnumPF", TempDataStorage.TextDataregmunPF);
                    command.Parameters.AddWithValue("@ValueregnumFSS", TempDataStorage.TextDataregmunFSS);
                    command.Parameters.AddWithValue("@ValueOKATO", TempDataStorage.TextDataOKATO);
                    command.Parameters.AddWithValue("@ValueOKTMO", TempDataStorage.TextDataOKTMO);
                    command.Parameters.AddWithValue("@ValueOKPO", TempDataStorage.TextDataOKPO);
                    command.Parameters.AddWithValue("@ValueActivityСodeOKVED", TempDataStorage.TextDataActivityСodeOKVED);
                    command.Parameters.AddWithValue("@ValuekindAcrivity", TempDataStorage.TextDatakindAcrivity);
                    command.Parameters.AddWithValue("@ValueownershipCode", TempDataStorage.TextDataownershipCode);
                    command.Parameters.AddWithValue("@ValuetypeOwnership", TempDataStorage.TextDatatypeOwnership);

                    // Выполняем команду
                    int rowsAffected = command.ExecuteNonQuery();
                    Window parentWindow = Window.GetWindow(this);

                    // Проверяем, что окно не равно null и закрываем его
                    if (parentWindow != null)
                    {
                        parentWindow.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void butretframe(object sender, RoutedEventArgs e)
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

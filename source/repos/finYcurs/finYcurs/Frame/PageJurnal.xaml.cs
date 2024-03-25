using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace finYcurs.Frame
{
    /// <summary>
    /// Логика взаимодействия для PageJurnal.xaml
    /// </summary>
    public partial class PageJurnal : Page
    {
        public PageJurnal()
        {
            InitializeComponent();
            addtable();
        }
        private void addtable()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TBDN17P; Initial Catalog=DBFinY; Integrated Security=True");
            // Открываем подключение
            connection.Open();
            // Создаем SQL запрос для выборки данных из таблицы jurnal
            string query = "SELECT * FROM Jurnal;";
            // Создаем объект SqlCommand с нашим запросом и подключением
            SqlCommand command = new SqlCommand(query, connection);
            // Создаем объект SqlDataAdapter с нашим объектом SqlCommand
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            // Создаем объект DataTable для хранения данных из таблицы books
            DataTable table = new DataTable("TableBooks");
            // Заполняем объект DataTable данными из таблицы books с помощью объекта SqlDataAdapter
            adapter.Fill(table);
            // Устанавливаем свойство ItemsSource элемента DataGrid равным свойству DefaultView объекта DataTable
            DGJur.ItemsSource = table.DefaultView;
            // Закрываем подключение
            connection.Close();
        }
    }
}

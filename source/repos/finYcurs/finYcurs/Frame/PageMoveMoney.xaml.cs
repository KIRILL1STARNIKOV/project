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
    /// Логика взаимодействия для PageMoveMoney.xaml
    /// </summary>
    public partial class PageMoveMoney : Page
    {
        public PageMoveMoney()
        {
            InitializeComponent();
            addtableMoveMoney();
        }
        private void addtableMoveMoney()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TBDN17P; Initial Catalog=DBFinY; Integrated Security=True");
            // Открываем подключение
            connection.Open();
            // Создаем SQL запрос для выборки данных из таблицы jurnal
            string query = "SELECT * FROM InternalMovements;";
            // Создаем объект SqlCommand с нашим запросом и подключением
            SqlCommand command = new SqlCommand(query, connection);
            // Создаем объект SqlDataAdapter с нашим объектом SqlCommand
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable("InternalMovements");
            // Заполняем объект DataTable данными из таблицы books с помощью объекта SqlDataAdapter
            adapter.Fill(table);
            // Устанавливаем свойство ItemsSource элемента DataGrid равным свойству DefaultView объекта DataTable
            DGMoveMoney.ItemsSource = table.DefaultView;
            string query1 = "SELECT * FROM IncomingBankOperations;";
            // Создаем объект SqlCommand с нашим запросом и подключением
            SqlCommand command1 = new SqlCommand(query1, connection);
            // Создаем объект SqlDataAdapter с нашим объектом SqlCommand
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable("IncomingBankOperations");
            // Заполняем объект DataTable данными из таблицы books с помощью объекта SqlDataAdapter
            adapter1.Fill(table1);
            // Устанавливаем свойство ItemsSource элемента DataGrid равным свойству DefaultView объекта DataTable
            DGInCompany.ItemsSource = table1.DefaultView;
            string query2 = "SELECT * FROM OutgoingBankOperations;";
            // Создаем объект SqlCommand с нашим запросом и подключением
            SqlCommand command2 = new SqlCommand(query2, connection);
            // Создаем объект SqlDataAdapter с нашим объектом SqlCommand
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table2 = new DataTable("OutgoingBankOperations");
            // Заполняем объект DataTable данными из таблицы books с помощью объекта SqlDataAdapter
            adapter2.Fill(table2);
            // Устанавливаем свойство ItemsSource элемента DataGrid равным свойству DefaultView объекта DataTable
            DGOutCompany.ItemsSource = table2.DefaultView;
            // Закрываем подключение
            connection.Close();
        }
    }
}

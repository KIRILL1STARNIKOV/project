using System;
using System.Collections.Generic;
using System.Data;
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

namespace finYcurs.Frame
{
    /// <summary>
    /// Логика взаимодействия для PageBankOut.xaml
    /// </summary>
    public partial class PageBankOut : Page
    {
        public PageBankOut()
        {
            InitializeComponent();
            addtableBankOut();
        }
        private void addtableBankOut()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TBDN17P; Initial Catalog=DBFinY; Integrated Security=True");
            connection.Open();
            string query = "SELECT * FROM OutgoingBankOperations";
            SqlCommand command= new SqlCommand(query, connection);
            SqlDataAdapter adapter= new SqlDataAdapter(command);
            DataTable table= new DataTable("OutgoingBankOperations");
            adapter.Fill(table);
            BankOutDG.ItemsSource = table.DefaultView;
            connection.Close();
        }
    }
}

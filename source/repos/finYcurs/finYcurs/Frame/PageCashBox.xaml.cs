using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Principal;
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
    /// Логика взаимодействия для PageCashBox.xaml
    /// </summary>
    public partial class PageCashBox : Page
    {
        public PageCashBox()
        {
            InitializeComponent();
        }
        private void addtableAccount()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TBDN17P; Initial Catalog=DBFinY; Integrated Security=True");
            connection.Open();
            string query = "SELECT * FROM Invoices;";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable("Invoices");
            adapter.Fill(table);
            firstDG.ItemsSource = table.DefaultView;
            connection.Close();
        }
        private void addtablepayrollissuance()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TBDN17P; Initial Catalog=DBFinY; Integrated Security=True");
            connection.Open();
            string query = "SELECT * FROM Payroll;";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable("Payroll");
            adapter.Fill(table);
            secondDG.ItemsSource = table.DefaultView;
            connection.Close();
        }
        private void addtablessuancereport()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TBDN17P; Initial Catalog=DBFinY; Integrated Security=True");
            connection.Open();
            string query = "SELECT * FROM issuance_report;";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable("issuance_report");
            adapter.Fill(table);
            thriDG.ItemsSource = table.DefaultView;
            connection.Close();
        }
        private void TabChanged(object sender, EventArgs e)
        {
            if (TabsCashbox.SelectedItem == first)
            {
                
                addtableAccount();
            }
            else if(TabsCashbox.SelectedItem == second)
            {
                addtablepayrollissuance();
            }
            else if(TabsCashbox.SelectedItem == thri)
            {
                addtablessuancereport();
            }
        }
    }
}

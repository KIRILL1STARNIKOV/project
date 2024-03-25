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
    /// Логика взаимодействия для PageOSandNMA.xaml
    /// </summary>
    public partial class PageOSandNMA : Page
    {
        public PageOSandNMA()
        {
            InitializeComponent();
        }
        private void TabChangedOSandNMA(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TBDN17P; Initial Catalog=DBFinY; Integrated Security=True");
            connection.Open();

            if (TabOSandNMA.SelectedItem == groundOS)
            {
                string query = "SELECT * FROM groundOS";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable("groundOS");
                adapter.Fill(table);
                OSandNMADG.ItemsSource = table.DefaultView;
            }
            else if(TabOSandNMA.SelectedItem == BuildingOS)
            {
                string query = "SELECT * FROM BuildingOS";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable("BuildingOS");
                adapter.Fill(table);
                OSandNMADG.ItemsSource = table.DefaultView;
            }
            else if(TabOSandNMA.SelectedItem == EngineryAndEquipment)
            {
                string query = "SELECT * FROM EngineryAndEquipmentOS";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable("EngineryAndEquipmentOS");
                adapter.Fill(table);
                OSandNMADG.ItemsSource = table.DefaultView;
            }
            else if (TabOSandNMA.SelectedItem == OfficeEquipment)
            {
                string query = "SELECT * FROM OfficeEquipmentOS";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable("OfficeEquipmentOS");
                adapter.Fill(table);
                OSandNMADG.ItemsSource = table.DefaultView;
            }
            else if (TabOSandNMA.SelectedItem == Vehicles)
            {
                string query = "SELECT * FROM VehiclesOS";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable("VehiclesOS");
                adapter.Fill(table);
                OSandNMADG.ItemsSource = table.DefaultView;
            }
            connection.Close();
        }
    }
}

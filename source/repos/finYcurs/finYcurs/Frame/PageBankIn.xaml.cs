﻿using System;
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
    /// Логика взаимодействия для PageBankIn.xaml
    /// </summary>
    public partial class PageBankIn : Page
    {
        public PageBankIn()
        {
            InitializeComponent();
            addtableBankIn();
        }
        private void addtableBankIn()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TBDN17P; Initial Catalog=DBFinY; Integrated Security=True");
            connection.Open();
            string query = "SELECT * FROM IncomingBankOperations";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter= new SqlDataAdapter(command);
            DataTable table = new DataTable("IncomingBankOperations");
            adapter.Fill(table);
            BankInDG.ItemsSource = table.DefaultView;
            connection.Close();
        }

    }
}

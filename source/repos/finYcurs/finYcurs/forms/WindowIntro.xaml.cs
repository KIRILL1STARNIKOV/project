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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace finYcurs.forms
{
    // пока бесполезная форма без подключения базы данных
    public partial class WindowIntro : Window
    {
        public WindowIntro()
        {
            InitializeComponent();
            checkBase();
        }

        private void ButDalClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void checkBase()
        {
            string connectionString = @"Data Source=DESKTOP-TBDN17P; Initial Catalog=DBFinY; Integrated Security=True";
            string query = "SELECT COUNT(*) FROM BasicDetalis;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int rowCount = (int)command.ExecuteScalar();

                if (rowCount == 0)
                {
                    // Если таблица пустая
                    FrameChangedWelcom.Navigate(new Frame.FrameWelcom.FrameBaseFalse());
                }
                else
                {
                    //если таблица заполнена хотябы на одну строку
                    FrameChangedWelcom.Navigate(new Frame.FrameWelcom.FrameBaseTrue());
                }
            }
        }
    }
}

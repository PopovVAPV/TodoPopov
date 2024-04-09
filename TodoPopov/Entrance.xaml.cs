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
using System.Windows.Shapes;

namespace TodoPopov
{
    /// <summary>
    /// Логика взаимодействия для Entrance.xaml
    /// </summary>
    public partial class Entrance : Window
    {
        private SqlConnection connection;
        public Entrance()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source = 3205EC08\SQLSERVER; Initial Catalog = Todo; Integrated Security = True;");
            connection.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand sql = new SqlCommand("select id from Users where login = '" + Login.Text + "' and password = '" + Password.Text + "';", connection);
            SqlDataReader reader = sql.ExecuteReader();
            if (reader.Read())
            {
                var id = reader[0].ToString();
                reader.Close();
                MainWindow mainWindow = new MainWindow(connection, id);
                mainWindow.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }

        }
    }
}

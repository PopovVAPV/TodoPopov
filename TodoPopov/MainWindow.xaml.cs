using System;
using System.Collections;
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

namespace TodoPopov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection connection;
        private string id;
        private string idRasdel;

        public MainWindow(SqlConnection connection, string id)
        {

            InitializeComponent();
            this.connection = connection;
            this.id = id;
            WriteKatigories();
                WriteNickname();


        }

        private void WriteKatigories()
        {
            SqlCommand cmd = new SqlCommand("select id_icon,title from Chapter where user_id=" + id, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListBox.Items.Add(CreateGrid(reader[1].ToString(), reader[0].ToString()));
            }
            reader.Close();
        }


        private void WriteNickname()
        {
            SqlCommand cmd = new SqlCommand("select fio from Users where id=" + id, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            NickName.Text = reader[0].ToString();
            reader.Close();
        }

        public Grid CreateGrid(string NameRazdel, string Icons)
        {
            Grid grid = new Grid();

            ColumnDefinition column1 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(column1);

            ColumnDefinition column2 = new ColumnDefinition();
            column2.Width = new GridLength(4, GridUnitType.Star);
            grid.ColumnDefinitions.Add(column2);

            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"C:\Users\admin\source\repos\TodoPopov\TodoPopov\images\icons\"+ Icons +".png"));
            image.Width = 30;
            image.Height = 30;     
            Grid.SetColumn(image, 0);
            grid.Children.Add(image);

            TextBlock textBlock = new TextBlock();
            textBlock.Text = NameRazdel;
            textBlock.FontSize = 16;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.Foreground = Brushes.Black;
            textBlock.Margin = new Thickness(5);
            Grid.SetColumn(textBlock, 1);
            grid.Children.Add(textBlock);
            return grid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Razdel add = new Razdel();
            Add func = new Add(add);

            func.ShowDialog();
            ListBox.Items.Add(CreateGrid(add.Name, add.IdIcon));
            SqlCommand sqlCommand = new SqlCommand($"insert into Chapter values ({id}, '{add.Name}',{add.IdIcon},2);", connection);
            sqlCommand.ExecuteNonQuery();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Stac.Children.Clear();
            Button but = new Button() { Content = "Добавить" };
            but.Click += Button_Click3;
            Stac.Children.Add(but);
            string sq = ((TextBlock)((Grid)ListBox.SelectedItem).Children[1]).Text;
            SqlCommand cmd = new SqlCommand($"select decription, status from Cases where id=(select id from Chapter where title ='{sq}');", connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = reader[0];
                checkBox.FontSize = 15;
                string a = reader[1].ToString();
                checkBox.IsChecked = (a == "True");
                Stac.Children.Add(checkBox);
            }
            reader.Close();

            cmd = new SqlCommand($"select id from Chapter where title ='{sq}';", connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            idRasdel = reader[0].ToString();
            reader.Close();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Delo del = new Delo();
            AddDelo delo = new AddDelo(del);
            delo.ShowDialog();
            
            Stac.Children.Add(new CheckBox() { Content = del.Name});
            SqlCommand sqlCommand = new SqlCommand($"insert into Cases values ({idRasdel},'{del.Name}',0);", connection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}

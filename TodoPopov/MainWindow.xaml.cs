using System;
using System.Collections.Generic;
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
        public MainWindow()
        {

            InitializeComponent();
            ListBox.Items.Add(CreateGrid());
        }

        public Grid CreateGrid()
        {
            Grid grid = new Grid();

            ColumnDefinition column1 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(column1);

            ColumnDefinition column2 = new ColumnDefinition();
            column2.Width = new GridLength(4, GridUnitType.Star);
            grid.ColumnDefinitions.Add(column2);

            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"C:\Users\admin\source\repos\TodoPopov\TodoPopov\images\icons\2.png"));
            image.Width = 30;
            image.Height = 30;
            Grid.SetColumn(image, 0);
            grid.Children.Add(image);

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Name";
            textBlock.FontSize = 16;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.Foreground = Brushes.Black;
            textBlock.Margin = new Thickness(5);
            Grid.SetColumn(textBlock, 1);
            grid.Children.Add(textBlock);
            return grid;
        }
    }
}

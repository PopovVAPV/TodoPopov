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
using System.Windows.Shapes;

namespace TodoPopov
{

    
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        Razdel razdel;
        public Add(Razdel razdel)
        {
            InitializeComponent();
            this.razdel = razdel;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon = "2";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon = "3";
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon = "4";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            razdel.Name = NameRazdel.Text;
            this.Close();
        }
    }
}

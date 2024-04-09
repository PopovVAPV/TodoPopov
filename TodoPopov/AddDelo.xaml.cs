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
    /// Логика взаимодействия для AddDelo.xaml
    /// </summary>
    public partial class AddDelo : Window
    {
        Delo delo;
        public AddDelo(Delo delo)
        {
            InitializeComponent();
            this.delo = delo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            delo.Name = AddDe.Text;
            this.Close();
        }
    }
}

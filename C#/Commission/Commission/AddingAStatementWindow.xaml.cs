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

namespace Commission
{
    /// <summary>
    /// Логика взаимодействия для AddingAStatementWindow.xaml
    /// </summary>
    public partial class AddingAStatementWindow : Window
    {
        public AddingAStatementWindow()
        {
            InitializeComponent();
        }

        private void Cansel_button(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new();
            Close();
            homeWindow.ShowDialog();
        }
    }
}

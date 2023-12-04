using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
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

namespace Commission
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Реакция на кнопку входа в аккаунт. При успешности - открывает главное окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Auth_btn(object sender, RoutedEventArgs e)
        {
            Authorization auth = new Authorization();
            bool auth_result = auth.Auth(textbox_login.Text, textbox_password.Password.ToString());
            if (auth_result) 
            {
                HomeWindow homeWindow = new HomeWindow();
                Close();
                homeWindow.ShowDialog();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Отмена действия и возврат в главное окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cansel_button(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new();
            Close();
            homeWindow.ShowDialog();
        }

        private void EnterStatementNumberButton(object sender, RoutedEventArgs e)
        {
            bool checkNumberOnBase = false;
            if (int.TryParse(statementNumberTextBox.Text, out int number) && number > 999 && number < 10000)
            {
                DataBase db = new DataBase();
                SqlCommand command_1 = new SqlCommand("SELECT Statement_ID FROM Statements", db.connection);
                SqlDataReader reader_1 = command_1.ExecuteReader();
                while (reader_1.Read()) 
                {
                    if (number == (int)reader_1["Statement_ID"])
                    { 
                        checkNumberOnBase = true;
                        break;
                    };
                }
                if (!checkNumberOnBase)
                {
                    MessageBox.Show("Данного номера не существует");
                }
                else
                {
                    ChangeStatementWindow changeStatementWindow = new ChangeStatementWindow(number);
                    Close();
                    changeStatementWindow.ShowDialog();
                }
            }
            else MessageBox.Show("Введён некорректный номер");
           

        }
    }
}

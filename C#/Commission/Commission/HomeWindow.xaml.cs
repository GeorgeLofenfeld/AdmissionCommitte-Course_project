using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
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
    /// Главная страница
    /// </summary>
    public partial class HomeWindow : Window
    {
        public BindingList<HomePageDataModel>? model;
        /// <summary>
        /// Конструктор главной страницы
        /// </summary>
        public HomeWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Кнопка выхода к окну авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        /// <summary>
        /// Открытие файла-справки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_btn(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(File.ReadAllText(System.Environment.CurrentDirectory + "/Info.txt"));
        }

        /// <summary>
        /// Событие при загрузке главной страницы - заполняет DataGrid из базы данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetData(object sender, RoutedEventArgs e)
        {
            int i = 1;
            DataBase db = new();
            SqlCommand command_Applicants = new SqlCommand("SELECT LastName, FirstName, MiddleName, dateOfBirth FROM Applicants", db.connection);
            SqlDataReader reader_Applicants = command_Applicants.ExecuteReader();
            model = new BindingList<HomePageDataModel>() { };
            while (reader_Applicants.Read())
            {
                model.Add(new HomePageDataModel()
                {
                    number = i,
                    lastName = reader_Applicants["LastName"].ToString(),
                    firstName = reader_Applicants["FirstName"].ToString(),
                    middleName = reader_Applicants["MiddleName"].ToString(),
                    dateOfBirth = reader_Applicants["dateOfBirth"]?.ToString()?.TrimEnd('0', ':', '0', '0', ':', '0'),
                }   );
                i++;
            }
            reader_Applicants.Close();
            i = 0;
            SqlCommand command_Statement = new SqlCommand("SELECT Statement_ID, Specialty_Code, Academic_year FROM Statements", db.connection);
            SqlDataReader reader_Statement = command_Statement.ExecuteReader();
            while (reader_Statement.Read()) 
            {
                model[i].specialtyCode = reader_Statement["Specialty_Code"].ToString();
                model[i].dateOfStatement = reader_Statement["Academic_year"].ToString()?.TrimEnd('0', ':', '0', '0', ':', '0');
                model[i].numberOfStatement = (int)reader_Statement["Statement_ID"];
                i++;
            }
            reader_Statement.Close();
            i = 0;
            SqlCommand command_Certificates = new SqlCommand("SELECT Avarage_Score FROM Certificates", db.connection);
            SqlDataReader reader_Certificates = command_Certificates.ExecuteReader();
            while (reader_Certificates.Read())
            {
                model[i].averageScore = (double)reader_Certificates["Avarage_Score"];
                i++;
            }
            reader_Certificates.Close();
            HomeDataGrid.ItemsSource = model;
        }

        /// <summary>
        /// Открытие окна добавления заявления при нажатии на соответствующую кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenAddingAStatement(object sender, RoutedEventArgs e)
        {
            AddingAStatementWindow addingAStatementWindow = new();
            Close();
            addingAStatementWindow.ShowDialog();
        }
    }
}

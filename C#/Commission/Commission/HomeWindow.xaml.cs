using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
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
            DataBase db = new();
            SqlCommand command_GetData = new SqlCommand("SELECT LastName, FirstName, MiddleName, dateOfBirth, Specialty_Code, Avarage_Score, Academic_year, Statement_ID FROM Applicants INNER JOIN Statements ON Applicants.Applicant_ID = Statements.Applicant_ID INNER JOIN Certificates ON Applicants.Applicant_ID = Certificates.Applicant_ID", db.connection);
            SqlDataReader reader_GetData = command_GetData.ExecuteReader();
            model = new BindingList<HomePageDataModel>() { };
            while (reader_GetData.Read())
            {
                model.Add(new HomePageDataModel()
                { 
                    lastName = reader_GetData["LastName"].ToString(),
                    firstName = reader_GetData["FirstName"].ToString(),
                    middleName = reader_GetData["MiddleName"].ToString(),
                    dateOfBirth = reader_GetData["dateOfBirth"]?.ToString()?.TrimEnd('0', ':', '0', '0', ':', '0'),
                    specialtyCode = reader_GetData["Specialty_Code"].ToString(),
                    averageScore = (double)reader_GetData["Avarage_Score"],
                    dateOfStatement = reader_GetData["Academic_year"].ToString()?.TrimEnd('0', ':', '0', '0', ':', '0'),
                    numberOfStatement = (int)reader_GetData["Statement_ID"],
            }   );
            }
            reader_GetData.Close();
            var sorted_model = model.OrderByDescending(x => x.averageScore).ToList();
            HomeDataGrid.ItemsSource = sorted_model;
            countOfStatementsLabel.Content = $"Количество заявлений: {sorted_model.Count}";
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

        private void SearchButton(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();
            Close();
            searchWindow.ShowDialog();
        }
    }
}

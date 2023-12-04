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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeCountOfSpecialtyButton(object sender, RoutedEventArgs e)
        {
            ChangeSpecialtyCount changeSpecialtyCount = new();
            Close();
            changeSpecialtyCount.ShowDialog();
        }

        private void Report_Button(object sender, RoutedEventArgs e)
        {
            BindingList<ChangeCountOfSpecialtyesDataModel>? model_changeCount;
            DataBase db = new();
            SqlCommand selectCommand = new SqlCommand($"SELECT * FROM Specialties", db.connection);
            SqlDataReader readerSelectCommand = selectCommand.ExecuteReader();
            model_changeCount = new BindingList<ChangeCountOfSpecialtyesDataModel>() { };
            while (readerSelectCommand.Read())
            {
                model_changeCount?.Add(new ChangeCountOfSpecialtyesDataModel()
                {
                    Specialty_Code = readerSelectCommand["Specialty_Code"].ToString(),
                    Budget_places = readerSelectCommand["Budget_places"].ToString(),
                    Extra_budgetary_places = readerSelectCommand["Extra_budgetary_places"].ToString()
                }
                );
            }
            readerSelectCommand.Close();
            if (!File.Exists(System.Environment.CurrentDirectory + "/report.txt")) File.Delete(System.Environment.CurrentDirectory + "/report.txt");
            FileInfo fi1 = new FileInfo(System.Environment.CurrentDirectory + "/report.txt");


            string? Budget_places_03 = "";
            string? Extra_budgetary_places_03 = "";
            SqlCommand selectCommandForCountOfSpecialtyPlacesCount_03 = new SqlCommand($"SELECT Budget_places, Extra_budgetary_places FROM Specialties WHERE Specialty_Code='09.02.03'", db.connection);
            SqlDataReader readerSpecialtyPlacesCount_03 = selectCommandForCountOfSpecialtyPlacesCount_03.ExecuteReader();
            while (readerSpecialtyPlacesCount_03.Read())
            {
                Budget_places_03 = readerSpecialtyPlacesCount_03["Budget_places"].ToString();
                Extra_budgetary_places_03 = readerSpecialtyPlacesCount_03["Extra_budgetary_places"].ToString();
            };
            readerSpecialtyPlacesCount_03.Close();

            string? Budget_places_07 = "";
            string? Extra_budgetary_places_07 = "";
            SqlCommand selectCommandForCountOfSpecialtyPlacesCount_07 = new SqlCommand($"SELECT Budget_places, Extra_budgetary_places FROM Specialties WHERE Specialty_Code='09.02.07'", db.connection);
            SqlDataReader readerSpecialtyPlacesCount_07 = selectCommandForCountOfSpecialtyPlacesCount_07.ExecuteReader();
            while (readerSpecialtyPlacesCount_07.Read())
            {
                Budget_places_07 = readerSpecialtyPlacesCount_07["Budget_places"].ToString();
                Extra_budgetary_places_07 = readerSpecialtyPlacesCount_07["Extra_budgetary_places"].ToString();
            };
            readerSpecialtyPlacesCount_07.Close();



            using (StreamWriter sw = fi1.CreateText())
            {
                sw.WriteLine("ОТЧЁТ О ПРОШЕДШИХ АБИТУРИЕНТАХ");
                sw.WriteLine();
                int.TryParse(Budget_places_03, out int int_Budget_places_03);
                int.TryParse(Extra_budgetary_places_03, out int int_Extra_budgetary_places_03);
                int i = 0;
                bool flag = false;
                if (model != null)
                {
                    var sorted_model = model.OrderByDescending(x => x.averageScore).ToList();
                    sw.WriteLine("БЮДЖЕТ 09.02.03");
                    foreach (var s in sorted_model)
                    {
                        if (s.specialtyCode == "09.02.03")
                        {
                            sw.WriteLine($"Фамилия: {s.lastName}, имя: {s.firstName}, отчество: {s.middleName}, балл: {s.averageScore}, номер заявления: {s.numberOfStatement}");
                            i++;
                            if (i == int_Budget_places_03)
                            {
                                sw.WriteLine($"Проходной балл: {s.averageScore}");
                                flag = true;
                                sw.WriteLine();
                                break;
                            } 
                        }
                    }
                    if (!flag) sw.WriteLine("Проходной балл: Любой выше 3.0 включительно");
                    flag = false;
                    i = 0;
                    sw.WriteLine("ВНЕБЮДЖЕТ 09.02.03");
                    foreach (var s in sorted_model)
                    {
                        if (s.specialtyCode == "09.02.03")
                        {
                            sw.WriteLine($"Фамилия: {s.lastName}, имя: {s.firstName}, отчество: {s.middleName}, балл: {s.averageScore}, номер заявления: {s.numberOfStatement}");
                            i++;
                            if (i == int_Extra_budgetary_places_03)
                            {
                                sw.WriteLine($"Проходной балл: {s.averageScore}");
                                flag = true;
                                sw.WriteLine();
                                break;
                            } 
                        }
                    }
                    if (!flag) sw.WriteLine("Проходной балл: Любой выше 3.0 включительно");
                    flag = false;
                    i = 0;
                    int.TryParse(Budget_places_07, out int int_Budget_places_07);
                    sw.WriteLine("БЮДЖЕТ 09.02.07");
                    foreach (var s in sorted_model)
                    {
                        if (s.specialtyCode == "09.02.07")
                        {
                            sw.WriteLine($"Фамилия: {s.lastName}, имя: {s.firstName}, отчество: {s.middleName}, балл: {s.averageScore}, номер заявления: {s.numberOfStatement}");
                            i++;
                            if (i == int_Budget_places_07)
                            {
                                sw.WriteLine($"Проходной балл: {s.averageScore}");
                                flag = true;
                                sw.WriteLine();
                                break;
                            }

                        }
                    }
                    if (!flag) sw.WriteLine("Проходной балл: Любой выше 3.0 включительно");
                    flag = false;
                    i = 0;
                    int.TryParse(Extra_budgetary_places_07, out int int_Extra_budgetary_places_07);
                    sw.WriteLine("ВНЕБЮДЖЕТ 09.02.07");
                    foreach (var s in sorted_model)
                    {
                        if (s.specialtyCode == "09.02.07")
                        {
                            sw.WriteLine($"Фамилия: {s.lastName}, имя: {s.firstName}, отчество: {s.middleName}, балл: {s.averageScore}, номер заявления: {s.numberOfStatement}");
                            i++;
                            if (i == int_Extra_budgetary_places_07)
                            {
                                sw.WriteLine($"Проходной балл: {s.averageScore}");
                                flag = true;
                                sw.WriteLine();
                                break;
                            } 

                        }
                    }
                    if (!flag) sw.WriteLine("Проходной балл: Любой выше 3.0 включительно");
                    flag = false;
                    i = 0;
                }
            }
            if (File.Exists(System.Environment.CurrentDirectory + "/report.txt"))
            {
                MessageBox.Show("Файл сохранен");
            }
            else
            {
                MessageBox.Show("Ошибка, файл не сохранен");
            }
        }
    }
}

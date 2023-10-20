using Microsoft.SqlServer.Server;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        OpenFileDialog dialog = new OpenFileDialog();
        DataBase db = new();
        public AddingAStatementWindow()
        {
            InitializeComponent();
            SearchFreeNumberForStatementNumber();
        }
        /// <summary>
        /// Кнопка отмены изменений и возврата в главное окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cansel_button(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new();
            Close();
            homeWindow.ShowDialog();
        }
        /// <summary>
        /// Кнопка выбора фотографии 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         public void choosePhoto(object sender, RoutedEventArgs e)
         {

            dialog.Filter = "Файлы рисунков (*.png, *.jpg)|*.png;*.jpg";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {

                using (var file = File.OpenRead(dialog.FileName))
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    Uri imageSource = new Uri(dialog.FileName);
                    image.UriSource = imageSource;
                    image.EndInit();
                    ApplicantImage.Source = image;
                    file.Close();
                }
            }
        }
        /// <summary>
        /// Кнопка сохранения данных в БД с их предварительной проверкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SaveButton(object sender, RoutedEventArgs e)
        {
            string
                lastName = lastNameTextBox.Text,
                firstName = firstNameTextBox.Text,
                middleName = middleNameTextBox.Text,
                dateOfBirth = dateOfBirthTextBox.Text,
                sertificateId = certificateIdTextBox.Text,
                placeOfEducation = placeOfEducationTextBox.Text,
                levelOfEducation = levelofEducationTextBox.Text,
                avarageScore = avarageScoreTextBox.Text,
                specialtyCode = specialtyCodeTextBox.Text,
                academicYear = academicYearTextBox.Text;
            bool flagForCorrectSpecialtyCode = false;
            SqlCommand commandForCheckSpecialtyCodes = new SqlCommand($"SELECT Specialty_Code FROM Specialties", db.connection);
            SqlDataReader readerForSpecialtiesCodes = commandForCheckSpecialtyCodes.ExecuteReader();
            while (readerForSpecialtiesCodes.Read())
            {
                if (specialtyCode == readerForSpecialtiesCodes["Specialty_Code"].ToString()) 
                { 
                    flagForCorrectSpecialtyCode = true;
                    break;
                }
            }
            readerForSpecialtiesCodes.Close();
            string datePattern = @"(0?[1-9]|[12][0-9]|3[01]).(0?[1-9]|1[012]).((19|20)\d\d)";
                if (
                    lastName == "" || firstName == "" ||
                    !Regex.IsMatch(dateOfBirth, datePattern) || sertificateId == "" ||
                    placeOfEducation == "" || levelOfEducation == "" ||
                    !Regex.IsMatch(academicYear, datePattern) || !flagForCorrectSpecialtyCode
                    )
                {
                    MessageBox.Show("Введенны некорректные данные");
                }
                else
                { 
                    int numberForApplicant = SearchFreeNumberForApplicantNumber();
                    int numberForStatement = SearchFreeNumberForStatementNumber();
                    if (dialog.FileName != "")
                    {
                        File.Copy(dialog.FileName, System.Environment.CurrentDirectory + $"/img/{numberForStatement}.jpg");
                    }
                    SqlCommand commandInsertApplicant = new SqlCommand($"INSERT INTO Applicants VALUES ('{numberForApplicant}','{lastName}', '{firstName}', '{middleName}', '{dateOfBirth}')", db.connection);
                    SqlCommand commandInsertCertificate = new SqlCommand($"INSERT INTO Certificates VALUES ('{sertificateId}','{numberForApplicant}', '{avarageScore}', '{placeOfEducation}', '{levelOfEducation}')", db.connection);
                    SqlCommand commandInsertStatement = new SqlCommand($"INSERT INTO Statements VALUES ('{numberForStatement}','{numberForApplicant}', '{specialtyCode}', '{academicYear}')", db.connection);
                    commandInsertApplicant.ExecuteNonQuery();
                    commandInsertCertificate.ExecuteNonQuery();
                    commandInsertStatement.ExecuteNonQuery();
                    HomeWindow homeWindow = new();
                    Close();
                    homeWindow.ShowDialog();
                }
        }
        /// <summary>
        /// Метод ищущий свободный номер в базе данных для номера заявления
        /// </summary>
        public int SearchFreeNumberForStatementNumber() 
        {
            Random rnd = new Random();
            int number = rnd.Next(1000, 9999);
            SqlCommand command_1 = new SqlCommand("SELECT Statement_ID FROM Statements", db.connection);
            SqlDataReader reader_1 = command_1.ExecuteReader();
            while (reader_1.Read()) 
            {
                if (number == (int)reader_1["Statement_ID"])
                {
                    SearchFreeNumberForStatementNumber();
                } 
            }
            numberOsStatementLabel.Content = $"Номер заявления: {number}";
            reader_1.Close();
            return number;
        }
        /// <summary>
        /// Метод ищущий свободный номер в базе данных для абитуриента
        /// </summary>
        public int SearchFreeNumberForApplicantNumber()
        {
            Random rnd = new Random();
            int number = rnd.Next(1000, 9999);
            SqlCommand command_1 = new SqlCommand("SELECT Applicant_ID FROM Applicants", db.connection);
            SqlDataReader reader_1 = command_1.ExecuteReader();
            while (reader_1.Read())
            {
                if (number == (int)reader_1["Applicant_ID"])
                {
                    SearchFreeNumberForApplicantNumber();
                }
            }
            reader_1.Close();
            return number;
        }
    }
}

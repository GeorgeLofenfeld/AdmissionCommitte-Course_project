using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Diagnostics;

namespace Commission
{
    /// <summary>
    /// Логика взаимодействия для ChangeStatementWindow.xaml
    /// </summary>
    public partial class ChangeStatementWindow : Window
    {
        DataBase db = new();
        OpenFileDialog dialog = new OpenFileDialog();
        public ChangeStatementWindow(int currentStatementNumber)
        {
            InitializeComponent();
            SqlCommand choiseCurrentStatement = new SqlCommand($"SELECT LastName, FirstName, MiddleName, dateOfBirth, Specialty_Code, Academic_year, Place_of_education, Avarage_Score, Level_of_education, Certificate_ID, Statement_ID FROM Applicants INNER JOIN Statements ON Applicants.Applicant_ID = Statements.Applicant_ID INNER JOIN Certificates ON Applicants.Applicant_ID = Certificates.Applicant_ID WHERE Statement_ID = {currentStatementNumber}", db.connection);
            SqlDataReader choiseCurrentStatement_reader = choiseCurrentStatement.ExecuteReader();
            while (choiseCurrentStatement_reader.Read())
            {
                lastNameTextBox.Text = choiseCurrentStatement_reader["LastName"].ToString();
                firstNameTextBox.Text = choiseCurrentStatement_reader["FirstName"].ToString();
                middleNameTextBox.Text = choiseCurrentStatement_reader["MiddleName"].ToString();
                dateOfBirthTextBox.Text = choiseCurrentStatement_reader["dateOfBirth"].ToString()?.TrimEnd('0', ':', '0', '0', ':', '0');
                specialtyCodeTextBox.Text = choiseCurrentStatement_reader["Specialty_Code"].ToString();
                academicYearTextBox.Text = choiseCurrentStatement_reader["Academic_Year"].ToString()?.TrimEnd('0', ':', '0', '0', ':', '0');
                placeOfEducationTextBox.Text = choiseCurrentStatement_reader["Place_of_education"].ToString();
                avarageScoreTextBox.Text = choiseCurrentStatement_reader["Avarage_Score"].ToString();
                levelofEducationTextBox.Text = choiseCurrentStatement_reader["Level_of_education"].ToString();
                certificateIdTextBox.Text = choiseCurrentStatement_reader["Certificate_ID"].ToString();
                numberOsStatementLabel.Content = $"Номер заявления: {currentStatementNumber}";
            }
            if (File.Exists(System.Environment.CurrentDirectory + $"/img/{currentStatementNumber}.jpg"))
            {
                using (var file = File.OpenRead(System.Environment.CurrentDirectory + $"/img/{currentStatementNumber}.jpg"))
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    Uri imageSource = new Uri(System.Environment.CurrentDirectory + $"/img/{currentStatementNumber}.jpg");
                    image.UriSource = imageSource;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = file;
                    image.EndInit();
                    ApplicantImage.Source = image;
                    file.Close();
                }
            };
            choiseCurrentStatement_reader.Close();
        }
        /// <summary>
        /// Кнопка выхода к главному окну
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cansel_button(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
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

        private void DeleteStatement_Button(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите удалить запись?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            int currentApplicantId = 0;
            string str = (string)numberOsStatementLabel.Content;
            string currentNumber = new string(str.Where(t => char.IsDigit(t)).ToArray());
            if (result == MessageBoxResult.Yes)
            {
                SqlCommand selectCurrentApplicantIdCommand = new SqlCommand($"SELECT Applicant_ID FROM Statements WHERE Statement_ID = {currentNumber}", db.connection);
                SqlDataReader selectCurrentApplicantIdReader = selectCurrentApplicantIdCommand.ExecuteReader();
                while (selectCurrentApplicantIdReader.Read())
                {
                    currentApplicantId = (int)selectCurrentApplicantIdReader["Applicant_ID"];
                }
                selectCurrentApplicantIdReader.Close();
                SqlCommand deleteStatementCommand = new SqlCommand($"DELETE FROM Certificates WHERE Applicant_ID = {currentApplicantId}; DELETE FROM Statements WHERE Applicant_ID = {currentApplicantId}; DELETE FROM Applicants WHERE Applicant_ID = {currentApplicantId}", db.connection);
                deleteStatementCommand.ExecuteNonQuery();
                HomeWindow homeWindow = new HomeWindow();
                Close();
                homeWindow.ShowDialog();
            }

        }

        private void SaveStatementChangeButton(object sender, RoutedEventArgs e)
        {
            int currentApplicantId = 0;
            string
                lastName = lastNameTextBox.Text,
                firstName = firstNameTextBox.Text,
                middleName = middleNameTextBox.Text,
                dateOfBirth = dateOfBirthTextBox.Text,
                sertificateId = certificateIdTextBox.Text,
                placeOfEducation = placeOfEducationTextBox.Text,
                levelOfEducation = levelofEducationTextBox.Text,
                specialtyCode = specialtyCodeTextBox.Text,
                academicYear = academicYearTextBox.Text,
                avarageScore = avarageScoreTextBox.Text,
                datePattern = @"(0?[1-9]|[12][0-9]|3[01]).(0?[1-9]|1[012]).((19|20)\d\d)";
            string str = (string)numberOsStatementLabel.Content;
            string currentNumber = new string(str.Where(t => char.IsDigit(t)).ToArray());
            SqlCommand selectCurrentApplicantIdCommand = new SqlCommand($"SELECT Applicant_ID FROM Statements WHERE Statement_ID = {currentNumber}", db.connection);
            SqlDataReader selectCurrentApplicantIdReader = selectCurrentApplicantIdCommand.ExecuteReader();
            while (selectCurrentApplicantIdReader.Read())
            {
                currentApplicantId = (int)selectCurrentApplicantIdReader["Applicant_ID"];
            }
            selectCurrentApplicantIdReader.Close();
            if (
                lastName == "" || firstName == "" ||
                !Regex.IsMatch(dateOfBirth, datePattern) || sertificateId == "" ||
                placeOfEducation == "" || levelOfEducation == "" ||
                !Regex.IsMatch(academicYear, datePattern)
                )
            {
                MessageBox.Show("Введенны некорректные данные");
            }
            else
            {
        
                if (dialog.FileName != "")
                {
                    File.Delete(System.Environment.CurrentDirectory + $"/img/{currentNumber}.jpg");
                    File.Copy(dialog.FileName, System.Environment.CurrentDirectory + $"/img/{currentNumber}.jpg");
                };
                SqlCommand commandUpdateApplicant = new SqlCommand($"UPDATE Applicants SET LastName='{lastName}', FirstName='{firstName}', MiddleName='{middleName}', dateOfBirth='{dateOfBirth}' WHERE Applicant_ID='{currentApplicantId}'", db.connection);
                SqlCommand commandUpdateCertificate = new SqlCommand($"UPDATE Certificates SET Certificate_ID='{sertificateId}', Avarage_Score='{avarageScore}', Place_of_education='{placeOfEducation}', Level_of_education='{levelOfEducation}' WHERE Applicant_ID='{currentApplicantId}'", db.connection);
                SqlCommand commandUpdateStatement = new SqlCommand($"UPDATE Statements SET Specialty_Code='{specialtyCode}', Academic_year='{academicYear}' WHERE Applicant_ID='{currentApplicantId}'", db.connection);
                commandUpdateApplicant.ExecuteNonQuery();
                commandUpdateCertificate.ExecuteNonQuery();
                commandUpdateStatement.ExecuteNonQuery();
                HomeWindow homeWindow = new();
                Close();
                homeWindow.ShowDialog();
            }
        }
    }
}

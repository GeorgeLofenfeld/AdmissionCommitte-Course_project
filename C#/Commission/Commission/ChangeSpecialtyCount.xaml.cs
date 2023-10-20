using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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

    public partial class ChangeSpecialtyCount : Window
    {
        DataBase db = new();
        public BindingList<ChangeCountOfSpecialtyesDataModel>? model;
        public ChangeSpecialtyCount()
        {
            InitializeComponent();
            SqlCommand selectCommand = new SqlCommand($"SELECT * FROM Specialties", db.connection);
            SqlDataReader readerSelectCommand = selectCommand.ExecuteReader();
            model = new BindingList<ChangeCountOfSpecialtyesDataModel>() { };
            while (readerSelectCommand.Read())
            {
                model?.Add(new ChangeCountOfSpecialtyesDataModel()
                {
                    Specialty_Code = readerSelectCommand["Specialty_Code"].ToString(),
                    Budget_places = readerSelectCommand["Budget_places"].ToString(),
                    Extra_budgetary_places = readerSelectCommand["Extra_budgetary_places"].ToString()
                }
                ); 
            }
            readerSelectCommand.Close();
            ChangeSpecialtyCountDataGrid.ItemsSource = model;
        }

        private void CanselButton(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
            Close();
            homeWindow.ShowDialog();
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            string specialtyCode = specialtyCodeTextBox.Text;
            string budgetaryCount = BudgetaryTextBox.Text;
            string extraBudgetaryCount = ExtraBudgetaryTextBox.Text;
            if (specialtyCode == "" && budgetaryCount == "" && extraBudgetaryCount == "")
            {
                MessageBox.Show("Введенны неверные данные");
            }
            else
            {
                SqlCommand commandForCheckSpecialtyCodes = new SqlCommand($"SELECT Specialty_Code FROM Specialties", db.connection);
                SqlDataReader readerForSpecialtiesCodes = commandForCheckSpecialtyCodes.ExecuteReader();
                bool flagForCorrectSpecialtyCode = false;
                while (readerForSpecialtiesCodes.Read())
                {
                    if (specialtyCode == readerForSpecialtiesCodes["Specialty_Code"].ToString())
                    {
                        flagForCorrectSpecialtyCode = true;
                        readerForSpecialtiesCodes.Close();
                        break;
                    }
                }
                if (!flagForCorrectSpecialtyCode || !int.TryParse(budgetaryCount, out int result) || !int.TryParse(extraBudgetaryCount, out result))
                {
                    MessageBox.Show("Введенны неверные данные");
                }
                else
                {
                    SqlCommand commandForUpdate = new SqlCommand($"UPDATE Specialties SET Budget_places='{budgetaryCount}', Extra_budgetary_places='{extraBudgetaryCount}' WHERE Specialty_Code='{specialtyCode}'", db.connection);
                    commandForUpdate.ExecuteNonQuery();
                    HomeWindow homeWindow = new();
                    Close();
                    homeWindow.ShowDialog();
                }
                

            }
        }
    }
}

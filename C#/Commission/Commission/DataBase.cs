using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Commission
{
    /// <summary>
    /// Класс необходимый для создания соединения с БД
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// Свойство подключения
        /// </summary>
        public SqlConnection connection = new SqlConnection("Data Source = localhost\\SQLEXPRESS01;\nInitial Catalog = Commission;\nIntegrated Security = true\n");
        /// <summary>
        /// Конструктор класса, открывающий  подключение
        /// </summary>
        public DataBase()
        {
            try
            { 
                connection.Open(); 
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно создать подключение к базе данных:\n{ex}");
                Environment.Exit(1);
            }
        }
    }
}

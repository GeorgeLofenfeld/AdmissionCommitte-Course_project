using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Commission
{
    public class DataBase
    {
        public SqlConnection connection = new SqlConnection("Data Source = localhost\\SQLEXPRESS01;\nInitial Catalog = Commission;\nIntegrated Security = true\n");
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

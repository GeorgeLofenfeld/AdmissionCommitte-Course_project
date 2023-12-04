using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Commission
{
    /// <summary>
    /// Класс необходимый для процесса авторизации пользователя
    /// </summary>
    internal class Authorization
    {
        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <param name="login">Введённый логин в textbox в окне авторизации</param>
        /// <param name="password">Введённый пароль в textbox в окне авторизации</param>
        /// <returns>Флаг успешности авторизации</returns>
        public bool Auth(string login, string password)
        { 
            DataBase db = new();
            SqlCommand command_1 = new SqlCommand("SELECT * FROM Employees", db.connection);
            SqlDataReader reader_1 = command_1.ExecuteReader();
            bool auth_flag = false;
            while (reader_1.Read())
            {
                if (login == reader_1["Login"].ToString() && password == reader_1["Password"].ToString())
                {
                    auth_flag = true;
                    break;
                }
            }
            if (!auth_flag) 
            {
                MessageBox.Show("Аккаунт не существует");
            }
            return auth_flag;
        }
    }
}

using System;
using System.Collections.Generic;
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
        /// Событие при загрузке главной страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetData(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

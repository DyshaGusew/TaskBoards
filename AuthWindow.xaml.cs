using System;
using System.Collections.Generic;
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

namespace TaskBoard
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }

        private void Auth(object sender, RoutedEventArgs e)
        {
            // проверка на то что поля не пустые, проверка существования пол-ля, сообщение об ошибке если его нет,
            // переход на основную страницу если он есть

            if (Login.Text.Length > 0 && Password.Password.Length > 0)
            {
                var Person = DataBase.Person.CheckPersonLogon(Login.Text, Password.Password);
                if (Person != null)
                {
                    // А как пользователя передать в основную логику программы???
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                } else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("Поля не должны быть пустыми!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

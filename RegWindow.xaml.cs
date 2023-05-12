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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }

        private void Reg(object sender, RoutedEventArgs e)
        {
            // проверка на то что поля не пустые, запись поль-ля, сообщение об ошибке если он уже есть,
            // переход на стартовую страницу если он зареган

            if (Login.Text.Length == 0 || Password1.Password.Length == 0 || Password2.Password.Length == 0)
            {
                MessageBox.Show("Поля не должны быть пустыми!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!DataCheckFunctions.CheckLenth1(Login.Text, 25))
            {
                MessageBox.Show("Логин должен содержать от 5 до 25 символов!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!DataCheckFunctions.CheckLenth1(Password1.Password, 25))
            {
                MessageBox.Show("Пароль должен содержать от 5 до 25 символов!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!DataCheckFunctions.CheckUpper(Password1.Password) || !DataCheckFunctions.CheckLower(Password1.Password) || !DataCheckFunctions.CheckFigure(Password1.Password))
            {
                MessageBox.Show("Пароль должен содержать как мимнимум одну заглавную букву, одну строчную букву и одну цифру!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Password1.Password != Password2.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                if (DataBase.Person.CreatePerson(100, Login.Text, Password1.Password, 1) == 0) // первый и последний аргументы могут быть ваще любыми, все равно они меняются
                {
                    MessageBox.Show("Регистрация прошла успешно!", "Все хорошо", MessageBoxButton.OK, MessageBoxImage.Information);
                    StartWindow startWindow = new StartWindow();
                    startWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

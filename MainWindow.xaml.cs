using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskBoard
{
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {

            InitializeComponent();

            DataBase DB = new DataBase();
            DB.Board.AppObject(new Board());
            DB.Card.MaxID();
            DB.Column.AppObject(new Column(15));
            DB.Column.AssignmentIDBoard(6, 866);

            //Добавление столбцов, не удалять, можно закомментить
            //Пока просто разбираюсь как добавлять, потом создать отдельный класс

            int a = 480; // Ширина
            int b = 640; // Высота досок
            Border btn = new Border();
            btn.Background = Brushes.Blue;
            btn.BorderBrush = Brushes.Black;
            btn.CornerRadius = new CornerRadius(25);
            btn.Width = a;
            btn.Height = b;
            btn.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
            btn.Margin = new Thickness(20, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.VerticalAlignment = VerticalAlignment.Top;
            MainPlane.Children.Add(btn);

            Border btn1 = new Border();
            btn1.Background = Brushes.Blue;
            btn1.BorderBrush = Brushes.Black;
            btn1.CornerRadius = new CornerRadius(25);
            btn1.Width = a;
            btn1.Height = b;
            btn1.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
            btn1.Margin = new Thickness(0, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn1.HorizontalAlignment = HorizontalAlignment.Center;
            btn1.VerticalAlignment = VerticalAlignment.Top;
            MainPlane.Children.Add(btn1);

            Border btn2 = new Border();
            btn2.Background = Brushes.Blue;
            btn2.BorderBrush = Brushes.Black;
            btn2.CornerRadius = new CornerRadius(25);
            btn2.Width = a;
            btn2.Height = b;
            btn2.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
            btn2.Margin = new Thickness(0, 100, 20, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn2.HorizontalAlignment = HorizontalAlignment.Right;
            btn2.VerticalAlignment = VerticalAlignment.Top;
            MainPlane.Children.Add(btn2);


        }
    }
}

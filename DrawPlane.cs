using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;
using TaskBoard;
using static DataBase;

public class DrawPlane 
{
    // ((MainWindow)System.Windows.Application.Current.MainWindow).DeleteList(); //Самая важнач строчка кода, позволяет обращаться к основному окну
    private static Border Border()
    {
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
        btn.HorizontalAlignment = HorizontalAlignment.Center;
        btn.VerticalAlignment = VerticalAlignment.Top;

        return btn;
    }
    public static Border[] DrawBorder(int id)
    {
        //int[] counter = Logic.GetIdColumsInBoard(15);
        //int a = counter.Length;
        int[]count = new int[id];
        if (count.Length == 1)
        {
            Border[] btn = new Border[1];
            btn[0] = Border();
            btn[0].Margin = new Thickness(20, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        if (count.Length == 2)
        {
            Border[] btn = new Border[2];
            btn[0] = Border();
            btn[0].Margin = new Thickness(250, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Left;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = Border();
            btn[1].Margin = new Thickness(0, 100, 250, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Right;
            btn[1].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        else
        {
            Border[] btn = new Border[3];
            btn[0] = Border();
            btn[0].Margin = new Thickness(20, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Left;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = Border();
            btn[1].Margin = new Thickness(0, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].VerticalAlignment = VerticalAlignment.Top;

            btn[2] = Border();
            btn[2].Margin = new Thickness(0, 100, 20, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[2].HorizontalAlignment = HorizontalAlignment.Right;
            btn[2].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
    }

    private static Border Card()
    {
        int a = 400; // Ширина
        int b = 200; // Высота досок
        Border btn = new Border();
        btn.Background = Brushes.Aqua;
        btn.BorderBrush = Brushes.Black;
        btn.CornerRadius = new CornerRadius(25);
        btn.Width = a;
        btn.Height = b;
        btn.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
        btn.Margin = new Thickness(20, 20, 20, 20); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
        btn.HorizontalAlignment = HorizontalAlignment.Center;
        btn.VerticalAlignment = VerticalAlignment.Top;
        return btn;
    }

    public static Border[] DrawCard(int id)
    {
        Border[] btn = new Border[id];

        btn[0] = Card();
        btn[0].Margin = new Thickness(0, 120, 0, 0);

        for (int i = 2; i<=id; i++)
        {
            btn[i-1] = Card();
            btn[i-1].Margin = new Thickness(0, 60+ 200*i, 0, 0);
        }

        return btn;
    }

    //Создание кнопок для списка досок
    public static Button ButtonBoard(int step, Board board)
    {
        Button btn = new Button();

        btn.Background = Brushes.Aquamarine;
        btn.BorderBrush = Brushes.Black;
        btn.Width = 250;
        btn.Height = 50;
        btn.Name = "Mini" + board.name.Replace(" ", "");
        btn.Content = board.name;
        btn.Margin = new Thickness(0, step+50, 0, 0); //Расположение каждый раз разное

        btn.HorizontalAlignment = HorizontalAlignment.Center;
        btn.VerticalAlignment = VerticalAlignment.Top;

        btn.Click += Click1;
        btn.BorderThickness = new Thickness(2); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
        
        //Функция клика для этих кнопок
        void Click1(object sender, RoutedEventArgs e)
        {
            DataBase.Board.ActivsBoard(board.id);
            ((MainWindow)System.Windows.Application.Current.MainWindow).DeleteList();
        }
            
        return btn;
    }

    //Объект задней стенки для списка досок
    public static ScrollViewer FonButtonBoard()
    {
        Border border = new Border();
        Grid grid = new Grid();
        ScrollViewer scrollViewer = new ScrollViewer();

        grid.Background = Brushes.White;
        border.BorderBrush = Brushes.Black;
        grid.Width = 300;

        border.Height = DataBase.Board.GetListBoards().Count * 50 + (DataBase.Board.GetListBoards().Count-1) * 20 + 100;
        scrollViewer.Name = "BordList";
        grid.Margin = new Thickness(0, 100, 0, 100);
        grid.HorizontalAlignment = HorizontalAlignment.Center;
        grid.VerticalAlignment = VerticalAlignment.Top;
        border.VerticalAlignment = VerticalAlignment.Top;
        border.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева

        grid.Children.Add(border);

        List<Board> boards = DataBase.Board.GetListBoards().ToList();
        int step = 0;
        foreach (Board board1 in boards)
        {
            grid.Children.Add(ButtonBoard(step, board1));
            step += 70;
        }

        grid.Children.Add(ButtonClose());
        scrollViewer.Content = grid;
        return scrollViewer;
    }

    public static Button ButtonClose()
    {
        Button btn = new Button();
        btn.Width = 80;
        btn.Height = 40;
        btn.Background = Brushes.IndianRed;
        btn.BorderBrush = Brushes.Black;
        btn.Content = "Закрыть";
        btn.Click += Click1;
        btn.BorderThickness = new Thickness(2); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
        btn.HorizontalAlignment = HorizontalAlignment.Right;
        btn.VerticalAlignment = VerticalAlignment.Top;

        //Функция клика для этих кнопок
        void Click1(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).DeleteList();
        }

        return btn;
    }


}


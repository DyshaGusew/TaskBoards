using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;
using TaskBoard;

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


    public static Button ButtonBoard(int step, Board board)
    {
        int a = 250; // Ширина
        int b = 50; // Высота досок

        Button btn = new Button();

        
        btn.Background = Brushes.Aquamarine;
        btn.BorderBrush = Brushes.Black;
        btn.Width = a;
        btn.Height = b;
        btn.Name = "Mini" + board.name.Replace(" ", "");
        btn.Content = board.name;
        HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
        btn.Margin = new Thickness(0, step + 150, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness

        btn.HorizontalAlignment = HorizontalAlignment.Center;
        btn.VerticalAlignment = VerticalAlignment.Top;

        btn.Click += Click1;
        btn.BorderThickness = new Thickness(2); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
        
        
        void Click1(object sender, RoutedEventArgs e)
        {
            DataBase.Board.ActivsBoard(board.id);
            ((MainWindow)System.Windows.Application.Current.MainWindow).DeleteList();
        }
            
        return btn;
    }

    public static Border FonButtonBoard()
    {
        Border border = new Border();

        border.Background = Brushes.White;
        border.BorderBrush = Brushes.Black;
        border.Width = 300;
        border.Height = DataBase.Board.GetListBoards().Count * 50 + (DataBase.Board.GetListBoards().Count-1) * 20 + 100;
        border.Name = "BordList";
        border.Margin = new Thickness(0, 100, 0, 0);
        border.HorizontalAlignment = HorizontalAlignment.Center;
        border.VerticalAlignment = VerticalAlignment.Top;
        border.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
        

        return border;
    }


}


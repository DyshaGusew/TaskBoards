using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

public class DrawPlane
{
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



}


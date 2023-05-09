using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TaskBoard
{
    public class DrawColumn
    {
        public Border Ret()
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
    }
}

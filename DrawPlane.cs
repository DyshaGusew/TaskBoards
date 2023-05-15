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
        int a = 440; // Ширина
        int b = 640; // Высота досок
        Border btn = new Border();
        btn.Background = Brushes.Blue;
        btn.BorderBrush = Brushes.Black;
        btn.CornerRadius = new CornerRadius(25);
        btn.Width = a;
        btn.Height = b;
        btn.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
        ///btn.Margin = new Thickness(20, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
        //btn.HorizontalAlignment = HorizontalAlignment.Center;
        //btn.VerticalAlignment = VerticalAlignment.Top;

        return btn;
    }
    private static Border BorderMini()
    {
        int a = 440; // Ширина
        int b = 60; // Высота досок
        Border btn = new Border();
        btn.Background = Brushes.Gray;
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
    private static TextBlock TextBlock()
    {
        TextBlock textBlock = new TextBlock();
        textBlock.FontSize = 40;
        textBlock.FontWeight = FontWeights.Bold;
        textBlock.FontStyle = FontStyles.Normal;

        textBlock.Text = "Типа тут название";
        //textBlock.Foreground = Brushes.Black;
        textBlock.HorizontalAlignment = HorizontalAlignment.Center;
        textBlock.VerticalAlignment = VerticalAlignment.Top;
        textBlock.Margin = new Thickness(0, 100, 0, 0);
        return textBlock;
    }
    public static TextBlock[] DrawTextBlock(int id)
    {
        int[] count = new int[id];
        if (count.Length == 1)
        {
            TextBlock[] btn = new TextBlock[1];
            btn[0] = TextBlock();
            btn[0].Margin = new Thickness(20, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        if (count.Length == 2)
        {
            TextBlock[] btn = new TextBlock[2];
            btn[0] = TextBlock();
            btn[0].Margin = new Thickness(290, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Left;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = TextBlock();
            btn[1].Margin = new Thickness(0, 100, 290, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Right;
            btn[1].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        else
        {
            TextBlock[] btn = new TextBlock[3];
            btn[0] = TextBlock();
            btn[0].Margin = new Thickness(100, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Left;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = TextBlock();
            btn[1].Margin = new Thickness(0, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].VerticalAlignment = VerticalAlignment.Top;

            btn[2] = TextBlock();
            btn[2].Margin = new Thickness(0, 100, 100, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[2].HorizontalAlignment = HorizontalAlignment.Right;
            btn[2].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
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
            btn[0].Margin = new Thickness(60, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Left;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = Border();
            btn[1].Margin = new Thickness(0, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].VerticalAlignment = VerticalAlignment.Top;

            btn[2] = Border();
            btn[2].Margin = new Thickness(0, 100, 60, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[2].HorizontalAlignment = HorizontalAlignment.Right;
            btn[2].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
    }
    public static Border[] DrawBorderBlox(int id)
    {
        //int[] counter = Logic.GetIdColumsInBoard(15);
        //int a = counter.Length;
        int[] count = new int[id];
        if (count.Length == 1)
        {
            Border[] btn = new Border[1];
            btn[0] = BorderMini();
            btn[0].Margin = new Thickness(20, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        if (count.Length == 2)
        {
            Border[] btn = new Border[2];
            btn[0] = BorderMini();
            btn[0].Margin = new Thickness(250, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Left;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = BorderMini();
            btn[1].Margin = new Thickness(0, 100, 250, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Right;
            btn[1].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        else
        {
            Border[] btn = new Border[3];
            btn[0] = BorderMini();
            btn[0].Margin = new Thickness(60, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Left;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = BorderMini();
            btn[1].Margin = new Thickness(0, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].VerticalAlignment = VerticalAlignment.Top;

            btn[2] = BorderMini();
            btn[2].Margin = new Thickness(0, 100, 60, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[2].HorizontalAlignment = HorizontalAlignment.Right;
            btn[2].VerticalAlignment = VerticalAlignment.Top;
            return btn;


        }
    }
    public static Border[] DrawBorderText(int id, string[] str)
    {
        //int[] counter = Logic.GetIdColumsInBoard(15);
        //int a = counter.Length;
        int[] count = new int[id];
        if (count.Length == 1)
        {
            Border[] btn = new Border[1];
            btn[0] = BorderMini();
            btn[0].Margin = new Thickness(20, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        if (count.Length == 2)
        {
            Border[] btn = new Border[2];
            btn[0] = BorderMini();
            btn[0].Margin = new Thickness(250, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Left;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = BorderMini();
            btn[1].Margin = new Thickness(0, 100, 250, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Right;
            btn[1].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        else
        {
            Border[] btn = new Border[3];
            btn[0] = BorderMini();
            btn[0].Margin = new Thickness(60, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Left;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = BorderMini();
            btn[1].Margin = new Thickness(0, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].VerticalAlignment = VerticalAlignment.Top;

            btn[2] = BorderMini();
            btn[2].Margin = new Thickness(0, 100, 60, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[2].HorizontalAlignment = HorizontalAlignment.Right;
            btn[2].VerticalAlignment = VerticalAlignment.Top;
            return btn;


        }
    }



    //Отрсовка объекта списка карточек
    public static Grid GridCards(MainWindow window)
    {
        //Основной блок, куда все помещаю
        Grid gridMain = new Grid();
        gridMain.Name = "GridCards";

        gridMain.Background = Brushes.White;
        gridMain.Width = 335;
        gridMain.Height = Logic.GetBoardsTrue().Count * 50 + (Logic.GetBoardsTrue().Count - 1) * 20 + 100;
        gridMain.MaxHeight = 5 * 50 + (Logic.GetBoardsTrue().Count - 1) * 20 + 100;
        gridMain.HorizontalAlignment = HorizontalAlignment.Center;
        gridMain.VerticalAlignment = VerticalAlignment.Top;
        gridMain.Margin = new Thickness(0, 150, 0, 0);

        //Сетка для отображения скрол бара и кнопок
        Grid gridScrollBut = new Grid();
        gridScrollBut.Margin = new Thickness(0, 0, 0, 0);
        gridScrollBut.Width = 300;
        gridScrollBut.HorizontalAlignment = HorizontalAlignment.Center;
        gridScrollBut.VerticalAlignment = VerticalAlignment.Top;
        gridScrollBut.Height = Logic.GetBoardsTrue().Count * 50 + (Logic.GetBoardsTrue().Count - 1) * 20 + 40;

        //Сам скрол объект куда позже помещается сетка выше 
        ScrollViewer scrollViewer = new ScrollViewer();
        scrollViewer.Width = 320;
        scrollViewer.VerticalAlignment = VerticalAlignment.Top;
        scrollViewer.HorizontalAlignment = HorizontalAlignment.Center;
        // scrollViewer.Height = Logic.GetBoardsTrue().Count * 50 + (Logic.GetBoardsTrue().Count - 1) * 20 + 20;
        scrollViewer.Margin = new Thickness(0, 50, 0, 10);

        //Обводка, помещаемая в главный блок
        Border border = new Border();
        border.BorderBrush = Brushes.Black;
        border.Height = Logic.GetBoardsTrue().Count * 50 + (Logic.GetBoardsTrue().Count - 1) * 20 + 100;
        border.MaxHeight = 5 * 50 + (Logic.GetBoardsTrue().Count - 1) * 20 + 100;
        border.VerticalAlignment = VerticalAlignment.Top;
        border.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева

        //Добавление кнопок в грид для скролл бара
        List<Board> boards = DataBase.Board.GetListBoards().ToList();
        int step = 0;
        foreach (Board board in Logic.GetBoardsTrue())
        {
            gridScrollBut.Children.Add(ButtonBoard(step, board, window));
            step += 70;
        }

        //Помещаю грид в скрол вью
        scrollViewer.Content = gridScrollBut;

        //Добавляю в главный элемент границы, скролл сетку с кнопками и кнопку закрытия
        gridMain.Children.Add(border);
        gridMain.Children.Add(scrollViewer);
        gridMain.Children.Add(ButtonListClose(window));
        return gridMain;
    }

    //
    public static Grid Card(Column column, MainWindow window)
    {
        Grid grid = new Grid();
        int widthCard = 400; 
        int heightCard = 200; 
        grid.Width = widthCard;
        grid.Height = heightCard;
        grid.HorizontalAlignment = HorizontalAlignment.Center;
        grid.VerticalAlignment = VerticalAlignment.Center;

        Border btn = new Border();
        btn.Background = Brushes.Aqua;
        btn.BorderBrush = Brushes.Black;
        btn.CornerRadius = new CornerRadius(25);
        btn.Width = widthCard;
        btn.Height = heightCard;
        btn.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
        btn.HorizontalAlignment = HorizontalAlignment.Center;
        btn.VerticalAlignment = VerticalAlignment.Top;


        Grid gridName = new Grid();
        gridName.VerticalAlignment = VerticalAlignment.Top;
        gridName.Margin = new Thickness(0,1,0,0);
        gridName.HorizontalAlignment = HorizontalAlignment.Center;
        gridName.Width = widthCard;
        gridName.Height = 50;

        Border btnName = new Border();
        btnName.BorderBrush = Brushes.Black;
        btnName.CornerRadius = new CornerRadius(15);
        btnName.Background = Brushes.White;
        btnName.Width = widthCard;
        btnName.Height = 50;
        btnName.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева

        TextBox nameCard = new TextBox();
        nameCard.Text = "gggg";
        nameCard.Height = 35;
        nameCard.Width = widthCard-35;
        nameCard.VerticalAlignment = VerticalAlignment.Center;
        nameCard.FontSize = 20;
        nameCard.BorderBrush = Brushes.White;
        nameCard.HorizontalContentAlignment = HorizontalAlignment.Center;
        nameCard.VerticalContentAlignment = VerticalAlignment.Center;


        gridName.Children.Add(btnName);
        gridName.Children.Add(nameCard);


        grid.Children.Add(btn);
        grid.Children.Add(gridName);
        

        return grid;
    }

    //Элементы карточек
    public static Border[] DrawCard(int id)
    {
        Border[] btn = new Border[id];

       // btn[0] = Card();
        btn[0].Margin = new Thickness(0, 120, 0, 0);

        for (int i = 2; i<=id; i++)
        {
        //    btn[i-1] = Card();
            btn[i-1].Margin = new Thickness(0, 60+ 200*i, 0, 0);
        }

        return btn;
    }



    //Объект для списка досок
    public static Grid FonButtonBoard(MainWindow window)
    {
        //Основной блок, куда все помещаю
        Grid gridMain = new Grid();
        gridMain.Name = "BordList";

        gridMain.Background = Brushes.White;
        gridMain.Width = 335;
        gridMain.Height = Logic.GetBoardsTrue().Count * 50 + (Logic.GetBoardsTrue().Count - 1) * 20 + 100;
        gridMain.MaxHeight = 5 * 50 + (Logic.GetBoardsTrue().Count - 1) * 20 + 100;
        gridMain.HorizontalAlignment = HorizontalAlignment.Center;
        gridMain.VerticalAlignment = VerticalAlignment.Top;
        gridMain.Margin = new Thickness(0, 150, 0, 0);

        //Сетка для отображения скрол бара и кнопок
        Grid gridScrollBut = new Grid();
        gridScrollBut.Margin = new Thickness(0, 0, 0, 0);
        gridScrollBut.Width = 300;
        gridScrollBut.HorizontalAlignment = HorizontalAlignment.Center;
        gridScrollBut.VerticalAlignment = VerticalAlignment.Top;
        gridScrollBut.Height = Logic.GetBoardsTrue().Count * 50 + (Logic.GetBoardsTrue().Count - 1) * 20 + 40;

        //Сам скрол объект куда позже помещается сетка выше 
        ScrollViewer scrollViewer = new ScrollViewer();
        scrollViewer.Width = 320;
        scrollViewer.VerticalAlignment = VerticalAlignment.Top;
        scrollViewer.HorizontalAlignment = HorizontalAlignment.Center;
       // scrollViewer.Height = Logic.GetBoardsTrue().Count * 50 + (Logic.GetBoardsTrue().Count - 1) * 20 + 20;
        scrollViewer.Margin = new Thickness(0, 50, 0, 10);

        //Обводка, помещаемая в главный блок
        Border border = new Border();
        border.BorderBrush = Brushes.Black;
        border.Height = Logic.GetBoardsTrue().Count * 50 + (Logic.GetBoardsTrue().Count - 1) * 20 + 100;
        border.MaxHeight = 5 * 50 + (Logic.GetBoardsTrue().Count - 1) * 20 + 100;
        border.VerticalAlignment = VerticalAlignment.Top;
        border.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева

        //Добавление кнопок в грид для скролл бара
        List<Board> boards = DataBase.Board.GetListBoards().ToList();
        int step = 0;
        foreach (Board board in Logic.GetBoardsTrue())
        {
            gridScrollBut.Children.Add(ButtonBoard(step, board, window));
            step += 70;
        }

        //Помещаю грид в скрол вью
        scrollViewer.Content = gridScrollBut;

        //Добавляю в главный элемент границы, скролл сетку с кнопками и кнопку закрытия
        gridMain.Children.Add(border);
        gridMain.Children.Add(scrollViewer);
        gridMain.Children.Add(ButtonListClose(window));
        return gridMain;
    }
    //Создание кнопок для списка досок
    public static Button ButtonBoard(int step, Board board, MainWindow window)
    {
        Button btn = new Button();

        btn.Background = Brushes.Aquamarine;
        btn.BorderBrush = Brushes.Black;
        btn.Width = 250;
        btn.Height = 50;
        btn.Name = "Mini" + board.name.Replace(" ", "");
        btn.Content = board.name;
        btn.Margin = new Thickness(0, step, 0, 0); //Расположение каждый раз разное

        btn.HorizontalAlignment = HorizontalAlignment.Center;
        btn.VerticalAlignment = VerticalAlignment.Top;

        btn.Click += Click1;
        btn.BorderThickness = new Thickness(2); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
        
        //Функция клика для этих кнопок
        void Click1(object sender, RoutedEventArgs e)
        {
            DataBase.Board.ActivsBoard(board.id);
            window.DeleteList();
        }
            
        return btn;
    }
    //Кнопка закрытия для списка досок
    public static Button ButtonListClose(MainWindow window)
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
            window.DeleteList();
        }

        return btn;
    }



    //Меню для выбора типа доски
    public static Grid PlaneStateBoard(MainWindow window)
    {
        Grid grid = new Grid();
        grid.Height = 230;
        grid.Width = 550;
        grid.Name = "PlaneStateBoard";
        grid.HorizontalAlignment = HorizontalAlignment.Center;
        grid.VerticalAlignment = VerticalAlignment.Center;
        grid.Background = Brushes.White;

        Border bord = new Border();
        bord.BorderBrush = Brushes.Black;
        bord.BorderThickness = new Thickness(4);

        TextBlock textBlock = new TextBlock();
        textBlock.Text = "Укажите тип доски";
        textBlock.HorizontalAlignment = HorizontalAlignment.Center;
        textBlock.VerticalAlignment = VerticalAlignment.Top;
        textBlock.Margin = new Thickness(0, 28, 0, 0);
        textBlock.FontSize = 28;
        //textBlock.Background = Brushes.Aquamarine;
        textBlock.Height = 50;


        Border bord2 = new Border();
        bord2.BorderBrush = Brushes.Black;
        bord2.BorderThickness = new Thickness(2.5);
        bord2.HorizontalAlignment = HorizontalAlignment.Center;
        bord2.VerticalAlignment = VerticalAlignment.Top;
        bord2.Height = 50;
        bord2.Width = 350;
        bord2.Margin = new Thickness(0, 20, 0, 0);
        bord2.Background = Brushes.Aquamarine;

        grid.Children.Add(bord);
        grid.Children.Add(bord2);
        grid.Children.Add(textBlock);
        grid.Children.Add(ButtonMenuTypeClose(window));
        grid.Children.Add(ButtonStateBoardGlobal(window));
        grid.Children.Add(ButtonStateBoardLocal(window));
        return grid;
    }
    //Глобальная кнопка
    public static Button ButtonStateBoardGlobal(MainWindow window)
    {
        Button button = new Button();
        button.Width = 200;
        button.Height = 100;
        button.Background = Brushes.Aquamarine;
        button.BorderBrush = Brushes.Black;
        button.Content = "Общественная";
        button.FontSize = 24;
        button.BorderThickness = new Thickness(2);

        button.Margin = new Thickness(0, 0, 30, 25);
        button.HorizontalAlignment = HorizontalAlignment.Right;
        button.VerticalAlignment = VerticalAlignment.Bottom;
        

        button.Click += Click2;

        void Click2(object sender, RoutedEventArgs e)
        {
            Board board = new Board(Logic.GetBoardNullName());
            board.userPresents = 0;               //Присваиваю доске владельца, тк общественна, то ноль

            DataBase.Board.AppObject(board);
            DataBase.Board.ActivsBoard(board.id);

            
            window.DeleteList();
            window.DraftBoard();
            window.DeleteMenuLocalOfGlobal();
        }

        return button;
    }
    //Локальная кнопка
    public static Button ButtonStateBoardLocal(MainWindow window)
    {
        Button button = new Button();
        button.Width = 200;
        button.Height = 100;
        button.Background = Brushes.Aquamarine;
        button.BorderBrush = Brushes.Black;
        button.Content = "Частная";
        button.FontSize = 24;
        button.BorderThickness = new Thickness(2);

        button.HorizontalAlignment = HorizontalAlignment.Left;
        button.VerticalAlignment = VerticalAlignment.Bottom;
        button.Margin = new Thickness(30, 0,0,25);

        button.Click += Click3;

        void Click3(object sender, RoutedEventArgs e)
        {
            Board board = new Board(Logic.GetBoardNullName());
            board.userPresents = Logic.GetCurrentPerson().id;               //Присваиваю доске владельца, тк общественна, то ноль

            DataBase.Board.AppObject(board);
            DataBase.Board.ActivsBoard(board.id);

            window.DeleteList();
            window.DraftBoard();
            window.DeleteMenuLocalOfGlobal();
        }

        return button;
    }
    //Кнопка закрытия выбора типа доски
    public static Button ButtonMenuTypeClose(MainWindow window)
    {
        Button btn = new Button();
        btn.Width = 60;
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
            window.DeleteMenuLocalOfGlobal();
        }

        return btn;
    }
}


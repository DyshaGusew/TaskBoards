using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        btn.Background = new SolidColorBrush(Color.FromRgb(194, 225, 255));
        //btn.BorderBrush = Brushes.Black;
        btn.CornerRadius = new CornerRadius(25);
        btn.Width = a;
        btn.Height = b;
        btn.BorderThickness = new Thickness(0); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
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
        btn.Background = Brushes.White;
        //btn.BorderBrush = Brushes.Black;
        btn.CornerRadius = new CornerRadius(25, 25, 0, 0);
        btn.Width = a;
        btn.Height = b;
        btn.BorderThickness = new Thickness(0); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
        btn.Margin = new Thickness(20, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
        btn.HorizontalAlignment = HorizontalAlignment.Center;
        btn.VerticalAlignment = VerticalAlignment.Top;

        return btn;
    }
    private static TextBox TextBox()
    {
        TextBox textBlock = new TextBox();
        textBlock.FontSize = 36;
        textBlock.Height = 50;
        textBlock.FontWeight = FontWeights.Bold;
        textBlock.FontStyle = FontStyles.Normal;
        textBlock.BorderBrush = Brushes.Transparent;
        textBlock.Text = "Типа тут название";
        //textBlock.Foreground = Brushes.Black;
        textBlock.HorizontalAlignment = HorizontalAlignment.Center;
        textBlock.VerticalAlignment = VerticalAlignment.Top;
        textBlock.Margin = new Thickness(0, 50, 0, 0);
        textBlock.TextChanged += TextBlock_TextChanged;

        void TextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        return textBlock;
    }

   

    public static TextBox[] DrawTextBox(int id)
    {
        int[] count = new int[id];
        if (count.Length == 1)
        {
            TextBox[] btn = new TextBox[1];
            btn[0] = TextBox();
            btn[0].Margin = new Thickness(0, 5, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].Background = Brushes.Transparent;
            return btn;
        }
        if (count.Length == 2)
        {
            TextBox[] btn = new TextBox[2];
            btn[0] = TextBox();
            btn[0].Margin = new Thickness(0, 5, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].Background = Brushes.Transparent;

            btn[1] = TextBox();
            btn[1].Margin = new Thickness(0, 5, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].Background = Brushes.Transparent;
            return btn;
        }
        else
        {
            TextBox[] btn = new TextBox[3];
            btn[0] = TextBox();
            btn[0].Margin = new Thickness(0, 5, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].Background = Brushes.Transparent;

            btn[1] = TextBox();
            btn[1].Margin = new Thickness(0, 5, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].Background = Brushes.Transparent;

            btn[2] = TextBox();
            btn[2].Margin = new Thickness(0, 5, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[2].HorizontalAlignment = HorizontalAlignment.Center;
            
            btn[2].Background = Brushes.Transparent;
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
            btn[0].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        if (count.Length == 2)
        {
            Border[] btn = new Border[2];
            btn[0] = Border();
            btn[0].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = Border();
            btn[1].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        else
        {
            Border[] btn = new Border[3];
            btn[0] = Border();
            btn[0].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = Border();
            btn[1].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].VerticalAlignment = VerticalAlignment.Top;

            btn[2] = Border();
            btn[2].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[2].HorizontalAlignment = HorizontalAlignment.Center;
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
            btn[0].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        if (count.Length == 2)
        {
            Border[] btn = new Border[2];
            btn[0] = BorderMini();
            btn[0].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = BorderMini();
            btn[1].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        else
        {
            Border[] btn = new Border[3];
            btn[0] = BorderMini();
            btn[0].Margin = new Thickness(0,0 ,0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = BorderMini();
            btn[1].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].VerticalAlignment = VerticalAlignment.Top;

            btn[2] = BorderMini();
            btn[2].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[2].HorizontalAlignment = HorizontalAlignment.Center;
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
            btn[0].Margin = new Thickness(0,0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        if (count.Length == 2)
        {
            Border[] btn = new Border[2];
            btn[0] = BorderMini();
            btn[0].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = BorderMini();
            btn[1].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].VerticalAlignment = VerticalAlignment.Top;
            return btn;
        }
        else
        {
            Border[] btn = new Border[3];
            btn[0] = BorderMini();
            btn[0].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[0].HorizontalAlignment = HorizontalAlignment.Center;
            btn[0].VerticalAlignment = VerticalAlignment.Top;

            btn[1] = BorderMini();
            btn[1].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[1].HorizontalAlignment = HorizontalAlignment.Center;
            btn[1].VerticalAlignment = VerticalAlignment.Top;

            btn[2] = BorderMini();
            btn[2].Margin = new Thickness(0, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
            btn[2].HorizontalAlignment = HorizontalAlignment.Center;
            btn[2].VerticalAlignment = VerticalAlignment.Top;
            return btn;


        }
    }
    public static Grid GridColumn()
    {
        Grid grid = new Grid();
        grid.Name = "Column";
        grid.Margin = new Thickness(60, 0, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
        grid.HorizontalAlignment = HorizontalAlignment.Center;
        grid.VerticalAlignment = VerticalAlignment.Top;
        grid.Width = 480;
        grid.Height = 740;
        return grid;
    }
    //Шаблоны гридов
    //Шаблоны для двух гридов
    public static Grid GridColumn2Left()
    {
        Grid grid = new Grid();
        grid.Name = "Column";
        grid.Width = 480;
        grid.Height = 740;
        grid.Margin = new Thickness(250, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
        grid.HorizontalAlignment = HorizontalAlignment.Left;
        grid.VerticalAlignment = VerticalAlignment.Top;
        return grid;
    }

    public static Grid GridColumn2Right()
    {
        Grid grid = new Grid();
        grid.Name = "Column";
        grid.Width = 480;
        grid.Height = 740;
        grid.Margin = new Thickness(0, 100, 250, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
        grid.HorizontalAlignment = HorizontalAlignment.Right;
        grid.VerticalAlignment = VerticalAlignment.Top;
        return grid;
    }
    //Шаблоны для трех гридов
    public static Grid GridColumn3Left()
    {
        Grid grid = new Grid();
        grid.Name = "Column";
        grid.Width = 480;
        grid.Height = 740;
        grid.Margin = new Thickness(60, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
        grid.HorizontalAlignment = HorizontalAlignment.Left;
        grid.VerticalAlignment = VerticalAlignment.Top;
        return grid;
    }
    public static Grid GridColumn3Center()
    {
        Grid grid = new Grid();
        grid.Name = "Column";
        grid.Width = 480;
        grid.Height = 740;
        grid.Margin = new Thickness(0, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
        grid.HorizontalAlignment = HorizontalAlignment.Center;
        grid.VerticalAlignment = VerticalAlignment.Top;
        return grid;
    }
    public static Grid GridColumn3Right()
    {
        Grid grid = new Grid();
        grid.Name = "Column";
        grid.Width = 480;
        grid.Height = 740;
        grid.Margin = new Thickness(0, 100, 60, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
        grid.HorizontalAlignment = HorizontalAlignment.Right;
        grid.VerticalAlignment = VerticalAlignment.Top;
        return grid;
    }


    public static Button ButtonRightLeft()
    {
        Button button = new Button();
        button.Content = "-";
        button.Width = 50;
        button.Height = 50;
        button.Margin = new Thickness(0, 0, 0, 0);
        button.HorizontalAlignment = HorizontalAlignment.Left;
        button.VerticalAlignment = VerticalAlignment.Center;
        button.FontSize = 15;
        button.FontWeight = FontWeights.ExtraBold;
        return button;
    }
    public static Button DelBatton(MainWindow window, string colId)
    {
        Button buttonDel1 = DrawPlane.ButtonRightLeft();
        buttonDel1.Content = "×";
        buttonDel1.HorizontalAlignment = HorizontalAlignment.Right;
        buttonDel1.VerticalAlignment = VerticalAlignment.Top;

        buttonDel1.Background = Brushes.Transparent;
        buttonDel1.BorderThickness = new Thickness(0);
        buttonDel1.Margin = new Thickness(0, 5, 30, 0);
        buttonDel1.FontSize = 35;
        buttonDel1.VerticalContentAlignment = VerticalAlignment.Center;
        buttonDel1.Click += ButtonDel1_Click;

        void ButtonDel1_Click(object sender, RoutedEventArgs e)
        {
            if (!window.CheckPressBut())
            {
                MessageBox.Show("Вы не можете редактировать эту доску", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DataBase.Column.DeleteByID(Convert.ToInt32(colId));

            if (Logic.GetIdCardInColomns(Convert.ToInt32(colId)) != null)
            {
                List<int> IdCards = Logic.GetIdCardInColomns(Convert.ToInt32(colId));
                foreach (int iCard in IdCards)
                {
                    //Удаляю каждую карточку столбца
                    DataBase.Card.DeleteByID(iCard);
                }
            }
            window.ClearColumn();
            window.DraftBoard();
        }
        return buttonDel1;
    }

    //Кнопка добавления карточки в столбец
    public static Button AppCardButton(MainWindow window, string colId)
    {
        Button buttonDel1 = DrawPlane.ButtonRightLeft();
        buttonDel1.Content = "+";
        buttonDel1.HorizontalAlignment = HorizontalAlignment.Right;
        buttonDel1.VerticalAlignment = VerticalAlignment.Top;
        buttonDel1.VerticalContentAlignment = VerticalAlignment.Center;

        buttonDel1.Background = Brushes.Transparent;
        buttonDel1.BorderThickness = new Thickness(0);
        buttonDel1.Margin = new Thickness(0, 5, 70, 0);
        buttonDel1.FontSize = 35;
        buttonDel1.Click += ButtonApp1_Click;

        void ButtonApp1_Click(object sender, RoutedEventArgs e)
        {
            if (!window.CheckPressBut())
            {
                MessageBox.Show("Вы не можете редактировать эту доску", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Card card = new Card();
            card.name = Logic.GetСardNullName(Convert.ToInt32(colId));
            card.idColumnsRef = Convert.ToInt32(colId);
            card.color = "white";
            card.text = "";

            DataBase.Card.AppObject(card);

            window.DraftBoard();
        }

        return buttonDel1;
    }

    //Функция для сохранения имени столбца
    public static void DraftNameColumn(Column column, TextBox textBox, MainWindow window)
    {
        textBox.TextChanged += MainWindow_TextChanged;
        void MainWindow_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Text != Logic.GetCurrentBoard().name)
            {
                if (!window.CheckPressBut())
                {
                    MessageBox.Show("Вы не можете редактировать эту доску", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                    window.DraftBoard();
                    return;
                }
            }
            column.name = textBox.Text;
            DataBase.Column.ReplaceObject(column.id, column);
        }
    }



    //Отрисовка карточек
    //Отрисовка всех карточек в столбце
    public static Grid DraftCards(Column column, MainWindow window)
    {

        Grid gridMain = new Grid();
        gridMain.Name = "Cards";

        //gridMain.Background = Brushes.White;
        gridMain.Width = 440;
        gridMain.Height = 570;
        gridMain.HorizontalAlignment = HorizontalAlignment.Center;
        gridMain.VerticalAlignment = VerticalAlignment.Top;
        gridMain.Margin = new Thickness(0, 60, 0, 0);
        //Сетка для отображения скрол бара и кнопок
        Grid gridScrollBut = new Grid();
        gridScrollBut.Width = 445;
       // gridScrollBut.Height = 690;
        gridScrollBut.HorizontalAlignment = HorizontalAlignment.Center;
        gridScrollBut.VerticalAlignment = VerticalAlignment.Top;
        gridScrollBut.Height = Logic.GetIdCardInColomns(column.id).Count * 100 + (Logic.GetIdCardInColomns(column.id).Count - 1) * 20 + 40;
        gridScrollBut.Margin = new Thickness(0, 10, 0, 0);


        //Сам скрол объект куда позже помещается сетка выше 
        ScrollViewer scrollViewer = new ScrollViewer();
        scrollViewer.Width = 430;
        scrollViewer.Height = 560;
        scrollViewer.VerticalAlignment = VerticalAlignment.Top;
        scrollViewer.HorizontalAlignment = HorizontalAlignment.Center;
        scrollViewer.Margin = new Thickness(0,10,0,0);


        int step = 0;
    
        foreach (int idCard in Logic.GetIdCardInColomns(column.id))
        {
            gridScrollBut.Children.Add(DraftCard(DataBase.Card.GetObjOfId(idCard), step, window));
            step += 120;     
        }

        scrollViewer.Content = gridScrollBut;
        gridMain.Children.Add(scrollViewer);
        return gridMain;

    }

    //Одиночная карточка 
    public static Grid DraftCard(Card card, int step, MainWindow window)
    {
        Grid grid = new Grid();
        grid.Name = "Card" + card.id;
        int widthCard = 400; 
        int heightCard = 100; 
        grid.Width = widthCard;
        grid.Height = heightCard;
        grid.HorizontalAlignment = HorizontalAlignment.Center;
        grid.VerticalAlignment = VerticalAlignment.Top;
        grid.Margin = new Thickness(0,step,0,0);

        Border btn = new Border();
        LogColorCard(card.color, btn);
        //btn.BorderBrush = Brushes.Black;
        btn.CornerRadius = new CornerRadius(15);
        btn.Width = widthCard;
        btn.Height = heightCard;
        btn.BorderThickness = new Thickness(0); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
        btn.HorizontalAlignment = HorizontalAlignment.Center;
        btn.VerticalAlignment = VerticalAlignment.Top;


        Grid gridName = new Grid();
        gridName.VerticalAlignment = VerticalAlignment.Top;
        gridName.Margin = new Thickness(0,0,0,0);
        gridName.HorizontalAlignment = HorizontalAlignment.Center;
        gridName.Width = widthCard;
        gridName.Height = 50;

        Border btnName = new Border();
        btnName.BorderBrush = Brushes.Black;
        btnName.CornerRadius = new CornerRadius(15, 15, 0, 0);
        LogColorCardHeader(card.color, btnName);
        btnName.Width = widthCard;
        btnName.Height = 50;
        btnName.BorderThickness = new Thickness(0); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева

        TextBox nameCard = new TextBox();
        nameCard.TextChanged += NameCard_TextChanged;
        nameCard.Text = card.name;
        nameCard.Height = 40;
        nameCard.Width = widthCard-35;
        nameCard.VerticalAlignment = VerticalAlignment.Center;
        nameCard.FontSize = 28;
        nameCard.BorderBrush = Brushes.Transparent;
        nameCard.Background = Brushes.Transparent;
        nameCard.HorizontalContentAlignment = HorizontalAlignment.Center;
        nameCard.VerticalContentAlignment = VerticalAlignment.Center;

        void NameCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            window.DeleteList();
            window.DeleteMenuLocalOfGlobal();
            TextBox text = (TextBox)sender;
            card.name = text.Text;
            DataBase.Card.ReplaceObject(card.id, card);
        }

        gridName.Children.Add(btnName);
        gridName.Children.Add(nameCard);


        grid.Children.Add(btn);
        grid.Children.Add(gridName);
        grid.Children.Add(ButtonCard(1, card, window));
        grid.Children.Add(ButtonCard(2, card, window));

        return grid;
    }

    //Кнопки карточки
    public static Button ButtonCard(int num, Card card, MainWindow window)
    { 
        Button buttonOpenInfo = new Button();
        buttonOpenInfo.Click += ButtonOpenInfo_Click;
        buttonOpenInfo.Width = 192;
        buttonOpenInfo.HorizontalAlignment = HorizontalAlignment.Left;
        buttonOpenInfo.VerticalAlignment = VerticalAlignment.Bottom;
        buttonOpenInfo.Margin = new Thickness(10, 0, 0, 10);
        LogColorButtonCard(card.color, buttonOpenInfo);
        buttonOpenInfo.BorderBrush = Brushes.Transparent;
        buttonOpenInfo.BorderThickness = new Thickness(3);
        buttonOpenInfo.FontSize = 20;

        if(card.text == "null")
            buttonOpenInfo.Content = "Добавить описание";
        else
            buttonOpenInfo.Content = "Открыть описание";

        Button buttonDeleteCard = new Button();
        buttonDeleteCard.Click += ButtonDeleteCard_Click;
        buttonDeleteCard.Width = 192;
        buttonDeleteCard.HorizontalAlignment = HorizontalAlignment.Right;
        buttonDeleteCard.VerticalAlignment = VerticalAlignment.Bottom;
        buttonDeleteCard.Margin = new Thickness(0, 0, 10, 10);
        buttonDeleteCard.Content = "Удалить карточку";
        LogColorButtonCard(card.color, buttonDeleteCard);
        buttonDeleteCard.BorderBrush = Brushes.Transparent;
        buttonDeleteCard.BorderThickness = new Thickness(3);
        buttonDeleteCard.FontSize = 20;

        void ButtonDeleteCard_Click(object sender, RoutedEventArgs e)
        {
            if (!window.CheckPressBut())
            {
                MessageBox.Show("Вы не можете редактировать эту доску", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DataBase.Card.DeleteByID(card.id);
            window.DraftBoard();
        }

        void ButtonOpenInfo_Click(object sender, RoutedEventArgs e)
        {
            if (!window.CheckPressBut())
            {
                MessageBox.Show("Вы не можете редактировать эту доску", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            window.MainPlane.Children.Add(MenuCardInfo(card, window));
        }

        if(num == 1)
        {
            return buttonOpenInfo;
        }
        else
        {
            return buttonDeleteCard;
        }
    }


    //Настройка цветов карточки
    //Настройка цвета карточки
    public static void LogColorCard(string textColor, Border bord)
    {
        switch (textColor)
        {
            case "green":
                bord.Background = new SolidColorBrush(Color.FromRgb(181, 245, 166));
                break;
            case "red":
                bord.Background = new SolidColorBrush(Color.FromRgb(245, 166, 166));
                break;
            case "blue":
                bord.Background = new SolidColorBrush(Color.FromRgb(138, 196, 255));
                break;
            case "aqua":
                bord.Background = new SolidColorBrush(Color.FromRgb(166, 245, 240));
                break; 
            case "yellow":
                bord.Background = new SolidColorBrush(Color.FromRgb(245, 240, 166));
                break;
            default: bord.Background = new SolidColorBrush(Color.FromRgb(247, 247, 247)); return;

        }

    }

    //Настройка цвета заголовка карточки
    public static void LogColorCardHeader(string textColor, Border bord)
    {
        switch (textColor)
        {
            case "green":
                bord.Background = new SolidColorBrush(Color.FromRgb(145, 227, 127));
                break;
            case "red":
                bord.Background = new SolidColorBrush(Color.FromRgb(227, 127, 127));
                break;
            case "blue":
                bord.Background = new SolidColorBrush(Color.FromRgb(115, 185, 255));
                break;
            case "aqua":
                bord.Background = new SolidColorBrush(Color.FromRgb(127, 227, 219));
                break;
            case "yellow":
                bord.Background = new SolidColorBrush(Color.FromRgb(227, 224, 127));
                break;
            default: bord.Background = new SolidColorBrush(Color.FromRgb(222, 222, 222)); return;

        }

    }

    //Настройка цвета кнопок
    public static void LogColorButtonCard(string textColor, Button but)
    {
        switch (textColor)
        {
            case "green":
                but.Background = new SolidColorBrush(Color.FromRgb(145, 227, 127));
                break;
            case "red":
                but.Background = new SolidColorBrush(Color.FromRgb(227, 127, 127));
                break;
            case "blue":
                but.Background = new SolidColorBrush(Color.FromRgb(115, 185, 255));            
                    break;
            case "aqua":
                but.Background = new SolidColorBrush(Color.FromRgb(127, 227, 219));
                break;
            case "yellow":
                but.Background = new SolidColorBrush(Color.FromRgb(227, 224, 127)); 
                break;
            default: but.Background = new SolidColorBrush(Color.FromRgb(222, 222, 222)); return;

        }

    }

    //Настройка чвета выпадающего списка
    public static void LogColorButtonList(string textColor, Grid gridList)
    {
        switch (textColor)
        {
            case "green":
                gridList.Background = new SolidColorBrush(Color.FromRgb(145, 227, 127));
                break;
            case "red":
                gridList.Background = new SolidColorBrush(Color.FromRgb(227, 127, 127));
                break;
            case "blue":
                gridList.Background = new SolidColorBrush(Color.FromRgb(115, 185, 255));
                break;
            case "aqua":
                gridList.Background = new SolidColorBrush(Color.FromRgb(127, 227, 219));
                break;
            case "yellow":
                gridList.Background = new SolidColorBrush(Color.FromRgb(227, 224, 127));
                break;
            default: gridList.Background = new SolidColorBrush(Color.FromRgb(222, 222, 222)); return;

        }

    }


    //Работа с меню карточки
    //Объект отображения описания карточки
    public static Grid MenuCardInfo(Card card, MainWindow window)
    {
        Grid mainGrid = new Grid();
        mainGrid.Name = "InfoCard";
        mainGrid.Width = 650;
        mainGrid.Height = 500;
        mainGrid.VerticalAlignment = VerticalAlignment.Center;
        mainGrid.HorizontalAlignment = HorizontalAlignment.Center;
        
        Border borderMainGrid = new Border();
        borderMainGrid.BorderBrush = Brushes.Black;
        borderMainGrid.CornerRadius = new CornerRadius(12);
        borderMainGrid.Width = 650;
        borderMainGrid.Height = 500;
        borderMainGrid.BorderThickness = new Thickness(3);
        borderMainGrid.Background = new SolidColorBrush(Color.FromRgb(194, 225, 255));
        mainGrid.Children.Add(borderMainGrid);


        Grid UpGrid = new Grid();
        UpGrid.Width = 650;
        UpGrid.Height = 100;
        UpGrid.VerticalAlignment = VerticalAlignment.Top;
        UpGrid.HorizontalAlignment = HorizontalAlignment.Center;

        Border borderUpGrid = new Border();
        borderUpGrid.Width = UpGrid.Width;
        borderUpGrid.Height = UpGrid.Height;
        borderUpGrid.BorderBrush = Brushes.Black;
        borderUpGrid.BorderThickness = new Thickness(2);
        borderUpGrid.CornerRadius = new CornerRadius(12);
        LogColorCard(card.color, borderUpGrid);


        UpGrid.Children.Add(borderUpGrid);
        UpGrid.Children.Add(ButtonMenuCardColor(card, window));
        UpGrid.Children.Add(ButtonMenuCardDeleteInfo(card, window));
        UpGrid.Children.Add(ButtonMenuCardAppCheckList(card, window));
        UpGrid.Children.Add(ButtonMenuCardTransform(card, window));
        UpGrid.Children.Add(ButtonMenuCardClose(card, window));

        mainGrid.Children.Add(UpGrid);

        TextBox mainText = new TextBox();
        mainText.Name = "MainTextCard";

        mainText.Background = Brushes.White;
        mainText.TextWrapping = TextWrapping.Wrap;
        mainText.AcceptsReturn = true;
        mainText.KeyUp += keyEnter;
        mainText.Width = 600;
        mainText.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        mainText.MinHeight = 50;
        mainText.MaxHeight = 300;
        mainText.HorizontalAlignment = HorizontalAlignment.Center;
        mainText.VerticalAlignment = VerticalAlignment.Top;
        mainText.Margin = new Thickness(0,130,0, 0);
        mainText.BorderBrush = Brushes.Black;
        mainText.BorderThickness = new Thickness(1);
        mainText.TextChanged += MainText_TextChanged;
        mainText.FontSize = 24;
        mainText.VerticalContentAlignment = VerticalAlignment.Center;

        mainText.Text = card.text.Replace('`', '\r').Replace('*', '\n');
        void keyEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                mainText.Select(mainText.Text.Length-1, 0); 
            }
        }
        void MainText_TextChanged(object sender, TextChangedEventArgs e)
        {
            mainText.Text = ((TextBox)sender).Text;
            Card card1 = card;
            card1.text = mainText.Text.Replace('\n', '*');
            card1.text = card1.text.Replace('\r', '`');
            DataBase.Card.ReplaceObject(card.id, card1 );
        }

        mainGrid.Children.Add(mainText);
        return mainGrid;
    }

    //Кнопки для работы с цветом карточки
    public static Grid ButtonMenuCardColor(Card card, MainWindow window)
    {
        Grid mainGrid = new Grid();
        mainGrid.VerticalAlignment = VerticalAlignment.Center;
        mainGrid.HorizontalAlignment = HorizontalAlignment.Left;
        mainGrid.Margin = new Thickness(30, 0, 0, 0);
        mainGrid.Height = 60;
        mainGrid.Width = 110;
        LogColorButtonList(card.color, mainGrid);

        Border border = new Border();
        border.Width = 110;
        border.Height = 60;
        border.BorderThickness = new Thickness(2);
        border.BorderBrush = Brushes.Black;


        ComboBox buttons = new ComboBox();
        buttons.Width = 20;
        buttons.Height = 60;
        
        buttons.FontSize = 20;

        buttons.HorizontalAlignment = HorizontalAlignment.Right;
        buttons.VerticalAlignment = VerticalAlignment.Center;

        TextBlock textBlock = new TextBlock();
        textBlock.FontSize = 16;
        textBlock.Text = "Поменять \n   цвет";
        textBlock.HorizontalAlignment = HorizontalAlignment.Center;
        textBlock.VerticalAlignment = VerticalAlignment.Center;
        textBlock.Margin = new Thickness(-12, 0, 0, 0);



        Button colorBut1 = new Button();
        colorBut1.Height = 30;
        colorBut1.Width = 120;
        colorBut1.Margin = new Thickness(0, 10, 0, 0);
        colorBut1.VerticalAlignment = VerticalAlignment.Top;
        colorBut1.Content = "Белый";
        colorBut1.Background = new SolidColorBrush(Color.FromRgb(222, 222, 222));
        colorBut1.Click += ColorBut1_Click;
        void ColorBut1_Click(object sender, RoutedEventArgs e)
        {
            Card card1 = card;
            card1.color = "white";
            DataBase.Card.ReplaceObject(card.id, card1);
            window.DraftBoard();
            window.DeleteInfoCard();
            window.MainPlane.Children.Add(MenuCardInfo(card, window));
        }

        Button colorBut2 = new Button();
        colorBut2.Height = 30;
        colorBut2.Width = 120;
        colorBut2.Margin = new Thickness(0, 50, 0, 0);
        colorBut2.VerticalAlignment = VerticalAlignment.Top;
        colorBut2.Content = "Зеленый";
        colorBut2.Background = new SolidColorBrush(Color.FromRgb(145, 227, 127));
        colorBut2.Click += ColorBut2_Click;
        void ColorBut2_Click(object sender, RoutedEventArgs e)
        {
            Card card1 = card;
            card1.color = "green";
            DataBase.Card.ReplaceObject(card.id, card1);
          //  window.DraftBoard();
            window.DeleteInfoCard();
            window.MainPlane.Children.Add(MenuCardInfo(card, window));
        }

        Button colorBut3 = new Button();
        colorBut3.Height = 30;
        colorBut3.Width = 120;
        colorBut3.Margin = new Thickness(0, 90, 0, 0);
        colorBut3.VerticalAlignment = VerticalAlignment.Top;
        colorBut3.Content = "Красный";
        colorBut3.Background = new SolidColorBrush(Color.FromRgb(227, 127, 127));
        colorBut3.Click += ColorBut3_Click;
        void ColorBut3_Click(object sender, RoutedEventArgs e)
        {
            Card card1 = card;
            card1.color = "red";
            DataBase.Card.ReplaceObject(card.id, card1);
         //   window.DraftBoard();
            window.DeleteInfoCard();
            window.MainPlane.Children.Add(MenuCardInfo(card, window));
        }

        Button colorBut4 = new Button();
        colorBut4.Height = 30;
        colorBut4.Width = 120;
        colorBut4.Margin = new Thickness(0, 130, 0, 0);
        colorBut4.VerticalAlignment = VerticalAlignment.Top;
        colorBut4.Content = "Синий";
        colorBut4.Background = new SolidColorBrush(Color.FromRgb(115, 185, 255));
        colorBut4.Click += ColorBut4_Click;
        void ColorBut4_Click(object sender, RoutedEventArgs e)
        {
            Card card1 = card;
            card1.color = "blue";
            DataBase.Card.ReplaceObject(card.id, card1);
           // window.DraftBoard();
            window.DeleteInfoCard();
            window.MainPlane.Children.Add(MenuCardInfo(card, window));
        }

        Button colorBut5 = new Button();
        colorBut5.Height = 30;
        colorBut5.Width = 120;
        colorBut5.Margin = new Thickness(0, 170, 0, 0);
        colorBut5.VerticalAlignment = VerticalAlignment.Top;
        colorBut5.Content = "Голубой";
        colorBut5.Background = new SolidColorBrush(Color.FromRgb(127, 227, 219));
        colorBut5.Click += ColorBut5_Click;
        void ColorBut5_Click(object sender, RoutedEventArgs e)
        {
            Card card1 = card;
            card1.color = "aqua";
            DataBase.Card.ReplaceObject(card.id, card1);
           // window.DraftBoard();
            window.DeleteInfoCard();
            window.MainPlane.Children.Add(MenuCardInfo(card, window));
        }


        Button colorBut6 = new Button();
        colorBut6.Height = 30;
        colorBut6.Width = 120;
        colorBut6.Margin = new Thickness(0, 210, 0, 10);
        colorBut6.VerticalAlignment = VerticalAlignment.Top;
        colorBut6.Content = "Желтый";
        colorBut6.Background = new SolidColorBrush(Color.FromRgb(227, 224, 127));
        colorBut6.Click += ColorBut6_Click;
        void ColorBut6_Click(object sender, RoutedEventArgs e)
        {
            Card card1 = card;
            card1.color = "yellow";
            DataBase.Card.ReplaceObject(card.id, card1);
           // window.DraftBoard();
            window.DeleteInfoCard();
            window.MainPlane.Children.Add(MenuCardInfo(card, window));
        }

        Grid grid = new Grid();
        mainGrid.Children.Add(textBlock);
        grid.Children.Add(colorBut1);
        grid.Children.Add(colorBut2);
        grid.Children.Add(colorBut3);
        grid.Children.Add(colorBut4);
        grid.Children.Add(colorBut5);
        grid.Children.Add(colorBut6);

        ComboBoxItem comboBoxItem = new ComboBoxItem();
        comboBoxItem.Content = grid;
        buttons.Items.Add(comboBoxItem);




        mainGrid.Children.Add(buttons);
        
        mainGrid.Children.Add(border);
        return mainGrid;
    }

    //Добавление чеклиста
    public static Button ButtonMenuCardAppCheckList(Card card, MainWindow window)
    {
        Button button = new Button();
        button.Width = 110;
        button.Height = 60;
        LogColorButtonCard(card.color, button);
        button.BorderBrush = Brushes.Black;
        button.Content = "Добавить\n чеклист";
        button.FontSize = 16;
        button.BorderThickness = new Thickness(2);
        button.HorizontalContentAlignment = HorizontalAlignment.Center;

        button.HorizontalAlignment = HorizontalAlignment.Left;
        button.Margin = new Thickness(165, 0, 0, 0);
        button.VerticalAlignment = VerticalAlignment.Center;

        button.Click += Click3;

        void Click3(object sender, RoutedEventArgs e)
        {
            //Объект для списка досок
            
        }

        return button;
    }

    //Перемещение карточки
    public static Button ButtonMenuCardTransform(Card card, MainWindow window)
    {
        Button button = new Button();
        button.Width = 110;
        button.Height = 60;
        LogColorButtonCard(card.color, button);
        button.BorderBrush = Brushes.Black;
        button.Content = "Переместить";
        button.FontSize = 16;
        button.BorderThickness = new Thickness(2);
        button.HorizontalContentAlignment = HorizontalAlignment.Center;

        button.HorizontalAlignment = HorizontalAlignment.Left;
        button.Margin = new Thickness(300, 0, 0, 0);
        button.VerticalAlignment = VerticalAlignment.Center;

        button.Click += Click3;

        void Click3(object sender, RoutedEventArgs e)
        {
            window.MainPlane.Children.Add(ButtonsColumn(window, card));

        }

        return button;
    }

    //Удаление содержания карточки
    public static Button ButtonMenuCardDeleteInfo(Card card, MainWindow window)
    {
        Button button = new Button();
        button.Width = 105;
        button.Height = 60;
        LogColorButtonCard(card.color, button);
        button.BorderBrush = Brushes.Black;
        button.Content = "    Удалить \n содержание";
        button.HorizontalContentAlignment = HorizontalAlignment.Center;
        button.FontSize = 16;
        button.BorderThickness = new Thickness(2);

        button.HorizontalAlignment = HorizontalAlignment.Right;
        button.VerticalAlignment = VerticalAlignment.Center;
        button.Margin = new Thickness(0, 0, 110, 0);
        button.HorizontalContentAlignment = HorizontalAlignment.Center;

        button.Click += Click3;

        void Click3(object sender, RoutedEventArgs e)
        {
            DataBase.Card.ReplaceObject(card.id, new Card(card.id, card.idColumnsRef, card.name, card.color, card.typeDeskrip, ""));
            window.DeleteInfoCard();
            window.MainPlane.Children.Add(MenuCardInfo(DataBase.Card.GetObjOfId(card.id), window));
        }

        return button;
    }

    //Закрытие информации карточки
    public static Button ButtonMenuCardClose(Card card, MainWindow window)
    {
        Button btn = new Button();
        btn.Width = 60;
        btn.Height = 35;
        btn.Background = Brushes.IndianRed;
        if(card.color == "red")
        {
            btn.Background = Brushes.Gray;
        }
        btn.BorderBrush = Brushes.Black;
        btn.Content = "Закрыть";
        btn.FontSize = 14;
        btn.Click += Click1;
        btn.BorderThickness = new Thickness(2); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева
        btn.HorizontalAlignment = HorizontalAlignment.Right;
        btn.VerticalAlignment = VerticalAlignment.Top;
        

        //Функция клика для этих кнопок
        void Click1(object sender, RoutedEventArgs e)
        {
            window.DraftBoard();
            window.DeleteInfoCard();
        }

        return btn;
    }


    //Объект для списка столбцов
    public static Grid ButtonsColumn(MainWindow window, Card card)
    {
        //Основной блок, куда все помещаю
        Grid gridMain = new Grid();
        gridMain.Name = "ColumnList";

        gridMain.Background = Brushes.White;
        gridMain.Width = 335;
        gridMain.Height = Logic.GetColumnsTrue().Count * 50 + (Logic.GetColumnsTrue().Count - 1) * 20 + 100;
        gridMain.MaxHeight = 5 * 50 + (Logic.GetColumnsTrue().Count - 1) * 20 + 100;
        gridMain.HorizontalAlignment = HorizontalAlignment.Center;
        gridMain.VerticalAlignment = VerticalAlignment.Top;
        gridMain.Margin = new Thickness(0, 150, 0, 0);

        //Сетка для отображения скрол бара и кнопок
        Grid gridScrollBut = new Grid();
        gridScrollBut.Margin = new Thickness(0, 0, 0, 0);
        gridScrollBut.Width = 300;
        gridScrollBut.HorizontalAlignment = HorizontalAlignment.Center;
        gridScrollBut.VerticalAlignment = VerticalAlignment.Top;
        gridScrollBut.Height = Logic.GetColumnsTrue().Count * 50 + (Logic.GetColumnsTrue().Count - 1) * 20 + 40;

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
        border.Height = Logic.GetColumnsTrue().Count * 50 + (Logic.GetColumnsTrue().Count - 1) * 20 + 100;
        border.MaxHeight = 5 * 50 + (Logic.GetColumnsTrue().Count - 1) * 20 + 100;
        border.VerticalAlignment = VerticalAlignment.Top;
        border.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева

        //Добавление кнопок в грид для скролл бара
        List<Column> columns = Logic.GetColumnsTrue().ToList();
        int step = 0;
        for (int i = columns.Count - 1; i >= 0; i--)
        {
            gridScrollBut.Children.Add(ButtonColumn(step, columns[i], card, window));
            step += 70;
        }

        //Помещаю грид в скрол вью
        scrollViewer.Content = gridScrollBut;

        //Добавляю в главный элемент границы, скролл сетку с кнопками и кнопку закрытия
        gridMain.Children.Add(border);
        gridMain.Children.Add(scrollViewer);
        gridMain.Children.Add(ColumnListClose(window));
        return gridMain;
    }
    //Создание кнопок для списка досок
    public static Button ButtonColumn(int step, Column column, Card card, MainWindow window)
    {
        Button btn = new Button();

        btn.Background = new SolidColorBrush(Color.FromRgb(194, 225, 255));
        btn.BorderBrush = Brushes.Black;
        btn.Width = 250;
        btn.Height = 50;
        btn.Name = "Mini" + column.name.Replace(" ", "");
        btn.Content = column.name;
        btn.Margin = new Thickness(0, step, 0, 0); //Расположение каждый раз разное

        btn.HorizontalAlignment = HorizontalAlignment.Center;
        btn.VerticalAlignment = VerticalAlignment.Top;

        btn.Click += Click1;
        btn.BorderThickness = new Thickness(2); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева

        //Функция клика для этих кнопок
        void Click1(object sender, RoutedEventArgs e)
        {
            Card card1 = DataBase.Card.GetObjOfId(card.id);
            card1.idColumnsRef = column.id;
            DataBase.Card.ReplaceObject(card.id, card1);
            window.DeleteList();
            window.ClearColumn();
            window.DraftBoard();
            window.DeleteInfoCard();
            window.MainPlane.Children.Add(MenuCardInfo(DataBase.Card.GetObjOfId(card.id), window));
        }

        return btn;
    }
    //Кнопка закрытия для списка досок
    public static Button ColumnListClose(MainWindow window)
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
        List<Board> boards = Logic.GetBoardsTrue().ToList();
        int step = 0;
        for(int i = boards.Count - 1; i>=0; i--)
        {
            gridScrollBut.Children.Add(ButtonBoard(step, boards[i], window));
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

        btn.Background = new SolidColorBrush(Color.FromRgb(194, 225, 255));
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
            window.ClearColumn();
            window.DraftBoard();
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



    //Объект для списка пользователей
    public static Grid FonButtonPerson(MainWindow window)
    {
        //Основной блок, куда все помещаю
        Grid gridMain = new Grid();
        gridMain.Name = "PersList";

        gridMain.Background = Brushes.White;
        gridMain.Width = 335;
        gridMain.Height = Logic.GetTruePersons().Count * 50 + (Logic.GetTruePersons().Count - 1) * 20 + 100;
        gridMain.MaxHeight = 5 * 50 + (Logic.GetTruePersons().Count - 1) * 20 + 100;
        gridMain.HorizontalAlignment = HorizontalAlignment.Center;
        gridMain.VerticalAlignment = VerticalAlignment.Top;
        gridMain.Margin = new Thickness(0, 150, 0, 0);

        //Сетка для отображения скрол бара и кнопок
        Grid gridScrollBut = new Grid();
        gridScrollBut.Margin = new Thickness(0, 0, 0, 0);
        gridScrollBut.Width = 300;
        gridScrollBut.HorizontalAlignment = HorizontalAlignment.Center;
        gridScrollBut.VerticalAlignment = VerticalAlignment.Top;
        gridScrollBut.Height = Logic.GetTruePersons().Count * 50 + (Logic.GetTruePersons().Count - 1) * 20 + 40;

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
        border.Height = Logic.GetTruePersons().Count * 50 + (Logic.GetTruePersons().Count - 1) * 20 + 100;
        border.MaxHeight = 5 * 50 + (Logic.GetTruePersons().Count - 1) * 20 + 100;
        border.VerticalAlignment = VerticalAlignment.Top;
        border.BorderThickness = new Thickness(4); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева

        //Добавление кнопок в грид для скролл бара
        int step = 0;
        foreach (Person person in Logic.GetTruePersons())
        {
            gridScrollBut.Children.Add(ButtonPerson(step, person, window));
            step += 70;
        }

        //Помещаю грид в скрол вью
        scrollViewer.Content = gridScrollBut;

        //Добавляю в главный элемент границы, скролл сетку с кнопками и кнопку закрытия
        gridMain.Children.Add(border);
        gridMain.Children.Add(scrollViewer);
        gridMain.Children.Add(PersonListClose(window));
        return gridMain;
    }
    //Создание кнопок для списка пользователей
    public static Button ButtonPerson(int step, Person person, MainWindow window)
    {
        Button btn = new Button();

        btn.Background = new SolidColorBrush(Color.FromRgb(194, 225, 255));
        btn.BorderBrush = Brushes.Black;
        btn.Width = 250;
        btn.Height = 50;
        btn.Name = "Mini" + person.login.Replace(" ", "");
        btn.Content = person.login;
        btn.Margin = new Thickness(0, step, 0, 0); //Расположение каждый раз разное

        btn.HorizontalAlignment = HorizontalAlignment.Center;
        btn.VerticalAlignment = VerticalAlignment.Top;

        btn.Click += Click1;
        btn.BorderThickness = new Thickness(2); // толщина границы: 2 пикселя сверху, 4 пикселя справа, 6 пикселей снизу, 8 пикселей слева

        //Функция клика для этих кнопок
        void Click1(object sender, RoutedEventArgs e)
        {
            //Доска добавляется к пользователю и теперь он может делать в ней что-либо
            DataBase.Person.AssignmentIDBoard(person.id, Logic.GetCurrentBoard().id.ToString());
            window.DeleteList();
        }

        return btn;
    }
    //Кнопка закрытия для списка пользователей
    public static Button PersonListClose(MainWindow window)
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
        bord2.Background = new SolidColorBrush(Color.FromRgb(100, 140, 255));

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
        button.Background = new SolidColorBrush(Color.FromRgb(194, 225, 255));
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
            DataBase.Person.AssignmentIDBoard(Logic.GetCurrentPerson().id, Logic.GetCurrentBoard().id.ToString());


            window.DeleteList();
            window.ClearColumn();
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
        button.Background = new SolidColorBrush(Color.FromRgb(194, 225, 255));
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
            DataBase.Person.AssignmentIDBoard(Logic.GetCurrentPerson().id, Logic.GetCurrentBoard().id.ToString());

            window.DeleteList();
            window.ClearColumn();
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


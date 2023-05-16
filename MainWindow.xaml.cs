using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace TaskBoard
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Создание активной доски если доски отсутствуют
            if (DataBase.Board.GetListBoards() == null)
            {
                Board board = new Board(Logic.GetBoardNullName());
                board.stateActive = 1;
                DataBase.Board.AppObject(board);
                DataBase.Board.ActivsBoard(DataBase.Board.GetListBoards()[0].id);
            }
            //Активация первой доски пользователя
            DataBase.Board.ActivsBoard(Logic.GetBoardsTrue()[Logic.GetBoardsTrue().Count-1].id);
            

            InitializeComponent();

            DraftBoard();
            MainPlane.Children.Add(DrawPlane.Card(DataBase.Card.GetObjOfId(4), this));
        }


        //Отрисовка элементов

        //Отрисовка доски
        public void DraftBoard()
        {
            BoardText.Text = Logic.GetCurrentBoard().name.ToString();

            //Удаление старых столбцов должно быть тут

            int IDboard = Logic.GetCurrentBoard().id;
            string[] str = Logic.GetNameColumns(IDboard);
            int a = new Logic().GetIdColumsInBoard(IDboard).Count();
            DraftColumns(a, str);
            
            
        }
        //отрисовывает определенное количество карточек
        public void DraftColumns(int All, string[] str, int Browsing = 0)
        {
            if (All == 0)
            {
                //Ничего
            }

            if (All == 1)
            {
                //Создание грида
                Grid grid = DrawPlane.NewGrid();
                grid.Margin = new Thickness(0, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
                grid.HorizontalAlignment = HorizontalAlignment.Center;
                grid.VerticalAlignment = VerticalAlignment.Top;

                Border[] borders = new Border[All];
                borders = DrawPlane.DrawBorder(All);
                grid.Children.Add(borders[All - 1]);

                //Выводим рамочку, куда поместим название 
                borders = DrawPlane.DrawBorderBlox(All);
                grid.Children.Add(borders[All - 1]);
                TextBlock[] txt = DrawPlane.DrawTextBlock(All);
                txt[0].Text = str[0];
                grid.Children.Add(txt[0]);
                MainPlane.Children.Add(grid);
            }
            if (All == 2)
            {
                Grid grid1 = DrawPlane.NewGrid();
                Grid grid2 = DrawPlane.NewGrid();

                grid1.Margin = new Thickness(250, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
                grid1.HorizontalAlignment = HorizontalAlignment.Left;
                grid1.VerticalAlignment = VerticalAlignment.Top;

                grid2.Margin = new Thickness(0, 100, 250, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
                grid2.HorizontalAlignment = HorizontalAlignment.Right;
                grid2.VerticalAlignment = VerticalAlignment.Top;


                Border[] borders = new Border[All];
                borders = DrawPlane.DrawBorder(All);
                grid1.Children.Add(borders[All - 1]);
                grid2.Children.Add(borders[All - 2]);

                //Выводи рамочку
                borders = DrawPlane.DrawBorderBlox(All);
                grid1.Children.Add(borders[All - 1]);
                grid2.Children.Add(borders[All - 2]);

                TextBlock[] txt = DrawPlane.DrawTextBlock(All);
                txt[0].Text = str[0];
                txt[1].Text = str[1];
                grid1.Children.Add(txt[0]);
                grid2.Children.Add(txt[1]);
                MainPlane.Children.Add(grid1);
                MainPlane.Children.Add(grid2);
            }
            if (All >= 3) /*(Logic.GetIdColInBoard(IDboard).Count == 3)*/
            {
                Grid grid1 = DrawPlane.NewGrid();

                grid1.Margin = new Thickness(60, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
                grid1.HorizontalAlignment = HorizontalAlignment.Left;
                grid1.VerticalAlignment = VerticalAlignment.Top;

                Grid grid2 = DrawPlane.NewGrid();

                grid2.Margin = new Thickness(0, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
                grid2.HorizontalAlignment = HorizontalAlignment.Center;
                grid2.VerticalAlignment = VerticalAlignment.Top;

                Grid grid3 = DrawPlane.NewGrid();
                grid3.Margin = new Thickness(0, 100, 60, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
                grid3.HorizontalAlignment = HorizontalAlignment.Right;
                grid3.VerticalAlignment = VerticalAlignment.Top;

                All = 3;
                Border[] borders = new Border[All];
                borders = DrawPlane.DrawBorder(All);
                grid1.Children.Add(borders[All - 1]);
                grid2.Children.Add(borders[All - 2]);
                grid3.Children.Add(borders[All - 3]);
                //Вывод рамочки
                borders = DrawPlane.DrawBorderBlox(All);
                grid1.Children.Add(borders[All - 1]);
                grid2.Children.Add(borders[All - 2]);
                grid3.Children.Add(borders[All - 3]);
                //отрисовываем текст
                TextBlock[] txt = DrawPlane.DrawTextBlock(All);
                txt[0].Text = str[0];
                txt[1].Text = str[1];
                txt[2].Text = str[2];

                grid1.Children.Add(txt[0]);
                grid2.Children.Add(txt[1]);
                grid3.Children.Add(txt[2]);
                MainPlane.Children.Add(grid1);
                MainPlane.Children.Add(grid2);
                MainPlane.Children.Add(grid3);
            }
        }
        public void DeleteColumn()
        {
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("Column1"))
                    {
                        MainPlane.Children.Remove((Grid)element);
                        break;
                    }
                }
            }
        }
        public void DraftCards()
        {
            //Отрисовка всех карточек в столбце
        }


        //Удаление элементов

        //Удаление открывающегося списка как пользователей, так и досок
        public void DeleteList()
        {
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("BordList"))
                    {
                        MainPlane.Children.Remove((Grid)element);
                        break;
                    }
                }
            }
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("PersList"))
                    {
                        MainPlane.Children.Remove((Grid)element);
                        break;
                    }
                }
            }
        }

        //Удаление меню с выбором вида доски
        public void DeleteMenuLocalOfGlobal()
        {
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("PlaneStateBoard"))
                    {
                        MainPlane.Children.Remove((Grid)element);

                        DraftBoard();
                        return;
                    }
                }
            }
        }


        //Обработчики нажатий на доске

        //Замена имени доски на введенную
        private void BoardText_TextChanget(object sender, TextChangedEventArgs e)
        {
            TextBox text = (TextBox)sender;
            //Получаю активную доску
            Board newBoard = Logic.GetCurrentBoard();
            newBoard.name = text.Text;   //Меняю имя на введенное
            BoardText.Text = newBoard.name;
            //Заменяю в базе данных
            DeleteList();
            DeleteMenuLocalOfGlobal();
            DataBase.Board.ReplaceObject(Logic.GetCurrentBoard().id, newBoard);
        }

        //Добавление доски(открытие меню какой тип доски добавить)
        private void ButtonAddBoard_Click(object sender, RoutedEventArgs e)
        {
            DeleteList();
            int flag = 1;

            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("PlaneStateBoard"))
                    {
                        flag = 0; break;
                    }
                }
            }


            //Создание кнопок и фона
            if (flag == 1)
            {
                DeleteList();
                MainPlane.Children.Add(DrawPlane.PlaneStateBoard(this));
            }
            //Иначе удаление
            else
            {
                foreach (UIElement element in MainPlane.Children)
                {
                    if (element is Grid)
                    {
                        if (((Grid)element).Name.ToString().Contains("PlaneStateBoard"))
                        {
                            MainPlane.Children.Remove((Grid)element);
                            break;
                        }
                    }
                }
            }
        }

        //Удаление доски со всеми ее элементами
        private void ButtonDeleteBoard_Click(object sender, RoutedEventArgs e)
        {
            DeleteList();
            if (Logic.GetBoardsTrue().Count() == 1)
            {
                MessageBox.Show("Нельзя удалить единственную доску");
                return;
            }
            int idBoard = Logic.GetCurrentBoard().id;
            //Удаляю доску
            DataBase.Board.DeleteByID(idBoard);

            //Получаю все столбцы этой доски      
            if (new Logic().GetIdColumsInBoard(idBoard) != null)
            {
                List<int> IdColumns = new Logic().GetIdColumsInBoard(idBoard);
                if (DataBase.Column.GetListСolumns() != null)
                {
                    foreach (int iColumn in IdColumns)
                    {
                        //Получаю все айди карточки в столбце
                        if (Logic.GetIdCardInColomns(iColumn) != null)
                        {
                            List<int> IdCards = Logic.GetIdCardInColomns(iColumn);
                            foreach (int iCard in IdCards)
                            {
                                //Удаляю каждую карточку столбца
                                DataBase.Card.DeleteByID(iCard);
                            }
                        }
                        //Удаляю сам столбец
                        DataBase.Column.DeleteByID(iColumn);
                    }
                }   
            }

            //Делаю активной другую доску, рисую активнцю доску
            DataBase.Board.ActivsBoard(Logic.GetBoardsTrue()[Logic.GetBoardsTrue().Count - 1].id);
            DeleteMenuLocalOfGlobal();
            DeleteList();
            DraftBoard();
        }

        //Удаление карточки в столбце
        public void DeleteCard(Card card)
        {
            DeleteList();
            DeleteMenuLocalOfGlobal();
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("Card"+card.id))
                    {
                        MainPlane.Children.Remove((Grid)element);
                        break;
                    }
                }
            }
        }

        //Открытие списка досок и закрытие
        public void ButtonOpenBoards_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("PersList"))
                    {
                        MainPlane.Children.Remove((Grid)element);
                        break;
                    }
                }
            }

            int flag = 1;

            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("BordList"))
                    {
                        flag = 0; break;
                    }
                }
            }


            //Создание кнопок и фона
            if (flag == 1)
            {
                DeleteMenuLocalOfGlobal();
                MainPlane.Children.Add(DrawPlane.FonButtonBoard(this));           
            }
            //Иначе удаление
            else
            {
                foreach (UIElement element in MainPlane.Children)
                {
                    if (element is Grid)
                    {
                        if (((Grid)element).Name.ToString().Contains("BordList"))
                        {
                            MainPlane.Children.Remove((Grid)element);
                            break;
                        }
                    }
                }
            } 
        }

        //Открыти списка пользователей для добавления
        public void ButtonOpenPerson_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("BordList"))
                    {
                        MainPlane.Children.Remove((Grid)element);
                        break;
                    }
                }
            }

            int flag = 1;

            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("PersList"))
                    {
                        flag = 0; break;
                    }
                }
            }


            //Создание кнопок и фона
            if (flag == 1)
            {
                DeleteMenuLocalOfGlobal();
                MainPlane.Children.Add(DrawPlane.FonButtonPerson(this));
            }
            //Иначе удаление
            else
            {
                foreach (UIElement element in MainPlane.Children)
                {
                    if (element is Grid)
                    {
                        if (((Grid)element).Name.ToString().Contains("PersList"))
                        {
                            MainPlane.Children.Remove((Grid)element);
                            break;
                        }
                    }
                }
            }
        }

        //Добавление столбцов
        private void ButtonAddColumn_Click(object sender, RoutedEventArgs e)
        {
            DeleteList();

            Column column = new Column(DataBase.Column.MaxID(), Logic.GetCurrentBoard().id, "Столбец " + (new Logic().GetIdColumsInBoard(Logic.GetCurrentBoard().id).Count() + 1).ToString());
            DataBase.Column.AppObject(column);

            DeleteMenuLocalOfGlobal();
            DraftBoard();
        }

        //Кнопка перехода к выбору пользователя
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }
    }
}

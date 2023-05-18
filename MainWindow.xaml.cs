using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
using static DataBase;
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
            ClearColumn();
            DraftBoard();
           
        }


        //Отрисовка элементов

        //Отрисовка доски
        public void DraftBoard()
        {
            BoardText.Text = Logic.GetCurrentBoard().name.ToString();
            TextPerson.Text = "Пользователь: ";
            TextPerson.Text += Logic.GetCurrentPerson().login;
            //Удаление старых столбцов должно быть тут

            int IDboard = Logic.GetCurrentBoard().id;
            string[] str = Logic.GetNameColumns(IDboard);
            ClearColumn();
            DraftColumns(new Logic().GetIdColumsInBoard(IDboard), str);    
        }

        //отрисовывает определенное количество столбцов
        public void DraftColumns(List<int> columnsId, string[] str, int Browsing = 0)
        {
            int All = columnsId.Count;

            Button buttonL = DrawPlane.ButtonRightLeft();
            buttonL.Content = "<";
            MainPlane.Children.Add(buttonL);

            Button buttonR = DrawPlane.ButtonRightLeft();
            buttonR.Content = ">";
            buttonR.HorizontalAlignment = HorizontalAlignment.Right;
            MainPlane.Children.Add(buttonR);

            if (All == 0)
            {
                //Ничего
            }
            if (All == 1)
            {
                //Создание грида
                Column column = DataBase.Column.GetObjOfId(columnsId[0]);
                Grid grid1 = DrawPlane.GridColumn();
                grid1.Name = "Column"+columnsId[0].ToString();
                grid1.Margin = new Thickness(0, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
                grid1.HorizontalAlignment = HorizontalAlignment.Center;
                grid1.VerticalAlignment = VerticalAlignment.Top;

                Border[] borders = new Border[All];
                borders = DrawPlane.DrawBorder(All);
                grid1.Children.Add(borders[All - 1]);

                //Выводим рамочку, куда поместим название 
                borders = DrawPlane.DrawBorderBlox(All);
                grid1.Children.Add(borders[All - 1]);
                TextBox[] txt = DrawPlane.DrawTextBox(All);
                txt[0].Text = column.name;
                DrawPlane.DraftNameColumn(column, txt[0], this);
                grid1.Children.Add(txt[0]);
                MainPlane.Children.Add(grid1);


                //делаем кнопку удаления столбцов
                Button buttonDel = DrawPlane.DelBatton(this, grid1.Name.Substring(6));
                grid1.Children.Add(buttonDel);
                if(Logic.GetIdCardInColomns(column.id) != null)
                {
                    grid1.Children.Add(DrawPlane.DraftCards(column, this));
                }
                
            }
            if (All == 2)
            {
                Column column1 = DataBase.Column.GetObjOfId(columnsId[0]);
                Column column2 = DataBase.Column.GetObjOfId(columnsId[1]);

                Grid grid1 = DrawPlane.GridColumn();
                Grid grid2 = DrawPlane.GridColumn();
                grid1.Name = "Column" + columnsId[0].ToString();
                grid2.Name = "Column" + columnsId[1].ToString(); 

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

                TextBox[] txt = DrawPlane.DrawTextBox(All);
                txt[0].Text = column1.name;
                txt[1].Text = column2.name;
                DrawPlane.DraftNameColumn(column1, txt[0], this);
                DrawPlane.DraftNameColumn(column2, txt[1], this);
                grid1.Children.Add(txt[0]);
                grid2.Children.Add(txt[1]);

                //делаем кнопку удаления столбцов
                Button buttonDel1 = DrawPlane.DelBatton(this, grid1.Name.Substring(6));
                grid1.Children.Add(buttonDel1);
                
                //делаем кнопку удаления столбцов
                Button buttonDel2 = DrawPlane.DelBatton(this, grid1.Name.Substring(6));
                grid2.Children.Add(buttonDel2);
                
                MainPlane.Children.Add(grid1);
                MainPlane.Children.Add(grid2);

                if (Logic.GetIdCardInColomns(column2.id) != null)
                {
                    grid2.Children.Add(DrawPlane.DraftCards(column2, this));
                }
                if (Logic.GetIdCardInColomns(column1.id) != null)
                {
                    grid1.Children.Add(DrawPlane.DraftCards(column1, this));
                }
            }
            if (All >= 3) /*(Logic.GetIdColInBoard(IDboard).Count == 3)*/
            {
                Column column1 = DataBase.Column.GetObjOfId(columnsId[0]);
                Column column2 = DataBase.Column.GetObjOfId(columnsId[1]);
                Column column3 = DataBase.Column.GetObjOfId(columnsId[2]);
                //grid.Background = Brushes.Black;

                Grid grid1 = DrawPlane.GridColumn();

                grid1.Margin = new Thickness(60, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
                grid1.HorizontalAlignment = HorizontalAlignment.Left;
                grid1.VerticalAlignment = VerticalAlignment.Top;

                Grid grid2 = DrawPlane.GridColumn();

                grid2.Margin = new Thickness(0, 100, 0, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
                grid2.HorizontalAlignment = HorizontalAlignment.Center;
                grid2.VerticalAlignment = VerticalAlignment.Top;

                Grid grid3 = DrawPlane.GridColumn();
                grid3.Margin = new Thickness(0, 100, 60, 0); // расположение элемента в контейнере задается с помощью свойства Margin и объекта Thickness
                grid3.HorizontalAlignment = HorizontalAlignment.Right;
                grid3.VerticalAlignment = VerticalAlignment.Top;


                grid1.Name = "Column" + columnsId[0].ToString(); 
                grid2.Name = "Column" + columnsId[1].ToString(); 
                grid3.Name = "Column" + columnsId[2].ToString(); 

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
                TextBox[] txt = DrawPlane.DrawTextBox(All);
                txt[0].Text = column1.name;
                txt[1].Text = column2.name;
                txt[2].Text = column3.name;
                DrawPlane.DraftNameColumn(column1, txt[0], this);
                DrawPlane.DraftNameColumn(column2, txt[1], this);
                DrawPlane.DraftNameColumn(column3, txt[2], this);


                //делаем кнопку удаления столбцов
                Button buttonDel1 = DrawPlane.DelBatton(this, grid1.Name.Substring(6));
                grid1.Children.Add(buttonDel1);
                

                //делаем кнопку удаления столбцов
                Button buttonDel2 = DrawPlane.DelBatton(this, grid1.Name.Substring(6));
                grid2.Children.Add(buttonDel2);
                

                //делаем кнопку удаления столбцов
                Button buttonDel3 = DrawPlane.DelBatton(this, grid1.Name.Substring(6));
                grid3.Children.Add(buttonDel3);
                

                grid1.Children.Add(txt[Browsing]);
                grid2.Children.Add(txt[Browsing + 1]);
                grid3.Children.Add(txt[Browsing + 2]);

                //Button buttonDel1 = DrawPlane.ButtonRightLeft();
                ////uttonDel.Content = "-";
                //buttonDel1.HorizontalAlignment = HorizontalAlignment.Right;
                //buttonDel1.VerticalAlignment = VerticalAlignment.Top;
                //buttonDel1.Width = 30;
                //buttonDel1.Height = 10;
                //buttonDel1.Background = new SolidColorBrush(Colors.Black);
                //buttonDel1.Margin = new Thickness(0, 23, 40, 0);
                //buttonDel1.FontSize = 15;
                //grid1.Children.Add(buttonDel1);




                //grid.Background = Brushes.Black;
                MainPlane.Children.Add(grid1);
                MainPlane.Children.Add(grid2);
                MainPlane.Children.Add(grid3);
                if (Logic.GetIdCardInColomns(column1.id) != null)
                {
                    grid1.Children.Add(DrawPlane.DraftCards(column1, this));
                }
                if (Logic.GetIdCardInColomns(column2.id) != null)
                {
                    grid2.Children.Add(DrawPlane.DraftCards(column2, this));
                }
                if (Logic.GetIdCardInColomns(column3.id) != null)
                {
                    grid3.Children.Add(DrawPlane.DraftCards(column3, this));
                }
            }

        }



        

        

        private void RightButton(object sender, RoutedEventArgs e)
        {
           ClearColumn();
            int IDboard = Logic.GetCurrentBoard().id;
            string[] str = Logic.GetNameColumns(IDboard);
            int a = new Logic().GetIdColumsInBoard(IDboard).Count();
            Enumeration.Change(Enumeration.value + 1);
            DraftColumns(new Logic().GetIdColumsInBoard(IDboard), str, Enumeration.value);

        }
        public class Enumeration
        {
            public static int value = 0;

            public static void Change(int a)
            {
                Enumeration.value = a;
            }
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

        //Удаление карточки в столбце
        public void DeleteCard(Card card)
        {
            if (!CheckPressBut())
            {
                MessageBox.Show("Вы не можете редактировать эту доску", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DeleteList();
            DeleteMenuLocalOfGlobal();

            DraftBoard();
        }

        //Удаление менюшки информации в карточке
        public void DeleteInfoCard()
        {
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("InfoCard"))
                    {
                        MainPlane.Children.Remove((Grid)element);
                        break;
                    }
                }
            }
        }

        //Отчистка столбцов, не удаление
        public void ClearColumn()
        {

            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("Column"))
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
                    if (((Grid)element).Name.ToString().Contains("Column"))
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
                    if (((Grid)element).Name.ToString().Contains("Column"))
                    {
                        MainPlane.Children.Remove((Grid)element);
                        break;
                    }
                }
            }
        }

        //Удаление столбца
        public void DeleteColumn(Grid grid)
        {
            if (!CheckPressBut())
            {
                MessageBox.Show("Вы не можете редактировать эту доску", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (UIElement element in grid.Children)
            {
                if (element is Grid)
                {
                    if (((Grid)element).Name.ToString().Contains("Columns"))
                    {
                        MainPlane.Children.Remove((Grid)element);
                        break;
                    }
                }
            }
        }

        //Проверка можно ли нажимать на кнопку
        public bool CheckPressBut()
        {
            Person person = Logic.GetCurrentPerson();

            foreach (int indexBoard in DataBase.Person.GetBoardsOfPerson(person.id))
            {
                if (Logic.GetCurrentBoard().id == indexBoard)
                    return true;
            }
            return false;
        }


        //Обработчики нажатий на доске

        //Замена имени доски на введенную
        private void BoardText_TextChanget(object sender, TextChangedEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if(text.Text != Logic.GetCurrentBoard().name)
            {
                if (!CheckPressBut())
                {
                    MessageBox.Show("Вы не можете редактировать эту доску", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                    DraftBoard() ;
                    return;
                }
            }
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
            if (!CheckPressBut())
            {
                MessageBox.Show("Вы не можете редактировать эту доску", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
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
            ClearColumn();
            DraftBoard();
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
            if (!CheckPressBut())
            {
                MessageBox.Show("Вы не можете редактировать эту доску", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Logic.GetCurrentBoard().userPresents != 0)
            {
                MessageBox.Show("К частной доске нельзя добавить пользователя", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

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
            if (!CheckPressBut())
            {
                MessageBox.Show("Вы не можете редактировать эту доску", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DeleteList();
            ClearColumn();
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

﻿using MaterialDesignThemes.Wpf;
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
        }


        //Отрисовка элементов

        //Отрисовка доски
        public void DraftBoard()
        {
            BoardText.Text = Logic.GetCurrentBoard().name.ToString();
            int IDboard = Logic.GetCurrentBoard().id;
            string[] str = Logic.GetNameColumns(IDboard);
            int a = new Logic().GetIdColumsInBoard(IDboard).Count();
            //Удаление старых столбцов
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
                Border[] borders = new Border[All];
                borders = DrawPlane.DrawBorder(All);
                borders[0].Name = "Border1";
                MainPlane.Children.Add(borders[All - 1]);
                //Выводим рамочку, куда поместим название 
                borders = DrawPlane.DrawBorderBlox(All);
                MainPlane.Children.Add(borders[All-1]);
                TextBlock[] txt = DrawPlane.DrawTextBlock(All);
                txt[0].Text = str[0];
                MainPlane.Children.Add(txt[0]);
            }
            if (All == 2)
            {
                Border[] borders = new Border[All];
                borders = DrawPlane.DrawBorder(All);
                MainPlane.Children.Add(borders[All - 1]);
                MainPlane.Children.Add(borders[All - 2]);
                //Выводи рамочку
                borders = DrawPlane.DrawBorderBlox(All);
                MainPlane.Children.Add(borders[All - 1]);
                MainPlane.Children.Add(borders[All - 2]);

                TextBlock[] txt = DrawPlane.DrawTextBlock(All);
                txt[0].Text = str[0];
                txt[1].Text = str[1];
                MainPlane.Children.Add(txt[0]);
                MainPlane.Children.Add(txt[1]);

            }
            if (All >= 3) /*(Logic.GetIdColInBoard(IDboard).Count == 3)*/
            {
                All = 3;
                Border[] borders = new Border[All];
                borders = DrawPlane.DrawBorder(All);
                MainPlane.Children.Add(borders[All - 1]);
                MainPlane.Children.Add(borders[All - 2]);
                MainPlane.Children.Add(borders[All - 3]);
                //Вывод рамочки
                borders = DrawPlane.DrawBorderBlox(All);
                MainPlane.Children.Add(borders[All - 1]);
                MainPlane.Children.Add(borders[All - 2]);
                MainPlane.Children.Add(borders[All - 3]);
                //отрисовываем текст
                TextBlock[] txt = DrawPlane.DrawTextBlock(All);

                txt[0].Text = str[0];
                txt[1].Text = str[1];
                txt[2].Text = str[2];
                MainPlane.Children.Add(txt[0]);
                MainPlane.Children.Add(txt[1]);
                MainPlane.Children.Add(txt[2]);
            }

            //DraftCards();
        }
        public void DraftCards()
        {
            //Отрисовка всех карточек в столбце
        }


        //Удаление элементов

        //Удаление открывающегося списка
        public void DeleteList()
        {
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is ScrollViewer)
                {
                    if (((ScrollViewer)element).Name.ToString().Contains("BordList"))
                    {
                        MainPlane.Children.Remove((ScrollViewer)element);

                        DraftBoard();
                        return;
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

            //Заменяю в базе данных
            DeleteList();
            DeleteMenuLocalOfGlobal();
            DataBase.Board.ReplaceObject(Logic.GetCurrentBoard().id, newBoard);
            
        }

        //Добавление доски(открытие меню какой тип доски добавить)
        private void ButtonAddBoard_Click(object sender, RoutedEventArgs e)
        {
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
            if (DataBase.Board.GetListBoards().Count() == 1)
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
                        if (new Logic().GetIdCardInColomns(iColumn) != null)
                        {
                            List<int> IdCards = new Logic().GetIdCardInColomns(iColumn);
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
            DataBase.Board.ActivsBoard(DataBase.Board.GetListBoards()[DataBase.Board.GetListBoards().Count - 1].id);
            DataBase.Board.ActivsBoard(DataBase.Board.GetListBoards()[DataBase.Board.GetListBoards().Count-1].id);
            DeleteMenuLocalOfGlobal();
            DeleteList();
            DraftBoard();
        }

        //Открытие списка досок и закрытие
        public void ButtonOpenBoards_Click(object sender, RoutedEventArgs e)
        {
            int flag = 1;

            foreach (UIElement element in MainPlane.Children)
            {
                if (element is ScrollViewer)
                {
                    if (((ScrollViewer)element).Name.ToString().Contains("BordList"))
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
                    if (element is ScrollViewer)
                    {
                        if (((ScrollViewer)element).Name.ToString().Contains("BordList"))
                        {
                            MainPlane.Children.Remove((ScrollViewer)element);
                            break;
                        }
                    }
                }
            } 
        }

        //Добавление столбцов
        private void ButtonAddColumn_Click(object sender, RoutedEventArgs e)
        {


            Column column = new Column(DataBase.Column.MaxID(), Logic.GetCurrentBoard().id, "Столбец " + (new Logic().GetIdColumsInBoard(Logic.GetCurrentBoard().id).Count() + 1).ToString());
            DataBase.Column.AppObject(column);

            DeleteList();
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

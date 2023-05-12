﻿using MaterialDesignThemes.Wpf;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

 namespace TaskBoard
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if(DataBase.Board.GetListBoards() == null)
            {
                Board board = new Board(Logic.GetBoardNullName());
                board.stateActive = 1;
                DataBase.Board.AppObject(board);
            }
            DataBase.Board.ActivsBoard(DataBase.Board.GetListBoards()[0].id);
            InitializeComponent();
            
            //DraftBoard();





            //BoardList.DisplayMemberPath = "name";

            // DataBase DB = new DataBase();

            //Пока косячно, надо переделать свои старые функции
            int IDboard = 2;
            Logic l = new Logic();
            int a = l.GetIdColumsInBoard(IDboard).Count();
            DraftColumns(a);


            //DisplayAllColomn();
            Border[] borders2 = DrawPlane.DrawCard(3);
            MainPlane.Children.Add(borders2[0]);
            MainPlane.Children.Add(borders2[1]);
            MainPlane.Children.Add(borders2[2]);
            //void DisplayAllColomn()
            //{

            //}
        }


        //Отрисовка доски
        public void DraftBoard()
        {
            BoardText.Text = Logic.GetCurrentBoard().name.ToString();
            //DraftColumns();
        }
        //отрисовывает определенное количество карточек
        public void DraftColumns(int All)
        { 
            if (All == 0)
            {
                //Ничего
            }
        
            if (All == 1)
            {
                Border[] borders = new Border[All];
                borders = DrawPlane.DrawBorder(All);
                MainPlane.Children.Add(borders[All-1]);
            }
            if (All == 2)
            {
                Border[] borders = new Border[All];
                borders = DrawPlane.DrawBorder(All);
                MainPlane.Children.Add(borders[All-1]);
                MainPlane.Children.Add(borders[All-2]);
            }
            if(All>=3) /*(Logic.GetIdColInBoard(IDboard).Count == 3)*/
            {
                Border[] borders = new Border[All];
                borders = DrawPlane.DrawBorder(All);
                MainPlane.Children.Add(borders[All - 1]);
                MainPlane.Children.Add(borders[All - 2]);
                MainPlane.Children.Add(borders[All - 3]);
            }

            //DraftCards();
        }
        public void DraftCards()
        {
            //Отрисовка всех карточек в столбце
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
            DataBase.Board.ReplaceObject(Logic.GetCurrentBoard().id, newBoard);
        }

        //Добавление доски
        private void ButtonAddBoard_Click(object sender, RoutedEventArgs e)
        {
            Board board = new Board(Logic.GetBoardNullName());
            
            DataBase.Board.AppObject(board);
            DataBase.Board.ActivsBoard(board.id);

            DeleteList();
            DraftBoard();
        }

        //Удаление доски со всеми ее элементами
        private void ButtonDeleteBoard_Click(object sender, RoutedEventArgs e)
        {
            if(DataBase.Board.GetListBoards().Count() == 1)
            {
               MessageBox.Show("Нельзя удалить единственную доску");
                return;
            }
            int idBoard = Logic.GetCurrentBoard().id;
            //Удаляю доску
            DataBase.Board.DeleteByID(idBoard);

            //Получаю все столбцы этой доски      
            if(new Logic().GetIdColumsInBoard(idBoard) != null)
            {
                List<int> IdColumns = new Logic().GetIdColumsInBoard(idBoard);
                if(DataBase.Column.GetListСolumns() != null)
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
            DataBase.Board.ActivsBoard(DataBase.Board.GetListBoards()[DataBase.Board.GetListBoards().Count-1].id);
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
                MainPlane.Children.Add(DrawPlane.FonButtonBoard());
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
    }
}

using MaterialDesignThemes.Wpf;
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
            
            DraftBoard();
            

           
            
            
            //BoardList.DisplayMemberPath = "name";

            // DataBase DB = new DataBase();

            //Пока косячно, надо переделать свои старые функции
            Border[] borders = new Border[3];
            borders = DrawPlane.DrawBorder(3);
            MainPlane.Children.Add(borders[0]);
            MainPlane.Children.Add(borders[1]);
            MainPlane.Children.Add(borders[2]);


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
            DraftColumns();
        }
        public void DraftColumns()
        {
            //Отрисовка всех столбцов и карточек
            DraftCards();
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
            DataBase.Board.ActivsBoard(DataBase.Board.GetListBoards()[0].id);
            DraftBoard();


        }

        //Открытие списка досок
        public void ButtonOpenBoards_Click(object sender, RoutedEventArgs e)
        {
            List<Board> boards = DataBase.Board.GetListBoards().ToList();
            List<Button> buttons = new List<Button>();
            List<Border> bords = new List<Border>();
            int flag = 0;
            
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Button)
                {
                    if (((Button)element).Name.ToString().Contains("Mini"))
                    {
                        buttons.Add((Button)element);
                        flag = 1;
                    }
                    
                }
            }
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Border)
                {
                    if (((Border)element).Name.ToString().Contains("BordList"))
                    {
                        bords.Add((Border)element);

                    }

                }
            }

            //Удаление
            foreach (Border border in bords)
            {
                MainPlane.Children.Remove(border);
            }

            foreach (Button but in buttons)
            {
                MainPlane.Children.Remove(but);
            }

            
            if (flag == 0)
            {
                MainPlane.Children.Add(DrawPlane.FonButtonBoard());
                int step = 0;
               // MainPlane.Children.Add(DrawPlane.FonButtonBoard());
                foreach (Board board1 in boards)
                {
                    MainPlane.Children.Add(DrawPlane.ButtonBoard(step, board1));
                    step += 70;
                }
            }
        }

        public void DeleteList()
        {
            List<Button> buttons = new List<Button>();
            List<Border> bords = new List<Border>();
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Button)
                {
                    if (((Button)element).Name.ToString().Contains("Mini"))
                    {
                        buttons.Add((Button)element);
                    }

                }
            }
            foreach (UIElement element in MainPlane.Children)
            {
                if (element is Border)
                {
                    if (((Border)element).Name.ToString().Contains("BordList"))
                    {
                        bords.Add((Border)element);

                    }

                }
            }
            foreach (Border border in bords)
            {
                MainPlane.Children.Remove(border);
            }
            foreach (Button but in buttons)
            {
                MainPlane.Children.Remove(but);
            }
            DraftBoard();
        }
    }
}

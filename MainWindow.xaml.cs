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

namespace TaskBoard
{
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DraftBoard();
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


        public void DraftBoard()
        {
            BoardText.Text = Logic.GetCurrentBoard().name.ToString();
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
    }
}

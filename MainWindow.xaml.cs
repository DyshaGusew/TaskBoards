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

            DataBase DB = new DataBase();
            DB.Board.AppObject(new Board());
            DB.Card.MaxID();
            DB.Column.AppObject(new Column(15));
            DB.Column.AssignmentIDBoard(6, 866);


                BoardNamePanel.Text = Convert.ToString(DB.Board.GetObjOfId(board.id).id);


            

            
            // Console.WriteLine(DB.GetIdRef(2, "col"));

            //Эту хрень используйте для вывода
            
        }
    }
}

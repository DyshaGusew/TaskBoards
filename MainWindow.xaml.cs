using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    //
    public partial class MainWindow : Window
    {
        DataBase DB;
        public MainWindow()
        {
           
            InitializeComponent();


            Column column1 = DB.Column.GetObjOfId(1);
            column1.name = "Name";
            DB.Column.ReplaceObject(1, column1);

            DB.Column.AssignmentIDBoard(column1.id, 48);

            Board board= new Board();
            board.name = "gggg";
            DB.Board.AppObject(board);
            
           // Console.WriteLine(DB.GetIdRef(2, "col"));

            //Эту хрень используйте для вывода
            txtOutput.Text = Convert.ToString(DB.Column.GetIdRef(2));
        }
    }
}

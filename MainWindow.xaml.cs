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
        public MainWindow()
        {
            InitializeComponent();

            //Создаю объекты и задаю им значение
            Card card = new Card(10);
            card.color = "green";
            card.text = "dsfsdfdddddddddddddddddddddd";

            Board board = new Board();
            board.name = "Доска номер 1";

            Column column = new Column();
            column.idBoardRef = 1;

            //Добавляю в БД
            DataBase DB = new DataBase();
            //DB.AppObject(column);

            Column column1 = (Column)DB.GetObjOfId(2, "col");
            column1.name = "Name";
            
            DB.AssignmentIDBoardColumn(column1.id, 45);
            DB.ReplaceObject(2, column1);
            Console.WriteLine(DB.GetIdRef(2, "col"));

            //Эту хрень используйте для вывода
            txtOutput.Text = Convert.ToString(DB.GetIdRef(2, "col"));
        }
    }
}

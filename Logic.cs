using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




internal class Logic
{
    DataBase DB = new DataBase();
    public Board GetCurrentBoard()
    {
        List<Board> boards = DB.Board.GetListBoards();
        foreach (Board board in boards) 
        { 
          if(board.stateActive != 0) 
            { 
                return board;
            }
        }
        Console.WriteLine("ошибка, нет активной доски");
        return null;
        
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface ILogic
{
    int[] GetIdColumsInBoard(int id);

    Board GetCurrentBoard();

    int[] GetIdCardInColomns(int id);
}


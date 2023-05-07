﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




public class Logic
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
    //ID of the columns contained in the boards - Айди столбцов содержащихся в досках
    public static int[] GetIdColumsInBoard(int id)
    {
        StreamReader rd = new StreamReader("../../DataBases\\Columns.csv");
        int[] Arr = Array.Empty<int>();
        //счеткик
        int i = 0;
        //Считываем базу данных
        while (!rd.EndOfStream)//Листаем до конца
        {
            string line = rd.ReadLine();
            string[] parms = line.Split(new char[] { ';' });
            if (id == Convert.ToInt32(parms[1]))
            {
                Arr[i] = Convert.ToInt32(parms[1]);
                i++;
            }
        }
        rd.Close();
        return Arr;
    }
    //ID of the cards contained in the columns - Айди карточек содержащихся в столбцах
    public static int[] GetIdCardInColomns(int id)
    {
        StreamReader rd = new StreamReader("../../DataBases\\Cards.csv");
        int[] Arr = Array.Empty<int>();
        //счеткик
        int i = 0;
        //Считываем базу данных
        while (!rd.EndOfStream)//Листаем до конца
        {
            string line = rd.ReadLine();
            string[] parms = line.Split(new char[] { ';' });
            if (id == Convert.ToInt32(parms[1]))
            {
                Arr[i] = Convert.ToInt32(parms[1]);
                i++;
            }
        }
        rd.Close();
        return Arr;
    }
}
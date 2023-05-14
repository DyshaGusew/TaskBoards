﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

public class Logic : ILogic
{
    //Проверка на текущую доску
    public static Board GetCurrentBoard()
    {
        List<Board> boards = DataBase.Board.GetListBoards();
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

    //Получение имени доски при создании
    public static string GetBoardNullName() 
    {
        if(DataBase.Board.GetListBoards() == null)
        {
            return "Доска номер 1";
        }
        string text = "Доска номер " + (DataBase.Board.GetListBoards().Count()+1).ToString();
        return text; 
    }

    //Поправить косяк со считыванием элементов
    //ID of the columns contained in the boards - Айди столбцов содержащихся в досках
    public List<int> GetIdColumsInBoard(int id)
    {
        
        List<int> Arr = new List<int>();
        //счеткик
        int count = 0;
        if(DataBase.Column.GetListСolumns() != null)
        {
            foreach (Column column in DataBase.Column.GetListСolumns())
            {
                if (column.idBoardRef == id)
                {
                    Arr.Add(column.id);
                    count++;
                }
            }
        }
        


            return Arr;

    }
    //ID of the cards contained in the columns - Айди карточек содержащихся в столбцах
    public List<int> GetIdCardInColomns(int id)
    {

        List<int> Arr = new List<int>();
        //счеткик
        int count = 0;
        //Считываем базу данных
        foreach (Card card in DataBase.Card.GetListСards())
        {
            if (card.idColumnsRef == id)
            {
                Arr.Add(card.id);
                count++;
            }
        }

        if (count != 0)
        {
            return Arr;
        }
        return null;
    }

    public static int GetCountColumn(int id)
    {
        StreamReader rd = new StreamReader("../../DataBases\\Columns.csv");
        int i = 0;
        while (!rd.EndOfStream)//Листаем до конца
        {
            string line = rd.ReadLine();
            string[] parms = line.Split(new char[] { ';' });
            if (id == Convert.ToInt32(parms[1]))
            {
                i++;
            }
        }
        rd.Close();
        return i;
   
    }
    public static string[] GetNameColumns(int id)
    {
        StreamReader rd = new StreamReader("../../DataBases\\Columns.csv");
        int i = 0;
        while (!rd.EndOfStream)//Листаем до конца
        {
            string line = rd.ReadLine();
            string[] parms = line.Split(new char[] { ';' });
            if (id == Convert.ToInt32(parms[1]))
            {
                i++;
            }
        }
        rd.Close();

        rd = new StreamReader("../../DataBases\\Columns.csv");
        string[] str = new string[i];
        i = 0;
        while (!rd.EndOfStream)//Листаем до конца
        {
            string line = rd.ReadLine();
            string[] parms = line.Split(new char[] { ';' });
            if (id == Convert.ToInt32(parms[1]))
            {
                str[i] = parms[2];
                i++;
            }
        }
        rd.Close();
        return str;

    }
}
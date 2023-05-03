using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Data.Common;
using System.Windows.Documents;

public partial class DataBase
{
    static readonly string pathDataBoards = "../../DataBases\\Boards.csv";
    static readonly string pathDataColumns = "../../DataBases\\Columns.csv";
    static readonly string pathDataCards = "../../DataBases\\Cards.csv";

    //Добавление карточки, столбца или же доски в БД(в какую добавлять определяет автоматически)
    public void AppObject(object sentObject)
    {
        //Проверяю на тип объекта и записываю в нужную БД
        if(sentObject is Board)
        {
            Board board = (Board)sentObject;

            //Проверка на наличие имени доски
            string name;
            if(board.name == null)
                name = "null";
            else
                name = board.name;

            StringBuilder scv = new StringBuilder();
            scv.AppendLine(board.id + ";" + name);
            File.AppendAllText(pathDataBoards, scv.ToString());
        }

        else if(sentObject is Column) 
        {
            Column column = (Column)sentObject;

            string name;
            if (column.name == null)
                name = "null";
            else
                name = column.name;

            StringBuilder scv = new StringBuilder();
            scv.AppendLine(column.id + ";" + column.idBoardRef + ";" + name);
            File.AppendAllText(pathDataColumns, scv.ToString());
        }

        else if(sentObject is Card)
        {
            Card card = (Card)sentObject;

            string name;
            string text;

            if (card.name == null)
                name = "null";
            else
                name = card.name;

            if (card.text == null)
                text = "null";
            else
                text = card.text;

            StringBuilder scv = new StringBuilder();
            scv.AppendLine(card.id + ";" + card.idColumnsRef + ";"  + name + ";" + card.color + ";" + card.typeDeskrip + ";" + text);
            File.AppendAllText(pathDataCards, scv.ToString());
        }

        else
        {
            Console.WriteLine("Данный тип нельзя передать в БД");
        }
    }

    //Вычестление максимального id у определенной базы данных
    public int MaxID(string typeBD)
    {
        //Определяю какую бд считывать
        StreamReader rd;
        if (typeBD == "boa")
            rd = new StreamReader(pathDataBoards);

        else if (typeBD == "col")
             rd = new StreamReader(pathDataColumns);

        else if (typeBD == "car")
             rd = new StreamReader(pathDataCards);

        else
        {
            Console.WriteLine("Неправильный формат ввода для базы данных");
            rd = null;
        }

        //Сам алгоритм нахождения максимального id
        int maxId = 0;
        while (!rd.EndOfStream)           //Пока не конец файла проверяю
        {
            string line = rd.ReadLine();
            string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 


            if (Convert.ToInt32(parms[0]) > maxId)          //Если ID равен указанному, то возвращаю пользователя
            {
                maxId = Convert.ToInt32(parms[0]);
            }
        }
        rd.Close();
        return maxId+1;
    }

    //Возвращаю объект с нужным id из указанной БД
    public object GetObjOfId(int id, string typeBD)
    {
        Object outObj;

        StreamReader rd;
        if (typeBD == "boa")
            rd = new StreamReader(pathDataBoards);

        else if (typeBD == "col")
            rd = new StreamReader(pathDataColumns);

        else if (typeBD == "car")
            rd = new StreamReader(pathDataCards);

        else
            rd = null;


        while (!rd.EndOfStream)           //Пока не конец файла проверяю
        {
            string line = rd.ReadLine();
            string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

            if (id == Convert.ToInt32(parms[0]))          //Если ID равен указанному, то возвращаю пользователя
            {
                switch (typeBD)
                {
                    case "bor":
                        Board board = new Board(Convert.ToInt32(parms[0]), parms[1]);
                        outObj = board;
                        break;
                    case "col":
                        Column column = new Column(Convert.ToInt32(parms[0]), Convert.ToInt32(parms[1]), parms[2]);
                        outObj = column;
                        break;
                    case "car":
                        Card card = new Card(Convert.ToInt32(parms[0]), Convert.ToInt32(parms[1]), parms[2], parms[3], Convert.ToInt32(parms[4]), parms[5]);
                        outObj = card;
                        break;

                    default: rd = null; outObj = null; break;
                }
                rd.Close();
                return outObj;
            }
        }
        Console.WriteLine($"Объект c id {id} не найден");
        return null;
    }

    //Замена одного столбика на другой
    public void ReplaceColumns(Column column, Column columnNew)
    {
        //УДАЛЕНИЕ СТАРОГО
        AppObject(columnNew);  //Добавление нового
    }

    //Замена одной доски на другую
    public void ReplaceBoard(Board board, Board boardNew)
    {
        //УДАЛЕНИЕ СТАРОГО
        AppObject(boardNew); //Добавление нового
    }

    //Замена одной карточки на другую
    public void ReplaceCard(Card card, Card cardNew)
    {
        //УДАЛЕНИЕ СТАРОГО

        AppObject(cardNew);  //Добавление нового
    }

}
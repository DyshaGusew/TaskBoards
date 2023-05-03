using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Data.Common;
using System.Windows.Documents;
using System.Runtime.InteropServices.ComTypes;

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

    //Удаление объекта в нужной БД
    public void DeleteByID(int id, string typeBD)
    {
        string NameBase;//Имя базы данных для дальнейшего удобства
        //Определяем базу данных
        StreamReader rd;
        if (typeBD == "boa")
        {
            rd = new StreamReader(pathDataBoards);
            NameBase = "../../DataBases\\Boards.csv";
        }

        else if (typeBD == "col")
        {
            rd = new StreamReader(pathDataColumns);
            NameBase = "../../DataBases\\Columns.csv";
        }

        else if (typeBD == "car")
        {
            rd = new StreamReader(pathDataCards);
            NameBase = "../../DataBases\\Cards.csv";
        }
        else
        {
            Console.WriteLine("Неправильный формат ввода для базы данных");
            rd = null;
            NameBase = null;
        }
        


        StreamWriter TimeBox = new StreamWriter("../../DataBases\\BoxBase.csv");//Временный файл для записи
        //Считываем базу данных
        while (!rd.EndOfStream)//Листаем до конца
        {
            string line = rd.ReadLine();
            string[] parms = line.Split(new char[] { ';' });

            if (Convert.ToInt32(parms[0]) != id)
            {
                TimeBox.WriteLine(line);
            }
        }
        rd.Close();
        TimeBox.Close();
        File.Delete(NameBase);//Удаляем оригинал
        File.Move("../../DataBases\\BoxBase.csv", NameBase);//Переименовываем новый файл без нужного айди
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
        rd.Close();
        Console.WriteLine($"Объект c id {id} не найден");
        return null;
    }

    //Возвращает ид объекта на который ссылается указанный объект
    public int GetIdRef(int id, string typeBD)
    {
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
                rd.Close();
                return Convert.ToInt32(parms[1]);
            }
        }
        rd.Close();
        Console.WriteLine($"Объект c id {id} не найден");
        return 0;
    }

    //Замена одного объекта на другой с сохранением id
    public void ReplaceObject(int objectId, object objectNew)
    {
        if (objectNew is Board)
        {
            Board board = (Board)objectNew;
            board.id = objectId;
            DeleteByID(objectId, "boa");
            AppObject(board);
        }

        else if (objectNew is Column)
        {
            Column column = (Column)objectNew;
            column.id = objectId;
            DeleteByID(objectId, "col");
            AppObject(column);
        } 

        else if (objectNew is Card)
        {
            Card card = (Card)objectNew;
            card.id = objectId;
            DeleteByID(objectId, "car");
            AppObject(card);
        }

        else
            Console.WriteLine("Объект неподходящего типа");
    }

    //добавление id доски в колонну
    public void AssignmentIDBoardColumn(int idColumn, int idBoardRef)  //Передаю id колонны в которую надо записать доску и id доски, в которой она должна находиться 
    {
        //Считываю базу пользователей
        StreamReader rd = new StreamReader(pathDataColumns);

        while (!rd.EndOfStream)           //Пока не конец файла проверяю
        {
            string line = rd.ReadLine();
            string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

            if (idColumn == Convert.ToInt32(parms[0]))          //Если ID равен указанному, до добавляю
            {
                //Получаем нужны столбец, создаем новый, новому добавляем ссылаемую доску
                Column columnNew = (Column)GetObjOfId(idColumn, "col");
                columnNew.idBoardRef = idBoardRef;
                rd.Close();
                //Меняем старый столбец на новый
                ReplaceObject(idColumn, columnNew);
                return;
            }
        }
        
    }
   
    //добавление id столбца в карточку
    public void AssignmentIDColumnCard(int idCard, int idColumnRef)
    {
        //Считываю базу пользователей
        StreamReader rd = new StreamReader(pathDataCards);

        while (!rd.EndOfStream)           //Пока не конец файла проверяю
        {
            string line = rd.ReadLine();
            string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

            if (idCard == Convert.ToInt32(parms[0]))          //Если ID равен указанному, до добавляю
            {
                //Получаем нужны столбец, создаем новый, новому добавляем ссылаемую доску
                Card cardNew = (Card)GetObjOfId(idCard, "col");
                cardNew.idColumnsRef = idColumnRef;
                rd.Close();

                //Меняем старый столбец на новый
                ReplaceObject(idCard, cardNew);
                return;
            }
        }
       

    }   
}
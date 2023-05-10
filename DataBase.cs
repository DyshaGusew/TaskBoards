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
using static System.Net.Mime.MediaTypeNames;
using static DataBase;
using MaterialDesignThemes.Wpf;
using System.Xml.Linq;

public partial class DataBase
{
    static readonly string pathDataBoards = "../../DataBases\\Boards.csv";
    static readonly string pathDataColumns = "../../DataBases\\Columns.csv";
    static readonly string pathDataCards = "../../DataBases\\Cards.csv";

    public static BoardsBD Board = new BoardsBD();
    public static ColumnsBD Column = new ColumnsBD();
    public static CardsBD Card = new CardsBD();


    public static void AppObject(Objeсts object_, string path)
    {
        //Проверка на наличие имени доски
        string name;
        if (object_.name == null)
            name = "null";
        else
            name = object_.name;

        StringBuilder scv = new StringBuilder();

        if(object_ is Board)
        {
            Board board = (Board)object_;
            scv.AppendLine($"{board.id};{name};{board.stateActive}");
        }

        else if(object_ is Column)
        {
            Column column = (Column)object_;
            scv.AppendLine($"{column.id};{column.idBoardRef};{name}");
        }

        else if(object_ is Card)
        {
            Card card = (Card)object_;
            string text;
            if (card.text == null)
                text = "null";
            else
                text = card.text;

            scv.AppendLine($"{card.id};{card.idColumnsRef};{name};{card.color};{card.typeDeskrip};{text}");
        }

        else
        {
            Console.WriteLine("Неподходящий тип");
            return;
        }
        
        File.AppendAllText(path, scv.ToString());
    }

    public static void DeleteByID(int id, string path)
    {
        StreamReader rd = new StreamReader(path);

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
        File.Delete(path);//Удаляем оригинал
        File.Move("../../DataBases\\BoxBase.csv", path);//Переименовываем новый файл без нужного айди
    }

    public static int MaxID(string path)
    {
        //Определяю какую бд считывать
        StreamReader rd = new StreamReader(path);

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
        return maxId + 1;
    }

    public static Objeсts GetObjOfId(int id, string path)
    {
        StreamReader rd = new StreamReader(path);

        while (!rd.EndOfStream)           //Пока не конец файла проверяю
        {
            string line = rd.ReadLine();
            string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 
            

            if (id == Convert.ToInt32(parms[0]))          //Если ID равен указанному, то возвращаю пользователя
            {
                rd.Close();
                if (path == pathDataBoards)
                {
                    Board board = new Board(Convert.ToInt32(parms[0]), parms[1], Convert.ToInt32(parms[2]));
                    return board;
                }
                else if(path == pathDataColumns)
                {
                    Column column = new Column(Convert.ToInt32(parms[0]), Convert.ToInt32(parms[1]), parms[2]);
                    return column;
                }
                else if(path == pathDataCards)
                {
                    Card card = new Card(Convert.ToInt32(parms[0]), Convert.ToInt32(parms[1]), parms[2], parms[3], Convert.ToInt32(parms[4]), parms[5]);
                    return card;
                }      
            } 
        }
        return null;
    }

    //Замена одного объекта на другой с сохранением id
    public static void ReplaceObject(int objectId, Objeсts objectNew, string path)
    {
        Objeсts obj = objectNew;
        obj.id = objectId; //id сохраняю
        DeleteByID(objectId, path);
        AppObject(obj, path);
    }

    public static List<Objeсts> GetListObjects(string path)
    {
        List<Objeсts> objeсts = new List<Objeсts>();

        StreamReader rd = new StreamReader(path);

        while (!rd.EndOfStream)           //Пока не конец файла проверяю
        {
            string line = rd.ReadLine();
            string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 
            if (GetObjOfId(Convert.ToInt32(parms[0]), path) is Board)
            {
                Board board = (Board)GetObjOfId(Convert.ToInt32(parms[0]), pathDataBoards);
                objeсts.Add(board);
            }
            else if (GetObjOfId(Convert.ToInt32(parms[0]), path) is Column)
            {
                Column column = (Column)GetObjOfId(Convert.ToInt32(parms[0]), pathDataColumns);
                objeсts.Add(column);
            }
            else if (GetObjOfId(Convert.ToInt32(parms[0]), path) is Card)
            {
                Card card = (Card)GetObjOfId(Convert.ToInt32(parms[0]), pathDataCards);
                objeсts.Add(card);
            }
        }
        rd.Close();
        return (objeсts);
    }


    public class BoardsBD
    {
        //Добавляю доску в базу данных
        public void AppObject(Board board)
        {
            DataBase.AppObject(board, pathDataBoards);
        }

        //Удаляю объект по id
        public void DeleteByID(int id)
        {
            DataBase.DeleteByID(id, pathDataBoards);
        }

        //Вычестление максимального id у определенной базы данных
        public int MaxID()
        {
           return DataBase.MaxID(pathDataBoards);
        }

        //Возвращаю объект с нужным id из указанной БД
        public Board GetObjOfId(int id)
        {
           return (Board)DataBase.GetObjOfId(id, pathDataBoards);
        }
    
        //Замена одного объекта на другой с сохранением id
        public void ReplaceObject(int objectId, Board objectNew)
        {
            DataBase.ReplaceObject(objectId, objectNew, pathDataBoards);
        }

        //Поучение массива всех досок
        public List<Board> GetListBoards()
        {
            List <Objeсts> objeсts = DataBase.GetListObjects(pathDataBoards);
            List<Board> boards  = new List<Board>();
            foreach(Objeсts board_ in objeсts)
            {
                boards.Add((Board)board_);
            }
            return boards;
        }

        //Активирую указанную доску
        public void ActivsBoard(int id)
        {
            Board board = GetObjOfId(id);

            List<Board> boards = GetListBoards();

            //Убираю активное состояние у другой и ставлю указанной
            foreach(Board board_ in boards)
            {
                if(board_.stateActive == 1)
                {
                    board_.stateActive = 0;
                    ReplaceObject(board_.id, board_);
                }
            }
            board.stateActive = 1;

            //Заменяю старую(временную) доску на новую
            ReplaceObject(id, board);
        }

    }

    public class ColumnsBD
    {
        //Добавля. доску в базу данных
        public void AppObject(Column column)
        {
            //Условие нужно при нажатии
            //if( new Logic().GetIdColumsInBoard(new Logic().GetCurrentBoard().id).Length >= 9)
           // {
                //Делать так нельзя, тк больше 9 запрещено
            //}
            DataBase.AppObject(column, pathDataColumns);
        }

        //Удаляю объект по id
        public void DeleteByID(int id)
        {
            DataBase.DeleteByID(id, pathDataColumns);
        }

        //Вычестление максимального id у определенной базы данных
        public int MaxID()
        {
            return DataBase.MaxID(pathDataColumns);
        }

        //Возвращаю объект с нужным id из указанной БД
        public Column GetObjOfId(int id)
        {
            return (Column)DataBase.GetObjOfId(id, pathDataColumns);
        }

        //Возвращает ид объекта на который ссылается указанный объект
        public int GetIdRef(int id)
        {
            StreamReader rd = new StreamReader(pathDataColumns);

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
        public void ReplaceObject(int objectId, Column objectNew)
        {
            DataBase.ReplaceObject(objectId, objectNew, pathDataColumns);
        }

        //Поучение массива всех столбцов
        public List<Column> GetListСolumns()
        {
            List<Objeсts> objeсts = DataBase.GetListObjects(pathDataColumns);
            List<Column> column = new List<Column>();
            foreach (Objeсts column_ in objeсts)
            {
                column.Add((Column)column_);
            }
            return column;
        }

        //добавление id доски в колонну
        public void AssignmentIDBoard(int idColumn, int idBoardRef)  //Передаю id колонны в которую надо записать доску и id доски, в которой она должна находиться 
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
                    rd.Close();
                    Column columnNew = (Column)DataBase.GetObjOfId(Convert.ToInt32(parms[0]), pathDataColumns);
                    columnNew.idBoardRef = idBoardRef;
                    
                    //Меняем старый столбец на новый
                    ReplaceObject(idColumn, columnNew);
                    return;
                }
            }
            rd.Close ();
            
        }
    }

    public class CardsBD
    {
        //Добавля. доску в базу данных
        public void AppObject(Card card)
        {
            DataBase.AppObject(card, pathDataCards);     
        }

        //Удаляю объект по id
        public void DeleteByID(int id)
        {
            DataBase.DeleteByID(id, pathDataCards);
        }

        //Вычестление максимального id у определенной базы данных
        public int MaxID()
        {
            return DataBase.MaxID(pathDataCards);
        }

        //Возвращаю объект с нужным id из указанной БД
        public Card GetObjOfId(int id)
        {
            return (Card)DataBase.GetObjOfId(id, pathDataCards);
        }

        //Возвращает ид объекта на который ссылается указанный объект
        public int GetIdRef(int id)
        {
            StreamReader rd = new StreamReader(pathDataCards);

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
        public void ReplaceObject(int objectId, Card objectNew)
        {
            DataBase.ReplaceObject(objectId, objectNew, pathDataCards);
        }

        //Получение массива карточек
        public List<Card> GetListСards()
        {
            List<Card> cards = new List<Card>();
            List<Objeсts> objeсts = DataBase.GetListObjects(pathDataCards);

            foreach (Objeсts card_ in objeсts)
            {
                cards.Add((Card)card_);
            }
            return cards;
        }

        //Добавление колонный в карточку
        public void AssignmentIDColumn(int idCard, int idColumnRef)
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
                    Card cardNew = (Card)GetObjOfId(idCard);
                    cardNew.idColumnsRef = idColumnRef;
                    rd.Close();

                    //Меняем старый столбец на новый
                    ReplaceObject(idCard, cardNew);
                    return;
                }
            }
            rd.Close();
        }
    }  
}
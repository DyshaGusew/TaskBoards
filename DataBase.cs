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

public partial class DataBase
{
    public BoardsBD Board = new BoardsBD();
    public ColumnsBD Column= new ColumnsBD();
    public CardsBD Card = new CardsBD();
    
    public class BoardsBD
    {
        static readonly string pathDataBoards = "../../DataBases\\Boards.csv";

        //Добавля. доску в базу данных
        public void AppObject(Board board)
        {
            //Проверка на наличие имени доски
            string name;
            if (board.name == null)
                name = "null";
            else
                name = board.name;

            StringBuilder scv = new StringBuilder();
            scv.AppendLine($"{board.id};{name};{board.stateActive}");
            File.AppendAllText(pathDataBoards, scv.ToString());
        }

        //Удаляю объект по id
        public void DeleteByID(int id)
        {
            string NameBase;//Имя базы данных для дальнейшего удобства
                            //Определяем базу данных
            StreamReader rd;
            rd = new StreamReader(pathDataBoards);
            NameBase = "../../DataBases\\Boards.csv";

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
        public int MaxID()
        {
            //Определяю какую бд считывать
            StreamReader rd = new StreamReader(pathDataBoards);

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

        //Возвращаю объект с нужным id из указанной БД
        public Board GetObjOfId(int id)
        {
            StreamReader rd = new StreamReader(pathDataBoards);

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                if (id == Convert.ToInt32(parms[0]))          //Если ID равен указанному, то возвращаю пользователя
                {
                    Board board = new Board(Convert.ToInt32(parms[0]), parms[1], Convert.ToInt32(parms[2]));
                    rd.Close();
                    return board;
                }   
            }
            rd.Close();
            Console.WriteLine($"Объект c id {id} не найден");
            return null;
        }

        //Замена одного объекта на другой с сохранением id
        public void ReplaceObject(int objectId, Board objectNew)
        {
            Board board = objectNew;
            board.id = objectId; //id сохраняю
            DeleteByID(objectId);
            AppObject(board);
        }

        //Поучение массива всех досок
        public List<Board> GetListBoards()
        {
            List<Board> boards = new List<Board>();

            StreamReader rd = new StreamReader(pathDataBoards);

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                Board board = new Board(Convert.ToInt32(parms[0]), parms[1], Convert.ToInt32(parms[2]));
                boards.Add(board);
            }
            rd.Close();
            return (boards);
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
        static readonly string pathDataColumns = "../../DataBases\\Columns.csv";

        //Добавля. доску в базу данных
        public void AppObject(Column column)
        {
            //Проверка на наличие имени доски
            string name;
            if (column.name == null)
                name = "null";
            else
                name = column.name;

            StringBuilder scv = new StringBuilder();
            scv.AppendLine($"{column.id};{column.idBoardRef};{name}");
            File.AppendAllText(pathDataColumns, scv.ToString());
        }

        //Удаляю объект по id
        public void DeleteByID(int id)
        {
            string NameBase;//Имя базы данных для дальнейшего удобства
                            //Определяем базу данных
            StreamReader rd;
            rd = new StreamReader(pathDataColumns);
            NameBase = "../../DataBases\\Columns.csv";

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
        public int MaxID()
        {
            //Определяю какую бд считывать
            StreamReader rd = new StreamReader(pathDataColumns);

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

        //Возвращаю объект с нужным id из указанной БД
        public Column GetObjOfId(int id)
        {
            StreamReader rd = new StreamReader(pathDataColumns);

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                if (id == Convert.ToInt32(parms[0]))          //Если ID равен указанному, то возвращаю пользователя
                {
                    Column column = new Column(Convert.ToInt32(parms[0]), Convert.ToInt32(parms[1]), parms[2]);
                    rd.Close();
                    return column;
                }
            }
            rd.Close();
            Console.WriteLine($"Объект c id {id} не найден");
            return null;
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
            Column column = objectNew;
            column.id = objectId; //id сохраняю
            DeleteByID(objectId);
            AppObject(column);
        }

        //Поучение массива всех столбцов
        public List<Column> GetListСolumns()
        {
            List<Column> columns = new List<Column>();

            StreamReader rd = new StreamReader(pathDataColumns);

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                Column column = new Column(Convert.ToInt32(parms[0]), Convert.ToInt32(parms[1]), parms[2]);
                columns.Add(column);
            }
            rd.Close();
            return (columns);
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
                    Column columnNew = (Column)GetObjOfId(idColumn);
                    columnNew.idBoardRef = idBoardRef;
                    rd.Close();
                    //Меняем старый столбец на новый
                    ReplaceObject(idColumn, columnNew);
                    return;
                }
            }
        }
    }

    public class CardsBD
    {
        static readonly string pathDataCards = "../../DataBases\\Cards.csv";

        //Добавля. доску в базу данных
        public void AppObject(Card card)
        {
            //Проверка на наличие имени и текста карточи
            string name, text;
            if (card.name == null)
                name = "null";
            else
                name = card.name;

            if (card.text == null)
                text = "null";
            else
                text = card.text;

            StringBuilder scv = new StringBuilder();
            scv.AppendLine($"{card.id};{card.idColumnsRef};{name};{card.color};{card.typeDeskrip};{text}");
            File.AppendAllText(pathDataCards, scv.ToString());  
        }

        //Удаляю объект по id
        public void DeleteByID(int id)
        {
            string NameBase;//Имя базы данных для дальнейшего удобства
                            //Определяем базу данных
            StreamReader rd;
            rd = new StreamReader(pathDataCards);
            NameBase = "../../DataBases\\Cards.csv";

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
        public int MaxID()
        {
            //Определяю какую бд считывать
            StreamReader rd = new StreamReader(pathDataCards);

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

        //Возвращаю объект с нужным id из указанной БД
        public Card GetObjOfId(int id)
        {
            StreamReader rd = new StreamReader(pathDataCards);

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                if (id == Convert.ToInt32(parms[0]))          //Если ID равен указанному, то возвращаю пользователя
                {
                    Card card = new Card(Convert.ToInt32(parms[0]), Convert.ToInt32(parms[1]), parms[2], parms[3], Convert.ToInt32(parms[4]), parms[5]);
                    rd.Close();
                    return card;
                }
            }
            rd.Close();
            Console.WriteLine($"Объект c id {id} не найден");
            return null;
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
            Card card = objectNew;
            card.id = objectId; //id сохраняю
            DeleteByID(objectId);
            AppObject(card);
        }

        //Получение массива карточек
        public List<Card> GetListСards()
        {
            List<Card> cards = new List<Card>();

            StreamReader rd = new StreamReader(pathDataCards);

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                Card card = new Card(Convert.ToInt32(parms[0]), Convert.ToInt32(parms[1]), parms[2], parms[3], Convert.ToInt32(parms[4]), parms[5]);
                cards.Add(card);
            }
            rd.Close();
            return (cards);
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


        }
    }  
}
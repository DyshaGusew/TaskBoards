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
    public static PersonsBD Person = new PersonsBD();


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
            scv.AppendLine($"{board.id};{name};{board.stateActive};{board.userPresents}");
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
                    Board board = new Board(Convert.ToInt32(parms[0]), parms[1], Convert.ToInt32(parms[2]), Convert.ToInt32(parms[3]));
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
        int count = 0;
        while (!rd.EndOfStream)           //Пока не конец файла проверяю
        {
            string line = rd.ReadLine();
            if (!line.Contains(";"))
            {
                rd.Close();
                return null;
            }
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
            count ++;
        }
        rd.Close();
        if (count == 0)
        {
            return null;
        }
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
            if(DataBase.GetListObjects(pathDataBoards) == null)
            {
                return null;
            }
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
            if (DataBase.GetListObjects(pathDataColumns) == null)
            {
                return null;
            }
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

            if (DataBase.GetListObjects(pathDataCards) == null)
            {
                return null;
            }

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

    public class PersonsBD
    {
        static readonly string pathDataPersons = "../../DataBases\\PersonBase.csv"; 
        
        // создает нового пользователя и добавляет его в бд
         public int CreatePerson(int id,string login, string password, int stateActivePerson, string idBoardsRef)
        {

            Person newPerson = new Person(id, login, password, stateActivePerson, idBoardsRef);

            //Проверка на наличие такого же пользователя
            int result;
            switch (CheckPersonRegistration(newPerson))
            {
                case 2:
                    result = 1;
                    break;

                default:   //Добавляет если нет ошибок
                    Person person = new Person();
                    StringBuilder scv = new StringBuilder();
                    scv.AppendLine($"{person.id};{login};{password};{person.stateActivePerson};{person.idBoardsRef}");
                    File.AppendAllText(pathDataPersons, scv.ToString());
                    result = 0;
                    break;
            }
            return result;
        }

        //добавляет сущестыующего пользователя в бд
        public void AppPerson(Person person)
        {
            //Проверка на наличие имени доски
            string login;
            if (person.login == null)
                login = "null";
            else
                login = person.login;

            StringBuilder scv = new StringBuilder();
            scv.AppendLine($"{person.id};{login};{person.password};{person.stateActivePerson},{person.idBoardsRef}");
            File.AppendAllText(pathDataPersons, scv.ToString());
        }

        //Удаляю пользователя по id
        public void DeletePersonByID(int id)
        {
            StreamReader rd = new StreamReader(pathDataPersons);
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
            File.Delete(pathDataPersons);//Удаляем оригинал
            File.Move("../../DataBases\\BoxBase.csv", pathDataPersons);//Переименовываем новый файл без нужного айди
        }

        //Вычестление максимального id у  базы данных пользователя
        public int PersonMaxID()
        {
            
            StreamReader rd = new StreamReader(pathDataPersons);

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

        //Возвращаю пользователя с нужным id 
        public Person GetPersonOfId(int id)
        {
            StreamReader rd = new StreamReader(pathDataPersons);

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                if (id == Convert.ToInt32(parms[0]))          //Если ID равен указанному, то возвращаю пользователя
                {
                    Person person = new Person(Convert.ToInt32(parms[0]), parms[1], parms[2], Convert.ToInt32(parms[3]), parms[4]);
                    rd.Close();
                    return person;
                }
            }
            rd.Close();
            Console.WriteLine($"Объект c id {id} не найден");
            return null;
        }

        //Замена одного пользователяя на другого с сохранением id
        public void ReplacePerson(int personId, Person personNew)
        {
            Person person = personNew;
            person.id = personId; //id сохраняю
            DeletePersonByID(personId);
            AppPerson(person);
        }

        //Поучение массива всех пользователей
        public List<Person> GetListPersons()
        {
            List<Person> persons = new List<Person>();

            StreamReader rd = new StreamReader(pathDataPersons);

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                Person person = new Person(Convert.ToInt32(parms[0]), parms[1], parms[2], Convert.ToInt32(parms[3]), parms[4]) ;
                persons.Add(person);
            }
            rd.Close();
            return (persons);
        }

        //Активирую указанного пользователя
        public void ActivsPerson(int id)
        {
            Person person = GetPersonOfId(id);

            List<Person> persons = GetListPersons();

            //Убираю активное состояние у другой и ставлю указанной
            foreach (Person person_ in persons)
            {
                if (person_.stateActivePerson == 1)
                {
                    person_.stateActivePerson = 0;
                    ReplacePerson(person_.id, person_);
                }
            }
            person.stateActivePerson = 1;

            //Заменяю старую(временную) доску на новую
            ReplacePerson(id, person);
        }

        //Проверка на присутствие пользователя со схожими характеристиками
        public int CheckPersonRegistration(Person person)
        {
            //Проверяю на наличие одинаковых свойств
            StreamReader rd = new StreamReader(pathDataPersons);
            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                if (person.id == Convert.ToInt32(parms[0]))          //Если ID есть в бд, то возвращаю предупреждение
                {
                    
                    rd.Close();
                    return 1;
                }

                if (person.login == parms[1])          //Если логин есть в бд, то возвращаю предупреждение
                {
                    
                    rd.Close();
                    return 2;
                }
            }
            //Если нет одинаковых свойств, то возвращаю ноль
            rd.Close();
            return 0;
        }

        //Проверка на присутствие пользователя с указанным логином и паролем
        public Person CheckPersonLogon(string login, string password)
        {
            //Проверяю на наличие одинаковых свойств
            StreamReader rd = new StreamReader(pathDataPersons);
            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                if (login == parms[1] && password == parms[2])          //Если пароль и логин совпадает, то возвращаю пользователя с такими параметрами
                {
                    Person personTrue = GetPersonOfId(Convert.ToInt32(parms[0]));
                    rd.Close();
                    return personTrue;
                }
            }
            //Иначе ебашу null
            rd.Close();
            return null;
        }


        //------Функции замены параметров пользователя
        //Замена логина
        public void ReplaceLoginPerson(int id, string newLogin)
        {
            //Считываю базу пользователей
            StreamReader rd = new StreamReader(pathDataPersons);

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                if (id == Convert.ToInt32(parms[0]))          //Если ID равен указанному, то возвращаю пользователя
                {
                    
                    Person ReplaceLoginPerson = new Person(Convert.ToInt32(parms[0]), newLogin, parms[2], Convert.ToInt32(parms[3]), parms[4]);

                    ReplacePerson(id, ReplaceLoginPerson);
                    return;
                }
            }

        }

        //замена пароля
        public void ReplacePasswordPerson(int id, string newPass)
        {
            //Считываю базу пользователей
            StreamReader rd = new StreamReader(pathDataPersons);

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                if (id == Convert.ToInt32(parms[0]))          //Если ID равен указанному, то возвращаю пользователя
                {
                    Person ReplacePassPerson = new Person(Convert.ToInt32(parms[0]), parms[1], newPass, Convert.ToInt32(parms[3]), parms[4]);
                    
                    rd.Close();
                    ReplacePerson(id, ReplacePassPerson);
                    return;
                }
            }

        }

        //добавление id доски пользователю
        
        public void AssignmentIDBoard(int idPerson, string idBoardsRef)  //Передаю id колонны в которую надо записать доску и id доски, в которой она должна находиться 
        {
            //Считываю базу пользователей
            StreamReader rd = new StreamReader(pathDataPersons);

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                if (idPerson == Convert.ToInt32(parms[0]))          //Если ID равен указанному, до добавляю
                {
                    //Получаем нужны столбец, создаем новый, новому добавляем ссылаемую доску
                    rd.Close();
                    if (parms[4]==null)
                    {
                        Person personNew = new Person(Convert.ToInt32(parms[0]), parms[1], parms[2], Convert.ToInt32(parms[3]), parms[4]);
                        personNew.idBoardsRef = idBoardsRef;
                        ReplacePerson(idPerson, personNew);
                        return;
                    }
                    else
                    {
                       
                        Person personNew = new Person(Convert.ToInt32(parms[0]), parms[1], parms[2], Convert.ToInt32(parms[3]), parms[4]);
                        personNew.idBoardsRef =parms[4]+','+ idBoardsRef;
                        ReplacePerson(idPerson, personNew);
                        return;
                    }
                        
                    
                }
            }
            rd.Close();

        }

        // вывод всех досок принадлежащих пользоватлю
        
        public void GetBoardsOfPerson(int idPerson)  //Передаю id колонны в которую надо записать доску и id доски, в которой она должна находиться 
        {
            //Считываю базу пользователей
            StreamReader rd = new StreamReader(pathDataPersons);

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                if (idPerson == Convert.ToInt32(parms[0]))          //Если ID равен указанному, до добавляю
                {
                    //Получаем нужны столбец, создаем новый, новому добавляем ссылаемую доску
                    rd.Close();
                    Person personNew = new Person(Convert.ToInt32(parms[0]), parms[1], parms[2], Convert.ToInt32(parms[3]), parms[4]);
                    string[] Boards = parms[4].Split(',');
                    for(int i = 0; i < Boards.Length; i++)
                    {
                        Console.WriteLine(Boards[i]);
                    }

                }
            }
            rd.Close();

        }

        //удаление указаной доски
        public void DeleteBoardsOfPerson(int idPerson, string idBoardsRef)  //Передаю id колонны в которую надо записать доску и id доски, в которой она должна находиться 
        {
            //Считываю базу пользователей
            StreamReader rd = new StreamReader(pathDataPersons);
            string[] TimeBox=null;

            while (!rd.EndOfStream)           //Пока не конец файла проверяю
            {
                string line = rd.ReadLine();
                string[] parms = line.Split(new char[] { ';' });   //Разделяю строчку на блоки 

                if (idPerson == Convert.ToInt32(parms[0]))          //Если ID равен указанному, до добавляю
                {
                    //Получаем нужны столбец, создаем новый, новому добавляем ссылаемую доску
                    rd.Close();
                    Person personNew = new Person(Convert.ToInt32(parms[0]), parms[1], parms[2], Convert.ToInt32(parms[3]), parms[4]);
                    string[] Boards = parms[4].Split(',');
                    for(int i = 0; i < Boards.Length; i++)
                    {
                        int result = string.Compare(Boards[i], idBoardsRef);
                        if (result != 0)
                        {
                            TimeBox[i]= Boards[i];
                        }
                    }
                    personNew.idBoardsRef = TimeBox[0];
                    for (int i = 1; i< TimeBox.Length; i++)
                    {
                        personNew.idBoardsRef = personNew.idBoardsRef + ',' + TimeBox[i];
                    }
                    ReplacePerson(idPerson, personNew);
                    return;
                }
            }
            rd.Close();

        }
    }
}
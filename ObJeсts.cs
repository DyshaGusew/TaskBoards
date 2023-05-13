using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

//Класс объектов и его подклассы с конструкторами и методами
public class Objeсts
{
    public int id;
    public string name;

    public Objeсts()
    {
        id = 0;
        name = null;
    }
    public Objeсts(int id)
    {
        this.id = id;
    }
}

public class Board : Objeсts
{
    //Является ли указанная доска текущей
    public int stateActive = 0;
    public int userPresents;
    public Board()
    {
        id = DataBase.Board.MaxID();
        name = null;
        stateActive = 0;
    }
    public Board(string name)
    {
        id = DataBase.Board.MaxID();
        this.name = name;
        stateActive = 0;
    }

    public Board(int id, string name, int stateActive, int userPresents)
    {
        this.userPresents = userPresents;
        this.stateActive = stateActive;
        this.id = id;
        this.name = name;
    }

}

public class Column : Objeсts
{
    public int idBoardRef;
    public Column()
    {
        id = DataBase.Column.MaxID();
        idBoardRef = 0;
        name = null;
    }

    public Column(int idBoardRef) : this()
    {
        this.idBoardRef = idBoardRef;
    }

    public Column(int id, int idBoardRef, string name)
    {
        this.idBoardRef = idBoardRef;
        this.name = name;
        this.id = id;
    }
}

public class Card : Objeсts
{
    public int idColumnsRef;
    public string color;
    public int typeDeskrip;
    public string text;
    public Card()
    {
        id = DataBase.Card.MaxID();
        idColumnsRef = 0;
        name = null;
        color = "white";
        typeDeskrip = 1;
        text = null;
    }

    public Card(int idColumnsRef):this() 
    {
        this.idColumnsRef = idColumnsRef;
    }

    public Card(int id, int idColumnsRef, string name, string color, int typeDeskrip, string text) : this(idColumnsRef)
    {
        this.name = name;
        this.id = id;
        this.color = color;
        this.typeDeskrip = typeDeskrip;
        this.text = text;
    }
}

public class Person
{
    public int id=0;
    public string login;
    public string password;
    public int stateActivePerson = 0;
    public string idBoardsRef = null;
    public Person()
    {
        id = DataBase.Person.PersonMaxID();
        stateActivePerson = 0;

    }
    public Person(int id, string login, string password, int stateActivePerson, string idBoardsRef)
    {
        this.login = login;
        this.password = password;
        this.stateActivePerson = stateActivePerson;
        this.id = id;
        this.idBoardsRef = idBoardsRef;
    }
    
}

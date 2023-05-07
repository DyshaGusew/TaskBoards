﻿using System;
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
    public Board()
    {
        id = new DataBase().Board.MaxID();
        name = null;
        stateActive = 0;
    }

    public Board(int id, string name, int stateActive)
    {
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
        id = new DataBase().Column.MaxID();
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
        id = new DataBase().Card.MaxID();
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

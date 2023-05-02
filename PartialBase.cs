using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

public partial class DataBase
{
    //static readonly string pathDataBoards = "../../DataBases\\Boards.csv";
    //static readonly string pathDataColumns = "../../DataBases\\Columns.csv";
    //static readonly string pathDataCards = "../../DataBases\\Cards.csv";
    public void DeleteID(int id, string typeBD)
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
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoard
{
    internal class DataCheckFunctions
    {
        //Проверка на наличие заглавных
        public static bool CheckUpper(string aboba)
        {
            bool c = false;
            for (int i = 0; i < aboba.Length; i++)
            {
                if (aboba[i] == Char.ToUpper(aboba[i])) { c = true; }
            }
            return c;
        }

        //Проверка на наличие строчных
        public static bool CheckLower(string aboba)
        {
            bool c = false;
            for (int i = 0; i < aboba.Length; i++)
            {
                if (aboba[i] == Char.ToLower(aboba[i])) { c = true; }
            }
            return c;
        }

        //Проверка на наличие цифр
        public static bool CheckFigure(string aboba)
        {
            bool c = false;
            for (int i = 0; i < aboba.Length; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if (aboba[i].ToString() == j.ToString()) { c = true; }
                }
            }
            return c;
        }

        //Проверка на 5 < lenth <= x
        public static bool CheckLenth1(string aboba, int abiba)
        {
            if (aboba.Length >= 5 && aboba.Length <= abiba) { return true; }
            else { return false; }
        }

        //Проверка на lenth == x
        public static bool CheckLenth2(string aboba, int abiba)
        {
            if (aboba.Length == abiba) { return true; }
            else { return false; }
        }
    }
}

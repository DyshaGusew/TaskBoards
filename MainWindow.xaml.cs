using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskBoard
{
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            DataBase DB = new DataBase();

            //Пока косячно, надо переделать свои старые функции
            Border[] borders = new Border[3];
            borders = DrawColumn.Draw(1);
            MainPlane.Children.Add(borders[0]);
            //MainPlane.Children.Add(borders[1]);
            //MainPlane.Children.Add(borders[2]);
            //DisplayAllColomn();


            //void DisplayAllColomn()
            //{

            //}
        }

    }
}

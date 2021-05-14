using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Shopping_List_2
{
    public class Program
    {


        static void Main(string[] args)
        {
            // mainhdhf
            Frame frame = new Frame();
            frame.LogoFrame();
            frame.MenuFrame();
            Console.WriteLine("Your Choice: ");

            var y = Convert.ToChar(Console.ReadLine());
            frame.start(y);



        }


    }
}
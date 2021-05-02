﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    static class FunkForHomework
    {
        public static void NextTask()
        {
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }

        public static int CheckInt(string str)
        {
            int forReturn;
            if (!int.TryParse(str, out forReturn))
            {
                Console.Clear();
                Console.WriteLine("Введённые символы не являются числом.");
                Console.WriteLine("Введите пожалуйста число!");
                forReturn = CheckInt(Console.ReadLine());
            }
            return forReturn;
        }

        public static int CheckInt(string str, bool moreThan, int borderOne)
        {
            int forReturn = CheckInt(str);
            if (((moreThan) ^ (forReturn > borderOne)) || (forReturn == borderOne))
            {
                Console.Clear();
                if (moreThan)
                {
                    Console.WriteLine($"Необходимо ввести число больше {borderOne}");
                }
                else
                {
                    Console.WriteLine($"Необходимо ввести число меньше {borderOne}");
                }
                forReturn = CheckInt(Console.ReadLine(), moreThan, borderOne);
            }
            return forReturn;
        }

        public static int CheckInt(string str, bool moreThan, int borderOne, int borderTwo)
        {
            int forReturn = CheckInt(str);
            if (((moreThan) ^ (forReturn > borderOne && forReturn < borderTwo)) || (forReturn == borderOne) || (forReturn == borderTwo))
            {
                Console.Clear();
                if (moreThan)
                {
                    Console.WriteLine($"Необходимо ввести число больше {borderOne} и меньше {borderTwo}");
                }
                else
                {
                    Console.WriteLine($"Необходимо ввести число меньше {borderOne} или больше {borderTwo}");
                }
                forReturn = CheckInt(Console.ReadLine(), moreThan, borderOne, borderTwo);
            }
            return forReturn;


        }
    }
}
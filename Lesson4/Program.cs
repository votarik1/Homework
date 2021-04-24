
using System;
using System.Collections.Generic;

namespace Lesson4
{
    class Program
    {
        enum seasonEng
        { Winter, Spring, Summer, Autumn }
        enum seasonRu
        { зима, весна, лето, осень }

        static void Main(string[] args)
        {
            //Задание1
            string[] lastName = new string[] { "Путин", "Байден", "Макрон", "Эрдоган", "Си" };
            string[] firstName = new string[] { "Владимир", "Джозеф", "Эмманюэль", "Реджеп", "Цзиньпин" };
            string[] patronymic = new string[] { "Владимирович", "Джозефович", "Жан-Мишелевич", "Ахметович", "Чжунсюнович" };

            for (int i = 0; i < 5; i++)
            {
                GetFullName(lastName[new Random().Next(5)], firstName[new Random().Next(5)], patronymic[new Random().Next(5)]);
            }
            NextTask();
            //Задание2
            Console.WriteLine("Введите числа через пробел"); // можно ввести через любые разделители!
            string strNumbers = Console.ReadLine();
            List<int> numbers = new List<int>();
            bool flag = false;
            bool negative = false;
            string forSave = "";
            int summ = 0;
            foreach (var item in strNumbers)
            {
                int i;
                if (int.TryParse(item.ToString(), out i))
                {
                    flag = true;
                    forSave += i;
                }
                else if (flag)
                {
                    if (forSave != "-")
                    {
                        numbers.Add(int.Parse(forSave));
                    }
                    forSave = "";
                    flag = false;
                }
                if (flag == false && item == '-')
                {
                    forSave = "-";
                    negative = true;
                    flag = true;
                }



            }
            if (forSave != "")
            {
                numbers.Add(int.Parse(forSave));
            }
            foreach (var item in numbers)
            {
                summ += item;
            }
            Console.WriteLine("Сумма всех чисел равна " + summ);
            NextTask();
            //Задание 3
            Console.WriteLine("Введите номер месяца");
            int month = CheckInt(Console.ReadLine(), true, 0, 13);
            Console.WriteLine($"{month} месяц это {TranslateMonth(ConvertNumberInMonth(month))} или {ConvertNumberInMonth(month)}");
            NextTask();
            //Задание 4*
            Console.WriteLine("Введите порядковый номер элемента числовой последовательности Фибоначи");
            int order = CheckInt(Console.ReadLine(), true, 0);
            Console.WriteLine($"Число занимающее {order} позицию в последовательности Фибоначи = {ReturnFibonacci(order)}");
            NextTask();
            //Задание 5**
            Console.WriteLine("Введите несколько предложений не разделённых точкой");
            string sentences = Console.ReadLine();
            Console.WriteLine(AddPoints(sentences));
            NextTask();

        }









        static void NextTask()
        {
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }

       // ChekInt проверяет на возможность перевести строку в int и переводит. С помощью доп параметров можно включить проверку > < или выбрать диапазон в которое должно попасть число (или не попасть)
        static int CheckInt(string str)
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

        static int CheckInt(string str, bool moreThan, int borderOne)
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

        static int CheckInt(string str, bool moreThan, int borderOne, int borderTwo)
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


        static void GetFullName(string lastName, string firstName, string patronymic)
        {
            Console.WriteLine(lastName + " " + firstName + " " + patronymic);
        }

        static seasonEng ConvertNumberInMonth(int numberOfMonth)
        {
            if (numberOfMonth < 3 || numberOfMonth == 12)
            {
                return seasonEng.Winter;
            }
            else if (numberOfMonth > 2 && numberOfMonth < 6)
            {
                return seasonEng.Spring;
            }
            else if (numberOfMonth > 5 && numberOfMonth < 9)
            {
                return seasonEng.Summer;
            }
            else
            {
                return seasonEng.Autumn;
            }
        }
        static seasonRu TranslateMonth(seasonEng season)
        {
            return (seasonRu)season;
        }

        static int ReturnFibonacci(int input)
        {
            switch (input)
            {
                case 1:
                    return 0;
                case 2:
                    return 1;
                default:
                    return CountFibonacci(input - 2, 0, 1);
            };


        }

        static int CountFibonacci(int pos, int preLast, int Last)
        {
            pos--;
            int save = preLast + Last;
            preLast = Last;
            Last = save;
            if (pos != 0)
            {
                Last = CountFibonacci(pos, preLast, Last);
            }
            return Last;

        }

        static string AddPoints(string input)
        {
            string output = "";
            string[] arr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < arr.Length; i++)
            {
                if (Char.IsUpper(arr[i], 0))
                {
                    arr[i - 1] += ".";
                }
                if (i == arr.Length - 1 && arr[i][arr[i].Length -1] != '.')
                {

                    arr[i] += ".";
                }

            }

            foreach (var item in arr)
            {
                output += item + " ";
            }
            return output;

        }

    }
}

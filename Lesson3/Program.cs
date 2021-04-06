using System;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание1
            {
                int[,] array = new int[5, 5];

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        array[i, j] = new Random().Next(10);
                        Console.Write(array[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                Console.Write("Элементы расположенные по диагонали: ");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(array[i, i] + " ");
                }
                Console.WriteLine();


            }
            Console.ReadKey();
            Console.Clear();
            //Задание2
            {
                string[,] PhoneBook = new string[2, 5];
                PhoneBook[0, 0] = "Имя ";
                PhoneBook[0, 1] = "Петя";
                PhoneBook[0, 2] = "Катя";
                PhoneBook[0, 3] = "Маша";
                PhoneBook[0, 4] = "Коля";

                PhoneBook[1, 0] = "Телефон";
                PhoneBook[1, 1] = "23543254";
                PhoneBook[1, 2] = "23780239";
                PhoneBook[1, 3] = "45625462";
                PhoneBook[1, 4] = "89535794";

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.Write(PhoneBook[j, i] + "   ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();


            }
            Console.ReadKey();
            Console.Clear();
            //Задание3
            {
                Console.WriteLine("Ввидите фразу");
                string phrase = Console.ReadLine();

                char[] revers = new char[phrase.Length];
                for (int i = 0; i < phrase.Length; i++)
                {
                    revers[i] = phrase[phrase.Length - 1 - i];
                }
                string reversephrase = new string(revers);
                Console.WriteLine(reversephrase);
            }
            Console.ReadKey();
            Console.Clear();
            //Морской Бой
            {
                string[,] SeaFight = new string[10, 10];
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        SeaFight[i, j] = "O";
                    }
                }
                SeaFight[0, 0] = "X";
                SeaFight[0, 1] = "X";
                SeaFight[0, 2] = "X";
                SeaFight[0, 3] = "X";

                SeaFight[2, 0] = "X";
                SeaFight[3, 0] = "X";
                SeaFight[4, 0] = "X";

                SeaFight[0, 7] = "X";
                SeaFight[0, 8] = "X";
                SeaFight[0, 9] = "X";

                SeaFight[2, 9] = "X";
                SeaFight[3, 9] = "X";

                SeaFight[5, 9] = "X";
                SeaFight[6, 9] = "X";

                SeaFight[6, 0] = "X";
                SeaFight[7, 0] = "X";

                SeaFight[9, 9] = "X";

                SeaFight[9, 4] = "X";

                SeaFight[6, 2] = "X";

                SeaFight[4, 6] = "X";



                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(SeaFight[i, j] + " ");
                    }
                    Console.WriteLine();
                }

            }
            Console.ReadKey();
            Console.Clear();
            //Задание4***
            int[] arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("На сколько позиций перенести массив?");
            int pos = CheckInt(Console.ReadLine());
            int count = 0;
            if (pos >= 0)
            {
                for (int i = 0; i < pos; i++)
                {
                    int save1 = arr[0];
                    int save2 = 0;
                    for (int j = 0; j < arr.Length; j++)
                    {

                        if (j % 2 == 0)
                        {
                            if (j + 1 == arr.Length)
                            {
                                arr[0] = save1;
                            }
                            else
                            {
                                save2 = arr[j + 1];
                                arr[j + 1] = save1;
                            }

                        }
                        else
                        {
                            if (j + 1 == arr.Length)
                            {
                                arr[0] = save2;
                            }
                            else
                            {
                                save1 = arr[j + 1];
                                arr[j + 1] = save2;
                            }

                        }
                    }

                }
            }

            if (pos < 0)
            {
                for (int i = 0; i > pos; i--)
                {
                    int save1 = arr[arr.Length-1];
                    int save2 = 0;
                    for (int j = arr.Length-1; j > -1; j--)
                    {

                        if (count % 2 == 0)
                        {
                            if (j == 0)
                            {
                                arr[arr.Length - 1] = save1;
                            }
                            else
                            {
                                save2 = arr[j - 1];
                                arr[j - 1] = save1;
                            }

                        }
                        else
                        {
                            if (j == 0)
                            {
                                arr[arr.Length - 1] = save2;
                            }
                            else
                            {
                                save1 = arr[j - 1];
                                arr[j - 1] = save2;
                            }

                        }
                        count++;
                    }
                    count = 0;
                }
            }

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }


        static int CheckInt(string str)
        {
            Console.Clear();
            int output;
            if (!int.TryParse(str, out output))
            {
                Console.WriteLine("Введённые символы не являются числом!");
                Console.WriteLine("Пожалуйста введите число!");
                output = CheckInt(Console.ReadLine());
            }
            return output;

        }
    }
}

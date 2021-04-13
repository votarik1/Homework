using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {


            //Задание 1
            Console.WriteLine("Введите полное имя файла");
            FileInfo newFile = new FileInfo(Console.ReadLine());
            Console.Clear();
            WriteInFile(newFile);
            NextTask();
            //Задание 2
            string time = DateTime.Now.ToString("HH:mm:ss");
            File.AppendAllText("startup.txt", time + "\n");
            Console.WriteLine($"текущее время {time} записано в файл «startup.txt»");
            NextTask();
            //Задание 3
            List<int> collection = new List<int>();
            string numbers = "";
            while (numbers.ToLower() != "x")
            {
                Console.WriteLine("Введите число в диапазоне (0...255). Для прекращения ввода чисел введите x");
                numbers = Console.ReadLine();
                if (numbers.ToLower() == "x")
                {
                    break;
                }
                collection.Add(CheckInt(numbers,true,-1,256));
                Console.Clear();
            }
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(new FileStream("arr.bin", FileMode.OpenOrCreate), collection);
            Console.Clear();
            Console.WriteLine("Введённые числа записаны в файл arr.bin");
            NextTask();
            //Задание 4
            Employee[] office = new Employee[5];
            office[0] = new Employee("Иванов Иван Иванович", "директор", "Boss@office.com", "89567794567", 214986, 54);
            office[1] = new Employee("Петров Петр Петрович", "зам директора", "almostBoss@office.com", "89567794569", 135986, 45);
            office[2] = new Employee("Сергеев Сергей Сергеевич", "бугалтер", "countman@office.com", "89567798954", 87996, 29);
            office[3] = new Employee("Попова Светлана Леонидовна", "продавец", "salewoman@office.com", "89567799023", 96996, 25);
            office[4] = new Employee("Барашков Николай Михаилович", "уборщик", "cleanman@office.com", "89567799023", 34700, 34);

            foreach (var item in office)
            {
                if (item.age > 40)
                {
                    item.list();
                }

            }
        }




        static void NextTask()
        {
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }

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

        static void WriteInFile(FileInfo fileName)
        {
            Console.WriteLine($"Введите текст который необходимо записать в файл {fileName.Name}");
            Console.WriteLine($"Для выхода из режима записи введите \"x\"");
            using (TextWriter stream = File.AppendText(fileName.FullName))
            {
                string input = "";
                while (input.ToLower() != "x")
                {
                    input = Console.ReadLine();
                    if (input.ToLower() != "x")
                    {
                        stream.WriteLine(input);
                    }

                }
            }


        }



    }





}

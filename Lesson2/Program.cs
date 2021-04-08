using System;

namespace Lesson2
{
    class Program
    {

        enum Month
        {
            январь =1,
            февраль,
            март,
            апрель,
            май,
            июнь,
            июль,
            август,
            сентябрь,
            октябрь,
            ноябрь,
            декабрь,
        }

        static void Main(string[] args)
        {
            //1 задание

            Console.WriteLine("Введите максимальную температуру за сутки");
            int highT;
            int lowT;
            highT = CheckInt(Console.ReadLine());
            Console.WriteLine("Введите минимальную температуру за сутки");
            lowT = CheckInt(Console.ReadLine());
            double average = (double)(highT + lowT) / 2;
            Console.WriteLine($"Средняя температура за сутки равна {average}°C");

            NextTask();
            //2 задание
            {
                int MonthInt = 0;
                while (!(MonthInt > 0 && MonthInt <= 12))
                {
                    if (MonthInt != 0)
                    {
                        Console.WriteLine("В году только 12 месяцев!");
                    }
                    Console.WriteLine("Введите номер месяца");
                    MonthInt = CheckInt(Console.ReadLine());
                }
                Console.WriteLine($"{MonthInt} месяц это {(Month)MonthInt}");
                if ((MonthInt == 1 || MonthInt == 2 || MonthInt == 12) && average > 0)
                {
                    Console.WriteLine("Дождливая зима!");
                }
            }
            NextTask();
            //3 задание
            {
                Console.WriteLine("Введите число");
                int a = CheckInt(Console.ReadLine());
                if (a % 2 == 0)
                {
                    Console.WriteLine($"{a} четное число");
                }
                else
                {
                    Console.WriteLine($"{a} нечетное число");
                }


            }
            NextTask();
            //4 задание
            {
                double Price = 735;
                double NDS = 20;
                string name = "Смеситель для кухни";
                string Cashier = "Хохлова Яна Сергеевна";
                string ShopName = "Петрович";
                DateTime BuyTime = new DateTime(2021, 1, 16, 17, 52, 0);
                Console.WriteLine("                " + ShopName);
                Console.WriteLine("*****************************************");
                Console.WriteLine($"{name}         1 шт = {Price.ToString("####.00")}");
                Console.WriteLine($"НДС {NDS}%                          = {(Price * 0.2).ToString("####.00")}");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"ИТОГ                               {Price.ToString("####.00")}");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Кассир              " + Cashier);
                Console.WriteLine();

            }
            NextTask();
            //5 задание
            {
                // битовые маски указывают рабочие дни офиса справо налево (крайнее правое значение понедельник)
                int Sberbank = 0b0111111;
                int Clinic =   0b0011111;
                int PassPort = 0b0001010;
                int Library =  0b1100000;
                int today = (int)DateTime.Today.DayOfWeek;

                int maskToday = 1;
                for (int i = today-1; i > 0; i--)
                {
                    maskToday *=2;
                }// битовая маска сегодняшнего дня

                if ((Sberbank & maskToday)!=0)
                {
                    Console.WriteLine("Сегодня работает Сбербанк");
                }

                if ((Clinic & maskToday) != 0)
                {
                    Console.WriteLine("Сегодня работает Поликлиника");
                }

                if ((PassPort & maskToday) != 0)
                {
                    Console.WriteLine("Сегодня работает Паспортный Стол");
                }

                if ((Library & maskToday) != 0)
                {
                    Console.WriteLine("Сегодня работает Библиотека");
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


using System;
using System.Diagnostics;
using FunkForHomework;
namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание1
            GetProcess();
            Console.WriteLine("Введите имя или PID процесса для удаления. Для выхода из программы введите \"x\"");
            FinishHim();
            Funck.NextTask();
            //Задание2                      
            Console.WriteLine("Введите длину двумерного массива");
            int lenth = Funck.CheckInt(Console.ReadLine(), true, 0);
            Console.Clear();
            Console.WriteLine("Введите ширину двумерного массива");
            int width = Funck.CheckInt(Console.ReadLine(), true, 0);
            Console.Clear();
            string[,] ourArray =  new string[lenth, width];
            int summ = 0;
            for (int i = 0; i < lenth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.WriteLine($"Введите значение которое Вы хотели бы поместить в ячейку {i},{j}");
                    ourArray[i,j] = Console.ReadLine();

                }
            }
            try
            {
             summ = SumArr(ourArray);
             Console.WriteLine($"Сумма всех чисел массива равна {summ}");
            }
            catch (MyArraySizeException)
            {
                Console.WriteLine("Размер массива должен быть 4х4");
            }

            catch (MyArrayDataException ex)
            {
                Console.WriteLine($"в поле {ex.i},{ex.j} находится строка которую невозможно преобразовать в число");
            }
            
        }

        static void GetProcess()
        {
            Process[] allProsess = Process.GetProcesses();




            foreach (var item in allProsess)
            {
                string processName = item.ProcessName;
                string itemId = item.Id.ToString();
                while (itemId.Length < 5)
                {
                    itemId += " ";
                }
                while (processName.Length < 63)
                {
                    processName += " ";
                }
                Console.WriteLine($"{processName}PID:{itemId}    Memory:{item.VirtualMemorySize64}");

            }
        }

        static void KillProcess(string name)
        {
            Process[] proc = Process.GetProcessesByName(name);
            if (proc.Length == 0)
            {
                throw new Exception();
            }
            foreach (var item in proc)
            {
                item.Kill();
            }

        }

        static void KillProcess(int pid)
        {
            Process proc = Process.GetProcessById(pid);
            proc.Kill();
        }

        static void FinishHim()
        {
            string input = " ";
            int pid;
            while (true)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "x")
                {
                    break;
                }
                if (int.TryParse(input, out pid))
                {
                    try
                    {
                        KillProcess(pid);
                        Console.WriteLine($"Процесс {pid} успешно удалён");
                    }
                    catch
                    {
                        Console.WriteLine($"Процесс {pid} не существует");
                    }
                }
                else
                {
                    try
                    {
                        KillProcess(input);
                        Console.WriteLine($"Процесс {input} успешно удалён");
                    }
                    catch
                    {
                        Console.WriteLine($"Процесс {input} не существует");
                    }

                }


            }




        }

        static int SumArr(string[,] arr)
        {
            if (arr.GetLength(0) != 4 || arr.GetLength(1) != 4)
            {
                throw new MyArraySizeException(); 
            }

            int output = 0;
            int i = 0;
            int j = 0;

            try
            {               
                for (; i < 4; i++)
                {
                    for (; j< 4; j++)
                    {
                        output += int.Parse(arr[i, j]);
                    }
                    j = 0;
                }
                i = 0;
                return output;
            }
            catch
            {
                throw new MyArrayDataException(i,j);
            }
                
        }




    }
}

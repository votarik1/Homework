using System;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("КРЕСТИКИ НОЛИКИ");
            Console.WriteLine("Введите ширину игрового поля");
            int xSize = FunkForHomework.CheckInt(Console.ReadLine(),true,1);
            Console.WriteLine("Введите высоту игрового поля");
            int ySize = FunkForHomework.CheckInt(Console.ReadLine(), true, 1);
            Console.WriteLine("Какое количество символов поставленных подряд приводит к победе?");
            int winPoint = FunkForHomework.CheckInt(Console.ReadLine(), true, 1);                      
            string input = " ";
            while (input!="x")
            {
                GameBoard game1 = new GameBoard(xSize, ySize, winPoint, '.', 'X', 'O');
                Console.Clear();
                game1.PrintBoard();

                while (!game1.gameEnd)
                {
                    game1.MovePlayer();
                    if (!game1.gameEnd)
                    {
                        game1.MoveAI();
                    }

                }
                Console.WriteLine("Чтобы сыграть ещё раз нажмите Enter");
                Console.WriteLine("Чтобы выйти введите \"x\"");
                input = Console.ReadLine().ToLower();
            }
            


        }
    }
}

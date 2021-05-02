using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    class GameBoard
    {
        
        public int XSize { get; set; }
        public int YSize { get; set; }
        public int pointsToWin { get; set;}
        public char PLAYER_DOT { get; set; }
        public char AI_DOT { get; set; }
        public char EMPTY_DOT { get; set; }
        public bool gameEnd { get; set; }

        Random random = new Random();


        public char[,] board { get; set; }

        public GameBoard(int xSize, int ySize, int PointsToWin, char empty, char player, char AI)
        {
            XSize = xSize;
            YSize = ySize;
            pointsToWin = PointsToWin;
            EMPTY_DOT = empty;
            PLAYER_DOT = player;
            AI_DOT = AI;
            board = new char[XSize, YSize];
            for (int i = 0; i < XSize; i++)
            {
                for (int j = 0; j < YSize; j++)
                {
                    board[i, j] = EMPTY_DOT;
                }
            }


        }

        public void PrintBoard()
        {
            string line = "-";

            for (int i = 0; i < XSize; i++)
            {
                line += "--";
            }

            Console.WriteLine(line);

            for (int i = 0; i < XSize; i++)
            {

                for (int j = 0; j < YSize; j++)
                {
                    Console.Write($"|{board[i, j]}");
                }
                Console.WriteLine("|");
            }




            Console.WriteLine(line);
        }

        void Move(int x, int y, char symbol)
        {
            Console.Clear();
            board[x, y] = symbol;
            PrintBoard();
            if (symbol== PLAYER_DOT && AllChecks.CheckWin(board, symbol, pointsToWin))
            {                
                Console.WriteLine("Вы победили!");
                gameEnd = true;
            }
            else if (symbol == AI_DOT && AllChecks.CheckWin(board, symbol, pointsToWin))
            {
                Console.WriteLine("Вы проиграли!");
                gameEnd = true;
            }
            else if (AllChecks.CheckDraw(board,EMPTY_DOT))
            {
                Console.WriteLine("Ничья!");
                gameEnd = true;
            }
        }

        public void MovePlayer()
        {
            int x, y;
            do
            {
                Console.WriteLine("Координат по строке ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + YSize);
                y = FunkForHomework.CheckInt(Console.ReadLine(), true,0, YSize+1) - 1;
                Console.WriteLine("Координат по столбцу ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + XSize);
                x = FunkForHomework.CheckInt(Console.ReadLine(), true, 0, XSize+1) - 1;
            } while (!(board[x, y] == EMPTY_DOT));
            Move(x, y, PLAYER_DOT);

        }

        public void MoveAI()
        {

            AI myAI = new AI(this);
            int[] coordinate = myAI.AIMove();
            int x = coordinate[0], y = coordinate[1];

            if (coordinate[0]==(-1))
            {
                do
                {
                    x = random.Next(0, XSize);
                    y = random.Next(0, YSize);

                } while (!(board[x, y] == EMPTY_DOT));

            }            
            Move(x, y, AI_DOT);
        }



    }
}

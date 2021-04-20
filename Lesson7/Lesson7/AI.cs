using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
     class AI
    {

        public GameBoard AIGameBoard { get; set; }
        public AI(GameBoard aiGameboard)
        {
            AIGameBoard = aiGameboard;
        }
        int[] CountOneStep(char whoWin)
        {
            int x = -1, y = -1;

            for (int i = 0; i < AIGameBoard.board.GetLength(0); i++)
            {
                for (int j = 0; j < AIGameBoard.board.GetLength(1); j++)
                {
                    if (AIGameBoard.board[i,j]==AIGameBoard.EMPTY_DOT)
                    {
                        AIGameBoard.board[i, j] = whoWin;
                        if (AllChecks.CheckWin(AIGameBoard.board, whoWin, AIGameBoard.pointsToWin))
                        {
                            x = i;
                            y = j;
                            AIGameBoard.board[i, j] = AIGameBoard.EMPTY_DOT;
                            return new int[] { i, j };

                        }
                        AIGameBoard.board[i, j] = AIGameBoard.EMPTY_DOT;
                    }

                }
            }         
            return new int[] { x, y };
        }
        int[] Attack()
        {
            return CountOneStep(AIGameBoard.AI_DOT);
        }
        int[] Defend()
        {
            return CountOneStep(AIGameBoard.PLAYER_DOT);
        }

        public int[] AIMove()
        {
            if (Attack()[0]==(-1))
            {
                return Defend();
            }
            else
            {
                return Attack();
            }

        }

    }
}

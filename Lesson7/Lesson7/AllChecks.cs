using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    static class AllChecks
    {
        
       static public bool CheckWin(char[,] arr, char winSimbol,int inARowToWin)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i,j] == winSimbol)
                    {
                        for (int k = 1; k < (inARowToWin); k++)
                        {
                            if (!IsCellValid((i - k), (j + k), arr, winSimbol))
                            {
                                break;
                            }
                            if (k==inARowToWin-1)
                            {
                                return true;
                            }                            
                        }
                        for (int k = 1; k < (inARowToWin); k++)
                        {
                            if (!IsCellValid((i + k), (j + k), arr, winSimbol))
                            {
                                break;
                            }
                            if (k == inARowToWin - 1)
                            {
                                return true;
                            }
                        }
                        for (int k = 1; k < (inARowToWin); k++)
                        {
                            if (!IsCellValid((i + k), (j), arr, winSimbol))
                            {
                                break;
                            }
                            if (k == inARowToWin - 1)
                            {
                                return true;
                            }
                        }
                        for (int k = 1; k < (inARowToWin); k++)
                        {
                            if (!IsCellValid((i), (j + k), arr, winSimbol))
                            {
                                break;
                            }
                            if (k == inARowToWin - 1)
                            {
                                return true;
                            }
                        }
                    }                   

                }

            }
            return false;

        }

        static public bool CheckDraw(char[,] arr, char freeCell)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i,j] == freeCell)
                    {
                        return false;
                    }

                }

            }
            return true;

        }


        static public bool IsCellValid(int x, int y, char[,] arr, char symbol)
        {
            if (x < 0 || y < 0 || x > arr.GetLength(0) - 1 || y > arr.GetLength(1) - 1)
            {
                return false;
            }

            return arr[x, y] == symbol;
        }

    }
}

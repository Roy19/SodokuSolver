using System;

namespace SodokuSolver
{
    internal class SodukuSolver
    {
        private const int BOARDSIZE = 9;
        private readonly int[,] BOARD;

        public SodukuSolver(int[,] board)
        {
            BOARD = board;
        }

        public bool Solve()
        {
            // find blank spot
            int i = 0, j = 0;
            bool foundBlankSpot = false;

            while(i < BOARDSIZE)
            {
                j = 0;
                while(j < BOARDSIZE)
                {
                    if (BOARD[i,j] == 0)
                    {
                        foundBlankSpot = true;
                        break;
                    }
                    j++;
                }
                
                if(foundBlankSpot)
                {
                    break;
                }
                i++;
            }

            if(!foundBlankSpot)
            {
                return CheckBoard();
            }

            // put a number there from 1 to 9
            for(int num = 1;num <= 9;num++)
            {
                BOARD[i,j] = num;
                if(Solve())
                {
                    return true;
                }
                BOARD[i,j] = 0;
            }

            return false;
        }

        private bool CheckBoard()
        {
            // check each row
            for(int i = 0;i < BOARDSIZE;i++)
            {
                int[] dict = new int[10];
                for (int j = 0;j < BOARDSIZE;j++)
                {
                    dict[BOARD[i,j]]++;
                    if(dict[BOARD[i,j]] > 1)
                    {
                        return false;
                    }
                }
            }

            // check each column
            for (int i = 0;i < BOARDSIZE;i++)
            {
                int[] dict = new int[10];
                for (int j = 0;j < BOARDSIZE;j++)
                {
                    dict[BOARD[j,i]]++;
                    if (dict[BOARD[j,i]] > 1)
                    {
                        return false;
                    }
                }
            }

            // check each 3x3 boxes
            for(int i = 0;i < 3;i++)
            {
                for(int j = 0;j < 3;j++)
                {
                    int[] dict = new int[10];
                    for(int x = 0;x < 3;x++)
                    {
                        for(int y = 0;y < 3;y++)
                        {
                            int i_idx = (x + (i * 3)), j_idx = (y + (j * 3));
                            dict[BOARD[i_idx,j_idx]]++;
                            if(dict[BOARD[i_idx,j_idx]] > 1)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PrintSolution()
        {
            for (int i = 0; i < BOARDSIZE; i++)
            {
                for (int j = 0; j < BOARDSIZE; j++)
                {
                    Console.Write($"{BOARD[i,j]},");
                }
                Console.WriteLine();
            }
        }
    }
}

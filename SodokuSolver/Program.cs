using System;

namespace SodokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new int[9,9] { 
                                        { 5, 3, 4, 6, 7, 8, 9, 1, 2 }, 
                                        { 6, 7, 2, 1, 9, 5, 3, 4, 0 }, 
                                        { 1, 0, 8, 3, 4, 2, 5, 6, 7 }, 
                                        { 8, 5, 9, 0, 0, 1, 4, 2, 3 }, 
                                        { 4, 2, 6, 0, 5, 3, 7, 9, 1 }, 
                                        { 7, 1, 3, 9, 2, 4, 8, 5, 6 }, 
                                        { 9, 0, 1, 5, 3, 7, 2, 8, 4 }, 
                                        { 2, 8, 7, 4, 1, 9, 0, 3, 5 }, 
                                        { 3, 4, 5, 2, 8, 6, 1, 7, 0 } 
                                    };
            SodukuSolver sodukuSolver = new SodukuSolver(board);
            sodukuSolver.Solve();
            sodukuSolver.PrintSolution();
        }
    }
}

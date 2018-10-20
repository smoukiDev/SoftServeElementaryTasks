using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameBoard.Bisuness_Logic;

namespace GameBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            Board gb = new Board(4, 4, false);
            gb.BuildBoard();

            for (int i = 0; i < gb.Height; i++)
            {
                for (int j = 0; j < gb.Width; j++)
                {
                    if (gb.BoardSurface[i, j].Color == CellColor.White)
                    {
                        Console.Write("0");
                    }

                    if (gb.BoardSurface[i, j].Color == CellColor.Black)
                    {
                        Console.Write("*");
                    }
                }

                Console.Write(Environment.NewLine);
            }

            Console.WriteLine(gb[4, 4].ToString());
            Console.WriteLine(gb[1, 1].ToString());
            Console.WriteLine(gb[1, 2].ToString());
            Console.ReadLine();
        }
    }
}

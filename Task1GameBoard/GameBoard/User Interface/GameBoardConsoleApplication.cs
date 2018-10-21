// <copyright file="GameBoardConsoleApplication.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace GameBoard.User_Interface
{
    using System;
    using GameBoard.Bisuness_Logic;

    /// <summary>
    /// Represents console application which builds and display game board
    /// </summary>
    public class GameBoardConsoleApplication
    {
        private static readonly string SEPARATE_LINE = new string('=', 60);
        private static readonly string WARNING_LINE = new string('!', 60);
        private const string LIGHT_CELL_FILLING = " ";
        private const string DARK_CELL_FILLING = "*";
        private const byte ARGS_LIMIT = 2;

        /// <summary>
        /// Receive console input arguments and runs application
        /// </summary>
        /// <param name="args">Console input arguments</param>
        public void Run(string[] args)
        {
            try
            {
                if (args.Length == ARGS_LIMIT)
                {
                    int width = 0;
                    int height = 0;
                    bool isParsed = false;
                    isParsed = int.TryParse(args[0], out width);

                    if (!isParsed)
                    {
                        throw new FormatException("Incorrect input. Enter values of board width and height");
                    }

                    isParsed = int.TryParse(args[1], out height);

                    if (!isParsed)
                    {
                        throw new FormatException("Incorrect input. Enter values of board width and height");
                    }

                    Board board = new Board(width, height, false);
                    board.BuildBoard();
                    this.DisplayBoard(board);

                    Console.WriteLine("Press enter to exit, please...");
                    Console.ReadLine();
                }
                else
                {
                    throw new FormatException("GameBoardConsoleApplication needs only two input arguments");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
                this.DisplayHelpMessage();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
                this.DisplayHelpMessage();
            }
        }

        private void DisplayBoard(Board board)
        {
            for (int i = 0; i < board.Height; i++)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    if (board.BoardSurface[i, j].Color == CellColor.White)
                    {
                        Console.Write(LIGHT_CELL_FILLING);
                    }

                    if (board.BoardSurface[i, j].Color == CellColor.Black)
                    {
                        Console.Write(DARK_CELL_FILLING);
                    }
                }

                Console.Write(Environment.NewLine);
            }
        }

        private void DisplayHelpMessage()
        {
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine("GameBoard Application");
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine("Print width and height of board, please");
            Console.WriteLine("Print format: GameBoard [width] [height]");
            Console.WriteLine("Application build and display the board");
            Console.WriteLine(SEPARATE_LINE);
            Console.Write("Press Enter to continue");
            Console.ReadLine();
        }
    }
}

// <copyright file="TriangleConsoleApplication.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace SortTriangles
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using SortTriangles.UI;

    /// <summary>
    /// Embed console user interface for SortTriangle application
    /// </summary>
    public class TriangleConsoleApplication : IUserGuide
    {
        private List<Triangle> _triangles = new List<Triangle>();

        private const int NUMBER_OF_ARGS = 4;

        private static readonly string SEPARATE_LINE = new string('=', 45);
        private static readonly string WARNING_LINE = new string('!', 45);

        private const string ARGUMENT_EXCEPTION_MESSAGE = "Incorrect print format";
        private const string ARGUMENT_NULL_EXCEPTION_MESSAGE = "No triangles have been added";

        /// <summary>
        /// Prints  information about triangles: name, square, measure. Sorts records in discending order.
        /// </summary>
        /// <exception cref="ArgumentNullException">Incorrect print format</exception>
        public void PrintTriangles()
        {
            if (_triangles == null)
            {
                throw new ArgumentNullException(ARGUMENT_NULL_EXCEPTION_MESSAGE);
            }

            _triangles.Sort();

            Console.Write(SEPARATE_LINE);
            Console.Write("Triangle list:");
            Console.Write(SEPARATE_LINE);
            Console.Write(Environment.NewLine);

            foreach (Triangle triangle in _triangles)
            {
                Console.Write("1.");
                Console.Write(triangle.ToString());
                Console.Write(Environment.NewLine);
            }

        }

        /// <summary>
        /// Runs TriangleConsoleApplication
        /// </summary>
        public void Run()
        {
            this.DisplayHelpMessage();

            string key = null;

            do
            {
                try
                {
                    (string name, double sideA, double sideB, double sideC) triangleArgs = this.ValidateInput(this.GetInput());
                    this.AddTriangle(triangleArgs);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(WARNING_LINE);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(WARNING_LINE);
                    this.DisplayHelpMessage();
                }

                Console.WriteLine(SEPARATE_LINE);
                Console.WriteLine("Do you want to add one more triangle?");
                Console.WriteLine("Print Y or YES to confirm...");
                Console.WriteLine("Print other string to show list of triangles...");
                Console.WriteLine(SEPARATE_LINE);
                key = Console.ReadLine().ToUpper();
            }
            while (key == "Y" || key == "YES");

            try
            {
                this.PrintTriangles();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
            }

            Console.WriteLine("Please press enter, to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// Gets Input of user
        /// </summary>
        /// <returns>Input string</returns>
        public string GetInput()
        {
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine("Print triangle parameters, please...");
            Console.WriteLine(SEPARATE_LINE);
            return Console.ReadLine();
        }

        /// <summary>
        /// Validates and returns input parameters
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Tuple with triangle name and sides</returns>
        /// <exception cref="ArgumentException">Incorrect print format</exception>
        public(string name, double sideA, double sideB, double sideC) ValidateInput(string input)
        {
            double sideA;
            double sideB;
            double sideC;
            string name;

            input = Regex.Replace(input, " ", string.Empty);
            input = Regex.Replace(input, "\t", string.Empty);

            string[] parameters = input.Split(',');

            if (parameters.Length != NUMBER_OF_ARGS)
            {
                throw new ArgumentException(ARGUMENT_EXCEPTION_MESSAGE);
            }

            if (parameters[0] == string.Empty)
            {
                throw new ArgumentException(ARGUMENT_EXCEPTION_MESSAGE);
            }
            else
            {
                name = parameters[0];
            }

            try
            {
                // TODO: Adapt to encoding сases
                sideA = double.Parse(parameters[1].Replace('.', ','));
                sideB = double.Parse(parameters[2].Replace('.', ','));
                sideC = double.Parse(parameters[3].Replace('.', ','));
            }
            catch (Exception)
            {
                throw new ArgumentException(ARGUMENT_EXCEPTION_MESSAGE);
            }

            return (name, sideA, sideB, sideC);
        }

        /// <summary>
        /// Add Triangle to list
        /// </summary>
        /// <param name="args">Tuple with triangle name and sides</param>
        /// <exception cref="ArgumentException">Incorrect print format</exception>
        public void AddTriangle((string name, double sideA, double sideB, double sideC) args)
        {
            Triangle triangle = new Triangle(args.name, "sm", args.sideA, args.sideB, args.sideC);
            if (triangle.IsExist())
            {
                _triangles.Add(triangle);
            }
            else
            {
                throw new ArgumentException("Triangle with such sides doesn't exist");
            }
        }

        /// <summary>
        /// Displays UserGuide
        /// </summary>
        public void DisplayHelpMessage()
        {
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine("Welcome to TriangleSort Application");
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine("Print format to add triangle:");
            Console.WriteLine("[name], [side 1], [side 2], [side 3]");
            Console.WriteLine("Print Y or YES to continue and add one more triangle");
            Console.WriteLine("Print other string to show list of triangles");
            Console.WriteLine("Triangles will be diplayed in discending order by square");
            Console.WriteLine(SEPARATE_LINE);
            Console.Write("Press Enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

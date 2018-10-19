namespace SortTriangles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SortTriangles.UI;
    using System.Text.RegularExpressions;

    class TriangleConsoleApplication : IUserGuide
    {
        private List<Triangle> _triangles = null;
        private static readonly string SEPARATE_LINE = new string('=', 70);
        private const int NUMBER_OF_ARGS = 4;
        private const string ARGUMENT_EXCEPTION_MESSAGE = "Incorrect print format";
        private const string ARGUMENT_NULL_EXCEPTION_MESSAGE = "No triangles have been added";

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

        public void Run()
        {
            this.DisplayHelpMessage();
            this.StartUp();

            string key = null;
            do
            {
                var triangleArgs = this.ValidateInput(this.GetInput());
                Console.WriteLine($"{triangleArgs.name} {triangleArgs.sideA} {triangleArgs.sideB} {triangleArgs.sideC}");
                Console.WriteLine("Do you want to add triangle?");
                Console.WriteLine("Print Y or YES to confirm...");
                Console.WriteLine("Print other string to show list of triangles...");
                key = Console.ReadLine().ToUpper();
            }
            while (key == "Y" || key == "YES");
        }

        private void StartUp()
        {
            Console.Write("Press Enter To Start");
            Console.ReadLine();
            Console.Clear();
        }

        private string GetInput()
        {
            Console.WriteLine("Print triangle parameters, please...");
            return Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Incorrect print format</exception>
        private(string name, double sideA, double sideB, double sideC) ValidateInput(string input)
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

            // TODO: Mention exceptions in my documentation
            try
            {
                // TODO: Encoding cases
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
        }
    }
}

namespace calculator
{
    class Program
    {
        public static List<string> history = new List<string>();
        static void Main(string[] args)
        {
            while (true)
            {
                string options;
                Console.WriteLine("Check history press c, otherwise press any button: ");
                options = Console.ReadLine();

                if (options == "c")
                {
                    foreach (string entry in history)
                    {
                        Console.WriteLine(entry);
                    }
                    continue;
                }

                double number1, number2;
                string op;

                number1 = InputNumber("first");
                number2 = InputNumber("second");
                op = InputOperator();

                Operate(number1, number2, op);
            }

        }

        public static double InputNumber(string idx)
        {
            string input;
            Console.WriteLine($"Enter the {idx} number: ");
            input = Console.ReadLine();

            double f;
            while (!double.TryParse(input, out f))
            {
                Console.WriteLine("Invalid number, please retry again: ");
                input = Console.ReadLine();
            }

            return f;
        }

        public static string InputOperator()
        {
            string[] operators = { "+", "-", "*", "/", "**", "sr" };
            string inputOperator = "";
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine($"Enter the operator({string.Join(", ", operators)}): ");
                inputOperator = Console.ReadLine();

                foreach (string op in operators)
                {
                    if (inputOperator == op)
                    {
                        isValid = true;
                        break;
                    }
                }
            }

            return inputOperator;
        }

        public static void Operate(double n1, double n2, string op)
        {
            string output;
            switch (op)
            {
                case "+":
                    output = $"{n1} + {n2} = {n1 + n2}\n";
                    history.Add(output);
                    Console.WriteLine(output);
                    break;
                case "-":
                    output = $"{n1} - {n2} = {n1 - n2}\n";
                    history.Add(output);
                    Console.WriteLine(output);
                    break;
                case "*":
                    output = $"{n1} * {n2} = {n1 * n2}\n";
                    history.Add(output);
                    Console.WriteLine(output);
                    break;
                case "/":
                    if (n2 == 0)
                    {
                        Console.WriteLine("The second number is invalid");
                        return;
                    }
                    output = $"{n1} / {n2} = {n1 / n2}\n";
                    history.Add(output);
                    Console.WriteLine(output);
                    break;
                case "**":
                    output = $"{n1} ** {n2} = {Math.Pow(n1, n2)}\n";
                    history.Add(output);
                    Console.WriteLine(output);
                    break;
                case "sr":
                    output = $"The square root of {n1} = {Math.Sqrt(n1)}. The square root of {n2} = {Math.Sqrt(n2)}\n";
                    history.Add(output);
                    Console.WriteLine(output);
                    break;
            }
        }

    }
}

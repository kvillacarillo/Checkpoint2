using System;

namespace Checkpoint2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Display instructions*/
            DisplayInstruction();
            /*He I am just using my generic functions that will handle inputs*/
            InputHandler<string>("Name ", out string name);
            InputHandler<int>("Age ", out int age);
            InputHandler<double>("Height ", out double height);

            /*Here checked conditionals solved with ternary operations to be appended to final message*/
            string eligibility = age >= 18 ? "You're" : "You're not";
            string cheers = age >= 18 ? "Cheers" : "Sorry";

            /*The message*/
            string message = $"Your Personal Details:\r\nName: {name}\r\nAge: {age}\r\nHeight: {height} meters\r\n\r\nAge Check:\r\nWelcome, {name}! {eligibility} eligible for additional features.\r\n\r\nLegal Drinking Age Verification:\r\n{cheers}, {name} {eligibility} legally allowed to enjoy alcoholic beverages.\r\n\r\nPersonal Details Presentation:\r\nYour Personal Information: {name}, {age} years old, {height} meters tall.";

            Console.WriteLine(message);
        }

        private static void DisplayInstruction()
        {
            string message = "Welcome to Your Personal Information System!\r\n\r\nPlease enter your name: Alice\r\nPlease enter your age: 28\r\nPlease enter your height in meters: 1.65";
            Console.WriteLine(message);
        }

        private static T InputHandler<T>(String inputName, out T value) where T : IConvertible
        {
            string input;
            try
            {
                Console.WriteLine("Enter the " + inputName + $" [TYPE] <{typeof(T).Name}>");
                input = Console.ReadLine() ?? "";

                if (string.IsNullOrEmpty(input))
                {
                    throw new Exception("Blank values are not allowed!");
                }

                if (typeof(T) != typeof(T))
                {
                    throw new Exception("Datatype Error!");
                }


                if (typeof(T) == typeof(string) && input.Any(char.IsDigit))
                {
                    throw new Exception("String cannot contain numbers!");
                }

                value = (T)Convert.ChangeType(input, typeof(T));

                return value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InputHandler(inputName, out value);
            }
        }
    }
}
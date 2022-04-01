using Common.Enums;
using Common.Models;
using System;
using System.Text.RegularExpressions;

namespace AsyncCalcTestTask.Helpers
{
    internal class InputBasicValidator
    {
        private readonly string _pattern = @"\w+\w*,(\-)*[0-9]+,((\-)*[0-9]+)$";

        public readonly string WelcomeMessage = "Welcome to Async Calculator!\nType in math command (Diff/Sum), then enter two integer values" +
            "\nand split everything with single commas.\n\nExample: \"Diff,10,3\".\n\n" +
            "Type in \"stop\" when you are done to exit the Calculator.\n";

        internal void Validate(string input, ref IntBasicMathEventModel model, ref bool isRunning)
        {
            if (input == "stop")
            {
                isRunning = false;
                return;
            }

            if (Regex.IsMatch(input, _pattern, RegexOptions.IgnoreCase))
            {
                string[] strValues = input.Split(',');
                string opName = strValues[0];

                switch (opName)
                {
                    case "sum":
                        model.Operation = MathOperationsEnum.Sum;
                        break;
                    case "diff":
                        model.Operation = MathOperationsEnum.Diff;
                        break;
                    default:
                        model.Code = EventCodeEnum.OperationNotFound;
                        return;
                }

                try
                {
                    model.IntVal1 = int.Parse(strValues[1]);
                    model.IntVal2 = int.Parse(strValues[2]);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    model.Code = EventCodeEnum.IncorrectInput;
                }
                
            }
            else
                model.Code = EventCodeEnum.IncorrectInput;
        }
    }
}

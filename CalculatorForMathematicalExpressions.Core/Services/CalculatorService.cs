using CalculatorForMathematicalExpressions.Core.Contracts;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculatorForMathematicalExpressions.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        public double Calculate(string mathExpression)
        {
            string regexPattern = @"[A-Za-z!@#$%^&<>?;:""'|\]\`[{}]"; 

            if (Regex.Match(mathExpression, regexPattern).Success)
            {
                throw new ArgumentException("Invalid input!");
            }

            var numbers = new Stack<double>();
            var operators = new Stack<char>();

            var validMathOperators = "+-/*";

            for (int i = 0; i < mathExpression.Length; i++)
            {
                var currChar = mathExpression[i];
                if (currChar == '(')
                {
                    operators.Push(currChar);
                }
                else if (currChar == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        var currOperator = operators.Pop();
                        var secondNumber = numbers.Pop();
                        var firstNumber = numbers.Pop();

                        var value = Operation(currOperator, firstNumber, secondNumber);

                        numbers.Push(value);
                    }
                    operators.Pop();
                }
                else if (validMathOperators.Contains(currChar))
                {
                    while (operators.Count > 0 && OperatorsPriority(operators.Peek()) >= OperatorsPriority(currChar) && operators.Count < numbers.Count)
                    {
                        var currOperator = operators.Pop();
                        var secondNumber = numbers.Pop();
                        var firstNumber = numbers.Pop();

                        var value = Operation(currOperator, firstNumber, secondNumber);

                        numbers.Push(value);
                    }

                    operators.Push(currChar);
                }
                else if (char.IsDigit(currChar) || currChar == '.' || currChar == ',')
                {
                    var currNumber = new StringBuilder();
                    while (char.IsDigit(currChar) || currChar == '.' || currChar == ',')
                    {
                        if (operators.Count > 0 && operators.Count >= numbers.Count && mathExpression[i - 1] == '-')
                        {
                            currNumber.Append(operators.Pop());
                        }
                        currNumber.Append(currChar);

                        i++;

                        if (i == mathExpression.Length)
                        {
                            break;
                        }

                        currChar = mathExpression[i];
                    }
                    i--;
                    numbers.Push(double.Parse(currNumber.ToString()));
                }
            }

            while (operators.Count() > 0)
            {
                var currOperator = operators.Pop();
                var secondNumber = numbers.Pop();
                var firstNumber = numbers.Pop();

                var value = Operation(currOperator, firstNumber, secondNumber);

                numbers.Push(value);
            }

            return numbers.Pop();
        }

        private double Operation(char mathOperator, double furstNumber, double secondNumber)
        {
            if (mathOperator == '+')
            {
                return furstNumber + secondNumber;
            }
            else if (mathOperator == '-')
            {
                return furstNumber - secondNumber;
            }
            else if (mathOperator == '*')
            {
                return furstNumber * secondNumber;
            }
            else if (mathOperator == '/')
            {
                if (secondNumber == 0)
                {
                    throw new ArgumentException("Cannot divide by zero!");
                }
                return furstNumber / secondNumber;
            }
            else
            {
                throw new ArgumentException("Invalid math operator!");
            }
        }

        private int OperatorsPriority(char mathOperator)
        {
            if (mathOperator == '+')
            {
                return 1;
            }
            else if (mathOperator == '-')
            {
                return 1;
            }
            else if (mathOperator == '*')
            {
                return 2;
            }
            else if (mathOperator == '/')
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}

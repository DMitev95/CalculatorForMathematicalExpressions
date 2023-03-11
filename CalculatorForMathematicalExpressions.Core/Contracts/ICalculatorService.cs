using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForMathematicalExpressions.Core.Contracts
{
    public interface ICalculatorService
    {
        double Calculate(string mathExpression);
    }
}

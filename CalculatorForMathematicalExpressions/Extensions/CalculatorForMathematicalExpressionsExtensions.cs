using CalculatorForMathematicalExpressions.Core.Contracts;
using CalculatorForMathematicalExpressions.Core.Services;

namespace CalculatorForMathematicalExpressions.Extensions
{
    public static class CalculatorForMathematicalExpressionsExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICalculatorService, CalculatorService>();
            
            return services;
        }
    }
}

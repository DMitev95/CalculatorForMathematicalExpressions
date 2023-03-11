using CalculatorForMathematicalExpressions.Core.Contracts;
using CalculatorForMathematicalExpressions.Core.Model;
using CalculatorForMathematicalExpressions.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorForMathematicalExpressions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculatorService calculatorService;

        public CalculateController(ICalculatorService _calculatorService)
        {
            calculatorService = _calculatorService;
        }

        [HttpPost]
        public async Task<ActionResult<CalculateResponseModel>> Calculate(CalculatorModel model)
        {
            try
            {
                var result = calculatorService.Calculate(model.Pattern);

                return new CalculateResponseModel { Result = result.ToString() };
            }
            catch (Exception ex)
            {
                return new CalculateResponseModel { Result = ex.Message };
            }
        }
    }
}

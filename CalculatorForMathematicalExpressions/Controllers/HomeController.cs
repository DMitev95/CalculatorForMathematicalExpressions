using CalculatorForMathematicalExpressions.Core.Contracts;
using CalculatorForMathematicalExpressions.Core.Model;
using CalculatorForMathematicalExpressions.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CalculatorForMathematicalExpressions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICalculatorService _calculatorService)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
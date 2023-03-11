using CalculatorForMathematicalExpressions.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorForMathematicalExpressions.Controllers
{
    public class HomeController : Controller
    {       
        public IActionResult Index()
        {
            return View();
        }      
    }
}
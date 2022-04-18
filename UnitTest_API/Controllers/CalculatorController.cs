using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitTest_API.Serivces;

namespace UnitTest_API.Controllers
{
 
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private ICalculatorService _calculatorService = null;
        public CalculatorController(ICalculatorService calculatorService)
        {
                this._calculatorService = calculatorService;
        }


        [HttpPost]
        //[Route("Add")]
        public double Add(double x1, double x2)
        {
            return _calculatorService.Add(x1, x2);
        }
        [HttpPost]
        //[Route("Divide")]
        public double Divide(double x1, double x2)
        {
            return _calculatorService.Divide(x1, x2);
        }
        [HttpPost]
        //[Route("Multiply")]
        public double Multiply(double x1, double x2)
        {
            return _calculatorService.Multiply(x1, x2);
        }
        [HttpPost]
        //[Route("Subtract")]
        public double Subtract(double x1, double x2)
        {
            return _calculatorService.Subtract(x1, x2);
        }
    }
}

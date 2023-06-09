
using Calculator.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Calculator.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            // Create a new ViewModel
            CalculatorViewModel model = new CalculatorViewModel
            {
                Number1 = "",
                Number2 = "",
                Operation = "",
                Result = ""
            };

            // Return the view
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CalculatorViewModel model)
        {
            // Validate the input
            if (string.IsNullOrEmpty(model.Number1))
            {
                // Set the error message
                model.ErrorMessage = "Please enter a number in the first field.";
            }
            else if (string.IsNullOrEmpty(model.Number2))
            {
                // Set the error message
                model.ErrorMessage = "Please enter a number in the second field.";
            }
            else if (string.IsNullOrEmpty(model.Operation))
            {
                // Set the error message
                model.ErrorMessage = "Please select an operation.";
            }
            else
            {
                // Perform the calculation
                int result = 0;
                switch (model.Operation)
                {
                    case "+":
                        result = Convert.ToInt32(model.Number1) + Convert.ToInt32(model.Number2);
                        break;
                    case "-":
                        result = Convert.ToInt32(model.Number1) - Convert.ToInt32(model.Number2);
                        break;
                    case "*":
                        result = Convert.ToInt32(model.Number1) * Convert.ToInt32(model.Number2);
                        break;
                    case "/":
                        result = Convert.ToInt32(model.Number1) / Convert.ToInt32(model.Number2);
                        break;
                }

                // Set the result in the view model
                model.Result = result.ToString();
            }

            // Return the view
            return View(model);
        }


    }
}
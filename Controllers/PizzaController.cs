using Logistics.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Logistics.Controllers
{
    public class PizzaController : Controller
    {
        private string _topping = "pineapple";
        private string _department = "Engineering";

        public ActionResult Index(string filePath)
        {
            StreamReader reader = new(filePath);
            string pizzaJson = reader.ReadToEnd();
            var employeeList = JsonConvert.DeserializeObject<List<Employee>>(pizzaJson);

            if (employeeList != null)
            {
                var statistics = new PizzaStatistics(employeeList)
                {
                    ToppingToCount = _topping,
                    DepartmentToFeed = _department
                };

                return View(statistics);            
            }

            return View();
        }      
    }
}

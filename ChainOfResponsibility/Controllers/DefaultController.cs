using ChainOfResponsibility.ChainOfResponsibility;
using ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee cashier = new Cashier();
            Employee assistantManager = new AssistantManager();
            Employee manager = new Manager();
            Employee regionManager = new RegionManager();

            cashier.SetNextApprover(assistantManager);
            assistantManager.SetNextApprover(manager);
            manager.SetNextApprover(regionManager);

            cashier.ProcessRequest(model);

            return View();
        }
    }
}

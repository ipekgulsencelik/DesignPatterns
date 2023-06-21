using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDesignPattern.Models;

namespace UnitOfWorkDesignPattern.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly ICustomerService _customerService;

        public SendMoneyController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerViewModel model)
        {

            var sender = _customerService.TGetByID(model.SenderID);
            var receiver = _customerService.TGetByID(model.ReceiverID);

            sender.CustomerBalance -= model.Amount;
            receiver.CustomerBalance += model.Amount;

            List<Customer> modifiedCustomers = new List<Customer>()
            {
                sender,
                receiver
            };

            _customerService.TMultiUpdate(modifiedCustomers);

            return View();
        }
    }
}

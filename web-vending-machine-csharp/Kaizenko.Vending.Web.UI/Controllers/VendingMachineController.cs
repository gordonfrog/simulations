using Kaizenko.Vending.Machine;
using Kaizenko.Vending.Web.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kaizenko.Vending.Web.UI.Controllers
{
    public class VendingMachineController : Controller
    {
        private readonly IVendingMachine _vendingMachine;

        public VendingMachineController(IVendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }

        public ActionResult Index()
        {
            var viewModel = new VendingMachineViewModel
            {
                Balance = _vendingMachine.Balance,
                ReleasedChange = 0,
                Message = _vendingMachine.Message
            };

            return View(viewModel);
        }

        public ActionResult IndexWithChange(int releasedChange, string message)
        {
            var viewModel = new VendingMachineViewModel
            {
                Balance = _vendingMachine.Balance,
                ReleasedChange = releasedChange,
                Message = message
            };

            return View("Index", viewModel);
        }

        public ActionResult InsertCoin()
        {
            _vendingMachine.InsertCoin();
            return RedirectToAction("Index");
        }

        public ActionResult ReleaseChange()
        {
            var releasedChange = _vendingMachine.ReleaseChange();
            var message = _vendingMachine.Message;

            return RedirectToAction("IndexWithChange", new { ReleasedChange = releasedChange, Message = message });
        }

        public ActionResult BuyProduct()
        {
            _vendingMachine.BuyProduct();
            var releasedChange = 0;
            var message = _vendingMachine.Message;
            return RedirectToAction("IndexWithChange", new { ReleasedChange = releasedChange, Message = message});            
        }
    }
}
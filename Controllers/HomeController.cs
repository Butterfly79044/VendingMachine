using Microsoft.AspNetCore.Mvc;
using VendingMachine.Models;
using VendingMachine.Repository;

namespace VendingMachine.Controllers
{
    public class HomeController : Controller
    {
        private readonly DrinkRepository _drinkRepository;

        public HomeController(DrinkRepository drinkRepository)
        {
            this._drinkRepository = drinkRepository;
        }

        public IActionResult Index()
        {
            var obj = _drinkRepository.GetDrinks();
            return View(obj);
        }

        [HttpPost]
        public IActionResult BuyDrink(int id)
        {
            _drinkRepository.BuyDrink(id);
            return RedirectToAction("Panel");
        }
    }
}

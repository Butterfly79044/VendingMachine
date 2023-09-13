using Microsoft.AspNetCore.Mvc;
using VendingMachine.Models;
using VendingMachine.Repository;

namespace VendingMachine.Controllers
{
    public class AdminController : Controller
    {
        private readonly DrinkRepository _drinkRepository;

        public AdminController(DrinkRepository drinkRepository)
        {
            this._drinkRepository = drinkRepository;
        }

        public IActionResult Panel()
        {
            var model = _drinkRepository.GetDrinks();
            return View(model);
        }

        public IActionResult EditDrink(int id)
        {
            Drink model = id == default ? new Drink() : _drinkRepository.GetDrink(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditDrink(Drink model)
        {
            if (ModelState.IsValid)
            {
                _drinkRepository.SaveDrink(model);
                return RedirectToAction("Panel");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteDrink(int id)
        {
            _drinkRepository.DeleteDrink(new Drink { ID = id });
            return RedirectToAction("Panel");
        }
    }
}

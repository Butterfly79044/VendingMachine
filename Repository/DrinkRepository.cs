using System.Web.Mvc;
using VendingMachine.Models;

namespace VendingMachine.Repository
{
    public class DrinkRepository
    {
        private readonly DBContent appDBContent;

        public DrinkRepository(DBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IQueryable<Drink> GetDrinks()
        {
            return appDBContent.Drinks.OrderBy(x => x.Name);
        }

        public Drink GetDrink(int id)
        {
            return appDBContent.Drinks.Single(x => x.ID == id);
        }

        public int SaveDrink(Drink entity)
        {
            if (entity.ID == default)
            {
                appDBContent.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                appDBContent.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            appDBContent.SaveChanges();
            return entity.ID;
        }

        public void DeleteDrink(Drink entity)
        {
            appDBContent.Remove(entity);
            appDBContent.SaveChanges();
        }

        public void BuyDrink(int id)
        {
            if(GetDrink(id) != null)
            {
                appDBContent.Drinks.Select(x => x.Qty - 1);
            }
        }
    }
}

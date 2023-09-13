using Microsoft.EntityFrameworkCore;
using VendingMachine.Models;

namespace VendingMachine
{
    public class DBContent : DbContext
    {
        public DBContent(DbContextOptions<DBContent> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Drink>().HasData(new Drink
            {
                ID = 1,
                Name = "Кока-кола",
                Img = "https://img.fix-price.com/800x800/images/origin/origin/fc6260a7ec3553b7c06c8a599ce971c3.jpg",
                Qty = 10,
                Price = 100
            });
        }

        public DbSet<Drink> Drinks { get; set; }
    }
}

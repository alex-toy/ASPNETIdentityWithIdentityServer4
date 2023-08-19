using API.Models;
using DataAccess.Data;

namespace API.Services
{
    public class CoffeeShopService : ICoffeeShopService
	{
        private readonly ApplicationDbContext dbContext;

        public CoffeeShopService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<CoffeeShopModel>> List()
        {
            List<CoffeeShopModel> coffeeShops = dbContext.CoffeeShops.Select(shop => new CoffeeShopModel()
            {
                Id = shop.Id,
                Name = shop.Name,
                OpeningHours = shop.OpeningHours,
                Address = shop.Address
            }).ToList();

            return coffeeShops;
        }
    }
}

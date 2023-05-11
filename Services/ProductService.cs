using KRK_Class7_Task1.Abstracts;
using KRK_Class7_Task1.Data;
using KRK_Class7_Task1.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace KRK_Class7_Task1.Services
{
    public class ProductService : IProductService
    {

        private readonly MyDbContext _dbContext;
        public ProductService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Przemapowanie danych z DbSet<Product> na obiekt ProductListViewModel.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductListViewModel>> GetAll()
        {
            var data = await _dbContext.Products.AsNoTracking().Select(
                    x => new ProductListViewModel
                    {
                        ProductID = x.ProductID,
                        Name = x.Name,
                        Price = x.Price
                    }
                ).ToListAsync();

            return data;
        }
    }
}

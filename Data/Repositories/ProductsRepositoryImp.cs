using Data.Context;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ProductsRepositoryImp : ProductsRepository
    {
        private DataContext _dataContext;

        public ProductsRepositoryImp(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Products>> GetAll(int pageNumber, int pageSize)
        {
            var products = await _dataContext.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return products;
        }
    }
}

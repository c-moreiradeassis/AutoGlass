using Domain.Models;

namespace Domain.Repositories
{
    public interface ProductsRepository
    {
        Task<List<Products>> GetAll(int pageNumber, int pageSize);
        Task<Products> GetByCode(int code);
    }
}

using Application.Dtos;

namespace Application.Interfaces
{
    public interface ProductManagerService
    {
        Task AddProduct(ProductsDto product);
    }
}

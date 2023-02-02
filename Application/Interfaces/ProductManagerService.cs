using Application.Dtos;

namespace Application.Interfaces
{
    public interface ProductManagerService
    {
        Task AddProduct(ProductsDto productDto);
        Task DeleteProduct(ProductsDto productDto);
        Task<IEnumerable<ProductsDto>> GetAll(int pageNumber, int pageSize);
        Task<ProductsDto> GetByCode(int code);
        Task UpdateProduct(ProductsDto productDto);
    }
}

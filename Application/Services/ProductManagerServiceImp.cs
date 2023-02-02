using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class ProductManagerServiceImp : ProductManagerService
    {
        private BaseRepository _repository;
        private ProductsRepository _productsRepository;
        private IMapper _mapper;

        public ProductManagerServiceImp(BaseRepository repository, IMapper mapper, ProductsRepository productsRepository)
        {
            _repository = repository;
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductsDto productDto)
        {
            Products product = _mapper.Map<Products>(productDto);

            _repository.AddEntity(product);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteProduct(ProductsDto productDto)
        {
            Products products = _mapper.Map<Products>(productDto);
            products.Situation = false;

            _repository.UpdateEntity(products);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductsDto>> GetAll(int pageNumber, int pageSize)
        {
            var result = await _productsRepository.GetAll(pageNumber, pageSize);

            var products = _mapper.Map<IEnumerable<ProductsDto>>(result);

            return products;
        }

        public async Task<ProductsDto> GetByCode(int code)
        {
            var result = await _productsRepository.GetByCode(code);

            var product = _mapper.Map<ProductsDto>(result);

            return product;
        }

        public async Task UpdateProduct(ProductsDto productDto)
        {
            Products products = _mapper.Map<Products>(productDto);

            _repository.UpdateEntity(products);
            await _repository.SaveChangesAsync();
        }
    }
}

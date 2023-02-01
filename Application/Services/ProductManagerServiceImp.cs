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
        private IMapper _mapper;

        public ProductManagerServiceImp(BaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductsDto productDto)
        {
            Products product = _mapper.Map<Products>(productDto);

            _repository.AddEntity(product);
            await _repository.SaveChangesAsync();
        }
    }
}

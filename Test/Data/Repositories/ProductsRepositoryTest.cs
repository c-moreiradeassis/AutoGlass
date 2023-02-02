using Data.Repositories;
using Domain.Models;
using Domain.Repositories;
using FluentAssertions;
using Test.Data.Context;
using Xunit;

namespace Test.Data.Repositories
{
    public class ProductsRepositoryTest : DataContextTest
    {
        private BaseRepository _repository;
        private ProductsRepository _productsRepository;

        public ProductsRepositoryTest()
        {
            _repository = new BaseRepositoryImp(_context);
            _productsRepository = new ProductsRepositoryImp(_context);
        }

        [Fact]
        public void GetAll_Should_Be_Success()
        {
            CreateData();

            var result = _productsRepository.GetAll(1, 10);

            result.Result.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void GetByCode_Should_Be_Success()
        {
            var products = CreateData();

            var productConsulted = products.First();

            var result = _productsRepository.GetByCode(productConsulted.Code);

            result.Result.Should().NotBeNull();
            result.Result.Code.Should().Be(1);
            result.Result.CodeProvider.Should().Be(productConsulted.CodeProvider);
            result.Result.Description.Should().Be(productConsulted.Description);
            result.Result.ManufactureDate.Should().Be(productConsulted.ManufactureDate);
            result.Result.ValidityDate.Should().Be(productConsulted.ValidityDate);
            result.Result.Situation.Should().Be(productConsulted.Situation);
        }

        private List<Products> CreateData()
        {
            var provider = new Providers()
            {
                Description = "Test_Provider",
                CNPJ = "31.844.354/0001-46"
            };

            _repository.AddEntity(provider);
            _repository.SaveChangesAsync();

            List<Products> products = new List<Products>();

            products.Add(new Products()
            {
                CodeProvider = provider.Code,
                Description = "Test_Product",
                ManufactureDate = DateTime.Now,
                ValidityDate = DateTime.Now.AddYears(2),
                Situation = true
            });

            products.Add(new Products()
            {
                CodeProvider = provider.Code,
                Description = "Test_Product_2",
                ManufactureDate = DateTime.Now,
                ValidityDate = DateTime.Now.AddYears(2),
                Situation = true
            });

            products.Add(new Products()
            {
                CodeProvider = provider.Code,
                Description = "Test_Product_3",
                ManufactureDate = DateTime.Now,
                ValidityDate = DateTime.Now.AddYears(2),
                Situation = true
            });

            foreach (var item in products)
            {
                _repository.AddEntity(item);
            }

            _repository.SaveChangesAsync();

            return products;
        }
    }
}

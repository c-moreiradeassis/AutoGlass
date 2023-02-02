using Data.Repositories;
using Domain.Models;
using Domain.Repositories;
using FluentAssertions;
using Test.Data.Context;
using Xunit;

namespace Test.Data.Repositories
{
    public class BaseRepositoryTest : DataContextTest
    {
        private BaseRepository _repository;
        private ProductsRepository _productsRepository;

        public BaseRepositoryTest()
        {
            _repository = new BaseRepositoryImp(_context);
            _productsRepository = new ProductsRepositoryImp(_context);
        }

        [Fact]
        public void Add_Should_Be_Success()
        {
            Products product = CreateData();

            var result = _productsRepository.GetByCode(product.Code);

            result.Result.Should().NotBeNull();
            result.Result.Code.Should().Be(product.Code);
            result.Result.CodeProvider.Should().Be(product.CodeProvider);
            result.Result.Description.Should().Be(product.Description);
            result.Result.ManufactureDate.Should().Be(product.ManufactureDate);
            result.Result.ValidityDate.Should().Be(product.ValidityDate);
            result.Result.Situation.Should().Be(product.Situation);
        }

        [Fact]
        public void Update_Should_Be_Success()
        {
            Products product = CreateData();

            var result = _productsRepository.GetByCode(product.Code);

            product.Description = "Test_Update";
            product.ManufactureDate = DateTime.Now.AddDays(30);
            product.ValidityDate = DateTime.Now.AddYears(1);

            _repository.UpdateEntity(product);
            _repository.SaveChangesAsync();

            var resultUpdated = _productsRepository.GetByCode(product.Code);

            resultUpdated.Result.Should().NotBeNull();
            resultUpdated.Result.Description.Should().Be(product.Description);
            resultUpdated.Result.ManufactureDate.Should().Be(product.ManufactureDate);
            resultUpdated.Result.ValidityDate.Should().Be(product.ValidityDate);
            resultUpdated.Result.Situation.Should().Be(product.Situation);
        }

        Products CreateData()
        {
            var provider = new Providers()
            {
                Description = "Test_Provider",
                CNPJ = "31.844.354/0001-46"
            };

            _repository.AddEntity(provider);
            _repository.SaveChangesAsync();

            var product = new Products()
            {
                CodeProvider = provider.Code,
                Description = "Test_Product",
                ManufactureDate = DateTime.Now,
                ValidityDate = DateTime.Now.AddYears(2),
                Situation = true
            };

            _repository.AddEntity(product);
            _repository.SaveChangesAsync();

            return product;
        }
    }
}

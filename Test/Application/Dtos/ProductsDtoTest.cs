using Application.Dtos;
using FluentAssertions;
using Xunit;

namespace Test.Applcation.Dtos
{
    public class ProductsDtoTest : Validation
    {
        [Fact]
        public void Products_Should_Be_Success()
        {
            var productDto = new ProductsDto
            {
                Description = "Test",
                Situation = true,
                ManufactureDate = DateTime.Now,
                ValidityDate = DateTime.Now.AddYears(1)
            };

            var errorCount = ValidationProperties(productDto);

            errorCount.Count.Should().Be(0);
        }

        [Fact]
        public void Products_When_Description_Is_Null_Should_Fail()
        {
            var productDto = new ProductsDto
            {
                Description = null,
                Situation = true,
                ManufactureDate = DateTime.Now,
                ValidityDate = DateTime.Now.AddYears(1)
            };

            var errorCount = ValidationProperties(productDto);

            errorCount.Count.Should().Be(1);
            errorCount[0].ErrorMessage.Should().Be("A descrição é obrigatória");
        }

        [Fact]
        public void Products_When_ManufactureDate_Is_Equal_ValidityDate_Should_Fail()
        {
            var date = DateTime.Now;

            var productDto = new ProductsDto
            {
                Description = "Test",
                Situation = true,
                ManufactureDate = date,
                ValidityDate = date
            };

            var errorCount = ValidationProperties(productDto);

            errorCount.Count.Should().Be(1);
            errorCount[0]
                .ErrorMessage
                .Should()
                .Be($"Data de fabricação {productDto.ManufactureDate} não pode ser maior que a data de validade {productDto.ValidityDate}.");
        }

        [Fact]
        public void Products_When_ManufactureDate_Is_Greather_ValidityDate_Should_Fail()
        {
            var productDto = new ProductsDto
            {
                Description = "Test",
                Situation = true,
                ManufactureDate = DateTime.Now.AddYears(1),
                ValidityDate = DateTime.Now
            };

            var errorCount = ValidationProperties(productDto);

            errorCount.Count.Should().Be(1);
            errorCount[0]
                .ErrorMessage
                .Should()
                .Be($"Data de fabricação {productDto.ManufactureDate} não pode ser maior que a data de validade {productDto.ValidityDate}.");
        }
    }
}

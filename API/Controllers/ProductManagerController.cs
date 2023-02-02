using API.Pagination;
using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductManagerController : ControllerBase
    {
        private ProductManagerService _productManagerService;

        public ProductManagerController(ProductManagerService productManagerService)
        {
            _productManagerService = productManagerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            try
            {
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

                var result = await _productManagerService.GetAll(validFilter.PageNumber, validFilter.PageSize);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NoContent();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByCode(int code)
        {
            try
            {
                var result = await _productManagerService.GetByCode(code);

                if (result != null)
                {
                    return Ok(result);
                }

                return NoContent();
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ProductsDto productDto)
        {
            try
            {
                await _productManagerService.AddProduct(productDto);

                var uri = Url.Action("Post");

                return Created(uri, productDto);
            }
            catch
            {
                throw;
            }
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch([FromBody] ProductsDto productsDto)
        {
            try
            {
                var product = await _productManagerService.GetByCode(productsDto.Code);

                if (product != null)
                {
                    await _productManagerService.UpdateProduct(productsDto);
                }

                return NoContent();
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int code)
        {
            try
            {
                var productDto = await _productManagerService.GetByCode(code);

                if (productDto != null)
                {
                    await _productManagerService.DeleteProduct(productDto);
                }

                return NoContent();
            }
            catch
            {
                throw;
            }
        }

        [Route("/error-development")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                type: "product",
                title: "Erro inesperado.",
                detail: exceptionHandlerFeature?.Error.Message);
        }

        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError() =>
            Problem();
    }
}
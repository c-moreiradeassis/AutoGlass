using API.Pagination;
using Application.Dtos;
using Application.Interfaces;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var result = await _productManagerService.GetAll(validFilter.PageNumber, validFilter.PageSize);

            if (result.Any())
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ProductsDto productDto)
        {
            await _productManagerService.AddProduct(productDto);

            var uri = Url.Action("Post");

            return Created(uri, productDto);
        }

        [HttpPatch]
        public ActionResult Patch()
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return Ok();
        }
    }
}
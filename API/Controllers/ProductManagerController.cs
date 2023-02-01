using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public ActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProductsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(ProductsDto productDto)
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
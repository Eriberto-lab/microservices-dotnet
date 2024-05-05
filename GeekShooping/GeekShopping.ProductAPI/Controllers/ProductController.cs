using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);

           if (product.Id <= 0) return NotFound();

           return Ok(product);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAll();

            return Ok(products);
        }

        [HttpPost]

        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO product)
        {
            if (product == null) return BadRequest();

             ProductVO newProduct = await _repository.Create(product);

            return Ok(newProduct);
        }

        [HttpPut]

        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO product)
        {
            if (product == null) return BadRequest();

            ProductVO updateProduct = await _repository.Update(product);

            return Ok(updateProduct);
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(long id)
        {
           
           bool status = await _repository.Delete(id);

            if (!status) return BadRequest();

            return Ok(status);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Products.Core.Dtos;
using Products.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Products.API.Controllers
{
    [Route("[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService) 
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductLookupDto>>> Get()
        {
            var products = await _productsService.GetAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(Guid id)
        {
            var product = await _productsService.GetById(id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post([FromBody] ProductCreateDto dto, CancellationToken cancellationToken)
        {
            var result = await _productsService.Create(dto, UserId, cancellationToken);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ProductDto dto, CancellationToken cancellationToken)
        {
            var result = await _productsService.Update(dto, UserId, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _productsService.Delete(id, UserId, cancellationToken);

            return Ok();
        }
    }
}

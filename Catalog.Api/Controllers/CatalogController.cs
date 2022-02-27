using Catalog.Api.Entities;
using Catalog.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public CatalogController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetProducts();
            return products == null ? BadRequest() : Ok(products);
        }

        [HttpGet("products/{id}")]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _repository.GetProductsById(id);
            return product == null ? BadRequest() : Ok(product);
        }

        [HttpGet("products/{category}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var product = await _repository.GetProductsByCategory(category);
            return product == null ? BadRequest() : Ok(category);
        }

        [HttpPost("product/crt")]
        public async Task<ActionResult> CreateProdut([FromBody] Product product)
        {
            if (product is null)
            {
                BadRequest("Invalid Produtct");
            }

            await _repository.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("product/upd")]
        public async Task<ActionResult> UpdateProduct([FromBody] Product product)
        {
            if(product is null) 
                return BadRequest("Invalid Update");

            return Ok(await _repository.UpdateProduct(product));
        }

        [HttpDelete("product/delete/{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            var product = await _repository.DeleteProduct(id);
            return product == null ? BadRequest("Produtct ID Dont Exists") : Ok(product);
        }
    }
}   

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restore.Core.Data.Repository;
using Restore.Core.Models;

namespace Restore.API.Controllers
{
    public class ProductsController: BaseApiController
    {
        private readonly IProductRepository _pRepo;
        public ProductsController(IProductRepository pRepo)
        {
            _pRepo = pRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var products = await _pRepo.GetPostsAsync();
                return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById( long id)
        {
            if (id <= 0)
            {
               return BadRequest("id is required");
            }

                var product = await _pRepo.GetPostById(id);
                if (product == null)
                {
                    return NotFound("item not found");
                }

                return Ok(product);
        }
    }
}
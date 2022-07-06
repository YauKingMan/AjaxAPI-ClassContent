using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjAjaxAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjAjaxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }

        //GET http://localhost:..../api/products
        [HttpGet]
        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }

        //GET http://localhost:..../api/products/12
        [HttpGet("{id}")]
        public Product GetProducts(int id)
        {
            return _context.Products.Find(id);
        }

        //GET http://localhost:..../api/products/category/2

        [Route("category/{id}")]
        [HttpGet]
        public IQueryable<Product> GetProductsByCategoryId(int id)
        {
            return _context.Products.Where(p => p.CategoryId == id);
        }

        [Route("supplier/{id:int}")]
        [HttpGet]
        public IQueryable<Product> GetProductsBySupplerId(int id)
        {
            return _context.Products.Where(p => p.SupplierId == id);
        }

        //[Route("supplier/{id:string}")]
        //[HttpGet]
        //public string GetProductsBySupplerId(string id)
        //{
        //    return id;
        //}

        //GET http://localhost:..../api/products/10/20
        [Route("{min}/{max}")]
        [HttpGet]
        public IQueryable<Product> GetProductsByPrice(decimal min, decimal max)
        {
            return _context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}

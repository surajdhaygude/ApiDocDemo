using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockWebApiDemo.Models;

namespace DockWebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>();
        static ProductsController()
        {
            products.Add(new Product { Id = 1, ProductName = "Pen", Price = 10 });
            products.Add(new Product { Id = 2, ProductName = "Book", Price = 50 });
        }
      
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return products.Find(e => e.Id == id);
        }
        [HttpPost]
        public string Post([FromBody] Product product)
        {
            if(product==null)
            {
                throw new ArgumentNullException("product");
            }
            products.Add(product);
            return "product added ";
        }
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }
            int Index = products.FindIndex(p => p.Id==product.Id);
            if (Index == -1)
            {
                return false;
            }
            products.RemoveAt(Index);
            products.Add(product);
            return true;

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
        
    }
}

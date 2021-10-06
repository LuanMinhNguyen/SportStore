using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        public ProductController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public IActionResult List(string category)
            =>View(new ProductListViewModels() 
            {
                  Products = productRepository.Products
                  .Where(p => category == null || p.Category == category)
                  .OrderBy(p => p.ProductId) 
            });
        
    }
}

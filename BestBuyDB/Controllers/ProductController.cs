using BestBuyDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuyDB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }
        //view all products Page
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }
        //view product Page
        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProductById(id);
            return View(product);
        }
    }
}

using BestBuyDB.Models;
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
        //Create Products
        public IActionResult CreateProduct()
        {
            var product = repo.AssignCategory();
            return View(product);
        }
        public IActionResult InsertNewProduct(Product product) 
        {
            repo.CreateProduct(product);
            return RedirectToAction("Index");
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

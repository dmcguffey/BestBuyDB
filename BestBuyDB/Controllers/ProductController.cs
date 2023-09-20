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

        //Update Product information
        public IActionResult UpdateProduct(int id)
        {
            Product product = repo.GetProductById(id);
            if(product ==  null)
            {
                return View("Product Not Found");
            }
            return View(product);
        }
        //insert new info into the database
        public IActionResult InsertUpdatedInfo(Product product)
        {
            try
            {
                repo.UpdateProduct(product);
                return RedirectToAction("ViewProduct", new {id = product.ProductID});
            }
            catch (Exception ex)
            {
                return View("Error on updating product information. Please try again.");
            }
        }

        //Delete Product
        public IActionResult DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);
            return RedirectToAction("Index");
        }
    }
}

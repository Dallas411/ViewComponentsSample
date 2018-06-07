using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewComponentsSample.Models;
using ViewComponentsSample.Services;

namespace ViewComponentsSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService) => _productService = productService;

        public IActionResult Index() => View();

        public IActionResult ChildAction(int numberOfItems, int skipItems)
        {
            ViewBag.PrintTitle = skipItems == 0 ? true : false;
            var products = numberOfItems == 0 ? _productService.GetAll().Skip(skipItems) : _productService.GetAll().Skip(skipItems).Take(numberOfItems);
            return View("~/Views/Shared/Components/Product/Default.cshtml", products);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentsSample.Services;

namespace ViewComponentsSample.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly ProductService _productService;

        public ProductViewComponent(ProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke(int numberOfItems, int skipItems)
        {
            ViewBag.PrintTitle = skipItems == 0 ? true : false;
            var products = _productService.GetAll().Skip(skipItems).Take(numberOfItems);
            return View(products);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftsStore.Web.Models;
using CraftsStore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CraftsStore.Web.Pages
{
    public class DetailsModel : PageModel
    {

        private readonly JsonFileProductService _productService;

        public DetailsModel(JsonFileProductService productService)
        {
            _productService = productService;
        }

        [BindProperty(SupportsGet =true)]
        public string Id { get; set; }

        public Product Product { get;private set; }
        public void OnGet()
        { 
            Product = _productService.GetProduct(Id);
        }
    }
}

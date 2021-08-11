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
    public class MakerProductsModel : PageModel
    {

        private readonly JsonFileProductService _ProductService;

        public MakerProductsModel(JsonFileProductService productService)
        {
            _ProductService = productService;
        }

        [BindProperty(SupportsGet = true)]
        public string Maker { get; set; }

        public IEnumerable<Product> Products { get; private set; }
        public void OnGet()
        {
            Products = _ProductService.GetMakerProducts(Maker);

        }
    }
}

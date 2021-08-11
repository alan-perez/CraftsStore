using CraftsStore.Web.Models;
using CraftsStore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftsStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly JsonFileProductService _ProductService;

        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService jsonFileProductService)
        {
            _logger = logger;
            _ProductService = jsonFileProductService;
        }

        public IEnumerable<Product> Products { get; private set; }


        public void OnGet()
        {
            Products = _ProductService.GetProducts();
        }
    }
}

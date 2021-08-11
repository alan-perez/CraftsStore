using CraftsStore.Web.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CraftsStore.Web.Services
{
    public class JsonFileProductService
    {
        public readonly IWebHostEnvironment _WebHostEnvironment;
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            _WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(_WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        public IEnumerable<Product> GetProducts()
        {
            // leer nuestro archivo de json
            using var jsonFileReader = File.OpenText(JsonFileName);
            //regresarlo en objeto de .net
            return JsonSerializer.Deserialize<List<Product>>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ;

        }

        public Product GetProduct(string id)
        {
            var product = GetProducts();

            return product.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Product> GetMakerProducts(string maker)
        {
            return GetProducts().Where(c =>c.Maker == maker);
        }



    }

    

}

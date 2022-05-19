using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Пример использование фильтров на null и применение дефолтных знамений 
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            var results = new List<string>();
            foreach (Product product in Product.GetProduct())
            {
                string name = product?.Name ?? "<No Name>";
                decimal? price = product?.Person ?? 0;
                string relatedName = product?.Related?.Name ?? "<No Name>";

                results.Add($"Name:  {name} ,  Price: {price:C2},  Related: {relatedName}");
            }

            return View(results);
        }

        public ViewResult IndexDictionary() //Использование инициализатора индексированной коллекции
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                ["Kayak"] = new Product() {Name = "Kayak", Person = 275M},
                ["Lifejacket"] = new Product() {Name = "Lifejacket", Person = 48.95M},
            };
            return View("Index", products.Keys);
        }

        /// <summary>
        /// Использование расширяющих методов и преимущества реализации IEnumerable<> позволяющий взаимодействовать с любым перечислением объектов.
        /// </summary>
        /// <returns></returns>
        public ViewResult IndexExtension()
        {
            ShoppingCart cart = new ShoppingCart {Products = Product.GetProduct()};
            Product[] product =
            {
                new Product {Name = "Kayak", Person = 275M},
                new Product {Name = "Lifejacket", Person = 48.95M},
            };
            decimal arreyTotel = product.TotalPrices();
            decimal cartTotal = cart.TotalPrices();

            return View("Index", new string[]
            {
                $"Total: {cartTotal:C2}",
                $"Total: {arreyTotel:C2}",
                $"Total: {cartTotal + arreyTotel:C2}"
            });
        }
        
        /// <summary>
        /// Применение фильтрующего расширения метода  MyExtensionMethobs.FilterByPrice и MyExtensionMethobs.FilterByName
        /// </summary>
        /// <returns></returns>
        public ViewResult IndexFilterByPrice()
        {
            Product[] product =
            {
                new Product {Name = "one", Person = 275M},
                new Product {Name = "two", Person = 12.95M},
                new Product {Name = "three", Person = 200M},
                new Product {Name = "four", Person = 8.95M},
                new Product {Name = "five", Person = 27M},
                new Product {Name = "Lifejacket", Person = 44.95M},
            };
            decimal arreyTotel = product.TotalPrices();
            decimal arreyTotelMin = product.FilterByPrice(100).TotalPrices();
            
            decimal nameFiltrTotel = product.FilterByName('f').TotalPrices();
           
            return View("Index", new string[]
            {
                $"Total: {arreyTotel:C2}",
                $"Arrey Total Min: {arreyTotelMin:C2}",
                $"Arrey Total Min: {nameFiltrTotel:C2}",
            });
        }
        
        /// <summary>
        /// Применение фильтрующего расширения метода  MyExtensionMethobs.Filter
        /// </summary>
        /// <returns></returns>
        public ViewResult IndexFilter()
        {
            Product[] product =
            {
                new Product {Name = "one", Person = 275M},
                new Product {Name = "two", Person = 12.95M},
                new Product {Name = "three", Person = 200M},
                new Product {Name = "four", Person = 8.95M},
                new Product {Name = "five", Person = 27M},
                new Product {Name = "Lifejacket", Person = 44.95M},
            };
           
            decimal arreyTotel = product.TotalPrices();
            decimal arreyTotelMin = product
                .Filter(p => (p?.Person ?? 0) >= 200)
                .TotalPrices();
            
            decimal nameFiltrTotel = product
                .Filter(p => (p?.Name?[0]) == 'f')
                .TotalPrices();
           
            return View("Index", new string[]
            {
                $"Total: {arreyTotel:C2}",
                $"Arrey Total Min: {arreyTotelMin:C2}",
                $"Arrey Total Min: {nameFiltrTotel:C2}",
            });
        }
    }
}
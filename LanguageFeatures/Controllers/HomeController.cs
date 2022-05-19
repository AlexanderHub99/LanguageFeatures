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
            return View("IndexDictionary", products.Keys);
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

            return View("IndexExtension", new string[]
            {
                $"Total: {cartTotal:C2}",
                $"Total: {arreyTotel:C2}",
                $"Total: {cartTotal + arreyTotel:C2}"
            });
        }
    }
}
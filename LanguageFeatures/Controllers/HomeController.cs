using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var results = new List<string>();
            foreach (Product product in Product.GetProduct())
            {
                string name = product?.Name ?? "<No Name>"; //проверка на null в избежание NullReferenceException и добавление дефолтного значения .
                decimal? price = product?.Person ?? 0; //проверка на null в избежание NullReferenceException и добавление дефолтного значения .
                string relatedName = product?.Related?.Name ?? "<No Name>"; //проверка на null в избежание NullReferenceException и добавление дефолтного значения .
                results.Add($"Name:  {name} ,  Price: {price:C2},  Related: {relatedName}");
            }
            return View(results);
        }

        public ViewResult IndexDictionary()//Использование инициализатора индексированной коллекции
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                ["Kayak"]= new Product(){ Name = "Kayak", Person = 275M},
                ["Lifejacket"]= new Product(){Name = "Lifejacket" , Person = 48.95M},
            };
            return View("IndexDictionary",products.Keys );
        }

        public ViewResult IndexExtension()
        {
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProduct()};
            decimal cartTotal = cart.TotalPrices();
            
            return View("IndexExtension", new string[] {$"Total: {cartTotal:C2}"});
        }
    }
}
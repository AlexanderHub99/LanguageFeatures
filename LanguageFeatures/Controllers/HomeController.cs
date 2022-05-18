using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
public class HomeController: Controller
{
    public ViewResult Index()
    {
        List<string> results = new List<string>();
        foreach (Product product in Product.GetProduct())
        {
            string name = product?.Name ?? "<No Name>";                 //проверка на null в избежание NullReferenceException и добавление дефолтного значения .
            decimal? price = product?.Person ?? 0;              //проверка на null в избежание NullReferenceException и добавление дефолтного значения .
            string relatedName = product?.Related?.Name ?? "<No Name>";   //проверка на null в избежание NullReferenceException и добавление дефолтного значения .
            results.Add($"Name:  {name} ,  Price: {price},  Related: {relatedName}");
        }
        return View(results);
    }
}
}
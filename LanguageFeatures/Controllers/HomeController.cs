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
            string name = product?.Name!;                 //проверка на null в избежании NullReferenceException
            decimal? price = product?.Person;             //проверка на null в избежании NullReferenceException
            string relatedName = product?.Related?.Name!; //проверка на null в избежании NullReferenceException
            results.Add($"Name:  {name} ,  Price: {price},  Related: {relatedName}");
        }
        return View(results);
    }
}
}
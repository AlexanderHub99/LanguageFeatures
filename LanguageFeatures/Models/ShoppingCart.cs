namespace LanguageFeatures.Models
{
    public class ShoppingCart// Класс оболочка для List
    {
        public IEnumerable<Product> Products { get; set; }
    }
}


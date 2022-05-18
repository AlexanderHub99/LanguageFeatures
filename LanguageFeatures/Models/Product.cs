namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Person { get; set; }
        public Product  Related { get; set; } //Добавил вложенности для усложнения 

        public static Product[] GetProduct()
        {
            Product kayak = new Product{ Name = "kayak", Person = 276m};
            Product lifejacket = new Product{ Name = "lifejacket", Person = 48.95m};
            kayak.Related = lifejacket;

            return new Product[] {kayak, lifejacket, null};//Добавил нулевую ссылку для усложнения и реализации проверки на null
        }
    }
}


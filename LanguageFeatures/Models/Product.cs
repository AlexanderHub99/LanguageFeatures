namespace LanguageFeatures.Models
{
    public class Product
    {
        public Product(bool stock = true)
        {
            InStock = InStock;
        }
        public string Name { get; set; } = null!;
        public string Category { get; set; } = "Watersports";
        public decimal? Person { get; set; }
        public Product  Related { get; set; } = null!; //Добавил вложенности для усложнения 

        public bool InStock { get; } 

        public static Product[] GetProduct()
        {
            Product kayak = new Product{ Name = "kayak", Category = "Water Craft", Person = 276m,};
            Product lifejacket = new Product(false){ Name = "lifejacket", Person = 48.95m};
            kayak.Related = lifejacket;

            return new Product[] {kayak, lifejacket, null};//Добавил нулевую ссылку для усложнения и реализации проверки на null
        }
    }
}


namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Person { get; set; }

        public static Product[] GetProduct()
        {
            Product kayak = new Product{ Name = "kayak", Person = 276m};
            Product lifejacket = new Product{ Name = "lifejacket", Person = 48.95m};

            return new Product[] {kayak, lifejacket, null};
        }
    }
}


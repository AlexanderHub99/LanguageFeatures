namespace LanguageFeatures.Models
{
    public static class MyExtensionMethobs//Класс с расширяемыми методами
    {
        public static decimal TotalPrices(this IEnumerable<Product> cartParam)
        {
            decimal total = 0;
            foreach (Product product in cartParam)
            {
                total += product?.Person ?? 0;
            }

            return total;
        }
    }
}


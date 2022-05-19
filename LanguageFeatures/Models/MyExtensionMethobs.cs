namespace LanguageFeatures.Models
{
    public static class MyExtensionMethobs//Класс с расширяемыми методами
    {
        public static decimal TotalPrices(this ShoppingCart cartParam)
        {
            decimal total = 0;
            foreach (Product product in cartParam.Products)
            {
                total += product?.Person ?? 0;
            }

            return total;
        }
    }
}


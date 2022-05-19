namespace LanguageFeatures.Models
{
    public static class MyExtensionMethobs //Класс с расширяемыми методами
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

        /// <summary>
        /// Расширяемый метод принимает дополнительный параметр, который позволяет фильтровать товары , как что в результате
        /// возвращаются объекты Product , значение свойства Person которых совпадает или превышает значение указанное в
        /// параметре minimumPrice.
        /// </summary>
        /// <param name="productEnum"></param>
        /// <param name="minimumPrice"></param>
        /// <returns></returns>
        public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> productEnum, decimal minimumPrice)
        {
            foreach (Product product in productEnum)
            {
                if ((product?.Person ?? 0) >= minimumPrice)
                {
                    yield return product;
                }
            }
        }
    }
}
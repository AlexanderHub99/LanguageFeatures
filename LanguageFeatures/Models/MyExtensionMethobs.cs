namespace LanguageFeatures.Models
{
    public static class MyExtensionMethobs //Класс с расширяемыми методами
    {
        /// <summary>
        /// Расширяемый метод 
        /// </summary>
        /// <returns>Сумму Product.Person</returns>
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
        /// Расширяемый метод принимает дополнительный параметр, который позволяет фильтровать товары по Price
        /// </summary>
        /// <param name="productEnum"></param>
        /// <param name="minimumPrice"></param>
        /// <returns>возвращаются объекты Product , значение свойства Person которых совпадает или превышает значение указанное в
        /// параметре minimumPrice.</returns>
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

        /// <summary>
        /// Расширяемый метод принимает дополнительный параметр, который позволяет фильтровать товары по Name
        /// </summary>
        /// <param name="productEnum"></param>
        /// <param name="minimumName"></param>
        /// <returns>возвращаются объекты Product , значение свойства Name которых совпадает c minimumName
        /// параметре minimumPrice.</returns>
        public static IEnumerable<Product> FilterByName(this IEnumerable<Product> productEnum, char minimumName)
        {
            foreach (Product product in productEnum)
            {
                if ((product?.Name?[0]) == minimumName)
                {
                    yield return product;
                }
            }
        }
        
        /// <summary>
        /// Расширяемый метод принимает аргумент (Лямбды -выражений)
        /// </summary>
        /// <param name="productEnum"></param>
        /// <param name="minimumName"></param>
        /// <returns>возвращаются объекты Product , значение свойства которых совпадает c Лямбдай
        /// параметре minimumPrice.</returns>
        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, bool> selector)
        {
            foreach (Product product in productEnum)
            {
                if (selector(product))
                {
                    yield return product;
                }
            }
        }
    }
}
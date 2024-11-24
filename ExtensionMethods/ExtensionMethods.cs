namespace ExtensionMethods
{
    internal static class ExtensionMethods
    {
        public static string GetFirstCharacter(this string input)
        {
            return input.Substring(0, 1);
        }

        public static string GetSeoUrl(this string text)
        {
            text = text.Replace(" ", "-").ToLower();
            text = text.Replace('ç', 'c');
            return text;
        }


        public static string GetFullName(this Product product)
        {
            return $"{product.Id} - {product.Name}";
        }
    }
}
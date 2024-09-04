namespace MovieWeb.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsString(this string propertyValue, string searchValue)
        {
            return propertyValue.Contains(searchValue, StringComparison.InvariantCultureIgnoreCase) ? true : false;
        }
    }
}

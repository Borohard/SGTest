namespace SGTest.Utils.Extentions
{
    public static class StringExtensions
    {
        public static string Repeat(this string value, int count) => string.Concat(Enumerable.Repeat(value, count));
    }
}

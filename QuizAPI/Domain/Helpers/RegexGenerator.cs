using Fare;

namespace Domain.Helpers
{
    public static class RegexGenerator
    {
        public static string Generate(string pattern)
        {
            var xeger = new Xeger(pattern);
            return xeger.Generate();
        }
    }
}

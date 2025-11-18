namespace Lab2Console.Part1
{
    public static class CustomExtensions
    {
        public static string GetMiddleCharacter(this string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            int len = str.Length;
            int middle = len / 2;
            return len % 2 == 0 ? str.Substring(middle - 1, 2) : str.Substring(middle, 1);
        }

        public static bool IsLengthValid(this Password p)
        {
            int len = p.Value.Length;
            return len >= 6 && len <= 12;
        }
    }
}

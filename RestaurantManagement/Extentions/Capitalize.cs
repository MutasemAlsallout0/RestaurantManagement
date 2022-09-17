namespace RestaurantManagement.Extentions
{
    public static class Capitalize
    {
        public static string CapitalizeName(this string str)
        {

            if (str.Length == 0)
                System.Console.WriteLine("Empty String");
            else if (str.Length == 1)
                System.Console.WriteLine(char.ToUpper(str[0]));
            else
                System.Console.WriteLine(char.ToUpper(str[0]) + str.Substring(1));
            return str;

        }
    }
}

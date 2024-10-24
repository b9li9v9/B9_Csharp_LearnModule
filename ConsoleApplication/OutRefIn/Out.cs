
namespace ConsoleApplication.OutAndIn
{
    internal static class Out
    {
        public static bool OutTryParseNumber(this string i,out int parsedNumber)
        {
            return int.TryParse(i, out parsedNumber);
        }

        public static void OutRun()
        {
            string input = "123";
            int parsedNumber = 0;
            Console.WriteLine($"before {parsedNumber} {parsedNumber.GetType()}");
            bool result = input.OutTryParseNumber(out parsedNumber);
            Console.WriteLine($"after {parsedNumber} {parsedNumber.GetType()}");
        }
    }
    
}

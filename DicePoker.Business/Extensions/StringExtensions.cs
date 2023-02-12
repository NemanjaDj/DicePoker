using System.Collections.Generic;

namespace DicePoker.Api.Extensions
{
    public static class StringExtensions
    {
        public static List<int> ConvertToListOfNumbers(this string numbers)
        {
            List<int> resultList = new List<int>();

            string formatedNumbers = numbers.Replace("-", "");

            foreach (char c in formatedNumbers)
            {
                resultList.Add((int)char.GetNumericValue(c));
            }

            return resultList;
        }
    }
}

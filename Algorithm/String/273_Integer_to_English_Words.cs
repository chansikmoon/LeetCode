public class Solution
{
    public string NumberToWords(int num)
    {
        if (num == 0)
            return "Zero";

        var numToStrMap = new Dictionary<int, string>()
        {
            {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, {10, "Ten"},
            {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"}, {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"},
            {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"}, {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"},
            {100, "Hundred"}, {1000, "Thousand"}, {1000000, "Million"}, {1000000000, "Billion"}
        };

        var ret = new List<string>();
        int count = 1;

        while (num > 0)
        {
            int lastThreeDigits = num % 1000;
            num /= 1000;

            var tmp = new List<string>();

            int hundreds = lastThreeDigits / 100;

            if (hundreds > 0)
            {
                tmp.Add(numToStrMap[hundreds]);
                tmp.Add(numToStrMap[100]);
            }

            int lastTwoDigits = lastThreeDigits % 100;

            if (numToStrMap.ContainsKey(lastTwoDigits))
                tmp.Add(numToStrMap[lastTwoDigits]);
            else if (lastTwoDigits > 0)
            {
                int ones = lastTwoDigits % 10;
                int tens = lastTwoDigits - ones;

                tmp.Add(numToStrMap[tens]);
                tmp.Add(numToStrMap[ones]);
            }

            if (tmp.Count > 0)
            {
                if (count > 1)
                    tmp.Add(numToStrMap[count]);
                ret.Insert(0, string.Join(" ", tmp));
            }

            count *= 1000;
        }

        return string.Join(" ", ret);
    }
}
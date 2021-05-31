public class Solution
{
    public IList<string> LetterCombinations(string digits)
    {
        var letters = new string[8];
        letters[0] = "abc";
        letters[1] = "def";
        letters[2] = "ghi";
        letters[3] = "jkl";
        letters[4] = "mno";
        letters[5] = "pqrs";
        letters[6] = "tuv";
        letters[7] = "wxyz";

        var ret = new List<string>();

        helper(letters, ret, digits, "", 0);

        return ret;
    }

    private void helper(string[] letters, List<string> ret, string digits, string curr, int index)
    {
        if (index >= digits.Length)
        {
            if (!string.IsNullOrWhiteSpace(curr))
                ret.Add(curr);
            return;
        }

        int currDigit = digits[index] - '2';

        for (int i = 0; i < letters[currDigit].Length; i++)
        {
            helper(letters, ret, digits, curr + letters[currDigit][i], index + 1);
        }
    }
}
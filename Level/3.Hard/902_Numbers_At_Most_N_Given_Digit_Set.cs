public class Solution {
    public int AtMostNGivenDigitSet(string[] digits, int n) {
        string nStr = n.ToString();
        int nLength = nStr.Length, ret = 0, digitsLength = digits.Length;
        
        for (int i = 1; i < nLength; i++)
            ret += (int) Math.Pow(digitsLength, i);
        
        for (int i = 0; i < nLength; i++)
        {
            bool sameDigit = false;
            for (int j = 0; j < digitsLength; j++)
            {
                if (digits[j][0] < nStr[i])
                    ret += (int) Math.Pow(digitsLength, nLength - i - 1);
                else if (digits[j][0] == nStr[i])
                    sameDigit = true;
            }
            
            if (!sameDigit)
                return ret;
        }
        
        return ret + 1;
    }
}
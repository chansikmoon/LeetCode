public class Solution {
    public bool SumGame(string num) {
        int n = num.Length;
        var bob = Convert(num, 0, n / 2);
        var alice = Convert(num, n / 2, n);
        
        int diff = bob[0] - alice[0];
        int diffQ = bob[1] - alice[1];
        
        return !(diff * 2 == diffQ * -9);
    }
    
    private int[] Convert(string num, int i, int n)
    {
        int sum = 0;
        int q = 0;
        
        for (; i < n; i++)
        {
            if (num[i] == '?')
                q++;
            else
                sum += (num[i] - '0');
        }
        
        return new int[] { sum, q };
    }
}
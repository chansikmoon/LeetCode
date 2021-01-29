public class Solution {
    public string GetSmallestString(int n, int k) {
        var sb = new StringBuilder();
        for (int i = 0; i < n; i++)
            sb.Append("a");
        k -= n;

        int ind = n - 1;
        while (k > 0)
        {
            int tmp = Math.Min(k, 25);
            sb[ind--] = (char) (tmp + 'a');
            k -= tmp;
        }
        
        return sb.ToString();
    }
}
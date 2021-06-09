public class Solution {
    public string ConvertToTitle(int n) {
        var sb = new StringBuilder();
        
        while (n > 0)
        {
            n--;
            sb.Append((char)('A' + n % 26));
            n /= 26;
        }
        
        for (int i = 0; i < sb.Length / 2; i++)
        {
            char tmp = sb[i];
            sb[i] = sb[sb.Length - i - 1];
            sb[sb.Length - i - 1] = tmp;
        }
        return sb.ToString();
    }
}
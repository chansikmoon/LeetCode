public class Solution {
    private int minVal = Int32.MaxValue;
    public string RemoveKdigits(string num, int k) {
        var sb = new StringBuilder();
        
        for (int i = 0; i < num.Length; i++) {
            while (sb.Length > 0 && sb[sb.Length - 1] > num[i] && k > 0) {
                sb.Remove(sb.Length - 1, 1);
                k--;
            }
            
            // ex. num = "10123"
            if (sb.Length > 0 || num[i] != '0') {
                sb.Append(num[i]);
            }
        }
        
        // ex. num = "321112345" and k = 3
        while (sb.Length > 0 && k-- > 0) {
            sb.Remove(sb.Length - 1, 1);
        }
            
        return sb.Length == 0 ? "0" : sb.ToString();
    }
}
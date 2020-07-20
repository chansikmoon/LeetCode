public class Solution {
    public string AddBinary(string a, string b) {
        StringBuilder sb = new StringBuilder();
        int n = a.Length - 1, m = b.Length - 1, carry = 0;
        
        while (n >= 0 || m >= 0 || carry > 0)
        {
            if (n >= 0)
                carry += a[n--] - '0';
            
            if (m >= 0)
                carry += b[m--] - '0';
            
            sb.Insert(0, carry % 2);
            carry /= 2;
        }
        
        return sb.ToString();
    }
}
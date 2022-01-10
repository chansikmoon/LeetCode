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

    public string AddBinary1(string a, string b) {
        int i = a.Length - 1, j = b.Length - 1, carryOver = 0;
        var sb = new StringBuilder();
        
        while (i >= 0 || j >= 0 || carryOver > 0)
        {
            if (i >= 0)
                carryOver += (a[i--] - '0');
            
            if (j >= 0)
                carryOver += (b[j--] - '0');
            
            sb.Append(carryOver % 2);
            carryOver /= 2;
        }
        
        var str = sb.ToString();
        var arr = str.ToCharArray();
        Array.Reverse(arr);
        
        return new string(arr);
    }
}
public class Solution {
    public bool IsStrobogrammatic(string num) {
        var map = new Dictionary<char, char>() 
        {
            {'6', '9'},
            {'9', '6'},
            {'1', '1'},
            {'8', '8'},
            {'0', '0'},
        };
        
        var sb = new StringBuilder();
        for (int i = num.Length - 1; i >= 0; i--)
        {
            if (!map.ContainsKey(num[i]))
                return false;
            
            sb.Append(map[num[i]]);
        }
        
        return num == sb.ToString();
    }
}
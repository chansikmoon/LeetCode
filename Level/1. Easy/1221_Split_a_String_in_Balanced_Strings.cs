public class Solution {
    public int BalancedStringSplit(string s) {
        int ret = 0;
        int bal = 0;
        foreach (char c in s)
        {
            bal += c == 'R' ? 1 : -1;
            ret += bal == 0 ? 1 : 0;
        }
            
        return ret;
    }
}
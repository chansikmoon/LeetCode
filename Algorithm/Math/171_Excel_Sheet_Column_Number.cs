public class Solution {
    public int TitleToNumber(string s) {
        int ret = 0;
        
        foreach(var c in s)
            ret = ret * 26 + (c - 'A') + 1;
        
        return ret;
    }
}
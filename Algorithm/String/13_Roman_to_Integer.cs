public class Solution {
    public int RomanToInt(string s) {
        var map = new Dictionary<char, int>()
        {
            {'I', 1}, {'V', 5}, {'X', 10}, 
            {'L', 50}, {'C', 100}, 
            {'D', 500}, {'M', 1000}, 
        };
        
        int ret = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            if (i < s.Length-1 && map[s[i]] < map[s[i+1]])
                ret -= map[s[i]];
            else
                ret += map[s[i]];
        }
        
        return ret;
    }
}
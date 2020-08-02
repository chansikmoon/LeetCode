public class Solution {
    public bool HasGroupsSizeX(int[] deck) {
        Dictionary<int, int> map = new Dictionary<int, int>(); 
        int ans = 0;
        
        foreach (int d in deck)
        {
            if (!map.ContainsKey(d))
                map.Add(d, 0);
            
            map[d]++;
        }
        
        foreach (var kvp in map)
            ans = gcd(kvp.Value, ans);
        
        return ans >= 2;
    }
    
    private int gcd(int a, int b)
    {
        return b > 0 ? gcd(b, a % b) : a;
    }
}
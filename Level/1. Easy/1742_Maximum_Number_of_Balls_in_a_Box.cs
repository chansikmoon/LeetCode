public class Solution {
    public int CountBalls(int lowLimit, int highLimit) {
        var map = new Dictionary<int, int>();
        
        for (int i = lowLimit; i <= highLimit; i++)
        {
            int sum = 0, tmp = i;

            while (tmp > 0)
            {
                sum += tmp % 10;
                tmp /= 10;
            }
            
            if (!map.ContainsKey(sum))
                map.Add(sum, 0);
            
            map[sum]++;
        }
        
        int ret = 0;
        
        foreach (var kvp in map)
            ret = Math.Max(ret, kvp.Value);
        
        return ret;
    }
}
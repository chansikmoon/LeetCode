public class Solution {
    public bool CarPooling(int[][] trips, int capacity) {
        var map = new Dictionary<int, int>();
        
        foreach (var trip in trips)
        {
            if (!map.ContainsKey(trip[1]))
                map.Add(trip[1], 0);
            if (!map.ContainsKey(trip[2]))
                map.Add(trip[2], 0);
            
            map[trip[1]] += trip[0];
            map[trip[2]] -= trip[0];
        }
        
        for (int i = 0; i < 1001 && capacity >= 0; i++)
        {
            if (map.ContainsKey(i))
                capacity -= map[i];
        }
        
        return capacity >= 0;
    }
}
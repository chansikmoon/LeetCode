public class Solution {
    public int SmallestChair(int[][] times, int targetFriend) {
        int n = times.Length;
            
        var arrival = new int[n];
        var leaving = new int[n];
        
        var pq = new SortedSet<int>();
        var timeMap = new Dictionary<int, int>();
        
        for (int i = 0; i < n; i++)
        {
            arrival[i] = times[i][0];
            leaving[i] = times[i][1];
            pq.Add(i);
            timeMap.Add(arrival[i], leaving[i]);
        }
        
        Array.Sort(arrival);
        Array.Sort(leaving);
        
        var map = new Dictionary<int, List<int>>();
        
        for (int s = 0, e = 0; s < n; s++)
        {
            while (leaving[e] <= arrival[s])
            {
                if (map.ContainsKey(leaving[e]))
                {
                    var leftChairs = map[leaving[e]];
                    map.Remove(leaving[e]);

                    foreach (int chair in leftChairs)
                        pq.Add(chair);    
                }
                e++;
            }
            
            int availableChair = pq.Min;
            
            if (arrival[s] == times[targetFriend][0])
                return availableChair;
            
            if (!map.ContainsKey(timeMap[arrival[s]]))
                map.Add(timeMap[arrival[s]], new List<int>());

            map[timeMap[arrival[s]]].Add(availableChair);
            pq.Remove(pq.Min);
        }
        
        return pq.Count > 0 ? pq.Min : n + 1;
    }
}
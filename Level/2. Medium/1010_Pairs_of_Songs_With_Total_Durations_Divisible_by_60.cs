public class Solution {
    public int NumPairsDivisibleBy60(int[] time) {
        int[] arr = new int[60];
        int ret = 0;

        for (int i = 0; i < time.Length; i++)
        {
            // time[i] = 60, 60 - 60 % 60 => 60. It should be 0
            ret += arr[(60 - time[i] % 60) % 60];
            arr[time[i] % 60]++;
        }

        return ret;
    }
    
    public int BruteForce(int[] time) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        
        int ret = 0;
        
        for (int i = 0; i < time.Length; i++)
        {
            int t = time[i] % 60;
            
            if (!map.ContainsKey(t))
                map.Add(t, 0);
            
            map[t]++;
        }
        
        for (int i = 0; i < time.Length; i++)
        {
            int t = time[i] % 60;
            map[t]--;
            ret += map[(60 - t) % 60];
        }
        
        return ret;
    }
}
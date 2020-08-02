public class Solution {
    public int MinSumOfLengths(int[] arr, int target) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int sum = 0, sub1 = Int32.MaxValue, ans = Int32.MaxValue;
        map.Add(0, -1);
        
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
            map.Add(sum, i);
        }
        
        sum = 0;
        
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
            if (map.ContainsKey(sum - target))
                sub1 = Math.Min(sub1, i - map[sum - target]);
            
            if (map.ContainsKey(sum + target) && sub1 < Int32.MaxValue)
                ans = Math.Min(ans, map[sum + target] - i + sub1);
        }
        
        return ans ==Int32.MaxValue ? -1 : ans;
    }
}
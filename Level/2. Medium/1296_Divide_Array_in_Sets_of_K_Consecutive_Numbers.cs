public class Solution {
    public bool IsPossibleDivide(int[] nums, int k) {
        if ((nums.Length % k) != 0) return false;
        
        Dictionary<int, int> map = new Dictionary<int, int>();
        
        foreach (int num in nums)
        {
            if (!map.ContainsKey(num))
                map.Add(num, 0);
            
            map[num]++;
        }
        
        while (map.Count > 0)
        {
            int key = map.Keys.Min();
            
            for (int i = key; i < key + k; i++)
            {
                if (!map.ContainsKey(i))
                    return false;
                    
                map[i]--;
                
                if (map[i] == 0)
                    map.Remove(i);
            }
        }
        
        return true;
    }
}
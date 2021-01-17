public class Solution {
    public int TupleSameProduct(int[] nums) {
        var map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                var tmp = nums[i] * nums[j];
                if (!map.ContainsKey(tmp))
                    map.Add(tmp, 0);
                map[tmp]++;
            }
        }
        
        int ret = 0;
        foreach (var kvp in map)
            ret += kvp.Value * (kvp.Value-1) * 4;
        
        return ret;
        // return bruteForce(nums, new int[4], new HashSet<int>(), new Dictionary<string, int>(), 0);
    }
    
    public int bruteForce(int[] nums, int[] arr, HashSet<int> visited, Dictionary<string, int> memo, int index)
    {
        if (index >= 4)
            return arr[0]*arr[1] == arr[2]*arr[3] ? 1 : 0;
        
        int ret = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            if (!visited.Add(nums[i]))
                continue;
            arr[index] = nums[i];
            ret += bruteForce(nums, arr, visited, memo, index+1);
            visited.Remove(nums[i]);
        }
        
        return ret;
    }
}
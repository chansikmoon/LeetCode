public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        List<int> ans = new List<int>();
        
        foreach (int num in nums)
        {
            int index = Math.Abs(num) - 1;
            if (nums[index] < 0)
                ans.Add(index + 1);
            
            nums[index] = -nums[index];
        }
        
        return ans;
    }
    
    private List<int> BruteForce(int[] nums)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        
        foreach (int num in nums)
        {
            if (!map.ContainsKey(num))
                map.Add(num, 0);
            
            map[num]++;
        }
        
        return map.Where(x => x.Value == 2).Select(x => x.Key).ToList();
    }
}
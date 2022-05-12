public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        var n = nums.Length;
        var ret = new List<IList<int>>();
        Array.Sort(nums);
        Helper(ret, new List<int>(), nums, new bool[n]);
        
        return ret;
    }
    
    private void Helper(List<IList<int>> ret, List<int> list, int[] nums, bool[] visited) {
        if (list.Count >= nums.Length) {
            ret.Add(new List<int>(list));
            return;
        }
        
        int prev = nums[0] - 1;
        
        for (int i = 0; i < nums.Length; i++) {
            if (visited[i] || prev == nums[i]) {
                continue;
            }
            
            prev = nums[i];
            
            visited[i] = true;
            list.Add(nums[i]);
            Helper(ret, list, nums, visited);
            list.RemoveAt(list.Count - 1);
            visited[i] = false;
        }
    }
}
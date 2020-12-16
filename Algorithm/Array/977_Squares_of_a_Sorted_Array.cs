public class Solution {
    public int[] SortedSquares(int[] nums) {
        int n = nums.Length;
        var ret = new int[n];
        int i = 0, j = n - 1;
        
        for (int k = n - 1; k >= 0; k--)
        {
            if (Math.Abs(nums[i]) > Math.Abs(nums[j]))
            {
                ret[k] = nums[i] * nums[i];
                i++;
            }
            else
            {
                ret[k] = nums[j] * nums[j];
                j--;
            }
        }
        
        return ret;
    }
    
    private int[] BruteForce(int[] nums) {
        var ret = new List<int>();
        
        for (int i = 0; i < nums.Length; i++)
            ret.Add(nums[i] * nums[i]);
        
        return ret.OrderBy(x => x).ToArray();
    }
}
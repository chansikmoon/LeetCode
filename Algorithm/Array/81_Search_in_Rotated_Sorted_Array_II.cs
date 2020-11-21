public class Solution {
    public bool Search(int[] nums, int target) {
        if (nums.Length == 0) return false;
        int l = 0, r = nums.Length - 1;
        
        while (l < r)
        {
            int mid = l + (r - l) / 2;
            
            if (nums[mid] == target)
                return true;
            
            if (nums[l] < nums[mid])
            {
                if (nums[l] <= target && nums[mid] > target)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            else if (nums[mid] < nums[r])
            {
                if (nums[mid] < target && nums[r] >= target)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            else
            {
                if (nums[l] == nums[mid]) l++;
                if (nums[r] == nums[mid]) r--;
            }
        }
        
        return nums[l] == target;
    }
    
    public bool BruteForce(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
            if (nums[i] == target) return true;
        
        return false;
    }
}
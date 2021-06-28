public class Solution {
    public bool CanBeIncreasing(int[] nums) {
        for (int i = 0; i < nums.Length; i++)
        {
            var list = new List<int>();
            for (int j = 0; j < nums.Length; j++)
            {
                if (j == i)
                    continue;
                list.Add(nums[j]);
            }
            
            bool ret = true;
            for (int j = 1; j < list.Count; j++)
            {
                if (list[j - 1] >= list[j])
                    ret = false;
            }
            
            if (ret)
                return true;
        }
        
        return false;
    }
}
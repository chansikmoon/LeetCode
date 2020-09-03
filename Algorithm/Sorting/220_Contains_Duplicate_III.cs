public class Solution {
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        // nums = 1, 5, 9, 1, 5, 9, k = 2, t = 3
        
        // sorted<int, int>
        // value = 1, index = 0
        // value = 1, index = 3
        // value = 5, index = 1
        // value = 5, index = 4
        // value = 9, index = 2
        // value = 9, index = 5

        // n log n
        var sorted = nums.Select((value, index) => new { value, index }).OrderBy(x => x.value).ToArray();

        // O(nt)
        for(int i = 0; i < sorted.Length; i++)
        {
            long currentNum = sorted[i].value;

            for(int j = i + 1; j < sorted.Length && (sorted[j].value - currentNum) <= t; j++)
            {
                if(Math.Abs(sorted[i].index - sorted[j].index) <= k)
                {
                    return true;
                }
            } 
        }

        return false;
    }
}
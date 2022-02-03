public class Solution {
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4) {
        var map = new Dictionary<int, int>();
        
        foreach (int i in nums1) {
            foreach (int j in nums2) {
                int sum = i + j;
                if (!map.ContainsKey(sum))
                    map.Add(sum, 0);
                map[sum]++;
            }
        }
        
        int ret = 0;
        
        foreach (int i in nums3) {
            foreach (int j in nums4) {
                int neg = -i - j;
                if (map.ContainsKey(neg))
                    ret += map[neg];
            }
        }
        
        return ret;
    }
}
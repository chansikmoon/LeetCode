public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int i = m+n-1;
        for (; i>=0; i--)
        {
            if (m-1 < 0 || n-1 < 0)
                break;
            
            nums1[i] = nums1[m-1] <= nums2[n-1] ? nums2[--n] : nums1[--m];
        }
        
        while (n-1 >= 0)
            nums1[i--] = nums2[--n];
    }
}
/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */

class Solution {
    public int FindInMountainArray(int target, MountainArray mountainArr) {
        int n = mountainArr.Length();
        int l = 0, r = n - 1, peak = 0;
        
        while (l < r)
        {
            int m = l + (r - l) / 2;
            
            if (mountainArr.Get(m) < mountainArr.Get(m + 1))
            {
                l = m + 1;
                peak = m + 1;
            }
            else
            {
                r = m;
            }
        }
        
        l = 0;
        r = peak;
        
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            
            int element = mountainArr.Get(m);
            if (element == target)
                return m;
            else if (element < target)
                l = m + 1;
            else 
                r = m - 1;
        }
        
        l = peak + 1;
        r = n - 1;
        
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            
            int element = mountainArr.Get(m);
            if (element == target)
                return m;
            else if (element > target)
                l = m + 1;
            else 
                r = m - 1;
        }
        
        return -1;
    }
}
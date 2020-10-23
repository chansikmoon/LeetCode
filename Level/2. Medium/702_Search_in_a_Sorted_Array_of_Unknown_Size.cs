/**
 * // This is ArrayReader's API interface.
 * // You should not implement it, or speculate about its implementation
 * class ArrayReader {
 *     public int Get(int index) {}
 * }
 */

class Solution {
    public int Search(ArrayReader reader, int target) {
        int left = 0, right = 1;
        
        while (reader.Get(right) < target)
        {
            left = right;
            right *= 2;
        }

        // [-1, 0, 3, 5, 9, 12]     target = 9
        //   l  r
        //      l  r   
        //         l     r
        //               l             r
        // To keep logarithmic time complexity, let's extend it twice as far.
        // If the reader[right] < target, then we can ignore all left side of the "right" index and move the search boundary to the right.
        
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int element = reader.Get(mid);
            if (element == target)
                return mid;
            else if (element < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        
        return -1;
    }
    
    public int BruteForce(ArrayReader reader, int target)
    {
        int left = 0, right = 10000;
        
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            
            int element = reader.Get(mid);
            
            if (element == Int32.MaxValue) 
            {
                right = mid - 1;
                continue;
            }
                
            if (element == target)
                return mid;
            else if (element < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        
        return -1;
    }
}
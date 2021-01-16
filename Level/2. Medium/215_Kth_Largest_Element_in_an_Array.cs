public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        int l = 0, r = nums.Length-1, index = nums.Length-k;
        while (l < r)
        {
            int pivot = Partition(nums, l, r);
            if (pivot < index)
                l = pivot + 1;
            else if (pivot > index)
                r = pivot - 1;
            else
                return nums[pivot];
        }
        
        return nums[l];
    }
    
    // O(N) best / O(N^2) worst
    // O(1)
    private int Partition(int[] nums, int l, int r)
    {
        int pivot = l;
        while (l <= r)
        {
            while (l <= r && nums[l] <= nums[pivot])
                l++;
            while (l <= r && nums[r] > nums[pivot])
                r--;
            if (l > r)
                break;
            Swap(nums, l, r);
        }
        Swap(nums, pivot, r);
        return r;
    }
    
    private void Swap(int[] nums, int i, int j)
    {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }
    
    // O(n log n)
    // O(1)
    public int bruteForce(int[] nums, int k)
    {
        Array.Sort(nums);
        return nums[nums.Length - k];
    }
}
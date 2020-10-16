public class Solution {
    public void Rotate(int[] nums, int k) {
        int n = nums.Length, count = 0;
        k %= n;
        
        for (int i = 0; count < n; i++)
        {
            int curr = i;
            int prev = nums[i];
            
            do {
                int next = (curr + k) % n;
                int temp = nums[next];
                nums[next] = prev;
                prev = temp;
                curr = next;
                count++;
            } while (i != curr);
        }
    }
    
    public void ReserveSolution(int[] nums, int k)
    {
        int n = nums.Length;
        k %= n;
        
        Reverse(nums, 0, n - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, n - 1);
    }
    
    public void Reverse(int[] nums, int i, int j)
    {
        while (i < j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
            
            i++;
            j--;
        }
    }
    
    public void ExtraSpaceSolution(int[] nums, int k)
    {
        int[] tmp = new int[nums.Length];
        
        for (int i = 0; i < nums.Length; i++)
        {
            tmp[(k + i) % nums.Length] = nums[i];
        }
        
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = tmp[i];
        }
    }
    
    public void BruteForce(int[] nums, int k)
    {
        int n = nums.Length;
        if (n == 0) return;
        
        for (k %= n; k > 0; k--)
        {
            int temp = nums[n - 1];
            
            for (int i = n - 1; i > 0; i--)
            {
                nums[i] = nums[i - 1];
            }
            
            nums[0] = temp;
        }
    }
}
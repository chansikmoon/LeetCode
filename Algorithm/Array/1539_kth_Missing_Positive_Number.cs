public class Solution {
    public int FindKthPositive(int[] arr, int k) {
        int n = arr.Length, num = 1;
        
        for (int i = 0, ret = 0; i < n; i++)
        {
            if (k == 0)
                return ret;
            
            if (num == arr[i])
            {
                num++;
                continue;
            }
                
            while (num < arr[i] && k > 0)
            {
                ret = num++;
                k--;
            }
            
            i--;
        }
        
        return arr[n-1] + k;
    }

    public int FindKthPositive(int[] arr, int k)
    {
        int l = 0, r = arr.Length;
        while (l < r)
        {
            int m = (l + r) / 2;
            if (arr[m] - 1 - m < k)
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }

        return l + k;
    }
}
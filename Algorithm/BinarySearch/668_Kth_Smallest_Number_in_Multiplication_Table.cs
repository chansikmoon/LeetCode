public class Solution {
    private int Rows { get; set; }
    private int Cols { get; set; }
    public int FindKthNumber(int m, int n, int k) {
        Rows = m;
        Cols = n;
        
        int left = 1, right = Rows * Cols + 1;
        
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            int count = CountLessThan(mid);
            if (count >= k)
                right = mid;
            else
                left = mid + 1;
        }
        
        return right;
    }
    
    private int CountLessThan(int val)
    {
        int ret = 0;
        
        for (int row = 1; row <= Rows; row++)
            ret += Math.Min(val / row, Cols);
        
        return ret;
    }
}
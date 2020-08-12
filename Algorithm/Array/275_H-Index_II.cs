public class Solution {
    public int HIndex(int[] citations) {
        return BinarySearch(citations);
        int n = citations.Length, index = 0;
        
        for (int i = 0; i < n; i++)
        {
            if (n - i <= citations[i])
                return n - i;
        }
        
        return 0;
    }
    
    public int BinarySearch(int[] citations)
    {
        int l = 0, r = citations.Length - 1, n = citations.Length;
        
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            
            if (citations[m] == n - m)
                return n - m;
            else if (citations[m] < n - m)
                l = m + 1;
            else
                r = m - 1;
        }
        
        return n - l;
    }
}
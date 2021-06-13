public class Solution {
    public int MaximumRemovals(string s, string p, int[] removable) {
        var arr = s.ToCharArray();
        
        int l = 0, r = removable.Length - 1;
        
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            
            for (int i = 0; i <= m; i++)
                arr[removable[i]] = '#';
            
            if (Check(arr, p))
                l = m + 1;
            else
            {
                for (int i = 0; i <= m; i++)
                    arr[removable[i]] = s[removable[i]];
                r = m - 1;
            }
        }
        
        return l;
    }
    
    private bool Check(char[] arr, string p)
    {
        for (int i = 0, j = 0; i < arr.Length; i++)
        {
            if (arr[i] == p[j])
                j++;    
            
            if (j >= p.Length)
                return true;
        }
        
        return false;
    }
}
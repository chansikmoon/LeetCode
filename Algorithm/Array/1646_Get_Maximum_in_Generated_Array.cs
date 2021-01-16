public class Solution {
    public int GetMaximumGenerated(int n) {
        if (n < 2)
            return n;
        
        var arr = new int[n+1];
        arr[0] = 0;
        arr[1] = 1;

        int ret = 1;
        
        for (int i = 2; i <= n; i++)
        {
            arr[i] = arr[i/2];
            if (i%2==1)
                arr[i] += arr[i/2+1];
            ret = Math.Max(ret, arr[i]);
        }
        
        return ret;
    }
}
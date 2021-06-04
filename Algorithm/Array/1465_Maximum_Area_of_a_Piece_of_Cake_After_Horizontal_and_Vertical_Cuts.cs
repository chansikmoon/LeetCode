public class Solution {
    // O(n log n + m log m)
    // n is the length of horizontalCuts and m is the length of verticalCuts.
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts) {
        long maxH = GetMaxGap(h, horizontalCuts);
        long maxW = GetMaxGap(w, verticalCuts);
        
        return (int)((maxH * maxW) % 1000000007);
    }
    
    private long GetMaxGap(int total, int[] arr)
    {
        // O(n log n)
        Array.Sort(arr);
        
        int n = arr.Length;   
        long ret = Math.Max((long)(total - arr[n-1]), (long)(arr[0]));
        
        // O(n)
        for (int i = 1; i < n; i++)
            ret = Math.Max(ret, (long)(arr[i]-arr[i-1]));
        
        return ret;
    }
}
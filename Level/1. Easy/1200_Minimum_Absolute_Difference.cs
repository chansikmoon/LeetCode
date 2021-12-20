public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        Array.Sort(arr);
        int minDiff = Int32.MaxValue;
        
        for (int i = 1; i < arr.Length; i++)
        {
            int diff = Math.Abs(arr[i] - arr[i-1]);
            minDiff = Math.Min(minDiff, diff);
        }
        
        var ret = new List<IList<int>>();
        
        for (int i = 1; i < arr.Length; i++)
        {
            int diff = Math.Abs(arr[i] - arr[i-1]);
            
            if (diff == minDiff)
                ret.Add(new List<int>() { arr[i-1], arr[i] });
        }
        
        return ret;
    }
}
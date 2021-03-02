public class Solution {
    public int DistributeCandies(int[] candyType) {
        var _set = new HashSet<int>();
        
        for (int i = 0; i < candyType.Length; i++)
        {
            _set.Add(candyType[i]);
        }
        
        return Math.Min(candyType.Length / 2, _set.Count);
    }
}
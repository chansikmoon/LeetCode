public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        var ret = new int[3];
        
        foreach (var tri in triplets)
        {
            if (tri[0] <= target[0] && tri[1] <= target[1] && tri[2] <= target[2])
            {
                ret[0] = Math.Max(ret[0], tri[0]);
                ret[1] = Math.Max(ret[1], tri[1]);
                ret[2] = Math.Max(ret[2], tri[2]);
            }
        }
        
        return ret[0] == target[0] && ret[1] == target[1] && ret[2] == target[2];
    }
}
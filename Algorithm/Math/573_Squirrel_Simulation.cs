public class Solution {
    public int MinDistance(int height, int width, int[] tree, int[] squirrel, int[][] nuts) {
        int totalDist = 0, maxStartDist = Int32.MinValue;
        foreach (var nut in nuts)
        {
            int dist = Math.Abs(tree[0] - nut[0]) + Math.Abs(tree[1] - nut[1]);
            totalDist += dist * 2;
            // Find the maximum one way starting distance
            maxStartDist = Math.Max(maxStartDist, dist - Math.Abs(squirrel[0] - nut[0]) - Math.Abs(squirrel[1] - nut[1]));
        }
        
        return totalDist - maxStartDist;
    }
}
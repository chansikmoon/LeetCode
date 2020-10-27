public class Solution {
    // O(R^2), where R is query_row
    // O(R)
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        // query_row is zero index so +1. To simulate the next level, we need extra space to compute the volume
        double[] res = new double[query_row + 2];
        res[0] = poured;
        for (int row = 1; row <= query_row; row++)
        {
            for (int col = row; col >= 0; col--)
            {
                // from the previous glass, subtract 1 and / 2 to get next level two glasses poured volume
                res[col + 1] += res[col] = Math.Max(0.0, (res[col] - 1) / 2);
            }
        }
        
        return Math.Min(1.0, res[query_glass]);
    }
}
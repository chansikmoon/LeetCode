public class Solution {
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        var res = new double[query_row + 2];
        res[0] = poured;
        for (int row = 1; row <= query_row; row++)
        {
            for (int col = row; col >= 0; col--)
            {
                res[col + 1] += res[col] = Math.Max(0.0, (res[col] - 1) / 2);
            }
        }
        
        return Math.Min(1.0, res[query_glass]);
    }
}
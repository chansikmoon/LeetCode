public class NumMatrix
{
    private int[,] preSumArr = null;
    public NumMatrix(int[][] matrix)
    {
        // TC: O(nm)
        // SC: O(nm)
        int n = matrix.Length, m = matrix[0].Length;
        preSumArr = new int[n + 1, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                preSumArr[i + 1, j] = preSumArr[i, j] + matrix[i][j];
            }
        }
    }

    // TC: O(m)
    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        int ret = 0;

        for (int j = col1; j <= col2; j++)
            ret += preSumArr[row2 + 1, j] - preSumArr[row1, j];

        return ret;
    }

    private int[,] preSumArr2 = null;
    // TC: O(nm)
    // SC: O(nm)
    public NumMatrix2(int[][] matrix)
    {
        int n = matrix.Length, m = matrix[0].Length;
        preSumArr2 = new int[n + 1, m + 1];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                preSumArr2[i + 1, j + 1] = preSumArr2[i + 1, j] + preSumArr2[i, j + 1] + matrix[i][j] - preSumArr2[i, j];
            }
        }
    }

    // TC: O(1)
    public int SumRegion2(int row1, int col1, int row2, int col2)
    {
        return preSumArr2[row2 + 1, col2 + 1] - preSumArr2[row1, col2 + 1] - preSumArr2[row2 + 1, col1] + preSumArr2[row1, col1];
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */
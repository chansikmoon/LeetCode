public class Solution
{
    public int TotalNQueens(int n)
    {
        return Backtrack(0, n, new HashSet<int>(), new HashSet<int>(), new HashSet<int>());
    }

    private int Backtrack(int row, int size,
        HashSet<int> dia, HashSet<int> antiDia, HashSet<int> cols)
    {
        if (row == size)
            return 1;

        int ret = 0;

        for (int col = 0; col < size; col++)
        {
            int currDia = row - col;
            int currAntiDia = row + col;

            if (cols.Contains(col) ||
               dia.Contains(currDia) ||
               antiDia.Contains(currAntiDia))
            {
                continue;
            }

            cols.Add(col);
            dia.Add(currDia);
            antiDia.Add(currAntiDia);

            ret += Backtrack(row + 1, size, dia, antiDia, cols);

            cols.Remove(col);
            dia.Remove(currDia);
            antiDia.Remove(currAntiDia);
        }

        return ret;
    }
}
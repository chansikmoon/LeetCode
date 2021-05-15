public class Solution
{
    public char[][] RotateTheBox(char[][] box)
    {
        int n = box.Length, m = box[0].Length;

        var arr = new char[m][];
        for (int i = 0; i < m; i++)
            arr[i] = new char[n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                arr[j][n - i - 1] = box[i][j];
        }

        for (int j = 0; j < n; j++)
        {
            int bottom = m - 1;

            while (bottom >= 0)
            {
                int tmp = bottom;
                int stone = 0;

                while (tmp >= 0)
                {
                    if (arr[tmp][j] == '*')
                    {
                        tmp--;
                        break;
                    }

                    if (arr[tmp][j] == '#')
                        stone++;

                    arr[tmp][j] = '.';
                    tmp--;
                }

                while (stone-- > 0)
                    arr[bottom--][j] = '#';

                bottom = tmp;
            }
        }

        return arr;
    }
}
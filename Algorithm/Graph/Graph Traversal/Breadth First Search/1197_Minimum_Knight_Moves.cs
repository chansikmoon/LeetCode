public class Solution
{
    public int MinKnightMoves(int x, int y)
    {
        x = Math.Abs(x);
        y = Math.Abs(y);

        return Helper(x, y, new Dictionary<string, int>());
    }

    private int Helper(int x, int y, Dictionary<string, int> memo)
    {
        string key = string.Format("{0},{1}", x, y);
        if (memo.ContainsKey(key))
            return memo[key];

        // These base cases are from here:
        // https://math.stackexchange.com/questions/1135683/minimum-number-of-steps-for-knight-in-chess
        if (x + y == 0)
            return 0;
        else if (x + y == 1)
            return 3;
        else if (x + y == 2)
            return 2;
        else if (x == 2 && y == 2)
            return 4;

        int min = Math.Min(Helper(Math.Abs(x - 1), Math.Abs(y - 2), memo),
                           Helper(Math.Abs(x - 2), Math.Abs(y - 1), memo)) + 1;
        memo.Add(key, min);

        return min;
    }
    private int[][] dirs = new int[8][]
    {
        new int[] { 2 , 1 }, new int[] { 1 , 2 }, new int[] { 2 , -1 },
        new int[] { -2 , 1 }, new int[] { -2 , -1 }, new int[] { -1 , -2 },
        new int[] { 1 , -2 }, new int[] { 2 , -1 },
    };

    public int BFS(int x, int y)
    {
        x = Math.Abs(x);
        y = Math.Abs(y);
        var q = new Queue<(int i, int j)>();
        var visited = new HashSet<(int i, int j)>();

        q.Enqueue((x, y));
        int ret = 0;
        while (q.Count > 0)
        {
            int size = q.Count;
            while (size-- > 0)
            {
                var curr = q.Dequeue();

                if (curr.i == 0 && curr.j == 0)
                    return ret;

                foreach (var dir in dirs)
                {
                    int nextX = curr.i + dir[0];
                    int nextY = curr.j + dir[1];
                    if (nextX >= -1 && nextY >= -1 && !visited.Contains((nextX, nextY)))
                    {
                        q.Enqueue((nextX, nextY));
                        visited.Add((nextX, nextY));
                    }
                }
            }

            ret++;
        }

        return ret;
    }
}